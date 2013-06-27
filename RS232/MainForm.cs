using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Be.Windows.Forms;
using System.IO;

namespace RS232
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            // Inicjalizacja HexBoxów
            uxTransmitHexBox.ByteProvider = new DynamicByteProvider(new byte[] {});
            uxReceivedHexBox.ByteProvider = new DynamicByteProvider(new byte[] { });

            // Początkowy tryb portu
            RS232.Instance.SetDataMode(DataModeEnum.TEXT);

            uxPortComboBox.DataSource = SerialPort.GetPortNames();

            // Ustawienie domyślnych parametrów.
            SetDefaultParameters();

            // Początkowo nie jesteśmy podłączeni.
            DisableCommunication();

            // Rejestracja metody na zdarzenia od klasy RS232.
            RS232.Instance.Communicate += OnRS232Communicate;
        }

        /// <summary>
        /// Dezaktywuje elementy interfejsu odpowiedzialne za komunikację
        /// (np. przycisk wyślij).
        /// </summary>
        private void DisableCommunication()
        {
            uxSendTextButton.Enabled = false;
            uxSendBinaryButton.Enabled = false;
            uxSendFileButton.Enabled = false;

            // Aktywacja kontrolek parametrów portu.
            uxPortComboBox.Enabled = true;
            uxSpeedComboBox.Enabled = true;
            uxDataBitsComboBox.Enabled = true;
            uxParityComboBox.Enabled = true;
            uxStopBitsComboBox.Enabled = true;
            uxDataControlFlowComboBox.Enabled = true;
            uxTerminatorComboBox.Enabled = true;
            uxTerminatorTextBox.Enabled = true;
            uxAutoboudingMenuItem.Enabled = true;

            uxPingMenuItem.Enabled = false;
            uxManualControlMenuItem.Enabled = false;
            uxAutoboudingMenuItem.Enabled = true;
        }

        /// <summary>
        /// Uaktywnia elementy interfejsu odpowiedzialne za komunikację
        /// (np. przycisk wyślij).
        /// </summary>
        private void EnableCommunication()
        {
            uxSendTextButton.Enabled = true;
            uxSendBinaryButton.Enabled = true;
            uxSendFileButton.Enabled = true;

            // Dezaktywacja kontrolek parametrów portu.
            uxPortComboBox.Enabled = false;
            uxSpeedComboBox.Enabled = false;
            uxDataBitsComboBox.Enabled = false;
            uxParityComboBox.Enabled = false;
            uxStopBitsComboBox.Enabled = false;
            uxDataControlFlowComboBox.Enabled = false;
            uxTerminatorComboBox.Enabled = false;
            uxTerminatorTextBox.Enabled = false;
            uxAutoboudingMenuItem.Enabled = false;

            uxPingMenuItem.Enabled = true;
            uxManualControlMenuItem.Enabled = true;
            uxAutoboudingMenuItem.Enabled = false;
        }

        /// <summary>
        /// Obsługa komunikatów z klasy RS232.
        /// </summary>
        /// <param name="arg"></param>
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
                case CommunicateType.TextDataReceived:
                    uxReceivedTextTextBox.AppendText(arg.TextData + "\n");
                    break;

                case CommunicateType.BinaryDataReceived:
                    DynamicByteProvider data = (DynamicByteProvider)uxReceivedHexBox.ByteProvider;
                    data.InsertBytes(data.Length, arg.BinaryData);
                    uxReceivedHexBox.Invalidate();
                    break;

                case CommunicateType.ErrorOccured:
                    ShowError(arg.ErrorMessage);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Wyświetla message boxa z podaną wiadomością.
        /// </summary>
        /// <param name="text"></param>
        private void ShowError(string text)
        {
            MessageBox.Show(text, "RS232");
        }

        /// <summary>
        /// Sprawdza poprawność własnego terminatora.
        /// </summary>
        /// <returns>Prawda jeśli poprawny, w przeciwnym razie fałsz.</returns>
        private bool ValidateTerminator()
        {
            if (uxTerminatorTextBox.Text.Length == 2)
            {
                Regex terminator = new Regex("[0-9a-fA-F]{2}");
                return terminator.IsMatch(uxTerminatorTextBox.Text);
            }

            if (uxTerminatorTextBox.Text.Length == 4)
            {
                Regex terminator = new Regex("[0-9a-fA-F]{4}");
                return terminator.IsMatch(uxTerminatorTextBox.Text);
            }

            return false;
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

            uxTerminatorTextBox.Enabled = false;
        }

        //////////////////////////////////////////////////////////////////////////
        /// METODY INTERFEJSU
        //////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Otwarcie połączenia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxConnectButton_Click(object sender, EventArgs e)
        {
            if (uxTerminatorComboBox.SelectedIndex == 3 && !ValidateTerminator())
            {
                MessageBox.Show("Wpisz dobry terminator.");
                return;
            }

            uxDisconnectButton.Enabled = true;
            uxConnectButton.Enabled = false;
            
            // Parsowanie parametrów
            string portName = uxPortComboBox.Text;
            int baudRate = Int32.Parse(uxSpeedComboBox.Text);
            int dataBits = Int32.Parse(uxDataBitsComboBox.Text);

            StopBits stopBits;
            switch(Int32.Parse(uxStopBitsComboBox.Text)) {
                case 0:
                    stopBits = StopBits.None;
                    break;
                case 1:
                    stopBits = StopBits.One;
                    break;
                case 2:
                    stopBits = StopBits.Two;
                    break;
                default:
                    stopBits = StopBits.None;
                    break;
            }

            Parity parity;
            switch (uxParityComboBox.SelectedIndex)
            {
                case 0:
                    parity = Parity.None;
                    break;
                case 1:
                    parity = Parity.Even;
                    break;
                case 2:
                    parity = Parity.Odd;
                    break;
                default:
                    parity = Parity.None;
                    break;
            }
            
            string terminator = "\n";
            switch (uxTerminatorComboBox.SelectedIndex)
            {
                case 0:
                    // CR
                    terminator = "\r";
                    break;
                case 1:
                    // LF
                    terminator = "\n";
                    break;
                case 2:
                    // CR-LF
                    terminator = "\r\n";
                    break;
                case 3:
                    // własny termiantor
                    string hex = uxTerminatorTextBox.Text;
                    break;
                case 4:
                    // zerowy termiantor
                    terminator = "\0";
                    break;
                default:
                    terminator = "\n";
                    break;
            }

            Handshake handshake;
            switch (uxDataControlFlowComboBox.SelectedIndex)
            {
                case 0:
                    handshake = Handshake.None;
                    break;
                case 1:
                    handshake = Handshake.RequestToSend;
                    break;
                case 2:
                    handshake = Handshake.XOnXOff;
                    break;
                default:
                    handshake = Handshake.None;
                    break;
            }

            if (RS232.Instance.Open(portName, baudRate, dataBits, stopBits, parity, terminator, handshake) == 0)
            {
                EnableCommunication();
            }
            else
            {
                ShowError("Nie udało się otworzyć portu!");
                uxDisconnectButton.Enabled = false;
                uxConnectButton.Enabled = true;
            }
        }

        /// <summary>
        /// Odłączenie od portu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDisconnectButton_Click(object sender, EventArgs e)
        {
            uxDisconnectButton.Enabled = false;
            uxConnectButton.Enabled = true;
            RS232.Instance.Close();
            DisableCommunication();
        }

        /// <summary>
        /// Formularz trybu ręcznego.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxManualControlMenuItem_Click(object sender, EventArgs e)
        {
            ManualControlForm form = new ManualControlForm();
            form.Show();
        }

        /// <summary>
        /// Zmiana trybu działania tekstowy <---> binarny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxModeTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxTabs.SelectedIndex == 0)
            {
                RS232.Instance.SetDataMode(DataModeEnum.TEXT);
                Console.WriteLine("Swtiching to text mode.");
            }
            else
            {
                RS232.Instance.SetDataMode(DataModeEnum.BINARY);
                Console.WriteLine("Switching to binary mode.");
            }
        }

        /// <summary>
        /// Otwarcie formularza pingu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPingMenuItem_Click(object sender, EventArgs e)
        {
            // Zapamiętanie poprzedniego trybu.
            DataModeEnum oldDataMode = RS232.Instance.DataMode;
            RS232.Instance.SetDataMode(DataModeEnum.PING);
            PingForm form = new PingForm();
            form.ShowDialog();
            RS232.Instance.SetDataMode(oldDataMode);
        }

        /// <summary>
        /// Odświeżenie dostępnych portów.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPortListRefreshButton_Click(object sender, EventArgs e)
        {
            uxPortComboBox.DataSource = SerialPort.GetPortNames();
        }

        /// <summary>
        /// Czyszczenie odebranych danych binarnych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxReceivedBinaryClearButton_Click(object sender, EventArgs e)
        {
            DynamicByteProvider data = (DynamicByteProvider)uxReceivedHexBox.ByteProvider;
            data.DeleteBytes(0, data.Length);
            uxReceivedHexBox.Invalidate();
        }

        /// <summary>
        /// Czyszczenie odebranych danych tekstowych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxReceivedTextClearButton_Click(object sender, EventArgs e)
        {
            uxReceivedTextTextBox.Clear();
        }

        /// <summary>
        /// Wysłanie danych binarnych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSendBinaryButton_Click(object sender, EventArgs e)
        {
            DynamicByteProvider data = (DynamicByteProvider)uxTransmitHexBox.ByteProvider;
            RS232.Instance.SendBinary(data.Bytes.ToArray());
        }

        /// <summary>
        /// Wysłanie pliku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSendFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if(dialog.ShowDialog() == DialogResult.OK) {
                BinaryReader b = new BinaryReader(File.Open(dialog.FileName, FileMode.Open));
                byte[] data = b.ReadBytes((int)(new FileInfo(dialog.FileName)).Length);
                RS232.Instance.SendBinary(data);
            }
        }

        /// <summary>
        /// Wysłanie danych tekstowych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSendTextButton_Click(object sender, EventArgs e)
        {
            string[] linesToSend = uxTransmitTextTextBox.Lines;

            foreach (string line in linesToSend)
            {
                RS232.Instance.SendText(line);
            }
        }

        private void uxTerminatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxTerminatorComboBox.SelectedIndex == 3)
                uxTerminatorTextBox.Enabled = true;
            else
                uxTerminatorTextBox.Enabled = false;
        }

        private void uxTransmitBinaryTextBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("TextChanged occured!");
        }

        private void uxTransmitBinaryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyDown");
            Console.WriteLine("KeyData = {0}", e.KeyData);
            Console.WriteLine("KeyValue = {0}", e.KeyValue);
            Console.WriteLine("KeyCode = {0}", e.KeyCode);

            // Dopuszczalne znaki
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                                              'A', 'B', 'C', 'D', 'E', 'F',
                                              '\r', '\n', '\b', ' '};

            for (int i = 0; i < allowedChars.Length; i++)
            {
                if (allowedChars[i] == (char)e.KeyValue)
                {
                    e.SuppressKeyPress = true;
                    break;
                }
            }

//             if (!allowedChars.Contains((char)e.KeyValue))
//                 e.SuppressKeyPress = true;
        }

        private void uxTransactionTimeout_ValueChanged(object sender, EventArgs e)
        {
            RS232.Instance.TransactionTimeout = (int)(uxTransactionTimeout.Value * 1000);
            Console.WriteLine("Zmieniono timeout na {0}ms", (int)(uxTransactionTimeout.Value * 1000));
        }

        private void uxTransactionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RS232.Instance.TransactionEnabled = uxTransactionCheckBox.Checked;
        }

        /// <summary>
        /// Formularz autobaudingu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAutoboudingMenuItem_Click(object sender, EventArgs e)
        {
            DataModeEnum oldDataMode = RS232.Instance.DataMode;
            RS232.Instance.SetDataMode(DataModeEnum.PING);
            AutobaudingForm form = new AutobaudingForm();
            form.ShowDialog();
            RS232.Instance.SetDataMode(oldDataMode);
        }
    }
}
