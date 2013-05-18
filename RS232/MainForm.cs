using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS232
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            uxPortComboBox.DataSource = RS232.GetSerialPorts();
            SetDefaultParameters();
        }

        private void uxPortListRefreshButton_Click(object sender, EventArgs e)
        {
            uxPortComboBox.DataSource = RS232.GetSerialPorts();
        }

        private void uxConnectButton_Click(object sender, EventArgs e)
        {
            uxDisconnectButton.Enabled = true;
            uxConnectButton.Enabled = false;
            SetupPort();
            RS232.Instance.Connect();
            EnableCommunication();
            RS232.Instance.Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void uxDisconnectButton_Click(object sender, EventArgs e)
        {
            uxDisconnectButton.Enabled = false;
            uxConnectButton.Enabled = true;
            RS232.Instance.Disconnect();
            DisableCommunication();
        }

        /// <summary>
        /// Uaktywnia elementy interfejsu odpowiedzialne za komunikację
        /// (np. przycisk wyślij).
        /// </summary>
        private void EnableCommunication()
        {
            uxSendTextButton.Enabled = true;
        }

        /// <summary>
        /// Dezaktywuje elementy interfejsu odpowiedzialne za komunikację
        /// (np. przycisk wyślij).
        /// </summary>
        private void DisableCommunication()
        {
            uxSendTextButton.Enabled = false;
        }

        /// <summary>
        /// Ustawia w formularzu domyślnie parametry.
        /// </summary>
        private void SetDefaultParameters()
        {
            if (uxPortComboBox.Items.Count > 0)
            {
                uxPortComboBox.SelectedIndex = 0;
            }

            uxSpeedComboBox.SelectedIndex = 0;
            uxDataBitsComboBox.SelectedIndex = 0;
            uxParityComboBox.SelectedIndex = 0;
            uxStopBitsComboBox.SelectedIndex = 0;
            uxDataControlFlowComboBox.SelectedIndex = 0;
            uxTerminatorComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Ustawia wszystkie paramatry portu w klasie RS232.
        /// </summary>
        private void SetupPort()
        {

            RS232 port = RS232.Instance;
            port.SelectPort(uxPortComboBox.Text);
            port.SetBaudRate(Int32.Parse(uxSpeedComboBox.Text));
            port.SetDataBits(Int32.Parse(uxDataBitsComboBox.Text));

            switch (uxParityComboBox.SelectedIndex)
            {
                case 0:
                    port.SetParity(Parity.None);
                    break;
                case 1:
                    port.SetParity(Parity.Even);
                    break;
                case 2:
                    port.SetParity(Parity.Odd);
                    break;
            }

            port.SetStopBits(Int32.Parse(uxStopBitsComboBox.Text));

            switch (uxDataControlFlowComboBox.SelectedIndex)
            {
                case 0:
                    port.SetHandshake(Handshake.None);
                    break;
                case 1:
                    port.SetHandshake(Handshake.RequestToSend);
                    break;
                case 2:
                    port.SetHandshake(Handshake.XOnXOff);
                    break;
            }

            switch (uxTerminatorComboBox.SelectedIndex)
            {
                case 0:
                    // CR
                    port.SetTerminator("\r");
                    break;
                case 1:
                    // LF
                    port.SetTerminator("\n");
                    break;
                case 2:
                    // CR-LF
                    port.SetTerminator("\r\n");
                    break;
                case 3:
                    // własny termiantor
                    break;
            }
        }

        private void uxSendTextButton_Click(object sender, EventArgs e)
        {
            string[] linesToSend = uxTransmitTextTextBox.Lines;

            foreach (string line in linesToSend)
            {
                RS232.Instance.SendText(line);
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            uxReceivedTextTextBox.AppendText(indata);
        }
    }
}
