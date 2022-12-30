namespace LoadKeyApp
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ComPort_CB1 = new System.Windows.Forms.ComboBox();
            this.ComPort_CB2 = new System.Windows.Forms.ComboBox();
            this.ComPort_CB3 = new System.Windows.Forms.ComboBox();
            this.ComPort_CB4 = new System.Windows.Forms.ComboBox();
            this.Reboot_BT1 = new System.Windows.Forms.Button();
            this.Browse_BT1 = new System.Windows.Forms.Button();
            this.Start_BT1 = new System.Windows.Forms.Button();
            this.Start_BT2 = new System.Windows.Forms.Button();
            this.Start_BT3 = new System.Windows.Forms.Button();
            this.Start_BT4 = new System.Windows.Forms.Button();
            this.RTB1 = new System.Windows.Forms.RichTextBox();
            this.RTB2 = new System.Windows.Forms.RichTextBox();
            this.RTB3 = new System.Windows.Forms.RichTextBox();
            this.RTB4 = new System.Windows.Forms.RichTextBox();
            this.Clear_BT1 = new System.Windows.Forms.Button();
            this.Clear_BT2 = new System.Windows.Forms.Button();
            this.Clear_BT3 = new System.Windows.Forms.Button();
            this.Clear_BT4 = new System.Windows.Forms.Button();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.Scroll_CB1 = new System.Windows.Forms.CheckBox();
            this.Scroll_CB2 = new System.Windows.Forms.CheckBox();
            this.Scroll_CB3 = new System.Windows.Forms.CheckBox();
            this.Scroll_CB4 = new System.Windows.Forms.CheckBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort4 = new System.IO.Ports.SerialPort(this.components);
            this.file_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DISC1 = new System.Windows.Forms.Button();
            this.DISC2 = new System.Windows.Forms.Button();
            this.DISC3 = new System.Windows.Forms.Button();
            this.DISC4 = new System.Windows.Forms.Button();
            this.Reboot_BT2 = new System.Windows.Forms.Button();
            this.Reboot_BT3 = new System.Windows.Forms.Button();
            this.Reboot_BT4 = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.ProgressBar3 = new System.Windows.Forms.ProgressBar();
            this.ProgressBar4 = new System.Windows.Forms.ProgressBar();
            this.Color_Lab1 = new System.Windows.Forms.Label();
            this.Color_Lab2 = new System.Windows.Forms.Label();
            this.Color_Lab3 = new System.Windows.Forms.Label();
            this.Color_Lab4 = new System.Windows.Forms.Label();
            this.Status_Lab1 = new System.Windows.Forms.Label();
            this.Status_Lab2 = new System.Windows.Forms.Label();
            this.Status_Lab3 = new System.Windows.Forms.Label();
            this.Status_Lab4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.燒錄模式設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalMode = new System.Windows.Forms.ToolStripMenuItem();
            this.NoneAppMode = new System.Windows.Forms.ToolStripMenuItem();
            this.EraseMode = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoErase_Mode = new System.Windows.Forms.ToolStripMenuItem();
            this.RTCtestMode = new System.Windows.Forms.ToolStripMenuItem();
            this.速率設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReaderApBaudSet = new System.Windows.Forms.ToolStripMenuItem();
            this.BaudSetTo57600 = new System.Windows.Forms.ToolStripMenuItem();
            this.BaudSetTo115200 = new System.Windows.Forms.ToolStripMenuItem();
            this.BurnCodeBaudRateSet = new System.Windows.Forms.ToolStripMenuItem();
            this.BurnCodeSpeed_Slow = new System.Windows.Forms.ToolStripMenuItem();
            this.BurnCodeSpeed_Fast = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolLine = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstErase = new System.Windows.Forms.ToolStripMenuItem();
            this.Erase2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Erase3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Erase4 = new System.Windows.Forms.ToolStripMenuItem();
            this.AllErase = new System.Windows.Forms.ToolStripMenuItem();
            this.aP層重啟ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AP_Reboot_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AP_Reboot_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.AP_Reboot_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.AP_Reboot_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.readerAP版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.APVersionGet1 = new System.Windows.Forms.ToolStripMenuItem();
            this.APVersionGet2 = new System.Windows.Forms.ToolStripMenuItem();
            this.APVersionGet3 = new System.Windows.Forms.ToolStripMenuItem();
            this.APVersionGet4 = new System.Windows.Forms.ToolStripMenuItem();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_VersionUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.操作說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.StatusTitle = new System.Windows.Forms.TextBox();
            this.AllInOne_Btn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DelayTimeSet = new System.Windows.Forms.TextBox();
            this.TreadReadyStatusCount_Lab = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AllAPReboot_Btn = new System.Windows.Forms.Button();
            this.GetRC531No = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComPort_CB1
            // 
            this.ComPort_CB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPort_CB1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComPort_CB1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ComPort_CB1.FormattingEnabled = true;
            this.ComPort_CB1.Location = new System.Drawing.Point(5, 23);
            this.ComPort_CB1.Margin = new System.Windows.Forms.Padding(2);
            this.ComPort_CB1.Name = "ComPort_CB1";
            this.ComPort_CB1.Size = new System.Drawing.Size(83, 24);
            this.ComPort_CB1.TabIndex = 0;
            this.ComPort_CB1.DropDown += new System.EventHandler(this.ComPort_CB1_DropDown);
            this.ComPort_CB1.TextChanged += new System.EventHandler(this.ComPort_CB1_TextChanged);
            // 
            // ComPort_CB2
            // 
            this.ComPort_CB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPort_CB2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComPort_CB2.FormattingEnabled = true;
            this.ComPort_CB2.Location = new System.Drawing.Point(5, 25);
            this.ComPort_CB2.Margin = new System.Windows.Forms.Padding(2);
            this.ComPort_CB2.Name = "ComPort_CB2";
            this.ComPort_CB2.Size = new System.Drawing.Size(83, 24);
            this.ComPort_CB2.TabIndex = 1;
            this.ComPort_CB2.DropDown += new System.EventHandler(this.ComPort_CB2_DropDown);
            this.ComPort_CB2.TextChanged += new System.EventHandler(this.ComPort_CB2_TextChanged);
            // 
            // ComPort_CB3
            // 
            this.ComPort_CB3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPort_CB3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComPort_CB3.FormattingEnabled = true;
            this.ComPort_CB3.Location = new System.Drawing.Point(5, 25);
            this.ComPort_CB3.Margin = new System.Windows.Forms.Padding(2);
            this.ComPort_CB3.Name = "ComPort_CB3";
            this.ComPort_CB3.Size = new System.Drawing.Size(83, 24);
            this.ComPort_CB3.TabIndex = 2;
            this.ComPort_CB3.DropDown += new System.EventHandler(this.ComPort_CB3_DropDown);
            this.ComPort_CB3.TextChanged += new System.EventHandler(this.ComPort_CB3_TextChanged);
            // 
            // ComPort_CB4
            // 
            this.ComPort_CB4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPort_CB4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComPort_CB4.FormattingEnabled = true;
            this.ComPort_CB4.Location = new System.Drawing.Point(5, 25);
            this.ComPort_CB4.Margin = new System.Windows.Forms.Padding(2);
            this.ComPort_CB4.Name = "ComPort_CB4";
            this.ComPort_CB4.Size = new System.Drawing.Size(83, 24);
            this.ComPort_CB4.TabIndex = 3;
            this.ComPort_CB4.DropDown += new System.EventHandler(this.ComPort_CB4_DropDown);
            this.ComPort_CB4.TextChanged += new System.EventHandler(this.ComPort_CB4_TextChanged);
            // 
            // Reboot_BT1
            // 
            this.Reboot_BT1.Enabled = false;
            this.Reboot_BT1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Reboot_BT1.Location = new System.Drawing.Point(110, 389);
            this.Reboot_BT1.Margin = new System.Windows.Forms.Padding(2);
            this.Reboot_BT1.Name = "Reboot_BT1";
            this.Reboot_BT1.Size = new System.Drawing.Size(89, 34);
            this.Reboot_BT1.TabIndex = 12;
            this.Reboot_BT1.Text = "Reboot";
            this.Reboot_BT1.UseVisualStyleBackColor = true;
            this.Reboot_BT1.Click += new System.EventHandler(this.Reboot_BT1_Click);
            // 
            // Browse_BT1
            // 
            this.Browse_BT1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Browse_BT1.Location = new System.Drawing.Point(734, 29);
            this.Browse_BT1.Margin = new System.Windows.Forms.Padding(2);
            this.Browse_BT1.Name = "Browse_BT1";
            this.Browse_BT1.Size = new System.Drawing.Size(96, 38);
            this.Browse_BT1.TabIndex = 16;
            this.Browse_BT1.Text = "Browse";
            this.Browse_BT1.UseVisualStyleBackColor = true;
            this.Browse_BT1.Click += new System.EventHandler(this.Browse_BT1_Click);
            // 
            // Start_BT1
            // 
            this.Start_BT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start_BT1.Enabled = false;
            this.Start_BT1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Start_BT1.ForeColor = System.Drawing.Color.Black;
            this.Start_BT1.Location = new System.Drawing.Point(101, 22);
            this.Start_BT1.Margin = new System.Windows.Forms.Padding(2);
            this.Start_BT1.Name = "Start_BT1";
            this.Start_BT1.Size = new System.Drawing.Size(98, 50);
            this.Start_BT1.TabIndex = 20;
            this.Start_BT1.Text = "Start";
            this.Start_BT1.UseVisualStyleBackColor = false;
            this.Start_BT1.Click += new System.EventHandler(this.Start_BT1_Click);
            // 
            // Start_BT2
            // 
            this.Start_BT2.Enabled = false;
            this.Start_BT2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Start_BT2.Location = new System.Drawing.Point(101, 24);
            this.Start_BT2.Margin = new System.Windows.Forms.Padding(2);
            this.Start_BT2.Name = "Start_BT2";
            this.Start_BT2.Size = new System.Drawing.Size(98, 50);
            this.Start_BT2.TabIndex = 21;
            this.Start_BT2.Text = "Start";
            this.Start_BT2.UseVisualStyleBackColor = true;
            this.Start_BT2.Click += new System.EventHandler(this.Start_BT2_Click);
            // 
            // Start_BT3
            // 
            this.Start_BT3.Enabled = false;
            this.Start_BT3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Start_BT3.Location = new System.Drawing.Point(100, 24);
            this.Start_BT3.Margin = new System.Windows.Forms.Padding(2);
            this.Start_BT3.Name = "Start_BT3";
            this.Start_BT3.Size = new System.Drawing.Size(98, 50);
            this.Start_BT3.TabIndex = 22;
            this.Start_BT3.Text = "Start";
            this.Start_BT3.UseVisualStyleBackColor = true;
            this.Start_BT3.Click += new System.EventHandler(this.Start_BT3_Click);
            // 
            // Start_BT4
            // 
            this.Start_BT4.Enabled = false;
            this.Start_BT4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Start_BT4.Location = new System.Drawing.Point(102, 24);
            this.Start_BT4.Margin = new System.Windows.Forms.Padding(2);
            this.Start_BT4.Name = "Start_BT4";
            this.Start_BT4.Size = new System.Drawing.Size(98, 50);
            this.Start_BT4.TabIndex = 23;
            this.Start_BT4.Text = "Start";
            this.Start_BT4.UseVisualStyleBackColor = true;
            this.Start_BT4.Click += new System.EventHandler(this.Start_BT4_Click);
            // 
            // RTB1
            // 
            this.RTB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(184)))), ((int)(((byte)(204)))));
            this.RTB1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RTB1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.RTB1.Location = new System.Drawing.Point(5, 78);
            this.RTB1.Margin = new System.Windows.Forms.Padding(2);
            this.RTB1.Name = "RTB1";
            this.RTB1.ReadOnly = true;
            this.RTB1.Size = new System.Drawing.Size(194, 280);
            this.RTB1.TabIndex = 24;
            this.RTB1.Text = "";
            this.RTB1.TextChanged += new System.EventHandler(this.RTB1_TextChanged);
            // 
            // RTB2
            // 
            this.RTB2.BackColor = System.Drawing.Color.SteelBlue;
            this.RTB2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RTB2.Location = new System.Drawing.Point(5, 78);
            this.RTB2.Margin = new System.Windows.Forms.Padding(2);
            this.RTB2.Name = "RTB2";
            this.RTB2.ReadOnly = true;
            this.RTB2.Size = new System.Drawing.Size(194, 280);
            this.RTB2.TabIndex = 25;
            this.RTB2.Text = "";
            this.RTB2.TextChanged += new System.EventHandler(this.RTB2_TextChanged);
            // 
            // RTB3
            // 
            this.RTB3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.RTB3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RTB3.Location = new System.Drawing.Point(5, 78);
            this.RTB3.Margin = new System.Windows.Forms.Padding(2);
            this.RTB3.Name = "RTB3";
            this.RTB3.ReadOnly = true;
            this.RTB3.Size = new System.Drawing.Size(194, 280);
            this.RTB3.TabIndex = 26;
            this.RTB3.Text = "";
            this.RTB3.TextChanged += new System.EventHandler(this.RTB3_TextChanged);
            // 
            // RTB4
            // 
            this.RTB4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.RTB4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RTB4.Location = new System.Drawing.Point(5, 78);
            this.RTB4.Margin = new System.Windows.Forms.Padding(2);
            this.RTB4.Name = "RTB4";
            this.RTB4.ReadOnly = true;
            this.RTB4.Size = new System.Drawing.Size(194, 280);
            this.RTB4.TabIndex = 27;
            this.RTB4.Text = "";
            this.RTB4.TextChanged += new System.EventHandler(this.RTB4_TextChanged);
            // 
            // Clear_BT1
            // 
            this.Clear_BT1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.Clear_BT1.Location = new System.Drawing.Point(109, 362);
            this.Clear_BT1.Margin = new System.Windows.Forms.Padding(2);
            this.Clear_BT1.Name = "Clear_BT1";
            this.Clear_BT1.Size = new System.Drawing.Size(89, 22);
            this.Clear_BT1.TabIndex = 32;
            this.Clear_BT1.Text = "Clear";
            this.Clear_BT1.UseVisualStyleBackColor = true;
            this.Clear_BT1.Click += new System.EventHandler(this.Clear_BT1_Click);
            // 
            // Clear_BT2
            // 
            this.Clear_BT2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Clear_BT2.Location = new System.Drawing.Point(109, 362);
            this.Clear_BT2.Margin = new System.Windows.Forms.Padding(2);
            this.Clear_BT2.Name = "Clear_BT2";
            this.Clear_BT2.Size = new System.Drawing.Size(89, 22);
            this.Clear_BT2.TabIndex = 33;
            this.Clear_BT2.Text = "Clear";
            this.Clear_BT2.UseVisualStyleBackColor = true;
            this.Clear_BT2.Click += new System.EventHandler(this.Clear_BT2_Click);
            // 
            // Clear_BT3
            // 
            this.Clear_BT3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Clear_BT3.Location = new System.Drawing.Point(109, 362);
            this.Clear_BT3.Margin = new System.Windows.Forms.Padding(2);
            this.Clear_BT3.Name = "Clear_BT3";
            this.Clear_BT3.Size = new System.Drawing.Size(89, 22);
            this.Clear_BT3.TabIndex = 34;
            this.Clear_BT3.Text = "Clear";
            this.Clear_BT3.UseVisualStyleBackColor = true;
            this.Clear_BT3.Click += new System.EventHandler(this.Clear_BT3_Click);
            // 
            // Clear_BT4
            // 
            this.Clear_BT4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Clear_BT4.Location = new System.Drawing.Point(109, 362);
            this.Clear_BT4.Margin = new System.Windows.Forms.Padding(2);
            this.Clear_BT4.Name = "Clear_BT4";
            this.Clear_BT4.Size = new System.Drawing.Size(89, 22);
            this.Clear_BT4.TabIndex = 35;
            this.Clear_BT4.Text = "Clear";
            this.Clear_BT4.UseVisualStyleBackColor = true;
            this.Clear_BT4.Click += new System.EventHandler(this.Clear_BT4_Click);
            // 
            // openFile1
            // 
            this.openFile1.Filter = "mmci files (*.mmci)|*.mmci|mci files (*.mci)|*.mci";
            this.openFile1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile1_FileOk);
            // 
            // Scroll_CB1
            // 
            this.Scroll_CB1.AutoSize = true;
            this.Scroll_CB1.Checked = true;
            this.Scroll_CB1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scroll_CB1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Scroll_CB1.Location = new System.Drawing.Point(5, 362);
            this.Scroll_CB1.Margin = new System.Windows.Forms.Padding(2);
            this.Scroll_CB1.Name = "Scroll_CB1";
            this.Scroll_CB1.Size = new System.Drawing.Size(70, 25);
            this.Scroll_CB1.TabIndex = 36;
            this.Scroll_CB1.Text = "Scroll";
            this.Scroll_CB1.UseVisualStyleBackColor = true;
            // 
            // Scroll_CB2
            // 
            this.Scroll_CB2.AutoSize = true;
            this.Scroll_CB2.Checked = true;
            this.Scroll_CB2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scroll_CB2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Scroll_CB2.Location = new System.Drawing.Point(5, 362);
            this.Scroll_CB2.Margin = new System.Windows.Forms.Padding(2);
            this.Scroll_CB2.Name = "Scroll_CB2";
            this.Scroll_CB2.Size = new System.Drawing.Size(70, 25);
            this.Scroll_CB2.TabIndex = 37;
            this.Scroll_CB2.Text = "Scroll";
            this.Scroll_CB2.UseVisualStyleBackColor = true;
            // 
            // Scroll_CB3
            // 
            this.Scroll_CB3.AutoSize = true;
            this.Scroll_CB3.Checked = true;
            this.Scroll_CB3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scroll_CB3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Scroll_CB3.Location = new System.Drawing.Point(5, 362);
            this.Scroll_CB3.Margin = new System.Windows.Forms.Padding(2);
            this.Scroll_CB3.Name = "Scroll_CB3";
            this.Scroll_CB3.Size = new System.Drawing.Size(70, 25);
            this.Scroll_CB3.TabIndex = 38;
            this.Scroll_CB3.Text = "Scroll";
            this.Scroll_CB3.UseVisualStyleBackColor = true;
            // 
            // Scroll_CB4
            // 
            this.Scroll_CB4.AutoSize = true;
            this.Scroll_CB4.Checked = true;
            this.Scroll_CB4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Scroll_CB4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Scroll_CB4.Location = new System.Drawing.Point(5, 362);
            this.Scroll_CB4.Margin = new System.Windows.Forms.Padding(2);
            this.Scroll_CB4.Name = "Scroll_CB4";
            this.Scroll_CB4.Size = new System.Drawing.Size(70, 25);
            this.Scroll_CB4.TabIndex = 39;
            this.Scroll_CB4.Text = "Scroll";
            this.Scroll_CB4.UseVisualStyleBackColor = true;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 38400;
            // 
            // serialPort2
            // 
            this.serialPort2.BaudRate = 38400;
            // 
            // serialPort3
            // 
            this.serialPort3.BaudRate = 38400;
            // 
            // serialPort4
            // 
            this.serialPort4.BaudRate = 38400;
            // 
            // file_box
            // 
            this.file_box.BackColor = System.Drawing.SystemColors.MenuBar;
            this.file_box.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.file_box.Location = new System.Drawing.Point(103, 37);
            this.file_box.Name = "file_box";
            this.file_box.ReadOnly = true;
            this.file_box.Size = new System.Drawing.Size(617, 23);
            this.file_box.TabIndex = 40;
            this.file_box.WordWrap = false;
            this.file_box.TextChanged += new System.EventHandler(this.file_box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "CAP FIle";
            // 
            // DISC1
            // 
            this.DISC1.Enabled = false;
            this.DISC1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DISC1.Location = new System.Drawing.Point(4, 50);
            this.DISC1.Margin = new System.Windows.Forms.Padding(2);
            this.DISC1.Name = "DISC1";
            this.DISC1.Size = new System.Drawing.Size(84, 22);
            this.DISC1.TabIndex = 44;
            this.DISC1.Text = "DISC";
            this.DISC1.UseVisualStyleBackColor = true;
            this.DISC1.Click += new System.EventHandler(this.DISC1_Click);
            // 
            // DISC2
            // 
            this.DISC2.Enabled = false;
            this.DISC2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DISC2.Location = new System.Drawing.Point(5, 52);
            this.DISC2.Margin = new System.Windows.Forms.Padding(2);
            this.DISC2.Name = "DISC2";
            this.DISC2.Size = new System.Drawing.Size(83, 22);
            this.DISC2.TabIndex = 45;
            this.DISC2.Text = "DISC";
            this.DISC2.UseVisualStyleBackColor = true;
            this.DISC2.Click += new System.EventHandler(this.DISC2_Click);
            // 
            // DISC3
            // 
            this.DISC3.Enabled = false;
            this.DISC3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DISC3.Location = new System.Drawing.Point(5, 53);
            this.DISC3.Margin = new System.Windows.Forms.Padding(2);
            this.DISC3.Name = "DISC3";
            this.DISC3.Size = new System.Drawing.Size(84, 22);
            this.DISC3.TabIndex = 46;
            this.DISC3.Text = "DISC";
            this.DISC3.UseVisualStyleBackColor = true;
            this.DISC3.Click += new System.EventHandler(this.DISC3_Click);
            // 
            // DISC4
            // 
            this.DISC4.Enabled = false;
            this.DISC4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DISC4.Location = new System.Drawing.Point(5, 53);
            this.DISC4.Margin = new System.Windows.Forms.Padding(2);
            this.DISC4.Name = "DISC4";
            this.DISC4.Size = new System.Drawing.Size(83, 22);
            this.DISC4.TabIndex = 47;
            this.DISC4.Text = "DISC";
            this.DISC4.UseVisualStyleBackColor = true;
            this.DISC4.Click += new System.EventHandler(this.DISC4_Click);
            // 
            // Reboot_BT2
            // 
            this.Reboot_BT2.Enabled = false;
            this.Reboot_BT2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Reboot_BT2.Location = new System.Drawing.Point(110, 389);
            this.Reboot_BT2.Margin = new System.Windows.Forms.Padding(2);
            this.Reboot_BT2.Name = "Reboot_BT2";
            this.Reboot_BT2.Size = new System.Drawing.Size(89, 34);
            this.Reboot_BT2.TabIndex = 60;
            this.Reboot_BT2.Text = "Reboot";
            this.Reboot_BT2.UseVisualStyleBackColor = true;
            this.Reboot_BT2.Click += new System.EventHandler(this.Reboot_BT2_Click);
            // 
            // Reboot_BT3
            // 
            this.Reboot_BT3.Enabled = false;
            this.Reboot_BT3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Reboot_BT3.Location = new System.Drawing.Point(109, 388);
            this.Reboot_BT3.Margin = new System.Windows.Forms.Padding(2);
            this.Reboot_BT3.Name = "Reboot_BT3";
            this.Reboot_BT3.Size = new System.Drawing.Size(89, 33);
            this.Reboot_BT3.TabIndex = 61;
            this.Reboot_BT3.Text = "Reboot";
            this.Reboot_BT3.UseVisualStyleBackColor = true;
            this.Reboot_BT3.Click += new System.EventHandler(this.Reboot_BT3_Click);
            // 
            // Reboot_BT4
            // 
            this.Reboot_BT4.Enabled = false;
            this.Reboot_BT4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Reboot_BT4.Location = new System.Drawing.Point(107, 388);
            this.Reboot_BT4.Margin = new System.Windows.Forms.Padding(2);
            this.Reboot_BT4.Name = "Reboot_BT4";
            this.Reboot_BT4.Size = new System.Drawing.Size(89, 34);
            this.Reboot_BT4.TabIndex = 62;
            this.Reboot_BT4.Text = "Reboot";
            this.Reboot_BT4.UseVisualStyleBackColor = true;
            this.Reboot_BT4.Click += new System.EventHandler(this.Reboot_BT4_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(5, 427);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(194, 23);
            this.ProgressBar1.TabIndex = 63;
            // 
            // ProgressBar2
            // 
            this.ProgressBar2.Location = new System.Drawing.Point(5, 427);
            this.ProgressBar2.Name = "ProgressBar2";
            this.ProgressBar2.Size = new System.Drawing.Size(194, 23);
            this.ProgressBar2.Step = 1;
            this.ProgressBar2.TabIndex = 64;
            // 
            // ProgressBar3
            // 
            this.ProgressBar3.Location = new System.Drawing.Point(4, 427);
            this.ProgressBar3.Name = "ProgressBar3";
            this.ProgressBar3.Size = new System.Drawing.Size(194, 23);
            this.ProgressBar3.Step = 1;
            this.ProgressBar3.TabIndex = 65;
            // 
            // ProgressBar4
            // 
            this.ProgressBar4.Location = new System.Drawing.Point(6, 427);
            this.ProgressBar4.Name = "ProgressBar4";
            this.ProgressBar4.Size = new System.Drawing.Size(194, 23);
            this.ProgressBar4.Step = 1;
            this.ProgressBar4.TabIndex = 66;
            // 
            // Color_Lab1
            // 
            this.Color_Lab1.BackColor = System.Drawing.Color.LightGray;
            this.Color_Lab1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Color_Lab1.Location = new System.Drawing.Point(6, 394);
            this.Color_Lab1.Name = "Color_Lab1";
            this.Color_Lab1.Size = new System.Drawing.Size(20, 20);
            this.Color_Lab1.TabIndex = 67;
            // 
            // Color_Lab2
            // 
            this.Color_Lab2.BackColor = System.Drawing.Color.LightGray;
            this.Color_Lab2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Color_Lab2.Location = new System.Drawing.Point(6, 394);
            this.Color_Lab2.Name = "Color_Lab2";
            this.Color_Lab2.Size = new System.Drawing.Size(20, 20);
            this.Color_Lab2.TabIndex = 68;
            // 
            // Color_Lab3
            // 
            this.Color_Lab3.BackColor = System.Drawing.Color.LightGray;
            this.Color_Lab3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Color_Lab3.Location = new System.Drawing.Point(6, 394);
            this.Color_Lab3.Name = "Color_Lab3";
            this.Color_Lab3.Size = new System.Drawing.Size(20, 20);
            this.Color_Lab3.TabIndex = 69;
            // 
            // Color_Lab4
            // 
            this.Color_Lab4.BackColor = System.Drawing.Color.LightGray;
            this.Color_Lab4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Color_Lab4.Location = new System.Drawing.Point(6, 394);
            this.Color_Lab4.Name = "Color_Lab4";
            this.Color_Lab4.Size = new System.Drawing.Size(20, 20);
            this.Color_Lab4.TabIndex = 70;
            // 
            // Status_Lab1
            // 
            this.Status_Lab1.AutoSize = true;
            this.Status_Lab1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Status_Lab1.Location = new System.Drawing.Point(24, 394);
            this.Status_Lab1.Name = "Status_Lab1";
            this.Status_Lab1.Size = new System.Drawing.Size(58, 21);
            this.Status_Lab1.TabIndex = 71;
            this.Status_Lab1.Text = "未連接";
            // 
            // Status_Lab2
            // 
            this.Status_Lab2.AutoSize = true;
            this.Status_Lab2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Status_Lab2.Location = new System.Drawing.Point(24, 394);
            this.Status_Lab2.Name = "Status_Lab2";
            this.Status_Lab2.Size = new System.Drawing.Size(58, 21);
            this.Status_Lab2.TabIndex = 72;
            this.Status_Lab2.Text = "未連接";
            // 
            // Status_Lab3
            // 
            this.Status_Lab3.AutoSize = true;
            this.Status_Lab3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Status_Lab3.Location = new System.Drawing.Point(24, 394);
            this.Status_Lab3.Name = "Status_Lab3";
            this.Status_Lab3.Size = new System.Drawing.Size(58, 21);
            this.Status_Lab3.TabIndex = 73;
            this.Status_Lab3.Text = "未連接";
            // 
            // Status_Lab4
            // 
            this.Status_Lab4.AutoSize = true;
            this.Status_Lab4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Status_Lab4.Location = new System.Drawing.Point(24, 394);
            this.Status_Lab4.Name = "Status_Lab4";
            this.Status_Lab4.Size = new System.Drawing.Size(58, 21);
            this.Status_Lab4.TabIndex = 74;
            this.Status_Lab4.Text = "未連接";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.ToolLine,
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 75;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.燒錄模式設定ToolStripMenuItem,
            this.速率設定ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.設定ToolStripMenuItem.Text = "燒錄模式";
            // 
            // 燒錄模式設定ToolStripMenuItem
            // 
            this.燒錄模式設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NormalMode,
            this.NoneAppMode,
            this.EraseMode,
            this.AutoErase_Mode,
            this.RTCtestMode,
            this.GetRC531No});
            this.燒錄模式設定ToolStripMenuItem.Name = "燒錄模式設定ToolStripMenuItem";
            this.燒錄模式設定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.燒錄模式設定ToolStripMenuItem.Text = "燒錄模式設定";
            // 
            // NormalMode
            // 
            this.NormalMode.Name = "NormalMode";
            this.NormalMode.Size = new System.Drawing.Size(180, 22);
            this.NormalMode.Text = "燒錄模式";
            this.NormalMode.Click += new System.EventHandler(this.NormalMode_Click);
            // 
            // NoneAppMode
            // 
            this.NoneAppMode.Name = "NoneAppMode";
            this.NoneAppMode.Size = new System.Drawing.Size(180, 22);
            this.NoneAppMode.Text = "無AP模式";
            this.NoneAppMode.Visible = false;
            this.NoneAppMode.Click += new System.EventHandler(this.NoneAppMode_Click);
            // 
            // EraseMode
            // 
            this.EraseMode.Name = "EraseMode";
            this.EraseMode.Size = new System.Drawing.Size(180, 22);
            this.EraseMode.Text = "清key模式";
            this.EraseMode.Click += new System.EventHandler(this.EraseMode_Click);
            // 
            // AutoErase_Mode
            // 
            this.AutoErase_Mode.Name = "AutoErase_Mode";
            this.AutoErase_Mode.Size = new System.Drawing.Size(180, 22);
            this.AutoErase_Mode.Text = "自動清Key模式";
            this.AutoErase_Mode.Click += new System.EventHandler(this.AutoErase_Mode_Click);
            // 
            // RTCtestMode
            // 
            this.RTCtestMode.Name = "RTCtestMode";
            this.RTCtestMode.Size = new System.Drawing.Size(180, 22);
            this.RTCtestMode.Text = "RTC測試模式";
            this.RTCtestMode.Click += new System.EventHandler(this.卡機時間確認ToolStripMenuItem_Click);
            // 
            // 速率設定ToolStripMenuItem
            // 
            this.速率設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReaderApBaudSet,
            this.BurnCodeBaudRateSet});
            this.速率設定ToolStripMenuItem.Name = "速率設定ToolStripMenuItem";
            this.速率設定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.速率設定ToolStripMenuItem.Text = "鮑率設定";
            // 
            // ReaderApBaudSet
            // 
            this.ReaderApBaudSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BaudSetTo57600,
            this.BaudSetTo115200});
            this.ReaderApBaudSet.Name = "ReaderApBaudSet";
            this.ReaderApBaudSet.Size = new System.Drawing.Size(146, 22);
            this.ReaderApBaudSet.Text = "AP鮑率設定";
            // 
            // BaudSetTo57600
            // 
            this.BaudSetTo57600.Name = "BaudSetTo57600";
            this.BaudSetTo57600.Size = new System.Drawing.Size(116, 22);
            this.BaudSetTo57600.Text = "57600";
            this.BaudSetTo57600.Click += new System.EventHandler(this.BaudSetTo57600_Click);
            // 
            // BaudSetTo115200
            // 
            this.BaudSetTo115200.Name = "BaudSetTo115200";
            this.BaudSetTo115200.Size = new System.Drawing.Size(116, 22);
            this.BaudSetTo115200.Text = "115200";
            this.BaudSetTo115200.Click += new System.EventHandler(this.BaudSetTo115200_Click);
            // 
            // BurnCodeBaudRateSet
            // 
            this.BurnCodeBaudRateSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BurnCodeSpeed_Slow,
            this.BurnCodeSpeed_Fast});
            this.BurnCodeBaudRateSet.Name = "BurnCodeBaudRateSet";
            this.BurnCodeBaudRateSet.Size = new System.Drawing.Size(146, 22);
            this.BurnCodeBaudRateSet.Text = "燒錄速率設定";
            // 
            // BurnCodeSpeed_Slow
            // 
            this.BurnCodeSpeed_Slow.Name = "BurnCodeSpeed_Slow";
            this.BurnCodeSpeed_Slow.Size = new System.Drawing.Size(116, 22);
            this.BurnCodeSpeed_Slow.Text = "57600";
            this.BurnCodeSpeed_Slow.Click += new System.EventHandler(this.BurnCodeSpeed_Slow_Click);
            // 
            // BurnCodeSpeed_Fast
            // 
            this.BurnCodeSpeed_Fast.Name = "BurnCodeSpeed_Fast";
            this.BurnCodeSpeed_Fast.Size = new System.Drawing.Size(116, 22);
            this.BurnCodeSpeed_Fast.Text = "115200";
            this.BurnCodeSpeed_Fast.Click += new System.EventHandler(this.BurnCodeSpeed_Fast_Click);
            // 
            // ToolLine
            // 
            this.ToolLine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eraseToolStripMenuItem,
            this.aP層重啟ToolStripMenuItem,
            this.readerAP版本ToolStripMenuItem});
            this.ToolLine.Name = "ToolLine";
            this.ToolLine.Size = new System.Drawing.Size(43, 20);
            this.ToolLine.Text = "工具";
            this.ToolLine.Visible = false;
            // 
            // eraseToolStripMenuItem
            // 
            this.eraseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstErase,
            this.Erase2,
            this.Erase3,
            this.Erase4,
            this.AllErase});
            this.eraseToolStripMenuItem.Name = "eraseToolStripMenuItem";
            this.eraseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eraseToolStripMenuItem.Text = "Erase";
            this.eraseToolStripMenuItem.Visible = false;
            // 
            // FirstErase
            // 
            this.FirstErase.Name = "FirstErase";
            this.FirstErase.Size = new System.Drawing.Size(110, 22);
            this.FirstErase.Text = "第一台";
            this.FirstErase.Click += new System.EventHandler(this.FirstErase_Click);
            // 
            // Erase2
            // 
            this.Erase2.Name = "Erase2";
            this.Erase2.Size = new System.Drawing.Size(110, 22);
            this.Erase2.Text = "第二台";
            this.Erase2.Click += new System.EventHandler(this.Erase2_Click);
            // 
            // Erase3
            // 
            this.Erase3.Name = "Erase3";
            this.Erase3.Size = new System.Drawing.Size(110, 22);
            this.Erase3.Text = "第三台";
            this.Erase3.Click += new System.EventHandler(this.Erase3_Click);
            // 
            // Erase4
            // 
            this.Erase4.Name = "Erase4";
            this.Erase4.Size = new System.Drawing.Size(110, 22);
            this.Erase4.Text = "第四台";
            this.Erase4.Click += new System.EventHandler(this.Erase4_Click);
            // 
            // AllErase
            // 
            this.AllErase.Name = "AllErase";
            this.AllErase.Size = new System.Drawing.Size(110, 22);
            this.AllErase.Text = "全部";
            this.AllErase.Click += new System.EventHandler(this.AllErase_Click);
            // 
            // aP層重啟ToolStripMenuItem
            // 
            this.aP層重啟ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AP_Reboot_1,
            this.AP_Reboot_2,
            this.AP_Reboot_3,
            this.AP_Reboot_4});
            this.aP層重啟ToolStripMenuItem.Name = "aP層重啟ToolStripMenuItem";
            this.aP層重啟ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aP層重啟ToolStripMenuItem.Text = "AP層重啟";
            // 
            // AP_Reboot_1
            // 
            this.AP_Reboot_1.Name = "AP_Reboot_1";
            this.AP_Reboot_1.Size = new System.Drawing.Size(110, 22);
            this.AP_Reboot_1.Text = "第一台";
            this.AP_Reboot_1.Click += new System.EventHandler(this.AP_Reboot_1_Click);
            // 
            // AP_Reboot_2
            // 
            this.AP_Reboot_2.Name = "AP_Reboot_2";
            this.AP_Reboot_2.Size = new System.Drawing.Size(110, 22);
            this.AP_Reboot_2.Text = "第二台";
            this.AP_Reboot_2.Click += new System.EventHandler(this.AP_Reboot_2_Click);
            // 
            // AP_Reboot_3
            // 
            this.AP_Reboot_3.Name = "AP_Reboot_3";
            this.AP_Reboot_3.Size = new System.Drawing.Size(110, 22);
            this.AP_Reboot_3.Text = "第三台";
            this.AP_Reboot_3.Click += new System.EventHandler(this.AP_Reboot_3_Click);
            // 
            // AP_Reboot_4
            // 
            this.AP_Reboot_4.Name = "AP_Reboot_4";
            this.AP_Reboot_4.Size = new System.Drawing.Size(110, 22);
            this.AP_Reboot_4.Text = "第四台";
            this.AP_Reboot_4.Click += new System.EventHandler(this.AP_Reboot_4_Click);
            // 
            // readerAP版本ToolStripMenuItem
            // 
            this.readerAP版本ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.APVersionGet1,
            this.APVersionGet2,
            this.APVersionGet3,
            this.APVersionGet4});
            this.readerAP版本ToolStripMenuItem.Name = "readerAP版本ToolStripMenuItem";
            this.readerAP版本ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readerAP版本ToolStripMenuItem.Text = "ReaderAP版本";
            // 
            // APVersionGet1
            // 
            this.APVersionGet1.Name = "APVersionGet1";
            this.APVersionGet1.Size = new System.Drawing.Size(110, 22);
            this.APVersionGet1.Text = "第一台";
            this.APVersionGet1.Click += new System.EventHandler(this.APVersionGet1_Click);
            // 
            // APVersionGet2
            // 
            this.APVersionGet2.Name = "APVersionGet2";
            this.APVersionGet2.Size = new System.Drawing.Size(110, 22);
            this.APVersionGet2.Text = "第二台";
            this.APVersionGet2.Click += new System.EventHandler(this.APVersionGet2_Click);
            // 
            // APVersionGet3
            // 
            this.APVersionGet3.Name = "APVersionGet3";
            this.APVersionGet3.Size = new System.Drawing.Size(110, 22);
            this.APVersionGet3.Text = "第三台";
            this.APVersionGet3.Click += new System.EventHandler(this.APVersionGet3_Click);
            // 
            // APVersionGet4
            // 
            this.APVersionGet4.Name = "APVersionGet4";
            this.APVersionGet4.Size = new System.Drawing.Size(110, 22);
            this.APVersionGet4.Text = "第四台";
            this.APVersionGet4.Click += new System.EventHandler(this.APVersionGet4_Click);
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_VersionUpdate,
            this.操作說明ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // Help_VersionUpdate
            // 
            this.Help_VersionUpdate.Name = "Help_VersionUpdate";
            this.Help_VersionUpdate.Size = new System.Drawing.Size(146, 22);
            this.Help_VersionUpdate.Text = "版本變更事項";
            this.Help_VersionUpdate.Click += new System.EventHandler(this.Help_VersionUpdate_Click);
            // 
            // 操作說明ToolStripMenuItem
            // 
            this.操作說明ToolStripMenuItem.Name = "操作說明ToolStripMenuItem";
            this.操作說明ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.操作說明ToolStripMenuItem.Text = "操作說明";
            this.操作說明ToolStripMenuItem.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComPort_CB1);
            this.groupBox1.Controls.Add(this.Start_BT1);
            this.groupBox1.Controls.Add(this.DISC1);
            this.groupBox1.Controls.Add(this.Status_Lab1);
            this.groupBox1.Controls.Add(this.Color_Lab1);
            this.groupBox1.Controls.Add(this.RTB1);
            this.groupBox1.Controls.Add(this.Scroll_CB1);
            this.groupBox1.Controls.Add(this.Clear_BT1);
            this.groupBox1.Controls.Add(this.ProgressBar1);
            this.groupBox1.Controls.Add(this.Reboot_BT1);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(2, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 461);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "第一台";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComPort_CB2);
            this.groupBox2.Controls.Add(this.Start_BT2);
            this.groupBox2.Controls.Add(this.DISC2);
            this.groupBox2.Controls.Add(this.Color_Lab2);
            this.groupBox2.Controls.Add(this.Status_Lab2);
            this.groupBox2.Controls.Add(this.RTB2);
            this.groupBox2.Controls.Add(this.Scroll_CB2);
            this.groupBox2.Controls.Add(this.Clear_BT2);
            this.groupBox2.Controls.Add(this.ProgressBar2);
            this.groupBox2.Controls.Add(this.Reboot_BT2);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(212, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 461);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "第二台";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComPort_CB3);
            this.groupBox3.Controls.Add(this.DISC3);
            this.groupBox3.Controls.Add(this.Start_BT3);
            this.groupBox3.Controls.Add(this.Status_Lab3);
            this.groupBox3.Controls.Add(this.Color_Lab3);
            this.groupBox3.Controls.Add(this.ProgressBar3);
            this.groupBox3.Controls.Add(this.RTB3);
            this.groupBox3.Controls.Add(this.Scroll_CB3);
            this.groupBox3.Controls.Add(this.Reboot_BT3);
            this.groupBox3.Controls.Add(this.Clear_BT3);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(422, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 461);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "第三台";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComPort_CB4);
            this.groupBox4.Controls.Add(this.DISC4);
            this.groupBox4.Controls.Add(this.Start_BT4);
            this.groupBox4.Controls.Add(this.ProgressBar4);
            this.groupBox4.Controls.Add(this.Status_Lab4);
            this.groupBox4.Controls.Add(this.Reboot_BT4);
            this.groupBox4.Controls.Add(this.Color_Lab4);
            this.groupBox4.Controls.Add(this.RTB4);
            this.groupBox4.Controls.Add(this.Scroll_CB4);
            this.groupBox4.Controls.Add(this.Clear_BT4);
            this.groupBox4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(632, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 461);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "第四台";
            // 
            // StatusTitle
            // 
            this.StatusTitle.BackColor = System.Drawing.SystemColors.Window;
            this.StatusTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StatusTitle.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusTitle.Location = new System.Drawing.Point(262, 0);
            this.StatusTitle.Multiline = true;
            this.StatusTitle.Name = "StatusTitle";
            this.StatusTitle.ReadOnly = true;
            this.StatusTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusTitle.Size = new System.Drawing.Size(566, 24);
            this.StatusTitle.TabIndex = 80;
            this.StatusTitle.Text = "於程式修改";
            // 
            // AllInOne_Btn
            // 
            this.AllInOne_Btn.Enabled = false;
            this.AllInOne_Btn.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AllInOne_Btn.Location = new System.Drawing.Point(295, 542);
            this.AllInOne_Btn.Name = "AllInOne_Btn";
            this.AllInOne_Btn.Size = new System.Drawing.Size(238, 68);
            this.AllInOne_Btn.TabIndex = 81;
            this.AllInOne_Btn.Text = "一鍵 Start";
            this.AllInOne_Btn.UseVisualStyleBackColor = true;
            this.AllInOne_Btn.Click += new System.EventHandler(this.AllInOne_Btn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.DelayTimeSet);
            this.groupBox6.Controls.Add(this.TreadReadyStatusCount_Lab);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(1145, 153);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(153, 100);
            this.groupBox6.TabIndex = 83;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "運行參數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "延遲間距";
            // 
            // DelayTimeSet
            // 
            this.DelayTimeSet.Enabled = false;
            this.DelayTimeSet.Location = new System.Drawing.Point(78, 37);
            this.DelayTimeSet.Name = "DelayTimeSet";
            this.DelayTimeSet.Size = new System.Drawing.Size(69, 22);
            this.DelayTimeSet.TabIndex = 1;
            this.DelayTimeSet.TextChanged += new System.EventHandler(this.DelayTimeSet_TextChanged);
            // 
            // TreadReadyStatusCount_Lab
            // 
            this.TreadReadyStatusCount_Lab.AutoSize = true;
            this.TreadReadyStatusCount_Lab.Location = new System.Drawing.Point(131, 22);
            this.TreadReadyStatusCount_Lab.Name = "TreadReadyStatusCount_Lab";
            this.TreadReadyStatusCount_Lab.Size = new System.Drawing.Size(11, 12);
            this.TreadReadyStatusCount_Lab.TabIndex = 0;
            this.TreadReadyStatusCount_Lab.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "TreadReadyStatusCount:";
            // 
            // AllAPReboot_Btn
            // 
            this.AllAPReboot_Btn.Location = new System.Drawing.Point(1145, 275);
            this.AllAPReboot_Btn.Name = "AllAPReboot_Btn";
            this.AllAPReboot_Btn.Size = new System.Drawing.Size(98, 40);
            this.AllAPReboot_Btn.TabIndex = 84;
            this.AllAPReboot_Btn.Text = "AllAPReboot";
            this.AllAPReboot_Btn.UseVisualStyleBackColor = true;
            this.AllAPReboot_Btn.Click += new System.EventHandler(this.AllAPReboot_Btn_Click);
            // 
            // GetRC531No
            // 
            this.GetRC531No.Name = "GetRC531No";
            this.GetRC531No.Size = new System.Drawing.Size(180, 22);
            this.GetRC531No.Text = "射頻IC序號讀取";
            this.GetRC531No.Click += new System.EventHandler(this.射頻IC序號讀取ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(842, 615);
            this.Controls.Add(this.AllAPReboot_Btn);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.AllInOne_Btn);
            this.Controls.Add(this.StatusTitle);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.file_box);
            this.Controls.Add(this.Browse_BT1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "標題文字於程式修改";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ComPort_CB1;
        private System.Windows.Forms.ComboBox ComPort_CB2;
        private System.Windows.Forms.ComboBox ComPort_CB3;
        private System.Windows.Forms.ComboBox ComPort_CB4;
        private System.Windows.Forms.Button Reboot_BT1;
        private System.Windows.Forms.Button Browse_BT1;
        private System.Windows.Forms.Button Start_BT1;
        private System.Windows.Forms.Button Start_BT2;
        private System.Windows.Forms.Button Start_BT3;
        private System.Windows.Forms.Button Start_BT4;
        private System.Windows.Forms.RichTextBox RTB1;
        private System.Windows.Forms.RichTextBox RTB2;
        private System.Windows.Forms.RichTextBox RTB3;
        private System.Windows.Forms.RichTextBox RTB4;
        private System.Windows.Forms.Button Clear_BT1;
        private System.Windows.Forms.Button Clear_BT2;
        private System.Windows.Forms.Button Clear_BT3;
        private System.Windows.Forms.Button Clear_BT4;
        private System.Windows.Forms.OpenFileDialog openFile1;
        private System.Windows.Forms.CheckBox Scroll_CB1;
        private System.Windows.Forms.CheckBox Scroll_CB2;
        private System.Windows.Forms.CheckBox Scroll_CB3;
        private System.Windows.Forms.CheckBox Scroll_CB4;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.IO.Ports.SerialPort serialPort3;
        private System.IO.Ports.SerialPort serialPort4;
        private System.Windows.Forms.TextBox file_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DISC1;
        private System.Windows.Forms.Button DISC2;
        private System.Windows.Forms.Button DISC3;
        private System.Windows.Forms.Button DISC4;
        private System.Windows.Forms.Button Reboot_BT2;
        private System.Windows.Forms.Button Reboot_BT3;
        private System.Windows.Forms.Button Reboot_BT4;
        public System.Windows.Forms.ProgressBar ProgressBar1;
        public System.Windows.Forms.ProgressBar ProgressBar2;
        public System.Windows.Forms.ProgressBar ProgressBar3;
        public System.Windows.Forms.ProgressBar ProgressBar4;
        private System.Windows.Forms.Label Color_Lab1;
        private System.Windows.Forms.Label Color_Lab2;
        private System.Windows.Forms.Label Color_Lab3;
        private System.Windows.Forms.Label Color_Lab4;
        private System.Windows.Forms.Label Status_Lab1;
        private System.Windows.Forms.Label Status_Lab2;
        private System.Windows.Forms.Label Status_Lab3;
        private System.Windows.Forms.Label Status_Lab4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 速率設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReaderApBaudSet;
        private System.Windows.Forms.ToolStripMenuItem BurnCodeBaudRateSet;
        private System.Windows.Forms.ToolStripMenuItem ToolLine;
        private System.Windows.Forms.ToolStripMenuItem eraseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstErase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help_VersionUpdate;
        private System.Windows.Forms.ToolStripMenuItem 燒錄模式設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NormalMode;
        private System.Windows.Forms.ToolStripMenuItem NoneAppMode;
        private System.Windows.Forms.ToolStripMenuItem BaudSetTo57600;
        private System.Windows.Forms.ToolStripMenuItem BaudSetTo115200;
        private System.Windows.Forms.ToolStripMenuItem BurnCodeSpeed_Slow;
        private System.Windows.Forms.ToolStripMenuItem BurnCodeSpeed_Fast;
        private System.Windows.Forms.ToolStripMenuItem AP_Reboot_1;
        private System.Windows.Forms.ToolStripMenuItem AP_Reboot_2;
        private System.Windows.Forms.ToolStripMenuItem AP_Reboot_3;
        private System.Windows.Forms.ToolStripMenuItem AP_Reboot_4;
        private System.Windows.Forms.ToolStripMenuItem Erase2;
        private System.Windows.Forms.ToolStripMenuItem Erase3;
        private System.Windows.Forms.ToolStripMenuItem Erase4;
        private System.Windows.Forms.ToolStripMenuItem aP層重啟ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EraseMode;
        private System.Windows.Forms.TextBox StatusTitle;
        private System.Windows.Forms.ToolStripMenuItem AutoErase_Mode;
        private System.Windows.Forms.ToolStripMenuItem AllErase;
        private System.Windows.Forms.Button AllInOne_Btn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label TreadReadyStatusCount_Lab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DelayTimeSet;
        private System.Windows.Forms.ToolStripMenuItem readerAP版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem APVersionGet1;
        private System.Windows.Forms.ToolStripMenuItem APVersionGet2;
        private System.Windows.Forms.ToolStripMenuItem APVersionGet3;
        private System.Windows.Forms.ToolStripMenuItem APVersionGet4;
        private System.Windows.Forms.ToolStripMenuItem 操作說明ToolStripMenuItem;
        private System.Windows.Forms.Button AllAPReboot_Btn;
        private System.Windows.Forms.ToolStripMenuItem RTCtestMode;
        private System.Windows.Forms.ToolStripMenuItem GetRC531No;
    }
}

