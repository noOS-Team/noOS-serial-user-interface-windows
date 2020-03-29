namespace noOS_serial_user_interface
{
    partial class menuCompass
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
            this.menuCompassLabel = new System.Windows.Forms.Label();
            this.updateFormTimer = new System.Windows.Forms.Timer(this.components);
            this.compassAbsoluteTextBox = new System.Windows.Forms.TextBox();
            this.compassAbsoluteLabel = new System.Windows.Forms.Label();
            this.compassRelativeLabel = new System.Windows.Forms.Label();
            this.compassRelativeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // menuCompassLabel
            // 
            this.menuCompassLabel.AutoSize = true;
            this.menuCompassLabel.Location = new System.Drawing.Point(12, 9);
            this.menuCompassLabel.Name = "menuCompassLabel";
            this.menuCompassLabel.Size = new System.Drawing.Size(78, 13);
            this.menuCompassLabel.TabIndex = 0;
            this.menuCompassLabel.Text = "menu compass";
            // 
            // updateFormTimer
            // 
            this.updateFormTimer.Tick += new System.EventHandler(this.updateFormTimer_Tick);
            // 
            // compassAbsoluteTextBox
            // 
            this.compassAbsoluteTextBox.Location = new System.Drawing.Point(69, 47);
            this.compassAbsoluteTextBox.Name = "compassAbsoluteTextBox";
            this.compassAbsoluteTextBox.Size = new System.Drawing.Size(60, 20);
            this.compassAbsoluteTextBox.TabIndex = 1;
            // 
            // compassAbsoluteLabel
            // 
            this.compassAbsoluteLabel.AutoSize = true;
            this.compassAbsoluteLabel.Location = new System.Drawing.Point(13, 50);
            this.compassAbsoluteLabel.Name = "compassAbsoluteLabel";
            this.compassAbsoluteLabel.Size = new System.Drawing.Size(50, 13);
            this.compassAbsoluteLabel.TabIndex = 2;
            this.compassAbsoluteLabel.Text = "absolute:";
            // 
            // compassRelativeLabel
            // 
            this.compassRelativeLabel.AutoSize = true;
            this.compassRelativeLabel.Location = new System.Drawing.Point(13, 80);
            this.compassRelativeLabel.Name = "compassRelativeLabel";
            this.compassRelativeLabel.Size = new System.Drawing.Size(44, 13);
            this.compassRelativeLabel.TabIndex = 3;
            this.compassRelativeLabel.Text = "relative:";
            // 
            // compassRelativeTextBox
            // 
            this.compassRelativeTextBox.Location = new System.Drawing.Point(69, 77);
            this.compassRelativeTextBox.Name = "compassRelativeTextBox";
            this.compassRelativeTextBox.Size = new System.Drawing.Size(60, 20);
            this.compassRelativeTextBox.TabIndex = 4;
            // 
            // menuCompass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 355);
            this.Controls.Add(this.compassRelativeTextBox);
            this.Controls.Add(this.compassRelativeLabel);
            this.Controls.Add(this.compassAbsoluteLabel);
            this.Controls.Add(this.compassAbsoluteTextBox);
            this.Controls.Add(this.menuCompassLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuCompass";
            this.Text = "menuCompass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuCompassLabel;
        private System.Windows.Forms.Timer updateFormTimer;
        private System.Windows.Forms.TextBox compassAbsoluteTextBox;
        private System.Windows.Forms.Label compassAbsoluteLabel;
        private System.Windows.Forms.Label compassRelativeLabel;
        private System.Windows.Forms.TextBox compassRelativeTextBox;
    }
}