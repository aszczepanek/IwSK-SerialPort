namespace RS232
{
    partial class AutobaudingForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.uxPortComboBox = new System.Windows.Forms.ComboBox();
            this.uxBeginButton = new System.Windows.Forms.Button();
            this.uxStopButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxStopbitsLabel = new System.Windows.Forms.Label();
            this.uxParityLabel = new System.Windows.Forms.Label();
            this.uxTerminatorLabel = new System.Windows.Forms.Label();
            this.uxHandshakeLabel = new System.Windows.Forms.Label();
            this.uxDatabitsLabel = new System.Windows.Forms.Label();
            this.uxBaudrateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // uxPortComboBox
            // 
            this.uxPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPortComboBox.FormattingEnabled = true;
            this.uxPortComboBox.Location = new System.Drawing.Point(48, 12);
            this.uxPortComboBox.Name = "uxPortComboBox";
            this.uxPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.uxPortComboBox.TabIndex = 5;
            // 
            // uxBeginButton
            // 
            this.uxBeginButton.Location = new System.Drawing.Point(16, 43);
            this.uxBeginButton.Name = "uxBeginButton";
            this.uxBeginButton.Size = new System.Drawing.Size(75, 23);
            this.uxBeginButton.TabIndex = 7;
            this.uxBeginButton.Text = "Rozpocznij";
            this.uxBeginButton.UseVisualStyleBackColor = true;
            this.uxBeginButton.Click += new System.EventHandler(this.uxBeginButton_Click);
            // 
            // uxStopButton
            // 
            this.uxStopButton.Location = new System.Drawing.Point(98, 42);
            this.uxStopButton.Name = "uxStopButton";
            this.uxStopButton.Size = new System.Drawing.Size(75, 23);
            this.uxStopButton.TabIndex = 8;
            this.uxStopButton.Text = "Przerwij";
            this.uxStopButton.UseVisualStyleBackColor = true;
            this.uxStopButton.Click += new System.EventHandler(this.uxStopButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Bity stopu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Parzystość:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Terminator:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Kontrola przepływu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Bity pola danych:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Szybkość:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Sprawdzana konfiguracja:";
            // 
            // uxStopbitsLabel
            // 
            this.uxStopbitsLabel.AutoSize = true;
            this.uxStopbitsLabel.Location = new System.Drawing.Point(128, 201);
            this.uxStopbitsLabel.Name = "uxStopbitsLabel";
            this.uxStopbitsLabel.Size = new System.Drawing.Size(55, 13);
            this.uxStopbitsLabel.TabIndex = 31;
            this.uxStopbitsLabel.Text = "<stopbits>";
            // 
            // uxParityLabel
            // 
            this.uxParityLabel.AutoSize = true;
            this.uxParityLabel.Location = new System.Drawing.Point(128, 174);
            this.uxParityLabel.Name = "uxParityLabel";
            this.uxParityLabel.Size = new System.Drawing.Size(44, 13);
            this.uxParityLabel.TabIndex = 30;
            this.uxParityLabel.Text = "<parity>";
            // 
            // uxTerminatorLabel
            // 
            this.uxTerminatorLabel.AutoSize = true;
            this.uxTerminatorLabel.Location = new System.Drawing.Point(128, 255);
            this.uxTerminatorLabel.Name = "uxTerminatorLabel";
            this.uxTerminatorLabel.Size = new System.Drawing.Size(65, 13);
            this.uxTerminatorLabel.TabIndex = 29;
            this.uxTerminatorLabel.Text = "<termiantor>";
            // 
            // uxHandshakeLabel
            // 
            this.uxHandshakeLabel.AutoSize = true;
            this.uxHandshakeLabel.Location = new System.Drawing.Point(128, 228);
            this.uxHandshakeLabel.Name = "uxHandshakeLabel";
            this.uxHandshakeLabel.Size = new System.Drawing.Size(72, 13);
            this.uxHandshakeLabel.TabIndex = 28;
            this.uxHandshakeLabel.Text = "<handshake>";
            // 
            // uxDatabitsLabel
            // 
            this.uxDatabitsLabel.AutoSize = true;
            this.uxDatabitsLabel.Location = new System.Drawing.Point(128, 147);
            this.uxDatabitsLabel.Name = "uxDatabitsLabel";
            this.uxDatabitsLabel.Size = new System.Drawing.Size(56, 13);
            this.uxDatabitsLabel.TabIndex = 27;
            this.uxDatabitsLabel.Text = "<databits>";
            // 
            // uxBaudrateLabel
            // 
            this.uxBaudrateLabel.AutoSize = true;
            this.uxBaudrateLabel.Location = new System.Drawing.Point(128, 120);
            this.uxBaudrateLabel.Name = "uxBaudrateLabel";
            this.uxBaudrateLabel.Size = new System.Drawing.Size(61, 13);
            this.uxBaudrateLabel.TabIndex = 26;
            this.uxBaudrateLabel.Text = "<baudrate>";
            // 
            // AutobaudingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 302);
            this.Controls.Add(this.uxStopbitsLabel);
            this.Controls.Add(this.uxParityLabel);
            this.Controls.Add(this.uxTerminatorLabel);
            this.Controls.Add(this.uxHandshakeLabel);
            this.Controls.Add(this.uxDatabitsLabel);
            this.Controls.Add(this.uxBaudrateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxStopButton);
            this.Controls.Add(this.uxBeginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxPortComboBox);
            this.Name = "AutobaudingForm";
            this.Text = "Autobauding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uxPortComboBox;
        private System.Windows.Forms.Button uxBeginButton;
        private System.Windows.Forms.Button uxStopButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uxStopbitsLabel;
        private System.Windows.Forms.Label uxParityLabel;
        private System.Windows.Forms.Label uxTerminatorLabel;
        private System.Windows.Forms.Label uxHandshakeLabel;
        private System.Windows.Forms.Label uxDatabitsLabel;
        private System.Windows.Forms.Label uxBaudrateLabel;

    }
}