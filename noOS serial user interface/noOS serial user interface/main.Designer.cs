namespace noOS_serial_user_interface
{
    partial class main
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
            this.menuListBox = new System.Windows.Forms.ListBox();
            this.comPortsComboBox = new System.Windows.Forms.ComboBox();
            this.openPortButton = new System.Windows.Forms.Button();
            this.updateFormTimer = new System.Windows.Forms.Timer(this.components);
            this.batteryPercentageTextBox = new System.Windows.Forms.TextBox();
            this.batteryLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.lastUpdateLabel = new System.Windows.Forms.Label();
            this.lastUpdateTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // menuListBox
            // 
            this.menuListBox.FormattingEnabled = true;
            this.menuListBox.Location = new System.Drawing.Point(12, 44);
            this.menuListBox.Name = "menuListBox";
            this.menuListBox.Size = new System.Drawing.Size(120, 355);
            this.menuListBox.TabIndex = 0;
            this.menuListBox.Click += new System.EventHandler(this.menuListBox_Click);
            // 
            // comPortsComboBox
            // 
            this.comPortsComboBox.FormattingEnabled = true;
            this.comPortsComboBox.Location = new System.Drawing.Point(12, 12);
            this.comPortsComboBox.Name = "comPortsComboBox";
            this.comPortsComboBox.Size = new System.Drawing.Size(120, 21);
            this.comPortsComboBox.TabIndex = 1;
            // 
            // openPortButton
            // 
            this.openPortButton.Location = new System.Drawing.Point(148, 12);
            this.openPortButton.Name = "openPortButton";
            this.openPortButton.Size = new System.Drawing.Size(75, 23);
            this.openPortButton.TabIndex = 2;
            this.openPortButton.Text = "Open Port";
            this.openPortButton.UseVisualStyleBackColor = true;
            this.openPortButton.Click += new System.EventHandler(this.openPortButton_Click);
            // 
            // updateFormTimer
            // 
            this.updateFormTimer.Interval = 200;
            this.updateFormTimer.Tick += new System.EventHandler(this.updateFormTimer_Tick);
            // 
            // batteryPercentageTextBox
            // 
            this.batteryPercentageTextBox.Location = new System.Drawing.Point(732, 12);
            this.batteryPercentageTextBox.Name = "batteryPercentageTextBox";
            this.batteryPercentageTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.batteryPercentageTextBox.Size = new System.Drawing.Size(40, 20);
            this.batteryPercentageTextBox.TabIndex = 3;
            this.batteryPercentageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // batteryLabel
            // 
            this.batteryLabel.AutoSize = true;
            this.batteryLabel.Location = new System.Drawing.Point(680, 15);
            this.batteryLabel.Name = "batteryLabel";
            this.batteryLabel.Size = new System.Drawing.Size(46, 13);
            this.batteryLabel.TabIndex = 4;
            this.batteryLabel.Text = "Battery: ";
            // 
            // menuPanel
            // 
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Location = new System.Drawing.Point(148, 44);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(624, 355);
            this.menuPanel.TabIndex = 5;
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.AutoSize = true;
            this.lastUpdateLabel.Location = new System.Drawing.Point(549, 15);
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.Size = new System.Drawing.Size(62, 13);
            this.lastUpdateLabel.TabIndex = 6;
            this.lastUpdateLabel.Text = "last update:";
            // 
            // lastUpdateTextBox
            // 
            this.lastUpdateTextBox.Location = new System.Drawing.Point(617, 12);
            this.lastUpdateTextBox.Name = "lastUpdateTextBox";
            this.lastUpdateTextBox.Size = new System.Drawing.Size(40, 20);
            this.lastUpdateTextBox.TabIndex = 7;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.lastUpdateTextBox);
            this.Controls.Add(this.lastUpdateLabel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.batteryLabel);
            this.Controls.Add(this.batteryPercentageTextBox);
            this.Controls.Add(this.openPortButton);
            this.Controls.Add(this.comPortsComboBox);
            this.Controls.Add(this.menuListBox);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "noOS serial user interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox menuListBox;
        private System.Windows.Forms.ComboBox comPortsComboBox;
        private System.Windows.Forms.Button openPortButton;
        private System.Windows.Forms.Timer updateFormTimer;
        private System.Windows.Forms.TextBox batteryPercentageTextBox;
        private System.Windows.Forms.Label batteryLabel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label lastUpdateLabel;
        private System.Windows.Forms.TextBox lastUpdateTextBox;
    }
}

