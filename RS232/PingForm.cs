using System;
using System.Windows.Forms;

namespace RS232
{
    public partial class PingForm : Form
    {
        public PingForm()
        {
            InitializeComponent();
        }

        private void uxPingButton_Click(object sender, EventArgs e)
        {
            uxRTDLabel.Text = "Oczekiwanie...";
            int ping = RS232.Instance.Ping();

            if (ping == -1)
            {
                uxRTDLabel.Text = "Brak odpowiedzi.";
            }
            else
            {
                uxRTDLabel.Text = ping.ToString() + "ms";
            }
        }
    }
}
