using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RS232
{
    /// <summary>
    /// Główna klasa obsługująca port.
    /// </summary>
    class RS232
    {
        /// <summary>
        /// Singleton.
        /// </summary>
        private static RS232 _instance;

        /// <summary>
        /// Dostęp do singletonu.
        /// </summary>
        public static RS232 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RS232();
                return _instance;
            }
        }

        /// <summary>
        /// Pusty prywatny konstruktor - realizacja singletonu.
        /// </summary>
        private RS232()
        {
            Port = new SerialPort();
        }

        /// <summary>
        /// Port, który będzie używany do transmisji.
        /// </summary>
        public SerialPort Port;

        public void SelectPort(string portName)
        {
            Port.PortName = portName;
        }

        public void SetBaudRate(int speed)
        {
            Port.BaudRate = speed;
        }

        public void SetDataBits(int n)
        {
            Port.DataBits = n;
        }

        public void SetParity(Parity parity)
        {
            Port.Parity = parity;
        }

        public void SetStopBits(int n)
        {
            switch(n) {
                case 1:
                    Port.StopBits = StopBits.One;
                    break;
                case 2:
                    Port.StopBits = StopBits.Two;
                    break;
                default:
                    Port.StopBits = StopBits.None;
                    break;
            }
        }

        public void SetHandshake(Handshake h)
        {
            Port.Handshake = h;
        }

        public void SetTerminator(string t)
        {
            Port.NewLine = t;
        }

        public void Connect()
        {
            Port.Open();
        }

        public void Disconnect()
        {
            Port.Close();
        }

        public void SendText(string text)
        {
            Port.WriteLine(text);
        }

        /// <returns>Lista portów dostępnych w komputerze.</returns>
        public static string[] GetSerialPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
