namespace RS232
{
    partial class PingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.uxPingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uxRTDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aby ta funkcja działała, w aplikacji po drugiej stronie łącza \r\nmusi być również " +
    "aktywowane okno Ping.\r\n";
            // 
            // uxPingButton
            // 
            this.uxPingButton.Location = new System.Drawing.Point(16, 42);
            this.uxPingButton.Name = "uxPingButton";
            this.uxPingButton.Size = new System.Drawing.Size(75, 23);
            this.uxPingButton.TabIndex = 1;
            this.uxPingButton.Text = "Ping";
            this.uxPingButton.UseVisualStyleBackColor = true;
            this.uxPingButton.Click += new System.EventHandler(this.uxPingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Round Trip Delay:";
            // 
            // uxRTDLabel
            // 
            this.uxRTDLabel.AutoSize = true;
            this.uxRTDLabel.Location = new System.Drawing.Point(112, 68);
            this.uxRTDLabel.Name = "uxRTDLabel";
            this.uxRTDLabel.Size = new System.Drawing.Size(42, 13);
            this.uxRTDLabel.TabIndex = 3;
            this.uxRTDLabel.Text = "<RTD>";
            // 
            // PingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 96);
            this.Controls.Add(this.uxRTDLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxPingButton);
            this.Controls.Add(this.label1);
            this.Name = "PingForm";
            this.Text = "Ping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxPingButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label uxRTDLabel;
    }
}