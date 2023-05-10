/* 1.藍燈狀態鮑率38400->Loadnew成功後鮑率57600->SetBuadRate115200成功後鮑率115200
 * 
 * 2.灰色:未進入Load Mode 
 *   藍色:Loadnew成功且進入偵測模式 
 *   黃色:燒錄中 
 *   綠色:燒錄完成
 *   紅色:燒錄NG
 *   
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;//Delay

using System.IO.Ports;

namespace LoadKeyApp
{
    
    public partial class Form1 : Form
    {
        //四個線程名稱
        LoadNew LoadNew1;
        LoadNew LoadNew2;
        LoadNew LoadNew3;
        LoadNew LoadNew4;

        public VersionChange VersionChangeWindow = new VersionChange();
        
        //版本變更參數
        private string TitleVersion = "FEP TS2000 Writer_V1.4_GetRC531",ModeStatus_Str= "含AP模式",BurnCodeRate_Str="、燒錄鮑率:115200", APBaudRate_Str = "、AP鮑率:57600", AutoErase_Str = "";

        private bool EraseMode_bool = false,AutoEraseMode_bool=false;

        /*ActiveBtnManage()參數*/
        private int All_StartLoadKey = 0, All_EraseKey = 1,BtnsDisable=2,BtnsEnable=3,LoadKeyFormat=4,EraseFormat=5,AutoEraseFormat=6;
        int AllStartDelayTime = 1000;

        public Form1()
        {
            InitializeComponent();
            
            Form.CheckForIllegalCrossThreadCalls = false;

            //各線程參數設定
            LoadNew1 = new LoadNew(file_box,TreadReadyStatusCount_Lab, AllInOne_Btn, Start_BT1, Reboot_BT1, DISC1, ComPort_CB1, serialPort1, RTB1, openFile1,ProgressBar1,  Color_Lab1, Status_Lab1);
            LoadNew2 = new LoadNew(file_box,TreadReadyStatusCount_Lab, AllInOne_Btn, Start_BT2, Reboot_BT2, DISC2, ComPort_CB2, serialPort2, RTB2, openFile1, ProgressBar2, Color_Lab2, Status_Lab2);
            LoadNew3 = new LoadNew(file_box,TreadReadyStatusCount_Lab, AllInOne_Btn, Start_BT3, Reboot_BT3, DISC3, ComPort_CB3, serialPort3, RTB3, openFile1, ProgressBar3, Color_Lab3, Status_Lab3);
            LoadNew4 = new LoadNew(file_box,TreadReadyStatusCount_Lab, AllInOne_Btn, Start_BT4, Reboot_BT4, DISC4, ComPort_CB4, serialPort4, RTB4, openFile1, ProgressBar4, Color_Lab4, Status_Lab4);

            //使各線程共同參考的參數
            DelayTimeSet.Text = Convert.ToString(AllStartDelayTime);

            Start_BT1.UseVisualStyleBackColor = true;

            //設定標題顯示
            this.Text = TitleVersion;

            StatusTitle.Text = ModeStatus_Str+ BurnCodeRate_Str+ APBaudRate_Str;
            /*
             *  設定模式初始狀態:
             *  鮑率:57600
             *  一般燒錄模式
             *  燒錄速率轉為115200
             *  
             *  
             * 
             */

            BaudSetTo57600.Checked = true;
            NormalMode.Checked = true;
            BurnCodeSpeed_Fast.Checked = true;

            //自動按下後觸發該元件

            RTCtestMode.PerformClick();
            AutoErase_Mode.PerformClick();
            NoneAppMode.PerformClick();
            GetRC531No.PerformClick();
        }

        //COMPort下拉觸發事件
        private void ComPort_CB1_DropDown(object sender, EventArgs e)
        {
            ComPort_CB1.Text = "";
            ComPort_CB1.Items.Clear();
            ComPort_CB1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());            
            ComPort_CB1.Items.Remove(ComPort_CB2.Text);
            ComPort_CB1.Items.Remove(ComPort_CB3.Text);
            ComPort_CB1.Items.Remove(ComPort_CB4.Text);
            
        }
        private void ComPort_CB2_DropDown(object sender, EventArgs e)
        {
            ComPort_CB2.Text = "";
            ComPort_CB2.Items.Clear();
            ComPort_CB2.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            ComPort_CB2.Items.Remove(ComPort_CB1.Text);
            ComPort_CB2.Items.Remove(ComPort_CB3.Text);
            ComPort_CB2.Items.Remove(ComPort_CB4.Text);
            RTB2.Text = "";
        }
        private void ComPort_CB3_DropDown(object sender, EventArgs e)
        {
            ComPort_CB3.Text = "";
            ComPort_CB3.Items.Clear();
            ComPort_CB3.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            ComPort_CB3.Items.Remove(ComPort_CB1.Text);
            ComPort_CB3.Items.Remove(ComPort_CB2.Text);
            ComPort_CB3.Items.Remove(ComPort_CB4.Text);
            RTB3.Text = "";
        }
        private void ComPort_CB4_DropDown(object sender, EventArgs e)
        {
            ComPort_CB4.Text = "";
            ComPort_CB4.Items.Clear();
            ComPort_CB4.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            ComPort_CB4.Items.Remove(ComPort_CB1.Text);
            ComPort_CB4.Items.Remove(ComPort_CB2.Text);
            ComPort_CB4.Items.Remove(ComPort_CB3.Text);
            RTB4.Text = "";
        }
        
        //COMPort文字變更觸發事件
        private void ComPort_CB1_TextChanged(object sender, EventArgs e)
        {
            if (ComPort_CB1.Text != "")
            {
                try
                {
                    if (serialPort1.IsOpen == true)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.PortName = ComPort_CB1.Text;
                    serialPort1.Open();
                    DISC1.Enabled = true;
                    ComPort_CB1.Enabled = false;
                    LoadNew1.ThreadStart();
                }
                catch { MessageBox.Show(this, "無法開啟通訊埠. 請確認是否被其它應用程式開啟, 或是通訊埠無效.", "Serial Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
               
            }
        }
        private void ComPort_CB2_TextChanged(object sender, EventArgs e)
        {
            try {
                if (ComPort_CB2.Text != "")
                {
                    if (serialPort2.IsOpen == true)
                    {
                        serialPort2.Close();
                    }
                    serialPort2.PortName = ComPort_CB2.Text;
                    serialPort2.Open();
                    DISC2.Enabled = true;
                    ComPort_CB2.Enabled = false;
                    LoadNew2.ThreadStart();
                }
            }
            catch { MessageBox.Show(this, "無法開啟通訊埠. 請確認是否被其它應用程式開啟, 或是通訊埠無效.", "Serial Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            
        }
        private void ComPort_CB3_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (ComPort_CB3.Text != "")
                {
                    if (serialPort3.IsOpen == true)
                    {
                        serialPort3.Close();
                    }
                    serialPort3.PortName = ComPort_CB3.Text;
                    serialPort3.Open();
                    ComPort_CB3.Enabled = false;
                    DISC3.Enabled = true;
                    LoadNew3.ThreadStart();
                }
            }
            catch { MessageBox.Show(this, "無法開啟通訊埠. 請確認是否被其它應用程式開啟, 或是通訊埠無效.", "Serial Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }
        private void ComPort_CB4_TextChanged(object sender, EventArgs e)
        {
            try {
                if (ComPort_CB4.Text != "")
                {
                    if (serialPort4.IsOpen == true)
                    {
                        serialPort4.Close();
                    }
                    serialPort4.PortName = ComPort_CB4.Text;
                    serialPort4.Open();
                    ComPort_CB4.Enabled = false;
                    DISC4.Enabled = true;
                    LoadNew4.ThreadStart();
                }
            }
            catch { MessageBox.Show(this, "無法開啟通訊埠. 請確認是否被其它應用程式開啟, 或是通訊埠無效.", "Serial Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            
        }
        
        //訊息欄文字變更觸發事件
        private void RTB1_TextChanged(object sender, EventArgs e)
        {
            if (Scroll_CB1.Checked == true)
            {
                RTB1.SelectionStart = RTB1.Text.Length;
                RTB1.ScrollToCaret();
            }
        }
        private void RTB2_TextChanged(object sender, EventArgs e)
        {
            if (Scroll_CB2.Checked == true)
            {
                RTB2.SelectionStart = RTB2.Text.Length;
                RTB2.ScrollToCaret();
            }
        }
        private void RTB3_TextChanged(object sender, EventArgs e)
        {
            if (Scroll_CB3.Checked == true)
            {
                RTB3.SelectionStart = RTB3.Text.Length;
                RTB3.ScrollToCaret();

            }
        }
        private void RTB4_TextChanged(object sender, EventArgs e)
        {
            if (Scroll_CB4.Checked == true)
            {
                RTB4.SelectionStart = RTB4.Text.Length;
                RTB4.ScrollToCaret();
            }
        }

        private void Clear_BT1_Click(object sender, EventArgs e)
        {
            RTB1.Clear();
        }
        private void Clear_BT2_Click(object sender, EventArgs e)
        {
            RTB2.Clear();
        }
        private void Clear_BT3_Click(object sender, EventArgs e)
        {
            RTB3.Clear();
        }
        private void Clear_BT4_Click(object sender, EventArgs e)
        {
            RTB4.Clear();
        }

        //啟動鍵
        private void Start_BT1_Click(object sender, EventArgs e)
        {
            AllInOne_Btn.Enabled = false;

            if (AutoEraseMode_bool && Start_BT1.Text=="Stop")
            {               
                LoadNew1.StartLoadKey();
            }
            else if (EraseMode_bool || AutoEraseMode_bool)
            { 
            LoadNew1.ResetKEK();
            }
            else
            {
                LoadNew1.StartLoadKey();
            }

        }
        private void Start_BT2_Click(object sender, EventArgs e)
        {
            AllInOne_Btn.Enabled = false;
            if (AutoEraseMode_bool && Start_BT2.Text == "Stop")
            {                
                LoadNew2.StartLoadKey();
            }
            else if (EraseMode_bool || AutoEraseMode_bool)
            {
                LoadNew2.ResetKEK();
            }
            else
            {
                LoadNew2.StartLoadKey();
            }

        }
        private void Start_BT3_Click(object sender, EventArgs e)
        {
            AllInOne_Btn.Enabled = false;

            if (AutoEraseMode_bool && Start_BT3.Text == "Stop")
            {                
                LoadNew3.StartLoadKey();
            }
            else if (EraseMode_bool || AutoEraseMode_bool)
            {
                LoadNew3.ResetKEK();
            }
            else
            {
                LoadNew3.StartLoadKey();
            }

        }
        private void Start_BT4_Click(object sender, EventArgs e)
        {
            AllInOne_Btn.Enabled = false;

            if (AutoEraseMode_bool && Start_BT4.Text == "Stop")
            {                
                LoadNew4.StartLoadKey();
            }
            else if (EraseMode_bool || AutoEraseMode_bool)
            {
                LoadNew4.ResetKEK();
            }
            else
            {
                LoadNew4.StartLoadKey();
            }
        }

        //一鍵啟動鍵
        private void AllInOne_Btn_Click(object sender, EventArgs e)
        {
            ActiveBtnManage(BtnsDisable);
            ActiveBtnManage(BtnsEnable);

            if (EraseMode_bool || AutoEraseMode_bool)
            {
                ActiveBtnManage(All_EraseKey);
            }
            else
            {
                ActiveBtnManage(All_StartLoadKey);
            }
        }


        //LN後的重啟鍵
        private void Reboot_BT1_Click(object sender, EventArgs e)
        {
            LoadNew1.RebootInLoadNew();
        }
        private void Reboot_BT2_Click(object sender, EventArgs e)
        {
            LoadNew2.RebootInLoadNew();
        }
        private void Reboot_BT3_Click(object sender, EventArgs e)
        {
            LoadNew3.RebootInLoadNew();
        }
        private void Reboot_BT4_Click(object sender, EventArgs e)
        {
            LoadNew4.RebootInLoadNew();
        }

        //連線中斷鍵
        private void DISC1_Click(object sender, EventArgs e)
        {
            if (LoadNew1.LoadStatus == 12)
            {
                TreadReadyStatusCount_Lab.Text = Convert.ToString(int.Parse(TreadReadyStatusCount_Lab.Text) - 1);
            }
            LoadNew1.initial();
            RTB1.Text = "COM port已關閉";
            
                
        }
        private void DISC2_Click(object sender, EventArgs e)
        {
            if (LoadNew2.LoadStatus == 12)
            {
                TreadReadyStatusCount_Lab.Text = Convert.ToString(int.Parse(TreadReadyStatusCount_Lab.Text) - 1);
            }
            LoadNew2.initial();
            RTB2.Text = "COM port已關閉";
            

            
        }
        private void DISC3_Click(object sender, EventArgs e)
        {
            if (LoadNew3.LoadStatus == 12)
            {
                TreadReadyStatusCount_Lab.Text = Convert.ToString(int.Parse(TreadReadyStatusCount_Lab.Text) - 1);
            }
            LoadNew3.initial();
            RTB3.Text = "COM port已關閉";
            
            
        }
        private void DISC4_Click(object sender, EventArgs e)
        {
            if (LoadNew4.LoadStatus == 12)
            {
                TreadReadyStatusCount_Lab.Text = Convert.ToString(int.Parse(TreadReadyStatusCount_Lab.Text) - 1);
            }
            LoadNew4.initial();
            RTB4.Text = "COM port已關閉";
            
            
        }

        private void Browse_BT1_Click(object sender, EventArgs e)
        {
            ChangeToNormalMode();

            openFile1.Title = "請選擇資料夾";
            openFile1.ShowDialog();

            LoadNew1.EncodingType = 65001;
            LoadNew2.EncodingType = 65001;
            LoadNew3.EncodingType = 65001;
            LoadNew4.EncodingType = 65001;

            LoadNew1.ChangEncoding = false;
            LoadNew2.ChangEncoding = false;
            LoadNew3.ChangEncoding = false;
            LoadNew4.ChangEncoding = false;


        }
        
        private void openFile1_FileOk(object sender, CancelEventArgs e)
        {

            file_box.Text = openFile1.FileName + Environment.NewLine;
            ActiveBtnManage(BtnsEnable);

            if (!IsAPMode(openFile1.FileName))
            {
                ChangeToNoneAppMode();
            }
            

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要關閉程式嗎？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;  //關閉視窗

                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;    //取消關閉
            }
        }

        private void BaudSetTo57600_Click(object sender, EventArgs e)
        {
            if (LoadNew1.LoadStatus == 0 && LoadNew2.LoadStatus == 0 && LoadNew3.LoadStatus == 0 && LoadNew4.LoadStatus == 0)
            {
                APBaudRate_Str = "、AP鮑率:57600";
                
                StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;

                BaudSetTo57600.Checked = true;
                BaudSetTo115200.Checked = false;
                LoadNew1.APBuadRate = 57600;
                LoadNew2.APBuadRate = 57600;
                LoadNew3.APBuadRate = 57600;
                LoadNew4.APBuadRate = 57600;
            }                
        }

        private void BaudSetTo115200_Click(object sender, EventArgs e)
        {
            if (LoadNew1.LoadStatus == 0 && LoadNew2.LoadStatus == 0 && LoadNew3.LoadStatus == 0 && LoadNew4.LoadStatus == 0 )
            {
                APBaudRate_Str = "、AP鮑率:115200";
                
                StatusTitle.Text = AutoErase_Str + ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;
                BaudSetTo57600.Checked = false;
                BaudSetTo115200.Checked = true;
                LoadNew1.APBuadRate = 115200;
                LoadNew2.APBuadRate = 115200;
                LoadNew3.APBuadRate = 115200;
                LoadNew4.APBuadRate = 115200;
            }
            
        }

        private void FirstErase_Click(object sender, EventArgs e)
        {
            LoadNew1.ResetKEK();

        }
        private void Erase2_Click(object sender, EventArgs e)
        {
            LoadNew2.ResetKEK();
        }

        private void Erase3_Click(object sender, EventArgs e)
        {
            LoadNew3.ResetKEK();
        }

        private void Erase4_Click(object sender, EventArgs e)
        {
            LoadNew4.ResetKEK();
        }
        private void AllErase_Click(object sender, EventArgs e)
        {
            ActiveBtnManage(All_EraseKey);
        }
        private void Help_VersionUpdate_Click(object sender, EventArgs e)
        {
            VersionChange VersionChangeWindow = new VersionChange();
            VersionChangeWindow.Show();
        }

        private void NormalMode_Click(object sender, EventArgs e)
        {
            ModeStatus_Str = "含AP模式";

            
            StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;

            AutoErase_Mode.Enabled = true;

            /****按鈕外觀變更****/
            if (!AutoEraseMode_bool)
            {
                ActiveBtnManage(LoadKeyFormat);
            }
            else
            {
                ActiveBtnManage(AutoEraseFormat);
            }            
            /*------------------*/


            NormalMode.Checked = true;
            NoneAppMode.Checked = false;
            EraseMode.Checked = false;

            ActiveBtnManage(BtnsDisable);

            if (openFile1.FileName != "")
            {
                ActiveBtnManage(BtnsEnable);
            }


            LoadNew1.NoneReaderAppMode = false;
            LoadNew2.NoneReaderAppMode = false;
            LoadNew3.NoneReaderAppMode = false;
            LoadNew4.NoneReaderAppMode = false;

            EraseMode_bool = false;
            LoadNew1.EraseMode_bool = false;
            LoadNew2.EraseMode_bool = false;
            LoadNew3.EraseMode_bool = false;
            LoadNew4.EraseMode_bool = false;

        }

        private void NoneAppMode_Click(object sender, EventArgs e)
        {
           
            ModeStatus_Str = "無AP模式";
            
            StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;
            AutoErase_Mode.Enabled = true;

            /****按鈕外觀變更****/
            if (!AutoEraseMode_bool)
            {
                ActiveBtnManage(LoadKeyFormat);
            }
            else
            {
                ActiveBtnManage(AutoEraseFormat);
            }
            /*------------------*/


            NormalMode.Checked = false;
            NoneAppMode.Checked = true;
            EraseMode.Checked = false;

            LoadNew1.NoneReaderAppMode = true;
            LoadNew2.NoneReaderAppMode = true;
            LoadNew3.NoneReaderAppMode = true;
            LoadNew4.NoneReaderAppMode = true;

            ActiveBtnManage(BtnsDisable);

            if (openFile1.FileName != "") 
            {
                ActiveBtnManage(BtnsEnable);
            }


            EraseMode_bool = false;
            LoadNew1.EraseMode_bool = false;
            LoadNew2.EraseMode_bool = false;
            LoadNew3.EraseMode_bool = false;
            LoadNew4.EraseMode_bool = false;

        }

        private void DelayTimeSet_TextChanged(object sender, EventArgs e)
        {
            AllStartDelayTime = int.Parse(DelayTimeSet.Text);
        }

        private void APVersionGet1_Click(object sender, EventArgs e)
        {
            if (LoadNew1.LoadStatus == 0)
            { 
            LoadNew1.GetAPVersion();
            }
            
        }

        private void APVersionGet2_Click(object sender, EventArgs e)
        {
            if (LoadNew2.LoadStatus == 0)
            {
                LoadNew2.GetAPVersion();
            }
            
        }

        private void APVersionGet3_Click(object sender, EventArgs e)
        {
            if (LoadNew3.LoadStatus == 0)
            {
LoadNew3.GetAPVersion();
            }
            
        }

        private void APVersionGet4_Click(object sender, EventArgs e)
        {
            if (LoadNew4.LoadStatus == 0)
            {
LoadNew4.GetAPVersion();
            }
            
        }


        private void EraseMode_Click(object sender, EventArgs e)
        {
            AutoErase_Mode.Enabled = false;
            ModeStatus_Str = "清Key模式";
            
            StatusTitle.Text = ModeStatus_Str ;

            ActiveBtnManage(EraseFormat);

            ActiveBtnManage(BtnsDisable);

            ActiveBtnManage(BtnsEnable);

            NormalMode.Checked = false;
            NoneAppMode.Checked = false;
            EraseMode.Checked = true;

            EraseMode_bool = true;
            LoadNew1.EraseMode_bool = true;
            LoadNew2.EraseMode_bool = true;
            LoadNew3.EraseMode_bool = true;
            LoadNew4.EraseMode_bool = true;

        }

        private void file_box_TextChanged(object sender, EventArgs e)
        {
            if (file_box.Text == "")
            {
                ActiveBtnManage(BtnsDisable);
            }
        }

        private void AllAPReboot_Btn_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate=LoadNew1.APBuadRate;
            serialPort2.BaudRate=LoadNew2.APBuadRate;
            serialPort3.BaudRate=LoadNew3.APBuadRate;
            serialPort4.BaudRate=LoadNew4.APBuadRate;

            LoadNew1.LoadStatus = 14;
            LoadNew2.LoadStatus = 14;
            LoadNew3.LoadStatus = 14;
            LoadNew4.LoadStatus = 14;
        }

        private void 卡機時間確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RTCtestMode.Checked)
            {
                RTCtestMode.Checked = false;

                LoadNew1.RTCCheckMode = false;
                LoadNew2.RTCCheckMode = false;
                LoadNew3.RTCCheckMode = false;
                LoadNew4.RTCCheckMode = false;
            }
            else
            {
                RTCtestMode.Checked = true;

                LoadNew1.RTCCheckMode = true;
                LoadNew2.RTCCheckMode = true;
                LoadNew3.RTCCheckMode = true;
                LoadNew4.RTCCheckMode = true;
            }
        }

        private void 射頻IC序號讀取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetRC531No.Checked)
            {
                GetRC531No.Checked = false;

                LoadNew1.CheckRC531NoMode = false;
                LoadNew2.CheckRC531NoMode = false;
                LoadNew3.CheckRC531NoMode = false;
                LoadNew4.CheckRC531NoMode = false;
            }
            else
            {
                GetRC531No.Checked = true;

                LoadNew1.CheckRC531NoMode = true;
                LoadNew2.CheckRC531NoMode = true;
                LoadNew3.CheckRC531NoMode = true;
                LoadNew4.CheckRC531NoMode = true;
            }
        }

        private void AutoErase_Mode_Click(object sender, EventArgs e)
        {
            if (AutoErase_Mode.Checked)
            {
                EraseMode.Enabled = true;
                AutoErase_Mode.Checked = false;

                AutoEraseMode_bool = false;
                LoadNew1.AutoEraseMode_bool = false;
                LoadNew2.AutoEraseMode_bool = false;
                LoadNew3.AutoEraseMode_bool = false;
                LoadNew4.AutoEraseMode_bool = false;

                AutoErase_Str = "";

                
                StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;

                ActiveBtnManage(LoadKeyFormat);

                ActiveBtnManage(BtnsDisable);

                if (openFile1.FileName != "")
                {
                    ActiveBtnManage(BtnsEnable);
                }


            }
            else
            {
                EraseMode.Enabled = false;
                AutoErase_Mode.Checked = true;

                AutoEraseMode_bool = true;
                LoadNew1.AutoEraseMode_bool = true;
                LoadNew2.AutoEraseMode_bool = true;
                LoadNew3.AutoEraseMode_bool = true;
                LoadNew4.AutoEraseMode_bool = true;

                AutoErase_Str = "AutoErase、";
                
                StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;


                ActiveBtnManage(AutoEraseFormat);

                ActiveBtnManage(BtnsDisable);

                if (openFile1.FileName != "")
                {
                    ActiveBtnManage(BtnsEnable);
                }


            }

        }

        private void BurnCodeSpeed_Slow_Click(object sender, EventArgs e)
        {
            BurnCodeRate_Str = "、燒錄鮑率:57600";            
            StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;

            BurnCodeSpeed_Fast.Checked = false;
            BurnCodeSpeed_Slow.Checked = true;

            LoadNew1.BurnSlow = true;
            LoadNew2.BurnSlow = true;
            LoadNew3.BurnSlow = true;
            LoadNew4.BurnSlow = true;
        }

        private void BurnCodeSpeed_Fast_Click(object sender, EventArgs e)
        {

            BurnCodeRate_Str = "、燒錄鮑率:115200";            
            StatusTitle.Text = AutoErase_Str+ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;

            BurnCodeSpeed_Fast.Checked = true;
            BurnCodeSpeed_Slow.Checked = false;


            LoadNew1.BurnSlow = false;
            LoadNew2.BurnSlow = false;
            LoadNew3.BurnSlow = false;
            LoadNew4.BurnSlow = false;
        }

        private void AP_Reboot_1_Click(object sender, EventArgs e)
        {
            if (LoadNew1.LoadStatus == 0)
            {
                LoadNew1.APReboot();
            }
            
        }

        private void AP_Reboot_2_Click(object sender, EventArgs e)
        {
            if (LoadNew2.LoadStatus == 0)
            {
                LoadNew2.APReboot();
            }           
        }

        private void AP_Reboot_3_Click(object sender, EventArgs e)
        {
            if (LoadNew3.LoadStatus == 0)
            {
                LoadNew3.APReboot();
            }
        }

        private void AP_Reboot_4_Click(object sender, EventArgs e)
        {
            if (LoadNew4.LoadStatus == 0)
            {
                LoadNew4.APReboot();
            }
        }


        /*How To Use The Btn
         * Case 0:所有通道執行錄碼
         * Case 1:所有通道執行Erase Key
         * Case 2:執行鈕系列不可用
         * Case 3:執行鈕系列Enable
         * Case 4:按鈕變更為正常模式外觀
         * Csee 5:按鈕變更為Erase模式外觀
         * Csee 6:按鈕變更為AutoErase模式外觀
         */

        public void ActiveBtnManage(int HTUTBtn)
        {

            switch (HTUTBtn)
            {
                case 0:
                    {
                        if (LoadNew1.LoadStatus == 12)
                        {
                            LoadNew1.StartLoadKey();
                        }
                        Task.Delay(AllStartDelayTime).Wait();
                        if (LoadNew2.LoadStatus == 12)
                        {
                            LoadNew2.StartLoadKey();
                        }
                        Task.Delay(AllStartDelayTime).Wait();
                        if (LoadNew3.LoadStatus == 12)
                        {
                            LoadNew3.StartLoadKey();
                        }
                        Task.Delay(AllStartDelayTime).Wait();
                        if (LoadNew4.LoadStatus == 12)
                        {
                            LoadNew4.StartLoadKey();
                        }
                        break;
                    }

                case 1:
                    {
                        if (LoadNew1.LoadStatus == 12)
                        {
                            LoadNew1.ResetKEK();
                        }
                        Task.Delay(AllStartDelayTime).Wait();
                        if (LoadNew2.LoadStatus == 12)
                        {
                            LoadNew2.ResetKEK();
                        }
                        Task.Delay(AllStartDelayTime).Wait();
                        if (LoadNew3.LoadStatus == 12)
                        {
                            LoadNew3.ResetKEK();
                        }
                        Task.Delay(AllStartDelayTime).Wait(); ;
                        if (LoadNew4.LoadStatus == 12)
                        {
                            LoadNew4.ResetKEK();
                        }
                        break;
                    }

                case 2:
                    {
                        Start_BT1.Enabled = false;
                        Start_BT2.Enabled = false;
                        Start_BT3.Enabled = false;
                        Start_BT4.Enabled = false;
                        AllInOne_Btn.Enabled = false;
                        break;
                    }

                case 3:
                    {
                        if (LoadNew1.LoadStatus == 12)
                        {
                            Start_BT1.Enabled = true;
                        }
                        if (LoadNew2.LoadStatus == 12)
                        {
                            Start_BT2.Enabled = true;
                        }
                        if (LoadNew3.LoadStatus == 12)
                        {
                            Start_BT3.Enabled = true;
                        }
                        if (LoadNew4.LoadStatus == 12)
                        {
                            Start_BT4.Enabled = true;
                        }
                        if (int.Parse(TreadReadyStatusCount_Lab.Text) >= 2)
                        {
                            AllInOne_Btn.Enabled = true;
                        }
                        break;
                    }

                case 4:
                    {
                        Start_BT1.UseVisualStyleBackColor = true;
                        Start_BT2.UseVisualStyleBackColor = true;
                        Start_BT3.UseVisualStyleBackColor = true;
                        Start_BT4.UseVisualStyleBackColor = true;
                        AllInOne_Btn.UseVisualStyleBackColor = true;

                        Start_BT1.Text = "Start";
                        Start_BT2.Text = "Start";
                        Start_BT3.Text = "Start";
                        Start_BT4.Text = "Start";
                        AllInOne_Btn.Text = "一鍵 Start";
                        break;
                    }
                case 5:
                    {
                        Start_BT1.BackColor = ColorTranslator.FromHtml("#80FFFF");
                        Start_BT2.BackColor = ColorTranslator.FromHtml("#80FFFF");
                        Start_BT3.BackColor = ColorTranslator.FromHtml("#80FFFF");
                        Start_BT4.BackColor = ColorTranslator.FromHtml("#80FFFF");
                        AllInOne_Btn.BackColor = ColorTranslator.FromHtml("#80FFFF");

                        Start_BT1.Text = "Erase";
                        Start_BT2.Text = "Erase";
                        Start_BT3.Text = "Erase";
                        Start_BT4.Text = "Erase";
                        AllInOne_Btn.Text = "一鍵 Erase";
                        break;
                    }


                case 6:
                    {
                        string BtnColor = "#FFFFAA";
                        Start_BT1.BackColor = ColorTranslator.FromHtml(BtnColor);
                        Start_BT2.BackColor = ColorTranslator.FromHtml(BtnColor);
                        Start_BT3.BackColor = ColorTranslator.FromHtml(BtnColor);
                        Start_BT4.BackColor = ColorTranslator.FromHtml(BtnColor);
                        AllInOne_Btn.BackColor = ColorTranslator.FromHtml(BtnColor);

                        Start_BT1.Text = "Erase+Start";
                        Start_BT2.Text = "Erase+Start";
                        Start_BT3.Text = "Erase+Start";
                        Start_BT4.Text = "Erase+Start";
                        AllInOne_Btn.Text = "一鍵 Erase+Start";
                        break;
                    }

                default:

                    break;
            }
        }

        private void ChangeToNormalMode()
        {
            ModeStatus_Str = "含AP模式";


            StatusTitle.Text = AutoErase_Str + ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;

            AutoErase_Mode.Enabled = true;

            /****按鈕外觀變更****/
            if (!AutoEraseMode_bool)
            {
                ActiveBtnManage(LoadKeyFormat);
            }
            else
            {
                ActiveBtnManage(AutoEraseFormat);
            }
            /*------------------*/


            ActiveBtnManage(BtnsDisable);

            if (openFile1.FileName != "")
            {
                ActiveBtnManage(BtnsEnable);
            }


            LoadNew1.NoneReaderAppMode = false;
            LoadNew2.NoneReaderAppMode = false;
            LoadNew3.NoneReaderAppMode = false;
            LoadNew4.NoneReaderAppMode = false;

            EraseMode_bool = false;
            LoadNew1.EraseMode_bool = false;
            LoadNew2.EraseMode_bool = false;
            LoadNew3.EraseMode_bool = false;
            LoadNew4.EraseMode_bool = false;

        }

        private void ChangeToNoneAppMode()
        {

            ModeStatus_Str = "無AP模式";

            StatusTitle.Text = AutoErase_Str + ModeStatus_Str + BurnCodeRate_Str + APBaudRate_Str;
            AutoErase_Mode.Enabled = true;

            /****按鈕外觀變更****/
            if (!AutoEraseMode_bool)
            {
                ActiveBtnManage(LoadKeyFormat);
            }
            else
            {
                ActiveBtnManage(AutoEraseFormat);
            }
            /*------------------*/


            LoadNew1.NoneReaderAppMode = true;
            LoadNew2.NoneReaderAppMode = true;
            LoadNew3.NoneReaderAppMode = true;
            LoadNew4.NoneReaderAppMode = true;

            /*-------------重整按鍵------------*/
            ActiveBtnManage(BtnsDisable);

            if (openFile1.FileName != "")
            {
                ActiveBtnManage(BtnsEnable);
            }

            /*------------------------------*/

            EraseMode_bool = false;
            LoadNew1.EraseMode_bool = false;
            LoadNew2.EraseMode_bool = false;
            LoadNew3.EraseMode_bool = false;
            LoadNew4.EraseMode_bool = false;

        }

        private bool IsAPMode(String StrName)
        {
            bool blnAns = false;
            


            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(StrName);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window                   
                    if (line.Contains("05"))
                    {
                        blnAns = true;
                        Console.WriteLine("Have App mci File!");
                    }
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


            return blnAns;
        }

    }


    public class LoadNew
    {
        
        //讀卡機回傳值
        byte[] LoadNewReturn = { 0x02, 0x00, 0x0E, 0x01, 0x0B, 0x01, 0xFE, 0x00, 0x01, 0x00, 0x37, 0x6D, 0x03 };  //LoadNew成功回傳值
        byte[] SuccessReturn = { 0x10, 0x02, 0x62, 0x00, 0x00, 0x62, 0x10, 0x03 };   //傳送成功回傳值
        byte[] CAPFile = { };

        //RTC前後比對用
        byte[] ReaderRTC1, ReaderRTC2;

        public int LoadStatus = 0,RTCTestStatus=0,APBuadRate=57600, EncodingType = 65001;
        int Position = 0, Count = 0, TimeOut_Counter = 0;
        bool LoadNewAlterVersion = true;//T->LN  F->Version


        public bool Start = false, Reboot_bool = false, APLoadKey=false ,StopStatus= false, BurnSlow=false, FreezeAP_bool=false, FreezeAPStatus_bool = true, JustGetAPVersion_bool=false;
        public bool CheckRC531NoMode, RTCCheckMode = false, NoneReaderAppMode= false, EraseMode_bool=false, AutoEraseMode_bool = false, AutoStartFlag_bool = false, ChangEncoding = false;
        bool REC = false;

        string[] CapPath = { };

        //Command List define
        int GetRTC = 9, SetRTC = 91;
        

        Thread REC_Thread, MainThread;  //接收用執行序,主要執行序
        Queue<byte> RecievedQ = new Queue<byte>(); //接收用佇列

        Button Start_BT, Reboot_BT, DisConnect_BT, AllInOne_BT;
        ComboBox ComPort_CB;
        SerialPort Serialport;
        RichTextBox RTB;
        OpenFileDialog OpenFile;
        ProgressBar ProgressBar;
        Label Color_Lab;
        Label Status_Lab;
        Label ThreadReadyStatus_Lab;//用於確認各tread皆LoadNew完成
        TextBox FileBox;



        public LoadNew(TextBox filebox, Label threadreadystatus_lab, Button allinone_bt, Button start_bt, Button reboot_bt, Button disc_bt, ComboBox comport_cb, SerialPort serialport, RichTextBox rtb, OpenFileDialog openfile, ProgressBar progressbar,Label color_lab,Label status_lab)
        {
            AllInOne_BT = allinone_bt;
            ThreadReadyStatus_Lab = threadreadystatus_lab;
            FileBox = filebox;
            Start_BT = start_bt;
            Reboot_BT = reboot_bt;
            DisConnect_BT = disc_bt;
            ComPort_CB = comport_cb;
            RTB = rtb;
            Serialport = serialport;
            OpenFile = openfile;
            ProgressBar = progressbar;
            Color_Lab = color_lab;
            Status_Lab = status_lab;

        }

        public void initial()   //初始化
        {
            LoadStatus = 0;
            Start = false;
            Reboot_BT.Enabled = false;
            DisConnect_BT.Enabled = false;
            ProgressBar.Value = 0;
            Serialport.BaudRate = 38400;

            if (Serialport.IsOpen)
            {
                RTB.Text += "\nCOM port已關閉\n";
                Serialport.Close();
            }            

            ComPort_CB.Enabled = true;
            ComPort_CB.Items.Clear();
            Start_BT.Enabled = false;


            if (EraseMode_bool)
            {
                Start_BT.Text = "Erase";
            }
            else if(AutoEraseMode_bool)
            {
                Start_BT.Text = "EStart";
            }
            else
            {
                Start_BT.Text = "Start";
            }
            
            if (TimeOut_Counter > 0)
            {
                Color_Lab.BackColor = Color.OrangeRed;
                Status_Lab.Text = "燒錄NG";
                TimeOut_Counter = 0;
            }
            else 
            {
                Color_Lab.BackColor = Color.LightGray;
                Status_Lab.Text = "未連接";
            }
           
            REC_Thread.Abort();
            MainThread.Abort();
        }

        public void ThreadStart()   //開啟執行序
        {
            REC_Thread = new Thread(DataReceived);
            MainThread = new Thread(LoadKey);
            REC_Thread.Start();
            MainThread.Start();
        }

        public void ThreadAbort()   //關閉執行敘
        {           
            //REC_Thread.Abort();
            //MainThread.Abort();
        }

        public void StartLoadKey()   //開始燒錄程式
        {
            if (Start == false)
            {
                RTB.Text = "";
                Start = true;
                Start_BT.Text = "Stop";
                DisConnect_BT.Enabled = false;
                Reboot_BT.Enabled = false;
                Color_Lab.BackColor = Color.Yellow;
                Status_Lab.Text = "燒錄中...";
                
            }
            else
            {
                RecievedQ.Clear();
                Reboot_BT.Enabled = true;
                Start = false;
                StopStatus = true;
                ProgressBar.Value = 0;

                if (!AutoEraseMode_bool)
                {
                    Start_BT.Text = "Start";
                }
                else 
                {
                    Start_BT.Text = "EStart";
                }
                

                RTB.Text += "燒錄已停止" + Environment.NewLine;
                DisConnect_BT.Enabled = true;                                
                LoadStatus = 12;

                /*******用於4台皆LN成功後,一鍵可啟用***************/


                ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) + 1);

                if (OpenFile.FileName != "")
                {
                    if (int.Parse(ThreadReadyStatus_Lab.Text) >= 2)
                    {
                        AllInOne_BT.Enabled = true;
                    }
                    else
                    {
                        AllInOne_BT.Enabled = false;
                    }
                }
                else if (EraseMode_bool)
                {
                    if (int.Parse(ThreadReadyStatus_Lab.Text) >= 2)
                    {
                        AllInOne_BT.Enabled = true;
                    }
                    else
                    {
                        AllInOne_BT.Enabled = false;
                    }
                }
                /*--------------------------------------------------------*/

                Start_BT.Enabled = false;
                Task.Delay(1000).Wait();//防短時間連續按
                Start_BT.Enabled = true;

            }
        }

        /***********************應用函式***********************/
        public void GetVersion()
        {
            LoadStatus = 8;
            SendCMD(2);
        }
        public void GetAPVersion()
        {           
            JustGetAPVersion_bool = true;
            LoadStatus = 18;
        }
        public void APReboot()
        {
            Serialport.BaudRate = APBuadRate;            
            Color_Lab.BackColor = Color.LightGray;
            Status_Lab.Text = "未連接";
            LoadStatus = 14;
        }
        public void RebootInLoadNew()
        {
            Start_BT.Enabled = false;
            AllInOne_BT.Enabled = false;
            ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) - 1);
            ProgressBar.Value = 0;
            LoadStatus = 13;
        }
        public void ResetKEK()
        {
            Start_BT.Enabled = false;
            AllInOne_BT.Enabled = false;
            ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) - 1);
            RTB.Text = "執行Erase\n";
            Reboot_BT.Enabled = false;
            LoadStatus = 15;
               
        }


        /***************************************************/


        /*LoadStatus說明
          * 
             *   0 一秒傳送LoadNew指令或版本詢問指令一次，等待回傳(灰)
             *   1  LoadNew成功後更改鮑率為115200(黃)
             *   2  讀取mmci或mci檔,儲存需燒錄的路徑(黃)
             *   3  讀取CAP檔內容並存於陣列後,傳送StartTran(黃)
             *   4  等待StartTran回應，並傳送DataTran(黃)
             *   5  等待最後一筆DataTran回傳，並傳送CheckTran(黃)
             *   6  等待CheckTran回傳，並傳送EndTran(黃)
             *   7  等待EndTran回傳，確認燒錄狀態(黃)
             *   8  等待韌體版本號回傳(綠)
             *   81 詢問AP層版本(綠)
             *   82 詢問射頻IC_RC531序號
             *   9  等待Reboot回傳,並判斷該重啟階段為何應用(灰or綠)
             *   10 通知燒錄程序完成,並回到自動LoadNew階段
             *   11 (未使用)
             *   12 偵測卡機是否存在
             *   13 送出於LoadNew模式的重啟CMD
             *   14 送出於AP模式的重啟CMD
             *   15 送出Erase CMD
             *   16 確認Erase成功,並送出Reboot
             *   17 確認FreezeAP指令成功
             *   18 轉換BaudRate進入讀取AP版本程序
             *   19 取得ReaderRTC流程處理
             *   20 RTC設置
         
         */

        private void LoadKey()   //燒錄主程式
        {
            while (ComPort_CB.Enabled == false)
            {
                switch (LoadStatus)
                {
                    case 0:    //loadnew Process
                        {
                            if (LoadNewAlterVersion)
                            {
                                SendCMD(0);
                            }
                            else 
                            {
                                SendCMD(2);
                            }


                            Thread.Sleep(1000);


                            if (REC)
                            {
                                RecievedQ.Clear();
                                REC = false;
                                LoadNewAlterVersion = true;
                                TimeOut_Counter = 0;
                                Color_Lab.BackColor = Color.Green;
                                Status_Lab.Text = "LN成功";
                                Serialport.BaudRate = 57600;

                                if (APLoadKey)
                                {
                                    if (BurnSlow)
                                    {
                                        APLoadKey = false;
                                        LoadStatus = 3;
                                    }
                                    else
                                    {
                                        LoadStatus = 1;//BaudRate 115200
                                        Thread.Sleep(4000);
                                        SendCMD(1);
                                    }
                                    
                                }
                                else 
                                {
                                    GetVersion();
                                }
                                
                            }
                            else 
                            {
                                if (LoadNewAlterVersion)
                                {
                                    Serialport.BaudRate = 57600;
                                    LoadNewAlterVersion = !LoadNewAlterVersion;
                                }
                                else
                                {
                                    Serialport.BaudRate = 38400;
                                    LoadNewAlterVersion = !LoadNewAlterVersion;
                                }

                            }

                            


                            break;
                        }
                    case 1:   //更改鮑率
                        {
                            if (REC)
                            {
                                REC = false;
                                TimeOut_Counter = 0;

                               RTB.Text = "BaudRate變更為115200" + Environment.NewLine;
                                //RTB.Text += "=================" + Environment.NewLine;
                                Serialport.BaudRate = 115200;
                                if (Start)
                                {
                                    if (APLoadKey)
                                    {
                                        APLoadKey = false;
                                        LoadStatus = 3;
                                    }
                                    else 
                                    {
                                        LoadStatus = 2;
                                    }
                                    
                                }             
                                

                            }
                            else
                            {
                                TimeOut_Counter++;
                                if(TimeOut_Counter==2000)
                                {
                                    initial();
                                    RTB.Text += "TimeOut" + Environment.NewLine;
                                    Color_Lab.BackColor = Color.OrangeRed;
                                    Status_Lab.Text = "BuadRate設定NG";
                                    TimeOut_Counter = 0;
                                    
                                }
                            }
                            break;
                        }
                    case 2:   //儲存檔案路徑
                        {
                            if (Start)
                            {
                                try
                                {
                                    Position = 0;
                                    Count = 0;
                                    StreamReader OutputFile_stream;
                                    //byte[] OutputFile_name = Encoding.ASCII.GetBytes(OpenFile.FileName);

                                    if (Path.GetExtension(OpenFile.FileName) == ".mmci")   //存取mmci檔
                                    {
                                        OutputFile_stream = new StreamReader(OpenFile.FileName, Encoding.GetEncoding(EncodingType));//V1.4.14 修改項目
                                        string line;
                                        string[] OutputFile_Path = { };
                                        while ((line = OutputFile_stream.ReadLine()) != null)
                                        {
                                            Console.WriteLine(line);
                                            Array.Resize(ref OutputFile_Path, Count + 1);
                                            if (line == "loadnew")   //判斷是否燒ap
                                            {
                                                OutputFile_Path[Count] = "loadnew";
                                            }
                                            else
                                            {
                                                OutputFile_Path[Count] = Path.GetDirectoryName(OpenFile.FileName) + '\\' + line.ToString();
                                                //RTB.Text += $"{OutputFile_Path[Count]}" + Environment.NewLine;//確認讀取路徑
                                            }
                                            Count++;
                                        }
                                        OutputFile_stream.Close();


                                        int Count2 = Count;

                                        Count = 0;

                                        for (int a = 0; a < Count2; a++)
                                        {
                                            if (OutputFile_Path[a] != "loadnew")
                                            {
                                                OutputFile_stream = new StreamReader(OutputFile_Path[a], Encoding.Default);
                                                while ((line = OutputFile_stream.ReadLine()) != null)
                                                {
                                                    Array.Resize(ref CapPath, Count + 1);
                                                    CapPath[Count] = Path.GetDirectoryName(OutputFile_Path[a]) + '\\' + line.ToString();
                                                    Count++;
                                                }
                                                OutputFile_stream.Close();

                                                Array.Resize(ref CapPath, Count + 1);
                                                CapPath[Count] = "";   //新增空白判斷是否是最後檔
                                                Count++;
                                            }

                                            else
                                            {
                                                Array.Resize(ref CapPath, Count + 1);
                                                CapPath[Count] = "loadnew";
                                                Count++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        OutputFile_stream = new StreamReader(OpenFile.FileName, Encoding.UTF8);
                                        string line;
                                        while ((line = OutputFile_stream.ReadLine()) != null)
                                        {
                                            Array.Resize(ref CapPath, Count + 1);
                                            CapPath[Count] = Path.GetDirectoryName(OpenFile.FileName) + '\\' + line.ToString();
                                            Count++;
                                        }
                                        OutputFile_stream.Close();
                                        Array.Resize(ref CapPath, Count + 1);
                                        CapPath[Count] = "";    //新增空白判斷是否是最後檔
                                    }
                                    LoadStatus = 3;
                                    Count = 0;
                                }
                                catch
                                {
                                    if(!ChangEncoding)
                                    {
                                        Console.Write("ChangEncoding!!\n");
                                        EncodingType = 950;
                                        ChangEncoding = true;
                                    }
                                    else
                                    {
                                        EncodingType = 65001;
                                        ChangEncoding = false;

                                        MessageBox.Show("請確認mci檔或mmci檔案內容路徑是否正確 或 mmci檔編碼不為UTF-8制", "File Path Err", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        FileBox.Text = "";
                                        OpenFile.FileName = "";
                                        MessageBox.Show("檔案路徑已重置,檔案修正完成後,請重新選取", "File Path Err", MessageBoxButtons.OK, MessageBoxIcon.Error);//1.4.15新增項目

                                        SendCMD(3);
                                        initial();
                                    }



                                    
                                }
                            }


                               
                            break;
                        }
                    case 3:  //判斷檔案是否加密(Decrypt  Process)
                        {
                            
                                if (Start)
                                {
                                    try
                                    {
                                        Color_Lab.BackColor = Color.Yellow;
                                        Status_Lab.Text = "燒錄中...";
                                        string[] name = CapPath[Count].Split(Path.DirectorySeparatorChar);
                                        RTB.Text += "燒錄檔案:" + Environment.NewLine;
                                        RTB.Text += name[name.Length - 2] + "\\" + name[name.Length - 1] + Environment.NewLine;
                                        FileStream CAP_stream = new System.IO.FileStream(CapPath[Count], System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                        Array.Resize(ref CAPFile, Convert.ToInt32(CAP_stream.Length));
                                        CAP_stream.Read(CAPFile, 0, Convert.ToInt32(CAP_stream.Length));
                                        CAP_stream.Close();
                                        if (CAPFile[0] == 0x53 && CAPFile[1] == 0x43 && CAPFile[2] == 0x50)
                                        {
                                            //RTB.Text += "檔案正確" + Environment.NewLine;
                                            if ((CAPFile[3] & 0x0F) == 0x05)
                                            {
                                                //RTB.Text += "檔案無加密" + Environment.NewLine;
                                                SendCMD(41);
                                            }
                                            else
                                            {
                                                //RTB.Text += "\n\n\n檔案有加密\n\n\n\n" + Environment.NewLine;
                                                SendCMD(42);
                                            }
                                            //RTB.Text += "傳送第" + (Count1 + 1) + "個檔案的StartTranCode" + Environment.NewLine;
                                            Position = 132;
                                            LoadStatus = 4;
                                        }
                                        else
                                        {
                                            RTB.Text += "檔案錯誤" + Environment.NewLine;
                                            LoadStatus = 2;
                                            Start = false;
                                            if (!AutoEraseMode_bool)
                                            {
                                                Start_BT.Text = "Start";
                                            }
                                            else
                                            {
                                                Start_BT.Text = "EStart";
                                            }
                                            Reboot_BT.Enabled = true;
                                            DisConnect_BT.Enabled = true;
                                        }
                                    }
                                    catch 
                                    { MessageBox.Show("請確認mci檔或mmci檔案內容路徑是否正確", "File Path Err", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        SendCMD(3);
                                        initial();
                                    }


                            }


                            break;
                        }
                    case 4:  //傳送data
                        {
                            if (REC && Start)
                            {
                                REC = false;
                                if (CAPFile.Length - 17 - Position >= 256)  //256個
                                {
                                    //RTB.Text += "傳送DataTranCode，位置從" + Position + "到" + (Position + 256 - 1) + Environment.NewLine;
                                    SendCMD(51);
                                    Position = Position + 256;
                                    if (Position == CAPFile.Length - 17)
                                    {
                                        LoadStatus = 5;
                                    }
                                }
                                else //不足256個
                                {
                                    //RTB.Text += "傳送DataTranCode，位置從" + Position + "到" + (CAPFile.Length - 18) + Environment.NewLine;
                                    SendCMD(52);
                                    Position = CAPFile.Length - 16;
                                    LoadStatus = 5;
                                }
                                ProgressBar.Value = (Position * 100) / CAPFile.Length;
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 10000)//原500
                                {
                                    initial();
                                    RTB.Text += "TimeOut" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }
                    case 5:  //傳送檢查碼
                        {
                            if (REC && Start)
                            {
                                REC = false;
                                //RTB.Text += "傳送checkCode位置從" + Position + "到" + (CAPFile.Length - 1) + Environment.NewLine;
                                SendCMD(6);
                                LoadStatus = 6;
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 20000)//原500
                                {
                                    initial();
                                    RTB.Text += "TimeOut" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }
                    case 6: //傳送最後或非最後指令
                        {
                            if (REC && Start)
                            {
                                REC = false;
                                if (CapPath[Count + 1] != "")
                                {
                                    //RTB.Text += "傳送EndTranCode(非最後)" + Environment.NewLine;
                                    SendCMD(71);
                                }
                                else
                                {
                                    //RTB.Text += "傳送EndTranCode(最後)" + Environment.NewLine;
                                    SendCMD(72);
                                }
                                LoadStatus = 7;
                                ProgressBar.Value = 100;
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 20000)////原500
                                {
                                    initial();
                                    RTB.Text += "TimeOut" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }
                    case 7:  //燒錄完成
                        {
                            if (REC && Start)
                            {
                                REC = false;
                                RTB.Text += "燒錄完成" + Environment.NewLine;
                                RTB.Text += "=================" + Environment.NewLine;
                                if (Count < CapPath.Length - 2)  //開始燒ap
                                {
                                    Color_Lab.BackColor = Color.Yellow;
                                    Status_Lab.Text = "燒錄中...";
                                    if (CapPath[Count + 1] == "")
                                    {
                                        Count += 2;
                                        if (CapPath[Count] == "loadnew")//燒錄 95 75後重啟的預判
                                        {
                                            if (NoneReaderAppMode == false)
                                            {
                                                APLoadKey = true;
                                                RTB.Text += "開始燒錄AP" + Environment.NewLine;
                                            }
                                            else
                                            {
                                                //用於僅燒95 75情況
                                                Start = false;
                                                Reboot_bool = true;
                                            }



                                            
                                            Serialport.BaudRate = 38400;
                                            Count += 1;                                            
                                            LoadStatus = 0;
                                            Thread.Sleep(5000);
                                        }
                                        else
                                        {
                                            LoadStatus = 3;
                                        }  
                                    }
                                    else
                                    {
                                        Count++;
                                        LoadStatus = 3;
                                    }
                                    //RTB.Text += "第" + Count1 + "個CAP檔燒錄完成" + Environment.NewLine;
                                }
                                else
                                {
                                   
                                    RTB.Text += "所有檔案燒錄完成" + Environment.NewLine;
                                    LoadStatus = 9;
                                    SendCMD(3);//重開機指令

                                }
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 20000)
                                {
                                    initial();
                                    RTB.Text += "TimeOut" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }
                    case 8:   //卡機版本顯示
                        {
                            if (REC)
                            {
                                REC = false;
                                byte[] Version = RecievedQ.ToArray();
                                RecievedQ.Clear();

                                string LoadVersionValue = Encoding.ASCII.GetString(Version, 13, 4);
                                string BasicVersionValue = Encoding.ASCII.GetString(Version, 19, 4);//19
                                string ULCVersionValue = Encoding.ASCII.GetString(Version, 25, 4);
                                string CTOSVersionValue = Encoding.ASCII.GetString(Version, 31, 4);
                                string EMVVersion = Encoding.ASCII.GetString(Version, 37, 4);
                                string EMVExtVersionValue = Encoding.ASCII.GetString(Version, 43, 4);
                                string FlashSizeValue = Encoding.ASCII.GetString(Version, 50, 4);
                                string SRAMSizeValue = Encoding.ASCII.GetString(Version, 57, 4);
                                string[] FrameWareValueArray ={LoadVersionValue, BasicVersionValue, ULCVersionValue, CTOSVersionValue,
                                                                EMVVersion, EMVExtVersionValue, FlashSizeValue, SRAMSizeValue };


                                //RTB.Text += "=================" + Environment.NewLine;
                                RTB.Text = "Load Version = " + LoadVersionValue + Environment.NewLine;
                                RTB.Text += "Basic Version = " + BasicVersionValue + Environment.NewLine;
                                RTB.Text += "ULC Version = " + ULCVersionValue + Environment.NewLine;
                                RTB.Text += "CTOS Version = " + CTOSVersionValue + Environment.NewLine;
                                RTB.Text += "EMV Version = " + EMVVersion + Environment.NewLine;
                                RTB.Text += "EMVExt Version = " + EMVExtVersionValue + Environment.NewLine;
                                RTB.Text += "Flash Size(kbyte) = " + FlashSizeValue + Environment.NewLine;
                                RTB.Text += "SRAM Size(kbyte) = " + SRAMSizeValue + Environment.NewLine;
                                //RTB.Text += "=================" + Environment.NewLine;

                                //確認版本資訊是否有重複的異常狀況
                                for (int i = 0; i < FrameWareValueArray.Length-1; i++)
                                {
                                    if (FrameWareValueArray[i] == FrameWareValueArray[i + 1])
                                        {

                                        initial();
                                        RTB.Text += "韌體版本異常!\n";
                                        Color_Lab.BackColor = Color.OrangeRed;
                                        Status_Lab.Text = "NG";
                                        
                                    }
                                    if (i == FrameWareValueArray.Length - 2)
                                    {
                                        RTB.Text += ("自動檢測OK");
                                     }
                                }




                                if (Start == true)
                                {
                                    LoadStatus = 9;
                                    SendCMD(3);   //顯示完版本重開機
                                    Reboot_bool = true;
                                }
                                else if(Reboot_bool == true)//判斷是否經過燒錄完成的重啟過
                                {                                   

                                    Start_BT.Enabled = false;
                                    if (NoneReaderAppMode == true)//
                                    {
                                        Reboot_bool = false;
                                        LoadStatus = 10;
                                    }
                                    else
                                    {
                                        LoadStatus = 9;
                                    }
                                    
                                    SendCMD(3);
                                }
                                else
                                {
                                    if (OpenFile.FileName != "")
                                    {
                                        Start_BT.Enabled = true;
                                    }
                                    else if (EraseMode_bool)
                                    {
                                        Start_BT.Enabled = true;
                                    }

                                    /*******用於2台以上LN成功後,一鍵可啟用***************/
                                    ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) + 1);

                                    if (OpenFile.FileName != "")
                                    {
                                        if (int.Parse(ThreadReadyStatus_Lab.Text) >= 2)
                                        {
                                            AllInOne_BT.Enabled = true;
                                            
                                        }
                                        else
                                        {
                                            AllInOne_BT.Enabled = false;
                                        }
                                    }
                                    else if (EraseMode_bool)
                                    {
                                        if (int.Parse(ThreadReadyStatus_Lab.Text) >= 2)
                                        {
                                            AllInOne_BT.Enabled = true;
                                        }
                                        else
                                        {
                                            AllInOne_BT.Enabled = false;
                                        }
                                    }
                                    /*--------------------------------------------------------*/


                                    Reboot_BT.Enabled = true;
                                    Color_Lab.BackColor = Color.Blue;
                                    Status_Lab.Text = "可燒錄";
                                    LoadStatus = 12;//卡機狀態確認
                                    SendCMD(2);
                                }
                            }
                            else
                            {
                                TimeOut_Counter++;                               
                                if (TimeOut_Counter == 500)
                                {
                                    /*
                                    Color_Lab.BackColor = Color.LightGray;
                                    Status_Lab.Text = "未連接";
                                    RTB.Text += "版本讀取失敗,重新LoadNew" + Environment.NewLine;
                                    */
                                    LoadStatus = 0;
                                }
                            }
                            break;
                        }
                    case 81://詢問AP層版本
                        {
                            int UselessVersionWordsCounter = 0, VersionErrTimes = 0;
                            if (REC == true)
                            {
                                REC = false;
                                byte[] APVersionRecieved = RecievedQ.ToArray();
                                //RTB.Text += "\n版本回傳值:"+BitConverter.ToString(APVersionRecieved);
                                RecievedQ.Clear();
                                try
                                {
                                    
                                    if (VersionErrTimes < 5 && (APVersionRecieved[0]!=0xEA || APVersionRecieved[1] != 0x01 || APVersionRecieved[2] != 0x00 || APVersionRecieved[APVersionRecieved.Length - 2] != 0x90 || APVersionRecieved[APVersionRecieved.Length-1] != 0x00))
                                    {
                                        //RTB.Text += "\nAP版本重新詢問";                                        
                                        VersionErrTimes++;
                                        REC = false;
                                        break;
                                    }

                                    else if (APVersionRecieved[1] == 0x01 && APVersionRecieved[2] == 0x00)
                                    {
                                        //richTextBox1.Text += "版本讀取成功" + Environment.NewLine;
                                        RTB.Text += "\nAP版本:";

                                        /*獲取前3版本字*/
                                        foreach (byte words in APVersionRecieved)
                                        {
                                            if (UselessVersionWordsCounter > 4 && UselessVersionWordsCounter < APVersionRecieved.Length - 2)
                                            {
                                                RTB.Text += Convert.ToChar(words);
                                            }
                                            UselessVersionWordsCounter++;
                                        }

                                    }
                                    else
                                    {
                                        RTB.Text += "版本讀取失敗" + Environment.NewLine;
                                    }
                                }
                                catch
                                {
                                    RTB.Text += "版本讀取失敗Err" + Environment.NewLine;
                                   
                                }
                                if (JustGetAPVersion_bool==true)
                                {
                                    RTB.Text += "\n***燒錄完成, 請確認版號***" + Environment.NewLine;
                                    JustGetAPVersion_bool = false;
                                    Thread.Sleep(1000);
                                    Serialport.BaudRate = 38400;                                    
                                    LoadStatus = 0;
                                }
                                else 
                                {
                                    LoadStatus = 10;
                                }
                                
                                REC = false;
                            }
                            else
                            {
                                if (TimeOut_Counter % 2 == 0)
                                { 
                                    SendCMD(21); 
                                }
                                
                                TimeOut_Counter++;
                                Thread.Sleep(1000);
                                if (TimeOut_Counter == 5000)//原為30
                                {
                                    initial();
                                    Color_Lab.BackColor = Color.OrangeRed;
                                    Status_Lab.Text = "NG";
                                    RTB.Text += "!!!AP版本讀取失敗!!!" + Environment.NewLine;
                                    
                                }
                            }

                            break;
                        }
                    case 82://詢問射頻IC_RC531序號
                        {
                            if (REC == true)
                            {
                                REC = false;
                                byte[] RC531Data = RecievedQ.ToArray();
                                int RealRC531No,CheckRC531=0;
                                RecievedQ.Clear();
                                if (RC531Data.Length == 14)
                                {
                                    for (int i = 5; i < 9; i++)
                                    {
                                        CheckRC531 ^= RC531Data[i];
                                    }
                                    if (CheckRC531 == 0)
                                    {
                                        initial();
                                        RTB.Text += "RC531NoErr,TimeOut" + Environment.NewLine;
                                        Color_Lab.BackColor = Color.OrangeRed;
                                        Status_Lab.Text = "NG";
                                        
                                    }

                                    RTB.Text += "ReaderRC531No :";

                                    //RC531轉碼
                                    RealRC531No=BitConverter.ToInt32(RC531Data, 5);
                                    RTB.Text += RealRC531No.ToString();
                                    JustGetAPVersion_bool = true;
                                    SendCMD(21);
                                    LoadStatus = 81;
                                }
                                else
                                {
                                    SendCMD(22);

                                    TimeOut_Counter++;
                                    if (TimeOut_Counter == 2000)
                                    {
                                        initial();
                                        RTB.Text += "RC531NoErr,TimeOut" + Environment.NewLine;
                                        
                                    }
                                }

                            }
                            else
                            {
                                SendCMD(22);

                                TimeOut_Counter++;
                                if (TimeOut_Counter == 2000)
                                {
                                    initial();
                                    RTB.Text += "RC531NoErr,TimeOut" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }

                    case 9:   //重開機後
                        {
                            if (REC)
                            {
                                REC = false;
                                Color_Lab.BackColor = Color.LightGray;
                                Status_Lab.Text = "未連接";

                                if (Start == true)
                                {
                                    Start = false;
                                    if (!AutoEraseMode_bool)
                                    {
                                        Start_BT.Text = "Start";
                                    }
                                    else
                                    {
                                        Start_BT.Text = "EStart";
                                    }
                                    Start_BT.Enabled = false;
                                    Reboot_BT.Enabled = false;
                                    DisConnect_BT.Enabled = true;
                                    RTB.Text += "reset成功,將執行LoadNew";
                                    Reboot_bool = true;
                                    Serialport.BaudRate = 38400;
                                    LoadStatus = 0;
                                }
                                else if (Reboot_bool)//韌體版本讀取後重開完成,進入AP讀取程序
                                {
                                    Reboot_BT.Enabled = false;
                                    Reboot_bool = false;
                                    LoadStatus = 81;
                                    Serialport.BaudRate = APBuadRate;                                    
                                    SendCMD(21);
                                }
                                else if (FreezeAP_bool) 
                                {
                                    RTB.Text += "Reset ok\n";
                                    FreezeAP_bool = false;
                                    Serialport.BaudRate = 38400;
                                    Thread.Sleep(4000);//原為:8000 1.4.17
                                    SendCMD(81);
                                    LoadStatus = 17;                                    
                                    //FreezeCheck

                                }
                                else
                                {
                                    RTB.Text = "執行Reboot成功\n請確認藍燈是否轉為綠燈" + Environment.NewLine;
                                    Reboot_BT.Enabled = false;
                                    Thread.Sleep(16000);

                                    RTB.Text = "請重新上電" + Environment.NewLine;

                                    Serialport.BaudRate = 38400;
                                    LoadStatus = 0;
                                    REC = false;

                                }
                                
                                
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 2000)
                                {
                                    initial();
                                    RTB.Text += "Reboot,TimeOut" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }
                    case 10://燒錄後版本讀取完成
                        {                                                
                            ProgressBar.Value = 0;
                            Color_Lab.BackColor = Color.Green;
                            Status_Lab.Text = "燒錄完成";
                            RTB.Text += "\n***燒錄完成, 請確認版號***" + Environment.NewLine;
                            Reboot_BT.Enabled = false;
                            Start_BT.Enabled = false;
                            
                            if (RTCCheckMode == false || NoneReaderAppMode==true)//是否進入RTC校正模式
                            {
                                Thread.Sleep(12000);//給時間確認版本
                                Serialport.BaudRate = 38400;
                                LoadStatus = 0;
                            }
                            else
                            {
                                //卡機RTC測試階段
                                RTB.Text += "***將執行RTC測試,請勿拔電***" + Environment.NewLine;
                                Thread.Sleep(10000);//給時間確認版本
                                RTB.Text = "***讀卡機RTC測試***" + Environment.NewLine;
                                LoadStatus = 19;
                                SendCMD(GetRTC);
                            }                            
                            break;
                        }
                    case 12://卡機狀態偵測模式(DetectProcess)
                        {
                            if (REC)
                            {
                                REC = false;                                
                                Thread.Sleep(1000);

                                if(AutoStartFlag_bool)
                                {
                                    AutoStartFlag_bool = false;

                                    AllInOne_BT.Enabled = false;

                                    Start = true;
                                    Start_BT.Text = "Stop";
                                    DisConnect_BT.Enabled = false;
                                    Reboot_BT.Enabled = false;
                                    Color_Lab.BackColor = Color.Yellow;
                                    Status_Lab.Text = "燒錄中...";

                                }


                                if (Start && StopStatus) 
                                {
                                    StopStatus = false;
                                    LoadStatus = 2;

                                    AllInOne_BT.Enabled = false;
                                    ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) - 1);
                                    
                                    break;
                                }
                                else if (Start)
                                {
                                    if (BurnSlow)
                                    {
                                        LoadStatus = 2;
                                        AllInOne_BT.Enabled = false;
                                        ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) - 1);

                                        break;
                                    }
                                    else 
                                    {
                                        LoadStatus = 1;//設定卡機BaudRate
                                        AllInOne_BT.Enabled = false;
                                        ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) - 1);

                                        SendCMD(1);
                                        break;
                                    }
                                }


                                SendCMD(2);
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 300)
                                {
                                    RTB.Text = "卡機未連接";
                                    Color_Lab.BackColor = Color.LightGray;
                                    Status_Lab.Text = "未連接";
                                    Start_BT.Enabled = false;
                                    Reboot_BT.Enabled = false;
                                    LoadStatus = 0;
                                    AllInOne_BT.Enabled = false;
                                    ThreadReadyStatus_Lab.Text = Convert.ToString(int.Parse(ThreadReadyStatus_Lab.Text) - 1);

                                    //initial();
                                }
                            }
                            break;

                        }
                    case 13://執行重開機指令
                        {
                            LoadStatus = 9;
                            SendCMD(3);
                            break;
                        }
                    case 14://AP層重啟
                        {                            
                            SendCMD(31);
                            Thread.Sleep(2000);
                            LoadStatus = 0;
                            break;
                        }
                    case 15://EraseCMD
                        {
                            Thread.Sleep(2000);

                            if (AutoEraseMode_bool)
                            {
                                AutoStartFlag_bool = true;
                            }

                            SendCMD(8);                            
                            LoadStatus = 16;
                            break;

                        }
                    case 16://EraseCheck
                        {
                            if (REC)
                            {
                                RTB.Text += "Erase ok\n";
                                REC = false;
                                FreezeAP_bool = true;
                                LoadStatus = 9;
                                SendCMD(3);//Reboot
                            }
                            else
                            {
                                TimeOut_Counter++;
                                if (TimeOut_Counter == 300)
                                {
                                    RTB.Text = "Erase 失敗_TimeOut";
                                    Thread.Sleep(10000);
                                    Color_Lab.BackColor = Color.LightGray;
                                    Status_Lab.Text = "未連接";
                                    Start_BT.Enabled = false;
                                    Reboot_BT.Enabled = false;
                                    LoadStatus = 0;
                                    //initial();
                                }
                            }
                            break;
                        }
                    case 17://FreezeCheck
                        {
                            if (REC)
                            {
                                REC = false;
                                if (FreezeAPStatus_bool)
                                { RTB.Text += "Freeze_AP ok\n"; }
                                else 
                                {
                                    FreezeAPStatus_bool = true;//初始值
                                    RTB.Text += "\nPlease UnFreeze First!\n"; 
                                }                               

                                RTB.Text += "即將重新LoadNew";
                                Thread.Sleep(10000);
                                LoadStatus = 0;                                
                            }
                            else
                            {
                                TimeOut_Counter++;
                                SendCMD(81);//Ver 1.4.17

                                if (TimeOut_Counter == 5000)
                                {
                                    RTB.Text += "Freeze 失敗_Time out";                                    
                                    Thread.Sleep(1000);
                                    Start_BT.Enabled = false;                                    
                                    LoadStatus = 0;
                                    //initial();
                                }
                            }
                            break;
                        }
                    case 18://獲取AP層版本
                        {
                            Serialport.BaudRate = APBuadRate;
                            LoadStatus = 81;
                            //SendCMD(21);
                            break;
                        }
                    case 19://GetRTC
                        {
                            if (REC == true)//顯示RTC時間
                            {
                                byte[] ReaderRTCdata = RecievedQ.ToArray();
                                


                                REC = false;
                                RecievedQ.Clear();
                                
                                if (ReaderRTCdata.Length == 14)
                                {
                                    
                                    //RTB.Text += "ReaderRTC :";
                                    //for (int i = 5; i < 12; i++)
                                    //{
                                    //    RTB.Text += Convert.ToString(ReaderRTCdata[i]) + " ";
                                    //}
                                    //取得第一個RTC
                                    if (RTCTestStatus == 0)
                                    {
                                        ReaderRTC1 = ReaderRTCdata;
                                        RTCTestStatus++;
                                        //RTB.Text += "\n請等待數秒\n";
                                        Thread.Sleep(1000);//等待數秒,確認RTC 正常運行
                                        SendCMD(GetRTC);
                                    }
                                    //比較RTC值是否正確
                                    else if (RTCTestStatus == 1)
                                    {
                                        ReaderRTC2 = ReaderRTCdata;
                                        if (ReaderRTC1[11] != ReaderRTC2[11])
                                        {
                                            RTB.Text += "RTC功能檢測OK";

                                            RTCTestStatus++;
                                            LoadStatus = 20;
                                            RTB.Text += "\n設定RTC\n";
                                            SendCMD(SetRTC);
                                        }
                                        else if (ReaderRTC1[10] != ReaderRTC2[10])
                                        {
                                            RTB.Text += "\nRTC功能檢測OK~\n";

                                            RTCTestStatus++;
                                            LoadStatus = 20;
                                            RTB.Text += "\n設定RTC\n";
                                            SendCMD(SetRTC);
                                        }
                                        else
                                        {
                                            initial();
                                            RTB.Text += "\n!!!!RTC功能異常!!!\n";
                                            Color_Lab.BackColor = Color.OrangeRed;
                                            Status_Lab.Text = "NG";
                                            
                                        }

                                    }
                                    else if (RTCTestStatus == 2)
                                    {
                                        RTCTestStatus = 0;
                                        RTB.Text += "ReaderRTC :";
                                        for (int i = 5; i < 12; i++)
                                        {
                                            RTB.Text += Convert.ToString(ReaderRTCdata[i]) + " ";
                                        }
                                        if (CheckRC531NoMode == true)
                                        {
                                            SendCMD(22);
                                            LoadStatus = 82;
                                        }
                                        else
                                        {
                                            JustGetAPVersion_bool = true;
                                            SendCMD(21);
                                            LoadStatus = 81;
                                        }

                                      
                                    }
                                }
                            }
                            else
                            {
                                SendCMD(GetRTC);
                                TimeOut_Counter++;
                                Thread.Sleep(1000);
                                if (TimeOut_Counter == 5)//原為30
                                {
                                    initial();
                                    Color_Lab.BackColor = Color.OrangeRed;
                                    Status_Lab.Text = "NG";
                                    RTB.Text += "!!!RTC讀取失敗!!!" + Environment.NewLine;
                                    
                                }
                            }
                            break;
                        }
                    case 20://CheckRTC Success
                        {
                            if (REC == true)
                            {
                                REC = false;
                                RecievedQ.Clear();

                                LoadStatus = 19;

                                RTB.Text += DateTime.Now.ToString("ddd yyyy MMM dd")+ DateTime.Now.ToString("T")+"\n";

                                SendCMD(GetRTC);

                            }
                            else 
                            {
                                SendCMD(SetRTC);
                                TimeOut_Counter++;
                                Thread.Sleep(10000);
                                if (TimeOut_Counter == 5)//原為30
                                {
                                    initial();
                                    Color_Lab.BackColor = Color.OrangeRed;
                                    Status_Lab.Text = "NG";
                                    RTB.Text += "!!!RTC設定失敗!!!" + Environment.NewLine;
                                    
                                }
                            }

                            break;
                        }
                }
                Thread.Sleep(5);
            }
        }

        private void DataReceived()  //接收資料處理
        {
            while (ComPort_CB.Enabled==false)
            {
                try
                {
                    if (Serialport.BytesToRead > 0)
                    {
                        do
                        {
                            RecievedQ.Enqueue(Convert.ToByte(Serialport.ReadByte()));
                        } while (Serialport.BytesToRead > 0);

                        byte[] RecievedQArray = RecievedQ.ToArray();

                        if (RecievedQ.Count >= 8)
                        {
                            if (LoadStatus == 0 && (BitConverter.ToString(RecievedQ.ToArray()) == BitConverter.ToString(LoadNewReturn)))
                            {
                                RecievedQ.Clear();
                                REC = true;
                            }
                            else if (LoadStatus == 82 && RecievedQ.Count > 12)
                            {
                                REC = true;
                            }
                            else if (LoadStatus == 20 && RecievedQ.Count > 4)
                            {
                                REC = true;
                            }
                            else if (LoadStatus == 19 && RecievedQ.Count > 13)
                            {
                                REC = true;
                            }
                            else if (LoadStatus == 10 && RecievedQ.Count > 4)
                            {
                                REC = true;
                            }
                            else if (LoadStatus == 8 && RecievedQ.Count == 64)
                            {
                                REC = true;
                            }
                            else if (LoadStatus == 81)
                            {
                                REC = true;
                            }                            
                            else if ((LoadStatus == 3 || LoadStatus == 4 || LoadStatus == 5 || LoadStatus == 6 || LoadStatus == 7) && RecievedQArray[2] != 0x62)
                             {
                                REC = false;
                                RTB.Text += $"\n資料傳輸失敗,錯誤代碼:\n";
                                RTB.Text += BitConverter.ToString(RecievedQArray);
                               
                                RecievedQ.Clear();
                                SendCMD(3);
                                initial();
                            }
                            else if (LoadStatus == 16 && RecievedQArray[2] != 0x62)
                            {
                                REC = false;
                                RTB.Text += $"\nErase失敗,錯誤代碼:\n";
                                RTB.Text += BitConverter.ToString(RecievedQArray);
                                RecievedQ.Clear();                                
                            }
                            else if (LoadStatus != 0 && LoadStatus != 8 && RecievedQ.Count >= 8)
                            
                            {
                                RecievedQ.Clear();
                                REC = true;
                            }


                            else if (LoadStatus == 0 && RecievedQ.Count == 64)
                            { 
                                RecievedQ.Clear();
                                REC = true;
                            }


                            /* Freeze UnFreeze判斷*/
                            try
                            {
                                if (LoadStatus == 17 && RecievedQArray[11] != 0x00)
                                {
                                    REC = true;
                                    FreezeAPStatus_bool = false;
                                    //RTB.Text += BitConverter.ToString(RecievedQArray);                                    
                                }

                            }
                            catch
                            {                             
                            
                            }
                            /*---------------------*/

                        }
                    }
               }
               catch
                {
                    SendCMD(3);
                    initial();
                    RTB.Text += "序列埠異常" + Environment.NewLine;
                    
                    
                    
                }
                Thread.Sleep(5);
            }
        }

        /*
         *   *  0   LoadNew Mode CMD
             *  1   設傳輸Baud為115200
             *  2   Get FrameWare Version
             *  21  Get AP Version
             *  3   Reboot at LoadNew Mode
             *  31  Reboot at AP Mode
             *  41  無加密檔案宣告
             *  42  加密檔案宣告
             *  51  傳送256個Byte 資料
             *  52  傳送少於256個Byte 資料
             *  6   傳送確認碼
             *  71  宣告mci檔的一個Cap資料傳輸完成,但還有Cap
             *  72  宣告mci檔完全傳輸完成
             *  8   Erase CMD
             *  81  FreezeAP CMD
             *  9   GetReaderRTC
             *  91  Set_ReaderRTC

         */

        private void SendCMD(int Code)     //傳送資料指令
        {
            byte[] CMD= { };
            RecievedQ.Clear();
            REC = false;
            switch (Code)
            {
                case 0:     //LoadNew
                    {
                        byte[] LoadNewCode = { 0x02, 0x00, 0x0B, 0x01, 0x0E, 0x01, 0xFE, 0x00, 0x00, 0xE9, 0x7B, 0x03 };
                        CMD = LoadNewCode;
                        break;
                    }
                case 1:     //SetBuadRate115200
                    {
                        byte[] SetBuadRate115200Code = { 0x10, 0x02, 0x80, 0x0E, 0x05, 0x8B, 0x10, 0x03 };
                        CMD = SetBuadRate115200Code;
                        break;
                    }
                case 2:     //GetFrameWareVersion
                    {
                        byte[] GetVersionCode = { 0x10, 0x02, 0x80, 0x30, 0x00, 0x00, 0xB0, 0x10, 0x03 };
                        CMD = GetVersionCode;
                        break;
                    }
                case 21://GetAPVisionCMD
                    {
                        byte[] GetAPVisionCMD = { 0xEA, 0x01, 0x00, 0x00, 0x01, 0x00, 0x90, 0x00};
                        CMD = GetAPVisionCMD;
                        break;
                    }
                case 22://GetRC531No.
                    {
                        byte[] GetRC531NoCMD = { 0xEA, 0x04, 0x01, 0x00, 0x06, 0x84, 0x0A, 0x00, 0x00, 0x04, 0x8A, 0x90, 0x00 };
                        CMD = GetRC531NoCMD;
                        break;
                    }
                case 3:     //RebootReader
                    {
                        byte[] RebootReaderCode = { 0x10, 0x02, 0x80, 0x31, 0x90, 0x00, 0x21, 0x10, 0x03 };
                        CMD = RebootReaderCode;
                        break;
                    }
                case 31: 
                    {
                        Char[] Resetchars = { 'R', 'E', 'S', 'E', 'T' };
                        byte[] CmdHead = { 0xEA, 0x01, 0x20, 0x00, 0x05 };
                        byte[] CmdTail = { 0x90, 0x00 };
                        int i = CmdHead.Length;
                        Array.Resize(ref CmdHead, CmdHead.Length + Resetchars.Length + CmdTail.Length);
                        foreach (char code in Resetchars)
                        {
                            CmdHead[i] = Convert.ToByte(code);
                            i++;
                        }
                        CmdHead[CmdHead.Length - 2] = 0x90;
                        CMD = CmdHead;
                        break;
                    }
                case 41:    //NOScryptStarTtran
                    {
                        byte[] NOScryptStarTtranCode = { 0x10, 0x02, 0x80, 0x01, 0x00, 0x00, 0x81, 0x10, 0x03 };
                        CMD = NOScryptStarTtranCode;
                        break;
                    }
                case 42:    //ScryptStartTran
                    {
                        byte[] ScryptStartTranCode = { 0x10, 0x02, 0x80, 0x01, 0x03, 0x00, 0x82, 0x10, 0x03 };
                        CMD = ScryptStartTranCode;
                        break;
                    }
                case 51:    //DataTran256
                    {
                        int b = 6;
                        byte Xor = 0x82;
                        byte[] DataTran = new byte[] { 0x10, 0x02, 0x80, 0x03, 0x01, 0x00 };
                        Array.Resize(ref DataTran, 263);
                        Array.Copy(CAPFile, Position, DataTran, 6, 256);
                        for (int a = 6; a < DataTran.Length - 1; a++)
                        {
                            Xor ^= DataTran[a];
                        }
                        DataTran[DataTran.Length - 1] = Xor;
                        List<byte> DataTranList = new List<byte>(DataTran);
                        b = DataTranList.IndexOf(0x10, b, 257);
                        while (b != -1)
                        {
                            DataTranList.Insert(b, 0x10);
                            b += 2;
                            b = DataTranList.IndexOf(0x10, b, DataTranList.Count - b);
                        }
                        Array.Resize(ref DataTran, DataTranList.Count + 2);
                        DataTranList.CopyTo(DataTran);
                        DataTran[DataTran.Length - 2] = 0x10;
                        DataTran[DataTran.Length - 1] = 0x03;
                        CMD = DataTran;
                        break;
                    }
                case 52:    //DataTran<256
                    {
                        int b = 5;
                        byte Xor = 0x83;
                        byte[] DataTran = new byte[] { 0x10, 0x02, 0x80, 0x03, 0x00 };
                        Array.Resize(ref DataTran, CAPFile.Length - 17 - Position + 7);
                        DataTran[b] = Convert.ToByte(CAPFile.Length - 17 - Position);
                        Array.Copy(CAPFile, Position, DataTran,6, CAPFile.Length - 17 - Position);
                        for (int a = 5; a < DataTran.Length - 1; a++)
                        {
                            Xor ^= DataTran[a];
                        }
                        DataTran[DataTran.Length - 1] = Xor;
                        List<byte> DataTranList = new List<byte>(DataTran);
                        b = DataTranList.IndexOf(0x10, b, DataTran.Length-5);
                        while (b != -1)
                        {
                            DataTranList.Insert(b, 0x10);
                            b += 2;
                            b = DataTranList.IndexOf(0x10, b, DataTranList.Count - b);
                        }
                        Array.Resize(ref DataTran, DataTranList.Count + 2);
                        DataTranList.CopyTo(DataTran);
                        DataTran[DataTran.Length - 2] = 0x10;
                        DataTran[DataTran.Length - 1] = 0x03;
                        CMD = DataTran;
                        break;
                    }
                case 6:     //CheckTran
                    {
                        int startIndex = 8;
                        byte Xor = 0x85;
                        byte[] CheckTran = new byte[] { 0x10, 0x02, 0x80, 0x05, 0x00, 0x10 };

                        byte[] LastData= new byte[17];
                        Array.Copy(CAPFile, CAPFile.Length - 17, LastData, 0, 17);

                        Array.Resize(ref CheckTran, 24);
                        Array.Copy(CAPFile, CAPFile.Length-17, CheckTran, 6, 17);

                        foreach(byte LeftData in LastData)
                        {
                            Xor ^= LeftData;
                        }

                        CheckTran[CheckTran.Length - 1] = Xor;
                        List<byte> CheckTranList = new List<byte>(CheckTran);

                        startIndex = CheckTranList.IndexOf(0x10, startIndex, CheckTran.Length-8);
                        while (startIndex != -1)
                        {
                            CheckTranList.Insert(startIndex, 0x10);
                            startIndex += 2;
                            startIndex = CheckTranList.IndexOf(0x10, startIndex, CheckTranList.Count - startIndex);
                        }

                        Array.Resize(ref CheckTran, CheckTranList.Count + 2);
                        CheckTranList.CopyTo(CheckTran);
                        CheckTran[CheckTran.Length - 2] = 0x10;
                        CheckTran[CheckTran.Length - 1] = 0x03;
                        CMD = CheckTran;
                        break;
                    }
                case 71:    //ENDTran
                    {
                        byte[] ENDTranCode = { 0x10, 0x02, 0x80, 0x02, 0x01, 0x00, 0x83, 0x10, 0x03 };
                        CMD = ENDTranCode;
                        break;
                    }
                case 72:    //LastENDTran
                    {
                        byte[] LastENDTranCode = { 0x10, 0x02, 0x80, 0x02, 0x00, 0x00, 0x82, 0x10, 0x03 };
                        CMD = LastENDTranCode;
                        break;
                    }
                case 8://EraseCMD
                    {
                        byte[] EraseCMDCode = { 0x10, 0x02, 0x80, 0x31,0x80,0x00,0x31, 0x10,0x03 };
                        CMD = EraseCMDCode;
                        break;
                    }
                case 81://FreezeAPCMD
                    {
                        byte[] EraseCheckCMDCode = { 0x10, 0x02, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,0x04,0x00,0x00,0x01,0x02,0xF8,0x10,0x03};
                        CMD = EraseCheckCMDCode;
                        break;
                    }
                case 9://GetReaderRTC
                    {
                        byte[] GetRTC = { 0xEA, 0x01, 0x02, 0x00, 0x01, 0x00, 0x90, 0x00 };
                        CMD = GetRTC;
                        break; 
                    }
                    
                case 91://Set_ReaderRTC
                    {
                        byte[] SetRCT = { 0xEA, 0x01, 0x02, 0x00, 0x07, 0x01, 0x15, 0x01, 0x01, 0x00, 0x00, 0x00, 0x90, 0x00 };
                        int Nowyear = DateTime.Now.Year;
                        int Nowmonth = DateTime.Now.Month;
                        int Nowday = DateTime.Now.Day;
                        int Nowhour = DateTime.Now.Hour;
                        int Nowminute = DateTime.Now.Minute;
                        int Nowsecond = DateTime.Now.Second;

                        DateTime dateValue = new DateTime(Nowyear, Nowmonth, Nowday);


                        SetRCT[5] = Convert.ToByte(dateValue.DayOfWeek);
                        SetRCT[6] = Convert.ToByte(Nowyear - 2000);
                        SetRCT[7] = Convert.ToByte(Nowmonth);
                        SetRCT[8] = Convert.ToByte(Nowday);
                        SetRCT[9] = Convert.ToByte(Nowhour);
                        SetRCT[10] = Convert.ToByte(Nowminute);
                        SetRCT[11] = Convert.ToByte(Nowsecond);

                        CMD = SetRCT;


                        break;
                    }

            }

            try   //
            {               
                Serialport.Write(CMD, 0, CMD.Length);

                //待確認
                //if (LoadStatus != 81)
                //{ 
                //    TimeOut_Counter = 0; 
                //}

                
            }
            catch  //comport斷線 回歸初始
            {
                initial();
                RTB.Text += "CMD失敗" + Environment.NewLine;                
                
            }
        }
    }
}

