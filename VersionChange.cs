using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadKeyApp
{
    /*
     * 
     * 由第一項增加
     * 新增時,要變更3個項目:"版本","修訂數量","修訂內容"
     * "修訂"顯示為藍色,"新增"&"移除"顯示為紅色
     * 其他版本變更事項:
     * 1.UI標題
     * 2.工作管理員標題
     * 3.編譯後EXE標題
     * 
     */

    public partial class VersionChange : Form
    {
        string[] Version ={
            "1.4.19","1.4.18","1.4.17","1.4.16","1.4.15",
            "1.4.14","1.4.13","1.4.12","1.4.11",
            "1.4.10","1.4.9","1.4.8.3","1.4.7.2","V1.4.6.6",
            "V1.4.5","V1.4.4","V1.4.3","V1.4.2","V1.4.1","V1.4.0",
            "V1.3.2","V1.3.1","V1.3.0",
            "V1.2.0",
            "V1.1.2","V1.1.1","V1.1.0",
            "V1.0.0"};

        int[] Updateitem = {//該次修訂項次
            1,1,2,2,1,4,1,1,1,
            5,1,3,2,6,
            1,2,2,1,1,1,
            3,1,1,
            1,
            2,1,2,
            1};

          /* "修訂"顯示為藍色,"新增"&"移除"顯示為紅色*/

        string[] VerUpdateitme =
            {
            "新增讀卡機時間校正功能",
            "修正只燒95、75但不燒AP問題",
            "新增於FreezeTimeOut段,仍會丟Freeze指令","修正Reset到Freeze的延遲時間",
            "修正將資料格式錯誤",
            "新增當燒錄檔案路徑為空值,將Start_Btn設為不可用",
            "新增路徑讀取失敗後,重置路徑,並告知使用者須重新點選",
            "新增自動判讀有/無AP模式","移除(隱藏)功能列中無AP模式的選項","移除標題版本旁的模式顯示","新增可使用Big5的編碼格式讀取mmci檔","修正檔案路徑讀取EnCoding方式","修正模式顯示顏色","新增顯示鮑率設定值",
            "修正於Reboot功能使用後,將轉AP層的時間延長至16秒","新增限制Stop鈕,不可短時間(1 sec)重複按","修正將AP詢問階段限制放寬,如遇回傳碼為錯誤值,則會重新詢問,上限為5次","修正將一鍵啟動鍵的限制條件,改為2台以上即可啟用","修正將預設值改為Erase+錄碼模式",
            "修正UI介面&描述修改",
            "新增一鍵啟動鈕","新增AutoErase模式","修正AutoErase模式切換時,未確認是否有燒錄檔,即可按下",
            "新增將Erase功能,變更為Erase模式","新增顯示當前模式於標題",
            "新增Erase功能",
            "修正未確認燒錄回應碼,導致誤判為燒錄成功問題",
            "新增可於AP層重啟卡機",
            "新增57600燒錄模式",
            "修正mmci或mci檔路徑內容錯誤直接導致程式崩潰問題",
            "新增新品燒錄模式(無ReaderApp模式)",
            "修正版本顯示敘述錯誤",
            "修正AP詢問時間",
            "變更原因:轉AP層時間需12秒以上",
            "修正Reboot後,未LoadNew成功,可按下Start鈕",
            "新增在Stop後,可偵測卡機的通訊狀況",
            "修正先選Comport再選檔案,會無法點選Start問題",
            "移除GetVersion按鈕與排版變更",
            "修正LoadNew成功,未偵測卡機是否存在或異常問題",
            "新增更版說明於欄位說明",
            "新增崩潰前,會回應崩潰資訊",
            "修正版本讀取階段未限制雜訊,導致程式閃退問題",
            "修正版本讀取TimeOut時間設定過短問題",
            "修正卡機進入LoadNew卻未回應成功問題",
            "修正正式Cap檔燒錄失敗問題",
            "修正Reboot後,進度條未清零問題",
            "修正Reboot後描述方式",
            "修正LoadNew下一台卡機後,清除歷史資訊",
            "修正Reboot功能需可將卡機轉回綠燈",
            "修正燒錄完成後須轉為綠燈問題", 
            "第一次釋出(修正Ctos燒錄失敗問題)" };

        string[] TheWordsB2R = { };
        string[] TheWordsB2Bl = { };
        int UpdateItemCount=0,WhichVersion=0;



        public VersionChange()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Version);
            ShowMessage();
        }

        private void ShowMessage()
        {            
            foreach (string x in Version)
            {
                richTextBox1.Text += x +":"+ Environment.NewLine;

                for (int i = 0; i < Updateitem[WhichVersion]; i++) 
                {
                    richTextBox1.Text += $"{i+1}.  "+ VerUpdateitme[UpdateItemCount] + Environment.NewLine;//顯示更新事項
                    UpdateItemCount++;//已顯示過說明+1
                }

                WhichVersion++;//已顯示過版本+1
                richTextBox1.Text += "=============================" + Environment.NewLine;

                SetTextColor();

            }


        }



        private void SetTextToRed(String[] Keyword)//將文字轉紅
        {
            for (int i = 0; i < Keyword.Length; i++)
            {
                int index = 0;
                while (index != -1)
                {
                    index = richTextBox1.Text.IndexOf(Keyword[i], index);
                    richTextBox1.Select(index, Keyword[i].Length);
                    richTextBox1.SelectionColor = Color.Red;
                    index++;
                }
            }
        }

        private void SetTextToBlue(String[] Keyword)//將文字轉藍
        {
            for (int i = 0; i < Keyword.Length; i++)
            {
                int index = 0;
                while (index != -1)
                {
                    index = richTextBox1.Text.IndexOf(Keyword[i], index);
                    richTextBox1.Select(index, Keyword[i].Length);
                    richTextBox1.SelectionColor = Color.Blue;
                    index++;
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateItemCount = 0;
            richTextBox1.Text = "";
            if (comboBox1.SelectedIndex != 0) 
            {
                for (int j = 0; j <= comboBox1.SelectedIndex-1; j++)
                {
                    UpdateItemCount += Updateitem[j];
                }
            }


            for (int i = 0; i < Updateitem[comboBox1.SelectedIndex]; i++)
            {
                richTextBox1.Text += $"{i + 1}.  " + VerUpdateitme[i + UpdateItemCount] + Environment.NewLine;//顯示更新事項               
            }

            SetTextColor();
        }

        private void SetTextColor()//將文字轉藍
        {
            try
            {
                TheWordsB2R = new String[] { "新增" };
                SetTextToRed(TheWordsB2R);
            }
            catch
            { }
            try
            {
                TheWordsB2Bl = new String[] { "修正" };
                SetTextToBlue(TheWordsB2Bl);
            }
            catch
            { }
            try
            {
                TheWordsB2R = new String[] { "移除" };
                SetTextToRed(TheWordsB2R);
            }
            catch
            { }
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            //richTextBox1.ScrollToCaret();
        }
    }
}
