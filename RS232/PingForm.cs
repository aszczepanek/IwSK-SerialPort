using System;
using System.Windows.Forms;

namespace RS232
{
    public partial class PingForm : Form
    {
        public PingForm()
        {
            InitializeComponent();
            RS232.Instance.Communicate += OnRS232Communicate;
        }

        private void OnRS232Communicate(RS232CommunicateEventArgs arg)
        {
            switch (arg.Type)
            {
                case CommunicateType.PingTimeCaluclated:
                    SetPingTimeoutLabel(arg.PingTime.ToString() + "ms");
                    break;

                case CommunicateType.PingTimeout:
                    SetPingTimeoutLabel("No response");
                    break;

                default:
                    break;
            }
        }

        public delegate void SetLabelTextDelegate(string text);

        /// <summary>
        /// Metoda ustawiania stanu pingu bezpieczna dla wielowątkowości
        /// (timeout z zewnętrznego timera może wywoływać tę metodę
        /// z innego wątku).
        /// </summary>
        /// <param name="text"></param>
        private void SetPingTimeoutLabel(string text)
        {
            if (InvokeRequired)
            {
                object[] param = new object[] { text };
                Invoke(new SetLabelTextDelegate(SetPingTimeoutLabel), param);
                return;
            }

            uxRTDLabel.Text = text;
        }

        private void uxPingButton_Click(object sender, EventArgs e)
        {
            uxRTDLabel.Text = "Oczekiwanie...";
            RS232.Instance.Ping();
        }
    }
}
