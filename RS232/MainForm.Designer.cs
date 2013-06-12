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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uxStatusStrip = new System.Windows.Forms.StatusStrip();
            this.uxStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxTestFormMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narzędziaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxAutoboudingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxManualControlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxTabs = new System.Windows.Forms.TabControl();
            this.uxTextModeTab = new System.Windows.Forms.TabPage();
            this.uxTextSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uxSendTextButton = new System.Windows.Forms.Button();
            this.uxTransmitTextTextBox = new System.Windows.Forms.TextBox();
            this.uxReceivedTextClearButton = new System.Windows.Forms.Button();
            this.uxReceivedTextTextBox = new System.Windows.Forms.TextBox();
            this.uxBinaryModeTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uxSendFileButton = new System.Windows.Forms.Button();
            this.uxTransmitHexBox = new Be.Windows.Forms.HexBox();
            this.uxSendBinaryButton = new System.Windows.Forms.Button();
            this.uxReceivedHexBox = new Be.Windows.Forms.HexBox();
            this.uxReceivedBinaryClearButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.uxTransactionTimeout = new System.Windows.Forms.NumericUpDown();
            this.uxTransactionCheckBox = new System.Windows.Forms.CheckBox();
            this.uxStopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uxParityComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uxDisconnectButton = new System.Windows.Forms.Button();
            this.uxConnectButton = new System.Windows.Forms.Button();
            this.uxTerminatorTextBox = new System.Windows.Forms.TextBox();
            this.uxTerminatorComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uxDataControlFlowComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uxDataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uxSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxPortComboBox = new System.Windows.Forms.ComboBox();
            this.uxPortListRefreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uxStatusStrip.SuspendLayout();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxMainSplitContainer)).BeginInit();
            this.uxMainSplitContainer.Panel1.SuspendLayout();
            this.uxMainSplitContainer.Panel2.SuspendLayout();
            this.uxMainSplitContainer.SuspendLayout();
            this.uxTabs.SuspendLayout();
            this.uxTextModeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxTextSplitContainer)).BeginInit();
            this.uxTextSplitContainer.Panel1.SuspendLayout();
            this.uxTextSplitContainer.Panel2.SuspendLayout();
            this.uxTextSplitContainer.SuspendLayout();
            this.uxBinaryModeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxTransactionTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // uxStatusStrip
            // 
            this.uxStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxStripStatusLabel});
            this.uxStatusStrip.Location = new System.Drawing.Point(0, 443);
            this.uxStatusStrip.Name = "uxStatusStrip";
            this.uxStatusStrip.Size = new System.Drawing.Size(841, 22);
            this.uxStatusStrip.TabIndex = 0;
            this.uxStatusStrip.Text = "statusStrip";
            // 
            // uxStripStatusLabel
            // 
            this.uxStripStatusLabel.Name = "uxStripStatusLabel";
            this.uxStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.uxStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.narzędziaToolStripMenuItem});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(841, 24);
            this.uxMenuStrip.TabIndex = 1;
            this.uxMenuStrip.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxTestFormMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // uxTestFormMenuItem
            // 
            this.uxTestFormMenuItem.Name = "uxTestFormMenuItem";
            this.uxTestFormMenuItem.Size = new System.Drawing.Size(124, 22);
            this.uxTestFormMenuItem.Text = "TestForm";
            // 
            // narzędziaToolStripMenuItem
            // 
            this.narzędziaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxPingMenuItem,
            this.uxAutoboudingMenuItem,
            this.uxManualControlMenuItem});
            this.narzędziaToolStripMenuItem.Name = "narzędziaToolStripMenuItem";
            this.narzędziaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.narzędziaToolStripMenuItem.Text = "Narzędzia";
            // 
            // uxPingMenuItem
            // 
            this.uxPingMenuItem.Name = "uxPingMenuItem";
            this.uxPingMenuItem.Size = new System.Drawing.Size(171, 22);
            this.uxPingMenuItem.Text = "Ping";
            this.uxPingMenuItem.Click += new System.EventHandler(this.uxPingMenuItem_Click);
            // 
            // uxAutoboudingMenuItem
            // 
            this.uxAutoboudingMenuItem.Name = "uxAutoboudingMenuItem";
            this.uxAutoboudingMenuItem.Size = new System.Drawing.Size(171, 22);
            this.uxAutoboudingMenuItem.Text = "Autobauding";
            this.uxAutoboudingMenuItem.Click += new System.EventHandler(this.uxAutoboudingMenuItem_Click);
            // 
            // uxManualControlMenuItem
            // 
            this.uxManualControlMenuItem.Name = "uxManualControlMenuItem";
            this.uxManualControlMenuItem.Size = new System.Drawing.Size(171, 22);
            this.uxManualControlMenuItem.Text = "Ręczne sterowanie";
            this.uxManualControlMenuItem.Click += new System.EventHandler(this.uxManualControlMenuItem_Click);
            // 
            // uxMainSplitContainer
            // 
            this.uxMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxMainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.uxMainSplitContainer.Name = "uxMainSplitContainer";
            // 
            // uxMainSplitContainer.Panel1
            // 
            this.uxMainSplitContainer.Panel1.Controls.Add(this.uxTabs);
            // 
            // uxMainSplitContainer.Panel2
            // 
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label9);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxTransactionTimeout);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxTransactionCheckBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxStopBitsComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label8);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxParityComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label7);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxDisconnectButton);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxConnectButton);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxTerminatorTextBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxTerminatorComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label6);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxDataControlFlowComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label5);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxDataBitsComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label4);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxSpeedComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label3);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label2);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxPortComboBox);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.uxPortListRefreshButton);
            this.uxMainSplitContainer.Panel2.Controls.Add(this.label1);
            this.uxMainSplitContainer.Size = new System.Drawing.Size(841, 419);
            this.uxMainSplitContainer.SplitterDistance = 473;
            this.uxMainSplitContainer.TabIndex = 2;
            // 
            // uxTabs
            // 
            this.uxTabs.Controls.Add(this.uxTextModeTab);
            this.uxTabs.Controls.Add(this.uxBinaryModeTab);
            this.uxTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTabs.Location = new System.Drawing.Point(0, 0);
            this.uxTabs.Name = "uxTabs";
            this.uxTabs.SelectedIndex = 0;
            this.uxTabs.Size = new System.Drawing.Size(473, 419);
            this.uxTabs.TabIndex = 0;
            this.uxTabs.SelectedIndexChanged += new System.EventHandler(this.uxModeTabs_SelectedIndexChanged);
            // 
            // uxTextModeTab
            // 
            this.uxTextModeTab.Controls.Add(this.uxTextSplitContainer);
            this.uxTextModeTab.Location = new System.Drawing.Point(4, 22);
            this.uxTextModeTab.Name = "uxTextModeTab";
            this.uxTextModeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxTextModeTab.Size = new System.Drawing.Size(465, 393);
            this.uxTextModeTab.TabIndex = 0;
            this.uxTextModeTab.Text = "Tryb tekstowy";
            this.uxTextModeTab.UseVisualStyleBackColor = true;
            // 
            // uxTextSplitContainer
            // 
            this.uxTextSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTextSplitContainer.IsSplitterFixed = true;
            this.uxTextSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.uxTextSplitContainer.Name = "uxTextSplitContainer";
            this.uxTextSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uxTextSplitContainer.Panel1
            // 
            this.uxTextSplitContainer.Panel1.Controls.Add(this.uxSendTextButton);
            this.uxTextSplitContainer.Panel1.Controls.Add(this.uxTransmitTextTextBox);
            this.uxTextSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // uxTextSplitContainer.Panel2
            // 
            this.uxTextSplitContainer.Panel2.Controls.Add(this.uxReceivedTextClearButton);
            this.uxTextSplitContainer.Panel2.Controls.Add(this.uxReceivedTextTextBox);
            this.uxTextSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uxTextSplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uxTextSplitContainer.Size = new System.Drawing.Size(459, 387);
            this.uxTextSplitContainer.SplitterDistance = 190;
            this.uxTextSplitContainer.TabIndex = 0;
            // 
            // uxSendTextButton
            // 
            this.uxSendTextButton.Enabled = false;
            this.uxSendTextButton.Location = new System.Drawing.Point(381, 164);
            this.uxSendTextButton.Name = "uxSendTextButton";
            this.uxSendTextButton.Size = new System.Drawing.Size(75, 23);
            this.uxSendTextButton.TabIndex = 2;
            this.uxSendTextButton.Text = "Wyślij";
            this.uxSendTextButton.UseVisualStyleBackColor = true;
            this.uxSendTextButton.Click += new System.EventHandler(this.uxSendTextButton_Click);
            // 
            // uxTransmitTextTextBox
            // 
            this.uxTransmitTextTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxTransmitTextTextBox.Location = new System.Drawing.Point(0, 0);
            this.uxTransmitTextTextBox.Multiline = true;
            this.uxTransmitTextTextBox.Name = "uxTransmitTextTextBox";
            this.uxTransmitTextTextBox.Size = new System.Drawing.Size(459, 158);
            this.uxTransmitTextTextBox.TabIndex = 1;
            // 
            // uxReceivedTextClearButton
            // 
            this.uxReceivedTextClearButton.Location = new System.Drawing.Point(381, 167);
            this.uxReceivedTextClearButton.Name = "uxReceivedTextClearButton";
            this.uxReceivedTextClearButton.Size = new System.Drawing.Size(75, 23);
            this.uxReceivedTextClearButton.TabIndex = 3;
            this.uxReceivedTextClearButton.Text = "Wyczyść";
            this.uxReceivedTextClearButton.UseVisualStyleBackColor = true;
            this.uxReceivedTextClearButton.Click += new System.EventHandler(this.uxReceivedTextClearButton_Click);
            // 
            // uxReceivedTextTextBox
            // 
            this.uxReceivedTextTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxReceivedTextTextBox.Location = new System.Drawing.Point(0, 0);
            this.uxReceivedTextTextBox.Multiline = true;
            this.uxReceivedTextTextBox.Name = "uxReceivedTextTextBox";
            this.uxReceivedTextTextBox.Size = new System.Drawing.Size(459, 158);
            this.uxReceivedTextTextBox.TabIndex = 2;
            // 
            // uxBinaryModeTab
            // 
            this.uxBinaryModeTab.Controls.Add(this.splitContainer1);
            this.uxBinaryModeTab.Location = new System.Drawing.Point(4, 22);
            this.uxBinaryModeTab.Name = "uxBinaryModeTab";
            this.uxBinaryModeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxBinaryModeTab.Size = new System.Drawing.Size(465, 393);
            this.uxBinaryModeTab.TabIndex = 2;
            this.uxBinaryModeTab.Text = "Tryb binarny";
            this.uxBinaryModeTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uxSendFileButton);
            this.splitContainer1.Panel1.Controls.Add(this.uxTransmitHexBox);
            this.splitContainer1.Panel1.Controls.Add(this.uxSendBinaryButton);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uxReceivedHexBox);
            this.splitContainer1.Panel2.Controls.Add(this.uxReceivedBinaryClearButton);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(459, 387);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 0;
            // 
            // uxSendFileButton
            // 
            this.uxSendFileButton.Location = new System.Drawing.Point(300, 164);
            this.uxSendFileButton.Name = "uxSendFileButton";
            this.uxSendFileButton.Size = new System.Drawing.Size(75, 23);
            this.uxSendFileButton.TabIndex = 4;
            this.uxSendFileButton.Text = "Wyślij plik";
            this.uxSendFileButton.UseVisualStyleBackColor = true;
            this.uxSendFileButton.Click += new System.EventHandler(this.uxSendFileButton_Click);
            // 
            // uxTransmitHexBox
            // 
            this.uxTransmitHexBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxTransmitHexBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTransmitHexBox.InfoForeColor = System.Drawing.Color.Empty;
            this.uxTransmitHexBox.Location = new System.Drawing.Point(0, 0);
            this.uxTransmitHexBox.Name = "uxTransmitHexBox";
            this.uxTransmitHexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.uxTransmitHexBox.Size = new System.Drawing.Size(459, 158);
            this.uxTransmitHexBox.TabIndex = 3;
            // 
            // uxSendBinaryButton
            // 
            this.uxSendBinaryButton.Location = new System.Drawing.Point(381, 164);
            this.uxSendBinaryButton.Name = "uxSendBinaryButton";
            this.uxSendBinaryButton.Size = new System.Drawing.Size(75, 23);
            this.uxSendBinaryButton.TabIndex = 2;
            this.uxSendBinaryButton.Text = "Wyślij";
            this.uxSendBinaryButton.UseVisualStyleBackColor = true;
            this.uxSendBinaryButton.Click += new System.EventHandler(this.uxSendBinaryButton_Click);
            // 
            // uxReceivedHexBox
            // 
            this.uxReceivedHexBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uxReceivedHexBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxReceivedHexBox.InfoForeColor = System.Drawing.Color.Empty;
            this.uxReceivedHexBox.Location = new System.Drawing.Point(0, 0);
            this.uxReceivedHexBox.Name = "uxReceivedHexBox";
            this.uxReceivedHexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.uxReceivedHexBox.Size = new System.Drawing.Size(459, 161);
            this.uxReceivedHexBox.TabIndex = 4;
            // 
            // uxReceivedBinaryClearButton
            // 
            this.uxReceivedBinaryClearButton.Location = new System.Drawing.Point(381, 167);
            this.uxReceivedBinaryClearButton.Name = "uxReceivedBinaryClearButton";
            this.uxReceivedBinaryClearButton.Size = new System.Drawing.Size(75, 23);
            this.uxReceivedBinaryClearButton.TabIndex = 3;
            this.uxReceivedBinaryClearButton.Text = "Wyczyść";
            this.uxReceivedBinaryClearButton.UseVisualStyleBackColor = true;
            this.uxReceivedBinaryClearButton.Click += new System.EventHandler(this.uxReceivedBinaryClearButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "sekund(y)";
            // 
            // uxTransactionTimeout
            // 
            this.uxTransactionTimeout.DecimalPlaces = 1;
            this.uxTransactionTimeout.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.uxTransactionTimeout.Location = new System.Drawing.Point(120, 257);
            this.uxTransactionTimeout.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxTransactionTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.uxTransactionTimeout.Name = "uxTransactionTimeout";
            this.uxTransactionTimeout.Size = new System.Drawing.Size(55, 20);
            this.uxTransactionTimeout.TabIndex = 21;
            this.uxTransactionTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.uxTransactionTimeout.ValueChanged += new System.EventHandler(this.uxTransactionTimeout_ValueChanged);
            // 
            // uxTransactionCheckBox
            // 
            this.uxTransactionCheckBox.AutoSize = true;
            this.uxTransactionCheckBox.Location = new System.Drawing.Point(19, 258);
            this.uxTransactionCheckBox.Name = "uxTransactionCheckBox";
            this.uxTransactionCheckBox.Size = new System.Drawing.Size(95, 17);
            this.uxTransactionCheckBox.TabIndex = 20;
            this.uxTransactionCheckBox.Text = "Tryb transakcji";
            this.uxTransactionCheckBox.UseVisualStyleBackColor = true;
            this.uxTransactionCheckBox.CheckedChanged += new System.EventHandler(this.uxTransactionCheckBox_CheckedChanged);
            // 
            // uxStopBitsComboBox
            // 
            this.uxStopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxStopBitsComboBox.FormattingEnabled = true;
            this.uxStopBitsComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.uxStopBitsComboBox.Location = new System.Drawing.Point(127, 130);
            this.uxStopBitsComboBox.Name = "uxStopBitsComboBox";
            this.uxStopBitsComboBox.Size = new System.Drawing.Size(80, 21);
            this.uxStopBitsComboBox.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Bity stopu:";
            // 
            // uxParityComboBox
            // 
            this.uxParityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxParityComboBox.FormattingEnabled = true;
            this.uxParityComboBox.Items.AddRange(new object[] {
            "Brak",
            "Parzytość",
            "Nieparzystość"});
            this.uxParityComboBox.Location = new System.Drawing.Point(127, 103);
            this.uxParityComboBox.Name = "uxParityComboBox";
            this.uxParityComboBox.Size = new System.Drawing.Size(80, 21);
            this.uxParityComboBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Parzystość:";
            // 
            // uxDisconnectButton
            // 
            this.uxDisconnectButton.Enabled = false;
            this.uxDisconnectButton.Location = new System.Drawing.Point(100, 219);
            this.uxDisconnectButton.Name = "uxDisconnectButton";
            this.uxDisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.uxDisconnectButton.TabIndex = 15;
            this.uxDisconnectButton.Text = "Rozłącz";
            this.uxDisconnectButton.UseVisualStyleBackColor = true;
            this.uxDisconnectButton.Click += new System.EventHandler(this.uxDisconnectButton_Click);
            // 
            // uxConnectButton
            // 
            this.uxConnectButton.Location = new System.Drawing.Point(19, 219);
            this.uxConnectButton.Name = "uxConnectButton";
            this.uxConnectButton.Size = new System.Drawing.Size(75, 23);
            this.uxConnectButton.TabIndex = 14;
            this.uxConnectButton.Text = "Połącz";
            this.uxConnectButton.UseVisualStyleBackColor = true;
            this.uxConnectButton.Click += new System.EventHandler(this.uxConnectButton_Click);
            // 
            // uxTerminatorTextBox
            // 
            this.uxTerminatorTextBox.Location = new System.Drawing.Point(254, 184);
            this.uxTerminatorTextBox.MaxLength = 4;
            this.uxTerminatorTextBox.Name = "uxTerminatorTextBox";
            this.uxTerminatorTextBox.Size = new System.Drawing.Size(75, 20);
            this.uxTerminatorTextBox.TabIndex = 13;
            // 
            // uxTerminatorComboBox
            // 
            this.uxTerminatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxTerminatorComboBox.FormattingEnabled = true;
            this.uxTerminatorComboBox.Items.AddRange(new object[] {
            "CR",
            "LF",
            "CR-LF",
            "Własny"});
            this.uxTerminatorComboBox.Location = new System.Drawing.Point(127, 184);
            this.uxTerminatorComboBox.Name = "uxTerminatorComboBox";
            this.uxTerminatorComboBox.Size = new System.Drawing.Size(121, 21);
            this.uxTerminatorComboBox.TabIndex = 12;
            this.uxTerminatorComboBox.SelectedIndexChanged += new System.EventHandler(this.uxTerminatorComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Terminator:";
            // 
            // uxDataControlFlowComboBox
            // 
            this.uxDataControlFlowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxDataControlFlowComboBox.FormattingEnabled = true;
            this.uxDataControlFlowComboBox.Items.AddRange(new object[] {
            "Brak",
            "Sprzętowa",
            "XON/XOF"});
            this.uxDataControlFlowComboBox.Location = new System.Drawing.Point(127, 157);
            this.uxDataControlFlowComboBox.Name = "uxDataControlFlowComboBox";
            this.uxDataControlFlowComboBox.Size = new System.Drawing.Size(121, 21);
            this.uxDataControlFlowComboBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kontrola przepływu:";
            // 
            // uxDataBitsComboBox
            // 
            this.uxDataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxDataBitsComboBox.FormattingEnabled = true;
            this.uxDataBitsComboBox.Items.AddRange(new object[] {
            "7",
            "8"});
            this.uxDataBitsComboBox.Location = new System.Drawing.Point(127, 76);
            this.uxDataBitsComboBox.Name = "uxDataBitsComboBox";
            this.uxDataBitsComboBox.Size = new System.Drawing.Size(80, 21);
            this.uxDataBitsComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bity pola danych:";
            // 
            // uxSpeedComboBox
            // 
            this.uxSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSpeedComboBox.FormattingEnabled = true;
            this.uxSpeedComboBox.Items.AddRange(new object[] {
            "150",
            "200",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "3600",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.uxSpeedComboBox.Location = new System.Drawing.Point(127, 49);
            this.uxSpeedComboBox.Name = "uxSpeedComboBox";
            this.uxSpeedComboBox.Size = new System.Drawing.Size(121, 21);
            this.uxSpeedComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Szybkość:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // uxPortComboBox
            // 
            this.uxPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPortComboBox.FormattingEnabled = true;
            this.uxPortComboBox.Location = new System.Drawing.Point(127, 22);
            this.uxPortComboBox.Name = "uxPortComboBox";
            this.uxPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.uxPortComboBox.TabIndex = 3;
            // 
            // uxPortListRefreshButton
            // 
            this.uxPortListRefreshButton.Location = new System.Drawing.Point(254, 22);
            this.uxPortListRefreshButton.Name = "uxPortListRefreshButton";
            this.uxPortListRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.uxPortListRefreshButton.TabIndex = 2;
            this.uxPortListRefreshButton.Text = "Odśwież";
            this.uxPortListRefreshButton.UseVisualStyleBackColor = true;
            this.uxPortListRefreshButton.Click += new System.EventHandler(this.uxPortListRefreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Konfiguracja portu";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 465);
            this.Controls.Add(this.uxMainSplitContainer);
            this.Controls.Add(this.uxStatusStrip);
            this.Controls.Add(this.uxMenuStrip);
            this.MainMenuStrip = this.uxMenuStrip;
            this.Name = "MainForm";
            this.Text = "GKiO1 RS232";
            this.uxStatusStrip.ResumeLayout(false);
            this.uxStatusStrip.PerformLayout();
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            this.uxMainSplitContainer.Panel1.ResumeLayout(false);
            this.uxMainSplitContainer.Panel2.ResumeLayout(false);
            this.uxMainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxMainSplitContainer)).EndInit();
            this.uxMainSplitContainer.ResumeLayout(false);
            this.uxTabs.ResumeLayout(false);
            this.uxTextModeTab.ResumeLayout(false);
            this.uxTextSplitContainer.Panel1.ResumeLayout(false);
            this.uxTextSplitContainer.Panel1.PerformLayout();
            this.uxTextSplitContainer.Panel2.ResumeLayout(false);
            this.uxTextSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxTextSplitContainer)).EndInit();
            this.uxTextSplitContainer.ResumeLayout(false);
            this.uxBinaryModeTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxTransactionTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip uxStatusStrip;
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripStatusLabel uxStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narzędziaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxPingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxAutoboudingMenuItem;
        private System.Windows.Forms.SplitContainer uxMainSplitContainer;
        private System.Windows.Forms.TabControl uxTabs;
        private System.Windows.Forms.TabPage uxTextModeTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uxPortComboBox;
        private System.Windows.Forms.Button uxPortListRefreshButton;
        private System.Windows.Forms.ComboBox uxSpeedComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uxDataBitsComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox uxDataControlFlowComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem uxManualControlMenuItem;
        private System.Windows.Forms.ComboBox uxTerminatorComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uxTerminatorTextBox;
        private System.Windows.Forms.SplitContainer uxTextSplitContainer;
        private System.Windows.Forms.Button uxDisconnectButton;
        private System.Windows.Forms.Button uxConnectButton;
        private System.Windows.Forms.Button uxSendTextButton;
        private System.Windows.Forms.TextBox uxTransmitTextTextBox;
        private System.Windows.Forms.TextBox uxReceivedTextTextBox;
        private System.Windows.Forms.Button uxReceivedTextClearButton;
        private System.Windows.Forms.ComboBox uxParityComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox uxStopBitsComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage uxBinaryModeTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button uxSendBinaryButton;
        private System.Windows.Forms.Button uxReceivedBinaryClearButton;
        private System.Windows.Forms.ToolStripMenuItem uxTestFormMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Be.Windows.Forms.HexBox uxTransmitHexBox;
        private Be.Windows.Forms.HexBox uxReceivedHexBox;
        private System.Windows.Forms.Button uxSendFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown uxTransactionTimeout;
        private System.Windows.Forms.CheckBox uxTransactionCheckBox;
    }
}

