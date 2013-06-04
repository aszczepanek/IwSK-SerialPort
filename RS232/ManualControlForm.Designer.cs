namespace RS232
{
    partial class ManualControlForm
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
            this.uxRTSLabel = new System.Windows.Forms.Label();
            this.uxDSRLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uxDTRLabel = new System.Windows.Forms.Label();
            this.uxCTSLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uxRTSCheckBox = new System.Windows.Forms.CheckBox();
            this.uxDTRCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxPortStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxRTSLabel
            // 
            this.uxRTSLabel.AutoSize = true;
            this.uxRTSLabel.Location = new System.Drawing.Point(68, 26);
            this.uxRTSLabel.Name = "uxRTSLabel";
            this.uxRTSLabel.Size = new System.Drawing.Size(35, 13);
            this.uxRTSLabel.TabIndex = 1;
            this.uxRTSLabel.Text = "label2";
            // 
            // uxDSRLabel
            // 
            this.uxDSRLabel.AutoSize = true;
            this.uxDSRLabel.Location = new System.Drawing.Point(68, 65);
            this.uxDSRLabel.Name = "uxDSRLabel";
            this.uxDSRLabel.Size = new System.Drawing.Size(35, 13);
            this.uxDSRLabel.TabIndex = 5;
            this.uxDSRLabel.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "DSR:";
            // 
            // uxDTRLabel
            // 
            this.uxDTRLabel.AutoSize = true;
            this.uxDTRLabel.Location = new System.Drawing.Point(68, 52);
            this.uxDTRLabel.Name = "uxDTRLabel";
            this.uxDTRLabel.Size = new System.Drawing.Size(35, 13);
            this.uxDTRLabel.TabIndex = 7;
            this.uxDTRLabel.Text = "label7";
            // 
            // uxCTSLabel
            // 
            this.uxCTSLabel.AutoSize = true;
            this.uxCTSLabel.Location = new System.Drawing.Point(68, 39);
            this.uxCTSLabel.Name = "uxCTSLabel";
            this.uxCTSLabel.Size = new System.Drawing.Size(35, 13);
            this.uxCTSLabel.TabIndex = 9;
            this.uxCTSLabel.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "CTS:";
            // 
            // uxRTSCheckBox
            // 
            this.uxRTSCheckBox.AutoSize = true;
            this.uxRTSCheckBox.Location = new System.Drawing.Point(12, 25);
            this.uxRTSCheckBox.Name = "uxRTSCheckBox";
            this.uxRTSCheckBox.Size = new System.Drawing.Size(51, 17);
            this.uxRTSCheckBox.TabIndex = 10;
            this.uxRTSCheckBox.Text = "RTS:";
            this.uxRTSCheckBox.UseVisualStyleBackColor = true;
            this.uxRTSCheckBox.Click += new System.EventHandler(this.uxRTSCheckBox_Click);
            // 
            // uxDTRCheckBox
            // 
            this.uxDTRCheckBox.AutoSize = true;
            this.uxDTRCheckBox.Location = new System.Drawing.Point(13, 51);
            this.uxDTRCheckBox.Name = "uxDTRCheckBox";
            this.uxDTRCheckBox.Size = new System.Drawing.Size(52, 17);
            this.uxDTRCheckBox.TabIndex = 11;
            this.uxDTRCheckBox.Text = "DTR:";
            this.uxDTRCheckBox.UseVisualStyleBackColor = true;
            this.uxDTRCheckBox.Click += new System.EventHandler(this.uxDTRCheckBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Status:";
            // 
            // uxPortStatusLabel
            // 
            this.uxPortStatusLabel.AutoSize = true;
            this.uxPortStatusLabel.Location = new System.Drawing.Point(69, 9);
            this.uxPortStatusLabel.Name = "uxPortStatusLabel";
            this.uxPortStatusLabel.Size = new System.Drawing.Size(47, 13);
            this.uxPortStatusLabel.TabIndex = 13;
            this.uxPortStatusLabel.Text = "<status>";
            // 
            // ManualControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 90);
            this.Controls.Add(this.uxPortStatusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.uxDTRCheckBox);
            this.Controls.Add(this.uxRTSCheckBox);
            this.Controls.Add(this.uxCTSLabel);
            this.Controls.Add(this.uxDTRLabel);
            this.Controls.Add(this.uxDSRLabel);
            this.Controls.Add(this.uxRTSLabel);
            this.Name = "ManualControlForm";
            this.Text = "ManualMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxRTSLabel;
        private System.Windows.Forms.Label uxDSRLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label uxDTRLabel;
        private System.Windows.Forms.Label uxCTSLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox uxRTSCheckBox;
        private System.Windows.Forms.CheckBox uxDTRCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uxPortStatusLabel;
    }
}