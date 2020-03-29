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
    public partial class menuShutdown : Form
    {
        public menuShutdown()
        {
            InitializeComponent();
        }

        public void setUpdateFormTimer(bool state)
        {
            updateFormTimer.Enabled = state;
        }

        private void updateFormTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
