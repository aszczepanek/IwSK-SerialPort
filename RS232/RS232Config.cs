using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace RS232
{
    /// <summary>
    /// Klasa przechowująca pojedynczą konfigurację portu.
    /// </summary>
    public class RS232Config
    {
        public RS232Config(int baudrate, int dataBits, Parity p, StopBits s, Handshake h, string t)
        {
            Baudrate = baudrate;
            DataBits = dataBits;
            Parity = p;
            StopBits = s;
            Handshake = h;
            Terminator = t;
        }

        public int Baudrate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }
        public string Terminator { get; set; }
    }
}
