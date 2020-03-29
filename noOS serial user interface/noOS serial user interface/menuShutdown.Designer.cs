namespace noOS_serial_user_interface
{
    partial class menuShutdown
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
            this.components = new System.ComponentModel.Container();
            this.menuShutdownLabel = new System.Windows.Forms.Label();
            this.updateFormTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // menuShutdownLabel
            // 
            this.menuShutdownLabel.AutoSize = true;
            this.menuShutdownLabel.Location = new System.Drawing.Point(12, 9);
            this.menuShutdownLabel.Name = "menuShutdownLabel";
            this.menuShutdownLabel.Size = new System.Drawing.Size(82, 13);
            this.menuShutdownLabel.TabIndex = 0;
            this.menuShutdownLabel.Text = "menu shutdown";
            // 
            // updateFormTimer
            // 
            this.updateFormTimer.Tick += new System.EventHandler(this.updateFormTimer_Tick);
            // 
            // menuShutdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 355);
            this.Controls.Add(this.menuShutdownLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuShutdown";
            this.Text = "menuShutdown";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuShutdownLabel;
        private System.Windows.Forms.Timer updateFormTimer;
    }
}