using Be.Windows.Forms;
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

            // Inicjalizacja HexBoxów.
            uxSentHexBox.ByteProvider = new DynamicByteProvider(new byte[] {});
            uxReceivedHexBox.ByteProvider = new DynamicByteProvider(new byte[] { });

            // Inicjalizacja listy portów.
            uxPortNameComboBox.DataSource = SerialPort.GetPortNames();

            // Domyślnie ustawienie na slave.
            uxStationComboBox.SelectedIndex = 1;

            // Domyślnie tryb ASCII 7E1.
            uxTransmissionModeComboBox.SelectedIndex = 0;

            // Domyślna szybkość 1200.
            uxBaudrateComboBox.SelectedIndex = 0;

            // Podłączenie do sieci (istnienie singletonu MODBUS oznacza
            // automatyczne podłączenie do sieci).
            MODBUS m = MODBUS.Instance;
            m.Communicate += OnMODBUSCommunicate;
        }

        /// <summary>
        /// Obsługa komunikatów z klasy MODBUS.
        /// </summary>
        /// <param name="arg"></param>
        private void OnMODBUSCommunicate(MODBUSCommunicateEventArgs arg)
        {
            switch (arg.Type)
            {
                case MODBUSCommunicateType.FrameSent:
                    uxSentHexBox.ByteProvider = new DynamicByteProvider(arg.Frame);
                    break;

                default:
                    break;
            }
        }

        private void uxStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxStationComboBox.SelectedIndex == 0)
            {
                MODBUS.Instance.Type = StationTypeEnum.MASTER;
                uxSendButton.Enabled = true;
                uxRetryCount.Enabled = true;
                uxTransactionTimeout.Enabled = true;
                uxInstructionCode.Enabled = true;
                uxDestinationAddress.Enabled = true;
            }
            else
            {
                MODBUS.Instance.Type = StationTypeEnum.SLAVE;
                uxSendButton.Enabled = false;
                uxRetryCount.Enabled = false;
                uxTransactionTimeout.Enabled = false;
                uxInstructionCode.Enabled = false;
                uxDestinationAddress.Enabled = false;
            }
        }

        private void uxTransmissionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Wybór trybu transmisji.
            switch (uxTransmissionModeComboBox.SelectedIndex)
            {
                case 0:
                    MODBUS.Instance.TransmissionMode = TransmissionModeEnum.ASCII7E1;
                    break;
                case 1:
                    MODBUS.Instance.TransmissionMode = TransmissionModeEnum.ASCII7O1;
                    break;
                case 2:
                    MODBUS.Instance.TransmissionMode = TransmissionModeEnum.ASCII7N2;
                    break;
                case 3:
                    MODBUS.Instance.TransmissionMode = TransmissionModeEnum.RTU8E1;
                    break;
                case 4:
                    MODBUS.Instance.TransmissionMode = TransmissionModeEnum.RTU8O1;
                    break;
                case 5:
                    MODBUS.Instance.TransmissionMode = TransmissionModeEnum.RTU8N2;
                    break;

                default:
                    break;
            }
        }

        private void uxBaudrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MODBUS.Instance.Baudrate = Int32.Parse(uxBaudrateComboBox.Text);
        }

        private void uxSendButton_Click(object sender, EventArgs e)
        {
            MODBUS.Instance.SendMessage((byte)uxDestinationAddress.Value, 1, uxMessageTextBox.Text);
        }

        private void uxStationAddress_ValueChanged(object sender, EventArgs e)
        {
            MODBUS.Instance.StationAddress = (byte)uxStationAddress.Value;
        }

        private void uxTransactionTimeout_ValueChanged(object sender, EventArgs e)
        {
            MODBUS.Instance.TransactionTimeout = (int)(uxTransactionTimeout.Value * 1000);
        }

        private void uxRetryCount_ValueChanged(object sender, EventArgs e)
        {
            MODBUS.Instance.RetryCount = (int)(uxRetryCount.Value);
        }

        private void uxIntercharInterval_ValueChanged(object sender, EventArgs e)
        {
            MODBUS.Instance.IntercharInterval = (int)(uxIntercharInterval.Value);
        }

        private void uxPortNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MODBUS.Instance.PortName = uxPortNameComboBox.Text;
        }
    }
}
