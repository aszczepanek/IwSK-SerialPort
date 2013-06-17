using Be.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
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
        /// Zmienia dostępność elementów (nie)dostępnych podczas zamkniętego portu.
        /// </summary>
        private void DisableCommunication()
        {
            uxPortNameComboBox.Enabled = true;
            uxStationComboBox.Enabled = true;
            uxTransmissionModeComboBox.Enabled = true;
            uxBaudrateComboBox.Enabled = true;
            uxSendButton.Enabled = false;
        }

        /// <summary>
        /// Zmienia dostępność elementów (nie)dostępnych podczas otwartego portu.
        /// </summary>
        private void EnableCommunication()
        {
            uxPortNameComboBox.Enabled = false;
            uxStationComboBox.Enabled = false;
            uxTransmissionModeComboBox.Enabled = false;
            uxBaudrateComboBox.Enabled = false;

            if (MODBUS.Instance.Type == StationTypeEnum.MASTER)
                uxSendButton.Enabled = true;
        }

        /// <summary>
        /// Obsługa komunikatów z klasy MODBUS.
        /// </summary>
        /// <param name="arg"></param>
        private void OnMODBUSCommunicate(MODBUSCommunicateEventArgs arg)
        {
            if (InvokeRequired)
            {
                // Aktualizacja kontrolki z innego wątku.
                MODBUS.MODBUSCommunicateDelegate d = new MODBUS.MODBUSCommunicateDelegate(OnMODBUSCommunicate);
                Invoke(d, new object[] { arg });
                return;
            }

            switch (arg.Type)
            {
                case MODBUSCommunicateType.FrameSent:
                    uxSentHexBox.ByteProvider = new DynamicByteProvider(arg.Frame);
                    break;

                case MODBUSCommunicateType.FrameReceived:
                    uxReceivedHexBox.ByteProvider = new DynamicByteProvider(arg.Frame);
                    break;

                case MODBUSCommunicateType.TextReceived:
                    uxReceivedTextBox.Text = arg.Text;
                    break;

                case MODBUSCommunicateType.ErrorOccured:
                    ShowMessage(arg.Text);
                    break;

                case MODBUSCommunicateType.TextRequest:
                    // Reakcja na rozkaz nr 2 - odesłanie tekstu.
                    MODBUS.Instance.SendMessage((byte)uxStationAddress.Value, 2, uxMessageTextBox.Text);
                    break;

                default:
                    break;
            }
        }

        private void ShowMessage(string text)
        {
            MessageBox.Show(text, "MODBUS");
        }

        private void uxStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxStationComboBox.SelectedIndex == 0)
            {
                MODBUS.Instance.Type = StationTypeEnum.MASTER;
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
            MODBUS.Instance.SendMessage((byte)uxDestinationAddress.Value, (byte)uxInstructionCode.Value, uxMessageTextBox.Text);
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

        private void uxConnectButton_Click(object sender, EventArgs e)
        {
            uxConnectButton.Enabled = false;
            uxDisconnectButton.Enabled = true;
            EnableCommunication();

            if (!MODBUS.Instance.OpenPort())
            {
                DisableCommunication();
                ShowMessage("Nie można otworzyć portu. (Zajęty port?)");
                uxConnectButton.Enabled = true;
                uxDisconnectButton.Enabled = false;
            }
        }

        private void uxDisconnectButton_Click(object sender, EventArgs e)
        {
            MODBUS.Instance.ClosePort();
            DisableCommunication();
            uxDisconnectButton.Enabled = false;
            uxConnectButton.Enabled = true;
        }
    }
}
