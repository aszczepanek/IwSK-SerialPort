using System;
using System.Collections.Generic;
using System.Text;

namespace RS232
{
    /// <summary>
    /// Rodzaje komunikatów.
    /// </summary>
    public enum MODBUSCommunicateType
    {
        ErrorOccured,
        FrameSent,
        FrameReceived,
        TextReceived,
        TextRequest
    }

    /// <summary>
    /// Klasa przechowująca komunikat z klasy MODBUS dla
    /// zarejestrowanych listenerów tego zdarzenia.
    /// </summary>
    public class MODBUSCommunicateEventArgs
    {
        public MODBUSCommunicateType Type { get; set; }

        public byte[] Frame { get; set; }
        public string Text { get; set; }

        public MODBUSCommunicateEventArgs(MODBUSCommunicateType t)
        {
            Type = t;
        }
    }
}
