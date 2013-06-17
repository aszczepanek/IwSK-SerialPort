namespace RS232
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxStationComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxTransmissionModeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uxStationAddress = new System.Windows.Forms.NumericUpDown();
            this.uxDestinationAddress = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.uxInstructionCode = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.uxTransactionTimeout = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.uxRetryCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.uxIntercharInterval = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.uxBaudrateComboBox = new System.Windows.Forms.ComboBox();
            this.uxMessageTextBox = new System.Windows.Forms.TextBox();
            this.uxSendButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.uxReceivedTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.uxSentHexBox = new Be.Windows.Forms.HexBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.uxReceivedHexBox = new Be.Windows.Forms.HexBox();
            this.label16 = new System.Windows.Forms.Label();
            this.uxPortNameComboBox = new System.Windows.Forms.ComboBox();
            this.uxConnectButton = new System.Windows.Forms.Button();
            this.uxDisconnectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxStationAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDestinationAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxInstructionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxTransactionTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxRetryCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxIntercharInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // uxStationComboBox
            // 
            this.uxStationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxStationComboBox.FormattingEnabled = true;
            this.uxStationComboBox.Items.AddRange(new object[] {
            "Master",
            "Slave"});
            this.uxStationComboBox.Location = new System.Drawing.Point(114, 34);
            this.uxStationComboBox.Name = "uxStationComboBox";
            this.uxStationComboBox.Size = new System.Drawing.Size(77, 21);
            this.uxStationComboBox.TabIndex = 0;
            this.uxStationComboBox.SelectedIndexChanged += new System.EventHandler(this.uxStationComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Typ stacji:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tryb transmisji:";
            // 
            // uxTransmissionModeComboBox
            // 
            this.uxTransmissionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxTransmissionModeComboBox.FormattingEnabled = true;
            this.uxTransmissionModeComboBox.Items.AddRange(new object[] {
            "ASCII 7E1",
            "ASCII 7O1",
            "ASCII 7N2",
            "RTU 8E1",
            "RTU 8O1",
            "RTU 8N2"});
            this.uxTransmissionModeComboBox.Location = new System.Drawing.Point(114, 61);
            this.uxTransmissionModeComboBox.Name = "uxTransmissionModeComboBox";
            this.uxTransmissionModeComboBox.Size = new System.Drawing.Size(77, 21);
            this.uxTransmissionModeComboBox.TabIndex = 2;
            this.uxTransmissionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.uxTransmissionModeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adres stacji:";
            // 
            // uxStationAddress
            // 
            this.uxStationAddress.Location = new System.Drawing.Point(114, 115);
            this.uxStationAddress.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.uxStationAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxStationAddress.Name = "uxStationAddress";
            this.uxStationAddress.ReadOnly = true;
            this.uxStationAddress.Size = new System.Drawing.Size(76, 20);
            this.uxStationAddress.TabIndex = 5;
            this.uxStationAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxStationAddress.ValueChanged += new System.EventHandler(this.uxStationAddress_ValueChanged);
            // 
            // uxDestinationAddress
            // 
            this.uxDestinationAddress.Location = new System.Drawing.Point(114, 141);
            this.uxDestinationAddress.Maximum = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.uxDestinationAddress.Name = "uxDestinationAddress";
            this.uxDestinationAddress.ReadOnly = true;
            this.uxDestinationAddress.Size = new System.Drawing.Size(76, 20);
            this.uxDestinationAddress.TabIndex = 7;
            this.uxDestinationAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Adres docelowy:";
            // 
            // uxInstructionCode
            // 
            this.uxInstructionCode.Location = new System.Drawing.Point(114, 167);
            this.uxInstructionCode.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.uxInstructionCode.Name = "uxInstructionCode";
            this.uxInstructionCode.ReadOnly = true;
            this.uxInstructionCode.Size = new System.Drawing.Size(76, 20);
            this.uxInstructionCode.TabIndex = 9;
            this.uxInstructionCode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kod rozkazu:";
            // 
            // uxTransactionTimeout
            // 
            this.uxTransactionTimeout.DecimalPlaces = 1;
            this.uxTransactionTimeout.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.uxTransactionTimeout.Location = new System.Drawing.Point(113, 193);
            this.uxTransactionTimeout.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxTransactionTimeout.Name = "uxTransactionTimeout";
            this.uxTransactionTimeout.ReadOnly = true;
            this.uxTransactionTimeout.Size = new System.Drawing.Size(76, 20);
            this.uxTransactionTimeout.TabIndex = 11;
            this.uxTransactionTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxTransactionTimeout.ValueChanged += new System.EventHandler(this.uxTransactionTimeout_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Timeout transakcji:";
            // 
            // uxRetryCount
            // 
            this.uxRetryCount.Location = new System.Drawing.Point(114, 219);
            this.uxRetryCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxRetryCount.Name = "uxRetryCount";
            this.uxRetryCount.ReadOnly = true;
            this.uxRetryCount.Size = new System.Drawing.Size(76, 20);
            this.uxRetryCount.TabIndex = 13;
            this.uxRetryCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxRetryCount.ValueChanged += new System.EventHandler(this.uxRetryCount_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Liczba retransmisji:";
            // 
            // uxIntercharInterval
            // 
            this.uxIntercharInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxIntercharInterval.Location = new System.Drawing.Point(114, 245);
            this.uxIntercharInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.uxIntercharInterval.Name = "uxIntercharInterval";
            this.uxIntercharInterval.ReadOnly = true;
            this.uxIntercharInterval.Size = new System.Drawing.Size(76, 20);
            this.uxIntercharInterval.TabIndex = 15;
            this.uxIntercharInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxIntercharInterval.ValueChanged += new System.EventHandler(this.uxIntercharInterval_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Max odstęp m-znak:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "s";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Szybkość:";
            // 
            // uxBaudrateComboBox
            // 
            this.uxBaudrateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxBaudrateComboBox.FormattingEnabled = true;
            this.uxBaudrateComboBox.Items.AddRange(new object[] {
            "1200",
            "1800",
            "2400",
            "3600",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200"});
            this.uxBaudrateComboBox.Location = new System.Drawing.Point(114, 88);
            this.uxBaudrateComboBox.Name = "uxBaudrateComboBox";
            this.uxBaudrateComboBox.Size = new System.Drawing.Size(77, 21);
            this.uxBaudrateComboBox.TabIndex = 18;
            this.uxBaudrateComboBox.SelectedIndexChanged += new System.EventHandler(this.uxBaudrateComboBox_SelectedIndexChanged);
            // 
            // uxMessageTextBox
            // 
            this.uxMessageTextBox.Location = new System.Drawing.Point(12, 329);
            this.uxMessageTextBox.Multiline = true;
            this.uxMessageTextBox.Name = "uxMessageTextBox";
            this.uxMessageTextBox.Size = new System.Drawing.Size(175, 49);
            this.uxMessageTextBox.TabIndex = 20;
            // 
            // uxSendButton
            // 
            this.uxSendButton.Location = new System.Drawing.Point(113, 300);
            this.uxSendButton.Name = "uxSendButton";
            this.uxSendButton.Size = new System.Drawing.Size(75, 23);
            this.uxSendButton.TabIndex = 21;
            this.uxSendButton.Text = "Wyślij";
            this.uxSendButton.UseVisualStyleBackColor = true;
            this.uxSendButton.Click += new System.EventHandler(this.uxSendButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Wiadomość:";
            // 
            // uxReceivedTextBox
            // 
            this.uxReceivedTextBox.Location = new System.Drawing.Point(197, 329);
            this.uxReceivedTextBox.Multiline = true;
            this.uxReceivedTextBox.Name = "uxReceivedTextBox";
            this.uxReceivedTextBox.Size = new System.Drawing.Size(175, 49);
            this.uxReceivedTextBox.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Tekst odebrany:";
            // 
            // uxSentHexBox
            // 
            this.uxSentHexBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSentHexBox.InfoForeColor = System.Drawing.Color.Empty;
            this.uxSentHexBox.Location = new System.Drawing.Point(239, 26);
            this.uxSentHexBox.Name = "uxSentHexBox";
            this.uxSentHexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.uxSentHexBox.Size = new System.Drawing.Size(296, 87);
            this.uxSentHexBox.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(236, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Ramka wysłana (HEX):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(236, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Ramka odebrana (HEX):";
            // 
            // uxReceivedHexBox
            // 
            this.uxReceivedHexBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxReceivedHexBox.InfoForeColor = System.Drawing.Color.Empty;
            this.uxReceivedHexBox.Location = new System.Drawing.Point(239, 135);
            this.uxReceivedHexBox.Name = "uxReceivedHexBox";
            this.uxReceivedHexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.uxReceivedHexBox.Size = new System.Drawing.Size(296, 87);
            this.uxReceivedHexBox.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Port:";
            // 
            // uxPortNameComboBox
            // 
            this.uxPortNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPortNameComboBox.FormattingEnabled = true;
            this.uxPortNameComboBox.Location = new System.Drawing.Point(114, 7);
            this.uxPortNameComboBox.Name = "uxPortNameComboBox";
            this.uxPortNameComboBox.Size = new System.Drawing.Size(77, 21);
            this.uxPortNameComboBox.TabIndex = 30;
            this.uxPortNameComboBox.SelectedIndexChanged += new System.EventHandler(this.uxPortNameComboBox_SelectedIndexChanged);
            // 
            // uxConnectButton
            // 
            this.uxConnectButton.Location = new System.Drawing.Point(13, 271);
            this.uxConnectButton.Name = "uxConnectButton";
            this.uxConnectButton.Size = new System.Drawing.Size(75, 23);
            this.uxConnectButton.TabIndex = 32;
            this.uxConnectButton.Text = "Podłącz";
            this.uxConnectButton.UseVisualStyleBackColor = true;
            this.uxConnectButton.Click += new System.EventHandler(this.uxConnectButton_Click);
            // 
            // uxDisconnectButton
            // 
            this.uxDisconnectButton.Location = new System.Drawing.Point(94, 271);
            this.uxDisconnectButton.Name = "uxDisconnectButton";
            this.uxDisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.uxDisconnectButton.TabIndex = 33;
            this.uxDisconnectButton.Text = "Rozłącz";
            this.uxDisconnectButton.UseVisualStyleBackColor = true;
            this.uxDisconnectButton.Click += new System.EventHandler(this.uxDisconnectButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 395);
            this.Controls.Add(this.uxDisconnectButton);
            this.Controls.Add(this.uxConnectButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.uxPortNameComboBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.uxReceivedHexBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.uxSentHexBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.uxReceivedTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.uxSendButton);
            this.Controls.Add(this.uxMessageTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.uxBaudrateComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.uxIntercharInterval);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.uxRetryCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uxTransactionTimeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uxInstructionCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.uxDestinationAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uxStationAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxTransmissionModeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxStationComboBox);
            this.Name = "MainForm";
            this.Text = "MODBUS GKiO1";
            ((System.ComponentModel.ISupportInitialize)(this.uxStationAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDestinationAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxInstructionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxTransactionTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxRetryCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxIntercharInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox uxStationComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uxTransmissionModeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uxStationAddress;
        private System.Windows.Forms.NumericUpDown uxDestinationAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown uxInstructionCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown uxTransactionTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uxRetryCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown uxIntercharInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox uxBaudrateComboBox;
        private System.Windows.Forms.TextBox uxMessageTextBox;
        private System.Windows.Forms.Button uxSendButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uxReceivedTextBox;
        private System.Windows.Forms.Label label13;
        private Be.Windows.Forms.HexBox uxSentHexBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Be.Windows.Forms.HexBox uxReceivedHexBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox uxPortNameComboBox;
        private System.Windows.Forms.Button uxConnectButton;
        private System.Windows.Forms.Button uxDisconnectButton;
    }
}

