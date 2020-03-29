namespace noOS_serial_user_interface
{
    partial class menuSettings
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
            this.menuSettingsLabel = new System.Windows.Forms.Label();
            this.updateFormTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // menuSettingsLabel
            // 
            this.menuSettingsLabel.AutoSize = true;
            this.menuSettingsLabel.Location = new System.Drawing.Point(12, 9);
            this.menuSettingsLabel.Name = "menuSettingsLabel";
            this.menuSettingsLabel.Size = new System.Drawing.Size(72, 13);
            this.menuSettingsLabel.TabIndex = 0;
            this.menuSettingsLabel.Text = "menu settings";
            // 
            // updateFormTimer
            // 
            this.updateFormTimer.Tick += new System.EventHandler(this.updateFormTimer_Tick);
            // 
            // menuSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 355);
            this.Controls.Add(this.menuSettingsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuSettings";
            this.Text = "menuSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuSettingsLabel;
        private System.Windows.Forms.Timer updateFormTimer;
    }
}