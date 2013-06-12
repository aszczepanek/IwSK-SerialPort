using System;
using System.IO.Ports;
using System.Diagnostics;
using System.Timers;

namespace RS232
{
    public enum DataModeEnum { BINARY, TEXT, PING };

    /// <summary>
    /// Główna klasa obsługująca port.
    /// </summary>
    public class RS232
    {
        /// <summary>
        /// Argumenty dla zdarzenia komunikacji z klasy RS232.
        /// </summary>
        /// <param name="arg"></param>
        public delegate void RS232CommunicateDelegate(RS232CommunicateEventArgs arg);

        /// <summary>
        /// Zdarzenie pozwalające syngalizować różne komunikaty
        /// klasie RS232.
        /// </summary>
        public event RS232CommunicateDelegate Communicate;

        /// <summary>
        /// Tryb interpretowania przychodzących danych.
        /// </summary>
        private DataModeEnum _dataMode;

        /// <summary>
        /// Singleton.
        /// </summary>
        private static RS232 _instance;

        /// <summary>
        /// Pomiar czasu pingu.
        /// </summary>
        private Stopwatch _pingStopwatch;

        /// <summary>
        /// Obsługa timeoutu pingu.
        /// </summary>
        private Timer _pingTimeoutTimer;

        /// <summary>
        /// Odpowiada za sposób interpretacji przychodzącego pingu -
        /// czy jest odpowiedź na nasz wysłany ping (true) czy
        /// jest to ping z "drugiej" strony łącza i należy odesłać
        /// odpowiedź na ping (false).
        /// </summary>
        private bool _pingIsRunnig;

        /// <summary>
        /// Obsługa timeoutu transakcji.
        /// </summary>
        private Timer _transactionTimeoutTimer;

        public DataModeEnum DataMode
        {
            get
            {
                return _dataMode;
            }
        }

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
        /// Przełącznik transakcji.
        /// </summary>
        public bool TransactionEnabled { get; set; }

        /// <summary>
        /// Czas oczekiwania na odpowiedź w transakcji.
        /// </summary>
        public int TransactionTimeout
        {
            get
            {
                return (int)_transactionTimeoutTimer.Interval;
            }

            set
            {
                _transactionTimeoutTimer.Interval = value;
            }
        }

        /// <summary>
        /// Port, który będzie używany do transmisji.
        /// </summary>
        public readonly SerialPort Port;

        private RS232()
        {
            // Ustawienie zmiennych związanych z pingiem.
            _pingStopwatch = new Stopwatch();
            _pingTimeoutTimer = new Timer(1000);
            _pingTimeoutTimer.Elapsed += OnPingTimeout;
            _pingIsRunnig = false;

            // Domyślne wyłączenie transakcji.
            TransactionEnabled = false;
            _transactionTimeoutTimer = new Timer(1000);
            _transactionTimeoutTimer.Elapsed += OnTransactionTimeout;

            Port = new SerialPort();
            _dataMode = DataModeEnum.TEXT;
            Port.DataReceived += DataReceivedHandler;
        }

        public void Close()
        {
            Port.Close();
        }

        /// <summary>
        /// Interpretacja przychodzących danych z portu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Przekazanie danych do odpowiednich funkcji
            // zależnie od trybu w jakim znajduje się aktualnie
            // port.
            switch (DataMode)
            {
                case DataModeEnum.BINARY:
                    BinaryDataHandler(sender, e);
                    break;
                case DataModeEnum.TEXT:
                    TextDataHandler(sender, e);
                    break;
                case DataModeEnum.PING:
                    PingHandler(sender, e);
                    break;
            }
        }

        /// <summary>
        /// Obsługa zdarzenia przekroczenia czasu oczekiwania na odpowiedź
        /// na wysłany ping.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPingTimeout(object sender, ElapsedEventArgs e)
        {
            _pingTimeoutTimer.Stop();
            _pingStopwatch.Stop();
            _pingStopwatch.Reset();

            

            RS232CommunicateEventArgs arg = new RS232CommunicateEventArgs(CommunicateType.PingTimeout);
            Communicate(arg);
        }

        /// <summary>
        /// Obsługa zdarzenia przekroczenia czasu oczekiwania na odpowiedź
        /// w ramach transakcji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTransactionTimeout(object sender, ElapsedEventArgs e)
        {
            _transactionTimeoutTimer.Stop();

            RS232CommunicateEventArgs arg = new RS232CommunicateEventArgs(CommunicateType.ErrorOccured);
            arg.ErrorMessage = "Nie otrzymano odpowiedzi w ramach transakcji w wyznaczonym czasie.";
            Communicate(arg);
        }

