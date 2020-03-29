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
        const byte SYNC = 0x55;
        const byte ESC = 0xAA;
        const byte ESC_ESC = 0x00;
        const byte ESC_SYNC = 0x01;

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

        bool frameStarted = false;
        bool escDetected = false;
        byte[] rxMsg = new byte[32];
        byte[] txMsg = new byte[32];
        byte rxByteCnt = 0;
        byte txByteCnt = 0;
        byte rxMsgLen = 0;
        byte rxChecksum = 0;
        byte txChecksum = 0;

        long lastTx = 0;
        long lastRx = 0;
        long rxInterval = 0;

        public enum dataRequest_t
        {
            DR_BATTERY_P = 0x01,
            DR_COMPASS,
            DR_LINE
        }

        public enum executionCommand_t
        {
            EC_UPDATE_LED = 0x80,
            EC_UPDATE_LINE_CALIBRATION,
            EC_ACTION,
        }

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

                    // detect SYNC character to define frame start
                    if (newByte == SYNC)
                    {
                        if (frameStarted)
                        {
                            //frameError++;
                        }

                        // start a new frame
                        frameStarted = true;
                        rxByteCnt = 0;
                    }

                    // detect ESC character
                    if (newByte == ESC)
                    {
                        escDetected = true;
                    }
                    else
                    {
                        // replace ESC sequence with correct byte
                        if (escDetected)
                        {
                            escDetected = false;

                            switch (newByte)
                            {
                                case ESC_ESC:
                                    newByte = ESC;
                                    break;
                                case ESC_SYNC:
                                    newByte = SYNC;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (frameStarted && !escDetected)
                    {
                        switch (rxByteCnt)
                        {
                            case 0: // SYNC byte
                                break;
                            case 1:
                                rxMsgLen = newByte;
                                rxChecksum = 0;
                                break;
                            default:
                                if (rxMsgLen > 0)
                                {
                                    rxMsg[rxByteCnt - 2] = newByte;
                                    rxChecksum += newByte;
                                    rxMsgLen--;
                                }
                                else
                                {
                                    // if message is error free then call process handler
                                    if (rxChecksum == newByte)
                                    {
                                        processRxPacket();
                                    }
                                    else
                                    {
                                        //checksumError++;
                                    }

                                    frameStarted = false;
                                    escDetected = false;
                                }
                                break;
                        }

                        rxByteCnt++;
                    }
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

                txMsg[0] = SYNC;
                txByteCnt = 1;
                addByteToTxBuffer(0x05); // message length spacing
                txChecksum = 0;
                addByteToTxBuffer((byte)executionCommand_t.EC_UPDATE_LED);
                addByteToTxBuffer((byte)(sharedData.ledState ? 1 : 0));
                addByteToTxBuffer((byte)dataRequest_t.DR_BATTERY_P);
                addByteToTxBuffer((byte)dataRequest_t.DR_COMPASS);
                addByteToTxBuffer((byte)dataRequest_t.DR_LINE);
                //txMsg[1] = (byte)(txByteCnt - 2);
                addByteToTxBuffer(txChecksum);
                serialComm.Write(txMsg, 0, txByteCnt);
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

        void addByteToTxBuffer(byte byteToAdd)
        {
            txChecksum += byteToAdd;

            switch (byteToAdd)
            {
                case SYNC:
                    txMsg[txByteCnt++] = ESC;
                    txMsg[txByteCnt++] = ESC_SYNC;
                    break;
                case ESC:
                    txMsg[txByteCnt++] = ESC;
                    txMsg[txByteCnt++] = ESC_ESC;
                    break;
                default:
                    txMsg[txByteCnt++] = byteToAdd;
                    break;
            }
        }

        private void processRxPacket()
        {
            byte processedBytes = 0;

            while (processedBytes < (rxByteCnt - 2))
            {
                if (rxMsg[processedBytes] <= 0x7f) // data request answer
                {
                    switch((dataRequest_t)rxMsg[processedBytes])
                    {
                        case dataRequest_t.DR_BATTERY_P:
                            sharedData.batteryPercentage = rxMsg[++processedBytes];
                            break;
                        case dataRequest_t.DR_COMPASS:
                            ushort absoluteCompassTmp = rxMsg[++processedBytes];
                            sharedData.absoluteCompass = ((float)((rxMsg[++processedBytes] << 8) + absoluteCompassTmp) / 10.0f);
                            ushort relativeCompassTmp = rxMsg[++processedBytes];
                            sharedData.relativeCompass = ((float)(((rxMsg[++processedBytes] << 8) + relativeCompassTmp) - 1800) / 10.0f);
                            break;
                        case dataRequest_t.DR_LINE:
                            sharedData.lineSegment[0] = ((rxMsg[++processedBytes] & 0x01) > 0 ? true : false);
                            sharedData.lineSegment[1] = ((rxMsg[processedBytes] & 0x02) > 0 ? true : false);
                            sharedData.lineSegment[2] = ((rxMsg[processedBytes] & 0x04) > 0 ? true : false);
                            sharedData.lineSegment[3] = ((rxMsg[processedBytes] & 0x08) > 0 ? true : false);
                            sharedData.lineSegment[4] = ((rxMsg[processedBytes] & 0x10) > 0 ? true : false);
                            sharedData.lineSegment[5] = ((rxMsg[processedBytes] & 0x20) > 0 ? true : false);
                            sharedData.lineSegment[6] = ((rxMsg[processedBytes] & 0x40) > 0 ? true : false);
                            sharedData.lineSegment[7] = ((rxMsg[processedBytes] & 0x80) > 0 ? true : false);
                            sharedData.lineSegment[8] = ((rxMsg[++processedBytes] & 0x01) > 0 ? true : false);
                            sharedData.lineSegment[9] = ((rxMsg[processedBytes] & 0x02) > 0 ? true : false);
                            sharedData.lineSegment[10] = ((rxMsg[processedBytes] & 0x04) > 0 ? true : false);
                            sharedData.lineSegment[11] = ((rxMsg[processedBytes] & 0x08) > 0 ? true : false);
                            break;
                        default:
                            break;
                    }
                }
                else {}

                processedBytes++;
            }
        }
    }
}
