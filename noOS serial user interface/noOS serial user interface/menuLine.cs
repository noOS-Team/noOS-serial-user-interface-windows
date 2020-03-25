using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noOS_serial_user_interface
{
    public partial class menuLine : Form
    {
        static byte displayedLineCalibration = 0;

        public menuLine()
        {
            InitializeComponent();
        }

        public void setUpdateFormTimer(bool state)
        {
            updateFormTimer.Enabled = state;
        }

        private void updateFormTimer_Tick(object sender, EventArgs e)
        {
            line1CheckBox.Checked = sharedData.lineSegment[0];
            line2CheckBox.Checked = sharedData.lineSegment[1];
            line3CheckBox.Checked = sharedData.lineSegment[2];
            line4CheckBox.Checked = sharedData.lineSegment[3];
            line5CheckBox.Checked = sharedData.lineSegment[4];
            line6CheckBox.Checked = sharedData.lineSegment[5];
            line7CheckBox.Checked = sharedData.lineSegment[6];
            line8CheckBox.Checked = sharedData.lineSegment[7];
            line9CheckBox.Checked = sharedData.lineSegment[8];
            line10CheckBox.Checked = sharedData.lineSegment[9];
            line11CheckBox.Checked = sharedData.lineSegment[10];
            line12CheckBox.Checked = sharedData.lineSegment[11];

            if (sharedData.currentLineCalibration != displayedLineCalibration)
            {
                displayedLineCalibration = sharedData.currentLineCalibration;
                lineCalibrationTextBox.Text = sharedData.currentLineCalibration.ToString();
            }
        }

        private void setLineCalibrationButton_Click(object sender, EventArgs e)
        {
            sharedData.setLineCalibration = true;
            sharedData.newLineCalibration = byte.Parse(lineCalibrationTextBox.Text);
        }
    }
}
