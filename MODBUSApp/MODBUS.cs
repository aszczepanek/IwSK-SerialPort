using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Timers;

namespace RS232
{
    public enum StationTypeEnum { MASTER, SLAVE }
    public enum TransmissionModeEnum { ASCII7E1, ASCII7O1, ASCII7N2, RTU8E1, RTU8O1, RTU8N2 }
    public enum GeneralTransmissionModeEnum { ASCII, RTU }

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
        private GeneralTransmissionModeEnum _generalTransimssionMode;

        /// <summary>
        /// Bufor wejściowy.
        /// </summary>
        private List<byte> _inBuffer = new List<byte>();

        // Timery do timeoutu dla odstępu między znakami.
        private Timer _intercharInterval = new Timer(10);
        private Timer _transactionTimeout = new Timer(1000);

        // Timer dla wykrywania ramki RTU
        private Timer _RTUTimer = new Timer();

        // Obsługa bufora odbioru
        private bool _SOFInBuffer = false;
        private bool _CRLFInBuffer = false;

        // Transakcja - czy MASTER ma interpretować przychodzące ramki (jako odpowiedź).
        private bool _transactionInProgress = false;

        private int _retransmittedCount = 0;

        // Do retransmisji ostatnio wysłana ramka.
        private byte[] _lastFrame;

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

                // Przerwa przed/po ramce RTU >= 4 * czas przesyłania jednego znaku (w ms)
                _RTUTimer.Interval = 4 * 1000 / (value / 10.0);

