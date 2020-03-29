namespace noOS_serial_user_interface
{
    partial class menuOverview
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
            this.label1 = new System.Windows.Forms.Label();
            this.ledStateCheckBox = new System.Windows.Forms.CheckBox();
            this.updateFormTimer = new System.Windows.Forms.Timer(this.components);
            this.startActionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "menu overview";
            // 
            // ledStateCheckBox
            // 
            this.ledStateCheckBox.AutoSize = true;
            this.ledStateCheckBox.Location = new System.Drawing.Point(15, 50);
            this.ledStateCheckBox.Name = "ledStateCheckBox";
            this.ledStateCheckBox.Size = new System.Drawing.Size(66, 17);
            this.ledStateCheckBox.TabIndex = 1;
            this.ledStateCheckBox.Text = "led state";
            this.ledStateCheckBox.UseVisualStyleBackColor = true;
            // 
            // updateFormTimer
            // 
            this.updateFormTimer.Tick += new System.EventHandler(this.updateFormTimer_Tick);
            // 
            // startActionButton
            // 
            this.startActionButton.Location = new System.Drawing.Point(12, 73);
            this.startActionButton.Name = "startActionButton";
            this.startActionButton.Size = new System.Drawing.Size(75, 23);
            this.startActionButton.TabIndex = 3;
            this.startActionButton.Text = "start action";
            this.startActionButton.UseVisualStyleBackColor = true;
            this.startActionButton.Click += new System.EventHandler(this.startActionButton_Click);
            // 
            // menuOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 355);
            this.Controls.Add(this.startActionButton);
            this.Controls.Add(this.ledStateCheckBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuOverview";
            this.Text = "menuOverview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ledStateCheckBox;
        private System.Windows.Forms.Timer updateFormTimer;
        private System.Windows.Forms.Button startActionButton;
    }
}