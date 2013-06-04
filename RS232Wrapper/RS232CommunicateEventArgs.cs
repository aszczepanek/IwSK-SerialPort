namespace RS232
{
    /// <summary>
    /// Rodzaje komunikatów.
    /// </summary>
    public enum CommunicateType {
        ErrorOccured,
        BinaryDataReceived,
        TextDataReceived,
        PingTimeout,
        PingTimeCaluclated }

    /// <summary>
    /// Klasa przechowująca komunikat z klasy RS232 dla
    /// zarejestrowanych listenerów tego zdarzenia.
    /// </summary>
    public class RS232CommunicateEventArgs
    {
        public CommunicateType Type { get; set; }

        public byte[] BinaryData { get; set; }
        public string TextData { get; set; }
        public long PingTime { get; set; }
        public string ErrorMessage { get; set; }

        public RS232CommunicateEventArgs(CommunicateType t)
        {
            Type = t;
        }
    }
}
