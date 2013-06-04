using System.Collections.Generic;
using System.IO.Ports;

namespace RS232
{
    public enum StationTypeEnum { MASTER, SLAVE }
    public enum TransmissionModeEnum { ASCII7E1, ASCII7O1, ASCII7N2, RTU8E1, RTU8O1, RTU8N2 }

    /// <summary>
    /// Wrapper do obsługi protokołu MODBUS.
    /// </summary>
    public class MODBUS
    {
        /// <summary>
        /// Tryb handshake'u portu.
        /// </summary>
        private const Handshake PORT_HANDSHAKE = Handshake.None;

        /// <summary>
        /// Argumenty dla zdarzenia komunikacji z klasy RS232.
        /// </summary>
        /// <param name="arg"></param>
        public delegate void MODBUSCommunicateDelegate(MODBUSCommunicateEventArgs arg);

        /// <summary>
        /// Zdarzenie pozwalające syngalizować różne komunikaty
        /// klasie MODBUS.
        /// </summary>
        public event MODBUSCommunicateDelegate Communicate;

        /// <summary>
        /// Singleton.
        /// </summary>
        private static MODBUS _instance;

        private int _baudrate;
        private string _portName;
        private TransmissionModeEnum _transmissionMode;


        public static MODBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MODBUS();
                return _instance;
            }
        }

        /// <summary>
        /// Szybkość transmisji.
        /// </summary>
        public int Baudrate
        {
            get { return _baudrate; }
            set
            {
                _baudrate = value;
                ClosePort();
                OpenPort();
            }
        }

        /// <summary>
        /// Maksymalny odstęp pomiędzy znakami w ms.
        /// </summary>
        public int IntercharInterval { get; set; }

        /// <summary>
        /// Nazwa portu komunikacyjnego.
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set
            {
                _portName = value;
                ClosePort();
                OpenPort();
            }
        }

        /// <summary>
        /// Liczba retransmisji.
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// Adres stacji.
        /// </summary>
        public byte StationAddress { get; set; }

        /// <summary>
        /// Timeout transakcji w ms.
        /// </summary>
        public int TransactionTimeout { get; set; }

        /// <summary>
        /// Tryb transmisji.
        /// </summary>
        public TransmissionModeEnum TransmissionMode
        {
            get { return _transmissionMode; }
            set
            {
                _transmissionMode = value;
                ClosePort();
                OpenPort();
            }
        }

        /// <summary>
        /// Tryb działania stacji.
        /// </summary>
        public StationTypeEnum Type { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        private MODBUS()
        {
            // Domyślne wartości.
            Baudrate = 1200;
            IntercharInterval = 100;
            RetryCount = 0;
            StationAddress = 1;
            TransactionTimeout = 1000;
            TransmissionMode = TransmissionModeEnum.ASCII7E1;
            Type = StationTypeEnum.SLAVE;
            RS232.Instance.Communicate += OnRS232Communicate;

            OpenPort();
        }

        private void ClosePort()
        {
            RS232.Instance.Close();
        }

        /// <summary>
        /// Tworzy ramkę do wysłania.
        /// </summary>
        /// <param name="destAddress"></param>
        /// <param name="instructionCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private byte[] CreateFrame(byte destAddress, byte instructionCode, string message)
        {
            List<byte> frame = new List<byte>();
            byte LRC = 0x00;
            byte address;

            // Slave umieszcza swój adres w odpowiedzi.
            if (Type == StationTypeEnum.MASTER)
                address = destAddress;
            else
                address = StationAddress;

            switch (_transmissionMode)
            {
                case TransmissionModeEnum.ASCII7E1:
                case TransmissionModeEnum.ASCII7O1:
                case TransmissionModeEnum.ASCII7N2:
                    // Znak początku ramki.
                    frame.Add((byte)':');
                    
                    // Adres
                    LRC += address;
                    byte b;
                    b = (byte)(address >> 4);
                    b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                    frame.Add(b);
                    b = (byte)(address & 0x0F);
                    b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                    frame.Add(b);

                    // Rozkaz.
                    LRC += instructionCode;
                    b = (byte)(instructionCode >> 4);
                    b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                    frame.Add(b);
                    b = (byte)(instructionCode & 0x0F);
                    b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                    frame.Add(b);

                    // Dane.
                    char[] m = message.ToCharArray();
                    for (int i = 0; i < m.Length; i++)
                    {
                        LRC += (byte)m[i];
                        b = (byte)(m[i] >> 4);
                        b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                        frame.Add(b);
                        b = (byte)(m[i] & 0x0F);
                        b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                        frame.Add(b);
                    }

                    // LRC
                    LRC = (byte)-LRC;
                    b = (byte)(LRC >> 4);
                    b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                    frame.Add(b);
                    b = (byte)(LRC & 0x0F);
                    b = (byte)(b <= 9 ? b + 0x30 : b + 0x37);
                    frame.Add(b);

                    // CR LF
                    frame.Add(0x0D);
                    frame.Add(0x0A);
                        break;

                default:
                    break;
            }

            return frame.ToArray();
        } 

        private void OnRS232Communicate(RS232CommunicateEventArgs arg)
        {
            // To implement.
            switch (arg.Type)
            {
                case CommunicateType.ErrorOccured:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Otwiera port RS232.
        /// </summary>
        private void OpenPort()
        {
            switch (TransmissionMode)
            {
                case TransmissionModeEnum.ASCII7E1:
                    RS232.Instance.Open(_portName, _baudrate, 7, StopBits.One, Parity.Even, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.ASCII7O1:
                    RS232.Instance.Open(_portName, _baudrate, 7, StopBits.One, Parity.Odd, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.ASCII7N2:
                    RS232.Instance.Open(_portName, _baudrate, 7, StopBits.Two, Parity.None, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.RTU8E1:
                    RS232.Instance.Open(_portName, _baudrate, 8, StopBits.One, Parity.Even, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.RTU8O1:
                    RS232.Instance.Open(_portName, _baudrate, 8, StopBits.One, Parity.Odd, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.RTU8N2:
                    RS232.Instance.Open(_portName, _baudrate, 8, StopBits.Two, Parity.None, "\n", PORT_HANDSHAKE); break;
                default:
                    break;
            }
        }

        public void SendMessage(byte destAddress, byte instructionCode, string message)
        {
            byte[] frame = CreateFrame(destAddress, instructionCode, message);

            MODBUSCommunicateEventArgs arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.FrameSent);
            arg.Frame = frame;
            Communicate(arg);
        }
    }
}
