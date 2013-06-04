using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace RS232
{
    public partial class ManualControlForm : Form
    {
        public ManualControlForm()
        {
            InitializeComponent();
            UpdateLinesStates();
            RS232.Instance.Port.PinChanged += OnPinChanged;
        }

        /// <summary>
        /// Aktualizacja stanu linii.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPinChanged(object sender, SerialPinChangedEventArgs e)
        {
            UpdateLinesStates();
        }

        private void UpdateLinesStates()
        {
            SerialPort port = RS232.Instance.Port;

            if (!port.IsOpen || port.Handshake == Handshake.RequestToSend || port.Handshake == Handshake.RequestToSendXOnXOff)
            {
                uxRTSLabel.Text = "-";
                uxCTSLabel.Text = "-";
                uxDTRLabel.Text = "-";
                uxDSRLabel.Text = "-";

                if (port.Handshake == Handshake.RequestToSend || port.Handshake == Handshake.RequestToSendXOnXOff)
                {
                    uxPortStatusLabel.Text = "Ustawiono sprzętowy handshake!";
                }

                if (!port.IsOpen)
                {
                    uxPortStatusLabel.Text = "Port jest zamknięty.";
                }

                uxDTRCheckBox.Enabled = false;
                uxRTSCheckBox.Enabled = false;

                return;
            }

            uxPortStatusLabel.Text = "Port is open.";

            uxDTRCheckBox.Enabled = true;
            uxRTSCheckBox.Enabled = true;

            uxRTSCheckBox.Checked = port.RtsEnable;
            uxDTRCheckBox.Checked = port.DtrEnable;

            if (port.RtsEnable == true)
                uxRTSLabel.Text = "1";
            else
                uxRTSLabel.Text = "0";

            if (port.CtsHolding == true)
                uxCTSLabel.Text = "1";
            else
                uxCTSLabel.Text = "0";

            if (port.DtrEnable == true)
                uxDTRLabel.Text = "1";
            else
                uxDTRLabel.Text = "0";

            if (port.DsrHolding == true)
                uxDSRLabel.Text = "1";
            else
                uxDSRLabel.Text = "0";
        }

        private void uxRTSCheckBox_Click(object sender, EventArgs e)
        {
            RS232.Instance.Port.RtsEnable = uxRTSCheckBox.Checked;
            UpdateLinesStates();
        }

        private void uxDTRCheckBox_Click(object sender, EventArgs e)
        {
            RS232.Instance.Port.DtrEnable = uxDTRCheckBox.Checked;
            UpdateLinesStates();
        }
    }
}
