using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RS232
{
    public partial class AutobaudingForm : Form
    {
        private List<RS232Config> _configList = new List<RS232Config>();

        private bool _stopTesting = false;

        private string _portName;

        public AutobaudingForm()
        {
            InitializeComponent();
            RS232.Instance.Communicate += OnRS232Communicate;

            uxPortComboBox.DataSource = SerialPort.GetPortNames();

            
        }

        /// <summary>
        /// Tworzy listę konfiguracji do przetestowania.
        /// </summary>
        private void CreateConfigList()
        {
            _configList.Clear();
            List<int> baudRates = new List<int>(new int[] { 150, 200, 300, 600, 1200, 1800, 2400,
                                                            3600, 4800, 7200, 9600, 14400, 19200,
                                                            28800, 38400, 56000, 57600, 115200 });
            List<int> dataBits = new List<int>(new int[] { 7, 8});
            List<Parity> parities = new List<Parity>(new Parity[] {Parity.None, Parity.Even, Parity.Odd });
            List<StopBits> stopBits = new List<StopBits>(new StopBits[] { StopBits.None, StopBits.One, StopBits.Two });
            List<Handshake> handshakes = new List<Handshake>(new Handshake[] { Handshake.None, Handshake.RequestToSend, Handshake.XOnXOff });
            List<string> terminators = new List<string>(new string[] { "\r", "\n", "\r\n" });

            _configList = new List<RS232Config>();

            foreach (int b in baudRates)
                foreach (int d in dataBits)
                    foreach (Parity p in parities)
                        foreach (StopBits s in stopBits)
                            foreach (Handshake h in handshakes)
                                foreach (string t in terminators)
                                    _configList.Add(new RS232Config(b, d, p, s, h, t));
        }

        private void OnRS232Communicate(RS232CommunicateEventArgs arg)
        {
            if (InvokeRequired)
            {
                // Aktualizacja kontrolki z innego wątku.
                RS232.RS232CommunicateDelegate d = new RS232.RS232CommunicateDelegate(OnRS232Communicate);
                Invoke(d, new object[] { arg });
                return;
            }

            switch (arg.Type)
            {
                case CommunicateType.PingTimeCaluclated:
                    MessageBox.Show("Znaleziono działającą konfigurację! Zobacz ostatnio sprawdzaną konfigurację.", "RS232");
                    break;

                case CommunicateType.PingTimeout:
                    if (_stopTesting == true) {
                        _stopTesting = false;
                        return;
                    }
                    TestNextConfig();
                    break;

                default:
                    break;
            }
        }

        private void uxBeginButton_Click(object sender, EventArgs e)
        {
            _portName = uxPortComboBox.Text;
            CreateConfigList();
            Console.WriteLine("Liczba konfiguracji: {0}", _configList.Count);
            RS232.Instance.Close();
            uxPortComboBox.Enabled = false;
            TestNextConfig();
        }

        private void TestNextConfig()
        {
            if (_configList.Count == 0)
            {
                MessageBox.Show("Nie znaleziono odpowiedniej konfiguracji.", "RS232");
                return;
            }

            RS232Config c = _configList[0];
            _configList.Remove(c);

            RS232.Instance.Close();

            if (RS232.Instance.Open(_portName, c.Baudrate, c.DataBits, c.StopBits, c.Parity, c.Terminator, c.Handshake) != 0)
            {
                TestNextConfig();
            }
            else
            {
                uxBaudrateLabel.Text = c.Baudrate.ToString();
                uxDatabitsLabel.Text = c.DataBits.ToString();
                uxParityLabel.Text = c.Parity.ToString();
                uxStopbitsLabel.Text = c.StopBits.ToString();
                uxHandshakeLabel.Text = c.Handshake.ToString();
                if (c.Terminator == "\r")
                    uxTerminatorLabel.Text = "CR";
                else if (c.Terminator == "\n")
                    uxTerminatorLabel.Text = "LF";
                else
                    uxTerminatorLabel.Text = "CRLF";
                RS232.Instance.Ping();
            }

        }

        private void uxStopButton_Click(object sender, EventArgs e)
        {
            uxPortComboBox.Enabled = true;
            _stopTesting = true;
        }
    }
}