        /// <summary>
        /// Otwiera port z zadanymi parametrami.
        /// </summary>
        /// <param name="portName">Nazwa portu (np. COM1)</param>
        /// <param name="baudRate">Szybkość w bitach/s</param>
        /// <param name="dataBits">Bity danych</param>
        /// <param name="stopBits">Bity stopu</param>
        /// <param name="parity">Parzystość</param>
        /// <param name="terminator">Znaki końca linii</param>
        /// <param name="handshake">Handshake</param>
        /// <returns>0 jeśli wszystko się powiodło.
        /// -1 jeśli wystąpił błąd.</returns>
        public int Open(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity, string terminator, Handshake handshake)
        {
            try
            {
                Port.PortName = portName;
                Port.BaudRate = baudRate;
                Port.DataBits = dataBits;
                Port.StopBits = stopBits;
                Port.Parity = parity;
                Port.NewLine = terminator;
                Port.Handshake = handshake;
                Port.Open();
            }
            catch (Exception e)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Rozpoczyna transakcję typu ping.
        /// </summary>
        public void Ping()
        {
            // To my wysyłamy ping.
            _pingIsRunnig = true;
            SendPing();

            // Ropoczęcie pomiaru czasu oraz timera timeoutu.
            _pingStopwatch.Start();
            _pingTimeoutTimer.Start();
        }

        

        /// <summary>
        /// Wysyła dane binarne jeśli port jest otwarty.
        /// </summary>
        /// <param name="data">Dane do przesłania.</param>
        public void SendBinary(byte[] data)
        {
            if (Port.IsOpen)
                Port.Write(data, 0, data.Length);

            if (TransactionEnabled)
                _transactionTimeoutTimer.Start();
        }

        /// <summary>
        /// Wysłanie znaku-pingu (0xAA).
        /// </summary>
        private void SendPing()
        {
            Port.WriteLine("A");
        }

        /// <summary>
        /// Wysyła tekst jeśli port jest otwarty.
        /// </summary>
        /// <param name="text">Tekst do przesłania.</param>
        public void SendText(string text)
        {
            if (Port.IsOpen)
                Port.WriteLine(text);

            if (TransactionEnabled)
                _transactionTimeoutTimer.Start();
        }

        /// <summary>
        /// Ustawienie trybu interpretowania przychodzących danych.
        /// </summary>
        /// <param name="mode"></param>
        public void SetDataMode(DataModeEnum mode)
        {
            if (_dataMode == mode)
                return;

            // Dodatkowe działania przy zmianie trybu
            _dataMode = mode;
        }

        //////////////////////////////////////////////////////////////////////////
        /// METODY INTERPRETUJĄCE DANE
        //////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Funkcja odpowiadająca za odbiór danych binarnych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BinaryDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Odczyt wszystkich danych z bufora wejściowego.
            SerialPort sp = sender as SerialPort;
            byte[] buf = new byte[sp.BytesToRead];
            sp.Read(buf, 0, buf.Length);

//             Console.WriteLine("Received binary data:");
//             for (int i = 0; i < buf.Length; i++)
//             {
//                 Console.Write(buf[i] + " ");
//             }

            RS232CommunicateEventArgs arg = new RS232CommunicateEventArgs(CommunicateType.BinaryDataReceived);
            arg.BinaryData = buf;
            Communicate(arg);
        }

        /// <summary>
        /// Funkcja odpowiadająca za odbiór danych tekstowych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Jeśli nie napotkano znaku końca linii to nie odczytujemy
            // bufora wejściowego.
//             if (e.EventType != SerialData.Eof)
//                 return;

            SerialPort sp = sender as SerialPort;
            string indata = sp.ReadLine();

            RS232CommunicateEventArgs arg = new RS232CommunicateEventArgs(CommunicateType.TextDataReceived);
            arg.TextData = indata;
            Communicate(arg);
        }

        /// <summary>
        /// Funkcja odpowiadająca za realizację interakcji "ping".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PingHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (_pingIsRunnig)
            {
                // Odbiór pingu i pomiar czasu.
                _pingStopwatch.Stop();
                _pingTimeoutTimer.Stop();
                long time = _pingStopwatch.ElapsedMilliseconds;
                _pingStopwatch.Reset();

                RS232CommunicateEventArgs arg = new RS232CommunicateEventArgs(CommunicateType.PingTimeCaluclated);
                arg.PingTime = time;
                Communicate(arg);

                _pingIsRunnig = false;
            }
            else
            {
                // Odesłanie odpowiedzi na ping.
                Port.ReadLine();
                SendPing();
            }

            // Wyczyszczenie bufora wejściowego.
            Port.DiscardInBuffer();
        }
    }
}
