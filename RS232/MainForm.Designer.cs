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
            this.uxStatusStrip = new System.Windows.Forms.StatusStrip();
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.narzędziaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autobaudingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxModeTabs = new System.Windows.Forms.TabControl();
            this.uxTextModeTab = new System.Windows.Forms.TabPage();
            this.uxBinaryModeTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.uxPortListRefreshButton = new System.Windows.Forms.Button();
            this.uxPortComboBox = new System.Windows.Forms.ComboBox();
            this.uxStatusStrip.SuspendLayout();
            this.uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.uxModeTabs.SuspendLayout();
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
            // uxStripStatusLabel
            // 
            this.uxStripStatusLabel.Name = "uxStripStatusLabel";
            this.uxStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.uxStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uxModeTabs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uxPortComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.uxPortListRefreshButton);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(841, 419);
            this.splitContainer1.SplitterDistance = 564;
            this.splitContainer1.TabIndex = 2;
            // 
            // narzędziaToolStripMenuItem
            // 
            this.narzędziaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingToolStripMenuItem,
            this.autobaudingToolStripMenuItem});
            this.narzędziaToolStripMenuItem.Name = "narzędziaToolStripMenuItem";
            this.narzędziaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.narzędziaToolStripMenuItem.Text = "Narzędzia";
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // autobaudingToolStripMenuItem
            // 
            this.autobaudingToolStripMenuItem.Name = "autobaudingToolStripMenuItem";
            this.autobaudingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autobaudingToolStripMenuItem.Text = "Autobauding";
            // 
            // uxModeTabs
            // 
            this.uxModeTabs.Controls.Add(this.uxTextModeTab);
            this.uxModeTabs.Controls.Add(this.uxBinaryModeTab);
            this.uxModeTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxModeTabs.Location = new System.Drawing.Point(0, 0);
            this.uxModeTabs.Name = "uxModeTabs";
            this.uxModeTabs.SelectedIndex = 0;
            this.uxModeTabs.Size = new System.Drawing.Size(564, 419);
            this.uxModeTabs.TabIndex = 0;
            // 
            // uxTextModeTab
            // 
            this.uxTextModeTab.Location = new System.Drawing.Point(4, 22);
            this.uxTextModeTab.Name = "uxTextModeTab";
            this.uxTextModeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxTextModeTab.Size = new System.Drawing.Size(556, 393);
            this.uxTextModeTab.TabIndex = 0;
            this.uxTextModeTab.Text = "Tryb tekstowy";
            this.uxTextModeTab.UseVisualStyleBackColor = true;
            // 
            // uxBinaryModeTab
            // 
            this.uxBinaryModeTab.Location = new System.Drawing.Point(4, 22);
            this.uxBinaryModeTab.Name = "uxBinaryModeTab";
            this.uxBinaryModeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxBinaryModeTab.Size = new System.Drawing.Size(523, 376);
            this.uxBinaryModeTab.TabIndex = 1;
            this.uxBinaryModeTab.Text = "Tryb binarny";
            this.uxBinaryModeTab.UseVisualStyleBackColor = true;
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
            // uxPortListRefreshButton
            // 
            this.uxPortListRefreshButton.Location = new System.Drawing.Point(132, 22);
            this.uxPortListRefreshButton.Name = "uxPortListRefreshButton";
            this.uxPortListRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.uxPortListRefreshButton.TabIndex = 2;
            this.uxPortListRefreshButton.Text = "Odśwież";
            this.uxPortListRefreshButton.UseVisualStyleBackColor = true;
            this.uxPortListRefreshButton.Click += new System.EventHandler(this.uxPortListRefreshButton_Click);
            // 
            // uxPortComboBox
            // 
            this.uxPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPortComboBox.FormattingEnabled = true;
            this.uxPortComboBox.Location = new System.Drawing.Point(5, 22);
            this.uxPortComboBox.Name = "uxPortComboBox";
            this.uxPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.uxPortComboBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 465);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.uxStatusStrip);
            this.Controls.Add(this.uxMenuStrip);
            this.MainMenuStrip = this.uxMenuStrip;
            this.Name = "MainForm";
            this.Text = "GKiO1 RS232";
            this.uxStatusStrip.ResumeLayout(false);
            this.uxStatusStrip.PerformLayout();
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.uxModeTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip uxStatusStrip;
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripStatusLabel uxStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narzędziaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autobaudingToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl uxModeTabs;
        private System.Windows.Forms.TabPage uxTextModeTab;
        private System.Windows.Forms.TabPage uxBinaryModeTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uxPortComboBox;
        private System.Windows.Forms.Button uxPortListRefreshButton;
    }
}