                if (TransmissionMode == TransmissionModeEnum.RTU8E1 ||
                   TransmissionMode == TransmissionModeEnum.RTU8O1 ||
                   TransmissionMode == TransmissionModeEnum.RTU8N2)
                    _intercharInterval.Interval = 1.5 * 1000 / (value / 10.0);
            }
        }

        /// <summary>
        /// Maksymalny odstęp pomiędzy znakami w ms.
        /// </summary>
        public int IntercharInterval
        {
            get { return (int)_intercharInterval.Interval; }
            set { _intercharInterval.Interval = value; }
        }

        /// <summary>
        /// Nazwa portu komunikacyjnego.
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set
            {
                _portName = value;
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
        public int TransactionTimeout
        {
            get { return (int)_transactionTimeout.Interval; }
            set { _transactionTimeout.Interval = value; }
        }

        /// <summary>
        /// Tryb transmisji.
        /// </summary>
        public TransmissionModeEnum TransmissionMode
        {
            get { return _transmissionMode; }
            set
            {
                _transmissionMode = value;

                if (_transmissionMode == TransmissionModeEnum.RTU8E1 ||
                   _transmissionMode == TransmissionModeEnum.RTU8O1 ||
                   _transmissionMode == TransmissionModeEnum.RTU8N2)
                {
                    _intercharInterval.Interval = 1.5 * 1000 / (_baudrate / 10.0);
                    _generalTransimssionMode = GeneralTransmissionModeEnum.RTU;
                }
                else
                {
                    _generalTransimssionMode = GeneralTransmissionModeEnum.ASCII;
                }
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
            IntercharInterval = 10;
            RetryCount = 1;
            StationAddress = 1;
            TransactionTimeout = 1000;
            TransmissionMode = TransmissionModeEnum.ASCII7E1;
            Type = StationTypeEnum.SLAVE;
            RS232.Instance.Communicate += OnRS232Communicate;
            RS232.Instance.SetDataMode(DataModeEnum.BINARY);


            _intercharInterval.Elapsed += OnIntercharIntervalElapsed;
            _transactionTimeout.Elapsed += OnTransactionTimeout;
            _RTUTimer.Elapsed += OnRTUTimerElapsed;
        }

        private bool CheckForASCIIFrameInBuffer()
        {
            if (_inBuffer.Contains((byte)':'))
                _SOFInBuffer = true;

            if (_inBuffer.Contains(0x0D))
            {
                int pos = _inBuffer.IndexOf(0x0D);
                if (_inBuffer[pos + 1] == 0x0A)
                    _CRLFInBuffer = true;
            }

            if (_SOFInBuffer && _CRLFInBuffer)
                return true;

            return false;
        }

        private void OnTransactionTimeout(object sender, System.EventArgs e)
        {
            _transactionTimeout.Stop();
            _transactionInProgress = false;
            Console.WriteLine("Timeout transakcji.");

            // Opcjonalna retransmisja
            if (_retransmittedCount < RetryCount)
            {
                Console.WriteLine("Retransmisja ramki");
                _retransmittedCount++;

                RS232.Instance.SendBinary(_lastFrame);
                _transactionInProgress = true;
                _transactionTimeout.Start();
            }
            else
                _retransmittedCount = 0;
        }

        private void OnIntercharIntervalElapsed(object sender, System.EventArgs e)
        {
            if (_generalTransimssionMode == GeneralTransmissionModeEnum.RTU)
                return;

            _intercharInterval.Stop();
            // Unieważnienie bufora
            _inBuffer.Clear();
            _SOFInBuffer = false;
            _CRLFInBuffer = false;
        }

        private void OnRTUTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _RTUTimer.Stop();
            List<byte> frame = new List<byte>(_inBuffer);
            _inBuffer.Clear();
            ProcessFrame(frame);
        }

        public void ClosePort()
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
        private byte[] CreateASCIIFrame(byte destAddress, byte instructionCode, string message)
        {
            List<byte> frame = new List<byte>();
            byte LRC = 0x00;
            byte address;

            // Slave umieszcza swój adres w odpowiedzi.
            if (Type == StationTypeEnum.MASTER)
                address = destAddress;
            else
                address = StationAddress;

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

            return frame.ToArray();
        }

        private byte[] CreateRTUFrame(byte destAddress, byte instructionCode, string message)
        {
            List<byte> frame = new List<byte>();

            frame.Add(destAddress);
            frame.Add(instructionCode);

            char[] m = message.ToCharArray();
            for (int i = 0; i < m.Length; i++)
            {
                frame.Add((byte)m[i]);
            }

            // Liczenie CRC
            UInt16 crc = 0xFFFF;

            for (int i = 0; i < frame.Count; i++)
            {
                crc ^= (UInt16)frame[i];

                for (int j = 8; j != 0; j--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                        crc >>= 1;
                }
            }

            frame.Add((byte)crc);
            frame.Add((byte)(crc >> 8));

            return frame.ToArray();
        }
        

        /// <summary>
        /// Reakcja na komunikaty z RS232.
        /// </summary>
        /// <param name="arg"></param>
        private void OnRS232Communicate(RS232CommunicateEventArgs arg)
        {
            switch (arg.Type)
            {
                case CommunicateType.ErrorOccured:
                    MODBUSCommunicateEventArgs modbusArg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.ErrorOccured);
                    modbusArg.Text = arg.ErrorMessage;
                    break;

                case CommunicateType.BinaryDataReceived:
                    _intercharInterval.Stop();
                    // Dodanie danych do bufora wejściowego i sprawdzenie czy jest tam ramka.
                    _inBuffer.AddRange(arg.BinaryData);

                    if(_generalTransimssionMode == GeneralTransmissionModeEnum.ASCII && CheckForASCIIFrameInBuffer())
                    {
                        int start = _inBuffer.IndexOf((byte)':');
                        int end = _inBuffer.IndexOf(0x0A);

                        List<byte> frame = _inBuffer.GetRange(start, end - start + 1);
                        _inBuffer.RemoveRange(start, end - start + 1);
                        ProcessFrame(frame);
                    }

                    if (_generalTransimssionMode == GeneralTransmissionModeEnum.RTU)
                    {
                        _RTUTimer.Stop();
                        _RTUTimer.Start();
                    }

                    // Zapewnienie ciągłości ramki
                    _intercharInterval.Start();
                    break;
                default:
                    break;
            }
        }

        private List<byte> ConvertASCIIToBytes(List<byte> frame)
        {
            List<byte> data = new List<byte>();

            // Przetwarzamy wszystko oprócz znaków początku ramki oraz CR LF końca.
            for (int i = 1; i < frame.Count - 2; i += 2)
            {
                // Zamiana ASCII na właściwe bajty.
                byte b = 0x00;

                if (frame[i] >= 0x30 && frame[i] <= 0x39)
                    b = (byte)((frame[i] - 0x30) << 4);
                else if (frame[i] >= 0x41 && frame[i] <= 0x46)
                    b = (byte)((frame[i] - 0x37) << 4);
                else
                    throw new Exception("Invalid ASCII code.");

                if (frame[i + 1] >= 0x30 && frame[i + 1] <= 0x39)
                    b += (byte)(frame[i + 1] - 0x30);
                else if (frame[i + 1] >= 0x41 && frame[i + 1] <= 0x46)
                    b += (byte)(frame[i + 1] - 0x37);
                else
                    throw new Exception("Invalid ASCII code.");

                data.Add(b);
            }

            return data;
        }

        private bool CheckLRC(List<byte> data)
        {
            byte LRC = 0x00;
            for (int i = 0; i < data.Count - 1; i++)
                LRC += data[i];

            LRC = (byte)-LRC;

            if (LRC == data[data.Count - 1])
                return true;
            else
                return false;
        }

        private bool CheckCRC(List<byte> data)
        {
            return true;
        }

        private void ProcessFrame(List<byte> frame)
        {
            List<byte> data;

            // Dane otrzymane.
            if (_generalTransimssionMode == GeneralTransmissionModeEnum.ASCII)
            {
                 data = ConvertASCIIToBytes(frame);

                 // Nic nie robimy jeśli nie zgadza się suma kontrolna.
                 if (!CheckLRC(data))
                     return;
            }
            else
            {
                // RTU
                data = frame;

                // Nic nie robimy jeśli nie zgadza się suma kontrolna.
                if (!CheckCRC(data))
                    return;
            }

            // Jeśli jesteśmy slavem to sprawdzamy czy ramka jest do nas.
            if (Type == StationTypeEnum.SLAVE && data[0] != StationAddress && data[0] != 0)
                return;

            // Akcje dla slave'a.
            if (Type == StationTypeEnum.SLAVE)
            {
                // Informacja o otrzymanej ramce.
                MODBUSCommunicateEventArgs arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.FrameReceived);
                arg.Frame = frame.ToArray();
                Communicate(arg);

                // Tekst ze stacji Master do Slave
                if (data[1] == 1)
                {
                    // Jeśli to nie broadcast to potwierdzenie wykonania rozkazu.
                    if(data[0] != 0)
                        SendMessage(StationAddress, 1, "");

                    List<byte> messageBytes = _generalTransimssionMode == GeneralTransmissionModeEnum.ASCII ?
                        data.GetRange(2, data.Count - 3) :
                        data.GetRange(2, data.Count - 4);

                    // Przetworzenie do tekstu
                    string message = System.Text.Encoding.ASCII.GetString(messageBytes.ToArray());
                    arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.TextReceived);
                    arg.Text = message;
                    Communicate(arg);
                }

                // Tekst ze stajcji Slave do Master
                if (data[1] == 2 && data[0] != 0)
                {
                    arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.TextRequest);
                    Communicate(arg);
                }
            }

            // Akcje dla Mastera.
            if (Type == StationTypeEnum.MASTER)
            {
                _transactionTimeout.Stop();
                _retransmittedCount = 0;
                _transactionInProgress = false;

                Console.WriteLine("Otrzymano potwierdzenie wykonania rozkazu {0}", data[1]);

                // Informacja o otrzymanej ramce.
                MODBUSCommunicateEventArgs arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.FrameReceived);
                arg.Frame = frame.ToArray();
                Communicate(arg);

                // Odczytanie tekstu
                if (data[1] == 2)
                {
                    List<byte> messageBytes = _generalTransimssionMode == GeneralTransmissionModeEnum.ASCII ?
                        data.GetRange(2, data.Count - 3) :
                        data.GetRange(2, data.Count - 4);

                    // Przetworzenie do tekstu
                    string message = System.Text.Encoding.ASCII.GetString(messageBytes.ToArray());
                    arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.TextReceived);
                    arg.Text = message;
                    Communicate(arg);
                }
            }
        }

        /// <summary>
        /// Otwiera port RS232.
        /// </summary>
        /// <returns>True jeśli otwarto port.</returns>
        public bool OpenPort()
        {
            int result = -1;

            switch (TransmissionMode)
            {
                case TransmissionModeEnum.ASCII7E1:
                    result = RS232.Instance.Open(_portName, _baudrate, 7, StopBits.One, Parity.Even, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.ASCII7O1:
                    result = RS232.Instance.Open(_portName, _baudrate, 7, StopBits.One, Parity.Odd, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.ASCII7N2:
                    result = RS232.Instance.Open(_portName, _baudrate, 7, StopBits.Two, Parity.None, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.RTU8E1:
                    result = RS232.Instance.Open(_portName, _baudrate, 8, StopBits.One, Parity.Even, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.RTU8O1:
                    result = RS232.Instance.Open(_portName, _baudrate, 8, StopBits.One, Parity.Odd, "\n", PORT_HANDSHAKE); break;
                case TransmissionModeEnum.RTU8N2:
                    result = RS232.Instance.Open(_portName, _baudrate, 8, StopBits.Two, Parity.None, "\n", PORT_HANDSHAKE); break;
                default:
                    break;
            }

            if (result == 0)
                return true;
            else
                return false;
        }

        public void SendMessage(byte destAddress, byte instructionCode, string message)
        {
            // Jeśli korzystamy z rozkazu nr 2 to nie ma sensu wysyłać dodatkowych danych
            // do slave'a.
            if (instructionCode == 2 && Type == StationTypeEnum.MASTER)
                message = "";

            byte[] frame = new byte[] {};
            switch (_generalTransimssionMode)
            {
                case GeneralTransmissionModeEnum.ASCII:
                    frame = CreateASCIIFrame(destAddress, instructionCode, message);
                    break;

                case GeneralTransmissionModeEnum.RTU:
                    frame = CreateRTUFrame(destAddress, instructionCode, message);
                    break;
            }
            
            _lastFrame = frame;

            {
                MODBUSCommunicateEventArgs arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.FrameSent);
                arg.Frame = frame;
                Communicate(arg);
            }

            if (!RS232.Instance.SendBinary(frame))
            {
                MODBUSCommunicateEventArgs arg = new MODBUSCommunicateEventArgs(MODBUSCommunicateType.ErrorOccured);
                arg.Text = "Nie udało się wysłać ramki - błąd zapisu do portu.";
                Communicate(arg);
                return;
            }

            if (Type == StationTypeEnum.MASTER && destAddress != 0)
            {
                _transactionInProgress = true;
                _transactionTimeout.Start();
            }
        }
    }
}
