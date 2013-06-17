using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace RS232
{
    public partial class AutobaudingForm : Form
    {
        private List<RS232Config> _configList = new List<RS232Config>();

        private string _portName;

        private bool _terminateThread = false;

        private Thread _testingThread;

        public AutobaudingForm()
        {
            InitializeComponent();

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
            List<StopBits> stopBits = new List<StopBits>(new StopBits[] { StopBits.One, StopBits.Two });
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

        private void uxBeginButton_Click(object sender, EventArgs e)
        {
            uxBeginButton.Enabled = false;
            _portName = uxPortComboBox.Text;
            CreateConfigList();
            Console.WriteLine("Liczba konfiguracji: {0}", _configList.Count);
            RS232.Instance.Close();
            uxPortComboBox.Enabled = false;
            _terminateThread = false;
            _testingThread = new Thread(TestConfigs);
            _testingThread.Start();
        }

        private void SetLabels(RS232Config c)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => SetLabels(c)));
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
            }
        }

        private void TestConfigs()
        {
            bool condition = true;

            while (condition)
            {
                if (_terminateThread)
                {
                    Console.WriteLine("Zakończono wątek testowania");
                    RS232.Instance.Close();
                    return;
                }

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
                    Console.WriteLine("Kontynuacja");
                    continue;
                }
                else
                {
                    RS232.Instance.Port.DiscardInBuffer();
                    RS232.Instance.Port.DiscardOutBuffer();
                    SetLabels(c);
                    
                    if (RS232.Instance.Ping() >= 0)
                    {
                        MessageBox.Show("Znaleziono działającą konfigurację! Zobacz ostatnio sprawdzaną konfigurację.", "RS232");
                        condition = false;
                    }
                }
            }

        }

        private void uxStopButton_Click(object sender, EventArgs e)
        {
            uxPortComboBox.Enabled = true;
            _terminateThread = true;
            _testingThread.Join();
            uxBeginButton.Enabled = true;
        }

        private void AutobaudingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _terminateThread = true;
            _testingThread.Join();
        }
    }
}
