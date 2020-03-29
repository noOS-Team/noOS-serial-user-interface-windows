using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noOS_serial_user_interface
{
    public partial class main : Form
    {
        menuOverview mOverview = new menuOverview() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        menuKicker mKicker = new menuKicker() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        menuCamera mCamera = new menuCamera() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        menuCompass mCompass = new menuCompass() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        menuLine mLine = new menuLine() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        menuSettings mSettings = new menuSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        menuShutdown mShutdown = new menuShutdown() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        public enum MENU
        {
            OVERVIEW,
            MATCH,
            KICKER,
            CAMERA,
            COMPASS,
            LINE,
            SETTINGS,
            SHUTDOWN,
        }

        static SerialPort serialComm = new SerialPort();

        static long lastRx = 0;
        static ushort rxInterval = 0;
        static long lastTx = 0;

        static byte rxChunk = 1;

        static ushort absoluteCompassTemp = 0;
        static ushort relativeCompassTemp = 0;

        static MENU selectedMenu = MENU.OVERVIEW;
        static MENU displayedMenu = (MENU)(-1);

        public main()
        {
            InitializeComponent();

            updateFormTimer.Stop();

            // get a list of serial port names
            comPortsComboBox.Items.AddRange(SerialPort.GetPortNames());
            comPortsComboBox.SelectedIndex = 0;

            // add menus
            menuListBox.Items.Clear();
            menuListBox.Items.Add("overview");
            menuListBox.Items.Add("match");
            menuListBox.Items.Add("kicker");
            menuListBox.Items.Add("camera");
            menuListBox.Items.Add("compass");
            menuListBox.Items.Add("line");
            menuListBox.Items.Add("settings");
            menuListBox.Items.Add("shutdown");
        }

        private void openPortButton_Click(object sender, EventArgs e)
        {
            if (string.Compare(openPortButton.Text, "Open Port") == 0)
            {
                openPortButton.Text = "Close Port";

                serialComm.PortName = comPortsComboBox.Text;
                serialComm.BaudRate = 38400;
                serialComm.Parity = (Parity)Enum.Parse(typeof(Parity), "None", true);
                serialComm.DataBits = 8;
                serialComm.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One", true);
                serialComm.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None", true);
                serialComm.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialComm.ReadBufferSize = 8192;
                serialComm.WriteBufferSize = 8192;

                serialComm.Open();
                updateFormTimer.Start();
            }
            else
            {
                openPortButton.Text = "Open Port";

                lastUpdateTextBox.Text = "";
                batteryPercentageTextBox.Text = "";

                updateFormTimer.Stop();
                serialComm.Close();
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int newData;

                while ((newData = serialComm.ReadByte()) > -1)
                {
                    byte newByte = (byte)newData;

                    if (newByte >= 128)
                    {
                        rxChunk = 1;
                        rxInterval = (ushort)((DateTime.Now.Ticks - lastRx) / 10000);
                        lastRx = DateTime.Now.Ticks;
                    }

                    switch(rxChunk)
                    {
                        case 1:
                            break;
                        case 2:
                            sharedData.batteryPercentage = newByte;
                            break;
                        case 3:
                            sharedData.lineSegment[0] = ((newByte & 0x01) > 0) ? true : false;
                            sharedData.lineSegment[1] = ((newByte & 0x02) > 0) ? true : false;
                            sharedData.lineSegment[2] = ((newByte & 0x04) > 0) ? true : false;
                            sharedData.lineSegment[3] = ((newByte & 0x08) > 0) ? true : false;
                            sharedData.lineSegment[4] = ((newByte & 0x10) > 0) ? true : false;
                            sharedData.lineSegment[5] = ((newByte & 0x20) > 0) ? true : false;
                            sharedData.lineSegment[6] = ((newByte & 0x40) > 0) ? true : false;
                            break;
                        case 4:
                            sharedData.lineSegment[7] = ((newByte & 0x01) > 0) ? true : false;
                            sharedData.lineSegment[8] = ((newByte & 0x02) > 0) ? true : false;
                            sharedData.lineSegment[9] = ((newByte & 0x04) > 0) ? true : false;
                            sharedData.lineSegment[10] = ((newByte & 0x08) > 0) ? true : false;
                            sharedData.lineSegment[11] = ((newByte & 0x10) > 0) ? true : false;
                            break;
                        case 5:
                            sharedData.currentLineCalibration = newByte;
                            break;
                        case 6:
                            absoluteCompassTemp = newByte;
                            break;
                        case 7:
                            absoluteCompassTemp += (ushort)(newByte << 7);
                            sharedData.absoluteCompass = (absoluteCompassTemp / 10.0f);
                            break;
                        case 8:
                            relativeCompassTemp = newByte;
                            break;
                        case 9:
                            relativeCompassTemp += (ushort)(newByte << 7);
                            sharedData.relativeCompass = ((float)(relativeCompassTemp - 1800) / 10.0f);
                            break;
                        default:
                            break;
                    }

                    rxChunk++;
                }
            }
            catch (Exception) { }
        }

        private void updateFormTimer_Tick(object sender, EventArgs e)
        {
            lastUpdateTextBox.Text = rxInterval.ToString();
            batteryPercentageTextBox.Text = sharedData.batteryPercentage.ToString() + "%";

            if(selectedMenu != displayedMenu)
            {
                this.menuPanel.Controls.Clear();
                mOverview.setUpdateFormTimer(false);
                mKicker.setUpdateFormTimer(false);
                mCamera.setUpdateFormTimer(false);
                mCompass.setUpdateFormTimer(false);
                mLine.setUpdateFormTimer(false);
                mSettings.setUpdateFormTimer(false);
                mShutdown.setUpdateFormTimer(false);

                switch (selectedMenu)
                {
                    case MENU.OVERVIEW:
                        this.menuPanel.Controls.Add(mOverview);
                        mOverview.setUpdateFormTimer(true);
                        mOverview.Show();
                        break;
                    case MENU.KICKER:
                        this.menuPanel.Controls.Add(mKicker);
                        mKicker.setUpdateFormTimer(true);
                        mKicker.Show();
                        break;
                    case MENU.CAMERA:
                        this.menuPanel.Controls.Add(mCamera);
                        mCamera.setUpdateFormTimer(true);
                        mCamera.Show();
                        break;
                    case MENU.COMPASS:
                        this.menuPanel.Controls.Add(mCompass);
                        mCompass.setUpdateFormTimer(true);
                        mCompass.Show();
                        break;
                    case MENU.LINE:
                        this.menuPanel.Controls.Add(mLine);
                        mLine.setUpdateFormTimer(true);
                        mLine.Show();
                        break;
                    case MENU.SETTINGS:
                        this.menuPanel.Controls.Add(mSettings);
                        mSettings.setUpdateFormTimer(true);
                        mSettings.Show();
                        break;
                    case MENU.SHUTDOWN:
                        this.menuPanel.Controls.Add(mShutdown);
                        mShutdown.setUpdateFormTimer(true);
                        mShutdown.Show();
                        break;
                    default:
                        break;
                }

                displayedMenu = selectedMenu;
            }
            
            if(((DateTime.Now.Ticks - lastTx) / 10000) >= 200)
            {
                lastTx = DateTime.Now.Ticks;

                byte[] txBuf = new byte[2];

                txBuf[0] = (byte)(128 + (sharedData.startAction ? 4 : 0) + (sharedData.setLineCalibration ? 2 : 0) + (sharedData.ledState ? 1 : 0));
                txBuf[1] = sharedData.newLineCalibration;

                serialComm.Write(txBuf, 0, 2);

                // reset single use variables
                sharedData.setLineCalibration = false;
                sharedData.startAction = false;
            }
        }

        private void menuListBox_Click(object sender, EventArgs e)
        {
            selectedMenu = (MENU)menuListBox.SelectedIndex;
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            serialComm.Close();
        }
    }
}
