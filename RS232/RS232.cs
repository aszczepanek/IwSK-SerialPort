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
        private RS232 _instance;

        /// <summary>
        /// Dostęp do singletonu.
        /// </summary>
        public RS232 Instance
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
        private RS232() { }

        /// <summary>
        /// Port, który będzie używany do transmisji.
        /// </summary>
        private SerialPort _port;

        

        


        /// <returns>Lista portów dostępnych w komputerze.</returns>
        public static string[] GetSerialPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
