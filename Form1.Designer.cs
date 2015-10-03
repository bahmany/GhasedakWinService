namespace GhasedakWinService
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmr_soapclientRecived = new System.Windows.Forms.Timer(this.components);
            this.tmr_InternetConnectionChecker = new System.Windows.Forms.Timer(this.components);
            this.tmr_SMSConnectionChecker = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmr_logChecker = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_logger = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_LastRowIndex = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_HostAddr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_TelNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tmr_schadualSmsGroup = new System.Windows.Forms.Timer(this.components);
            this.mainDataModule = new GhasedakWinService.MainDataModule();
            this.tblsmssendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_sms_sendTableAdapter = new GhasedakWinService.MainDataModuleTableAdapters.tbl_sms_sendTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblsmssendBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tmr_soapclientRecived
            // 
            this.tmr_soapclientRecived.Enabled = true;
            this.tmr_soapclientRecived.Interval = 4000;
            this.tmr_soapclientRecived.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmr_InternetConnectionChecker
            // 
            this.tmr_InternetConnectionChecker.Enabled = true;
            this.tmr_InternetConnectionChecker.Interval = 1000;
            this.tmr_InternetConnectionChecker.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tmr_SMSConnectionChecker
            // 
            this.tmr_SMSConnectionChecker.Enabled = true;
            this.tmr_SMSConnectionChecker.Interval = 3000;
            this.tmr_SMSConnectionChecker.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "سرور پیام رسان";
            this.notifyIcon1.Visible = true;
            // 
            // tmr_logChecker
            // 
            this.tmr_logChecker.Enabled = true;
            this.tmr_logChecker.Interval = 1000;
            this.tmr_logChecker.Tick += new System.EventHandler(this.tmr_logChecker_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 61);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(284, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Disconnected";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 35);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "ارتباط با سرویس پیام کوتاه :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(334, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ارتباط با اینترنت :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(202, 9);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(310, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "در صورت بسته شدن این فرم سیستم آنلاین کار نخواهد کرد";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 209);
            this.panel2.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 209);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb_logger);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(507, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "لوگ ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb_logger
            // 
            this.lb_logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_logger.FormattingEnabled = true;
            this.lb_logger.Location = new System.Drawing.Point(3, 3);
            this.lb_logger.Name = "lb_logger";
            this.lb_logger.Size = new System.Drawing.Size(501, 173);
            this.lb_logger.TabIndex = 10;
            this.lb_logger.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.lb_logger_ControlAdded);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_LastRowIndex);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txt_HostAddr);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txt_Pass);
            this.tabPage2.Controls.Add(this.txt_UserName);
            this.tabPage2.Controls.Add(this.txt_TelNo);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(507, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تنظیمات";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // txt_LastRowIndex
            // 
            this.txt_LastRowIndex.Location = new System.Drawing.Point(246, 118);
            this.txt_LastRowIndex.Name = "txt_LastRowIndex";
            this.txt_LastRowIndex.PasswordChar = '*';
            this.txt_LastRowIndex.Size = new System.Drawing.Size(91, 21);
            this.txt_LastRowIndex.TabIndex = 10;
            this.txt_LastRowIndex.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(343, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Last Row Index";
            // 
            // txt_HostAddr
            // 
            this.txt_HostAddr.Enabled = false;
            this.txt_HostAddr.Location = new System.Drawing.Point(246, 12);
            this.txt_HostAddr.Name = "txt_HostAddr";
            this.txt_HostAddr.Size = new System.Drawing.Size(100, 21);
            this.txt_HostAddr.TabIndex = 8;
            this.txt_HostAddr.Text = "http://sms1000.ir";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(352, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "آدرس سرویس";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(246, 93);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.PasswordChar = '*';
            this.txt_Pass.Size = new System.Drawing.Size(100, 21);
            this.txt_Pass.TabIndex = 6;
            this.txt_Pass.UseSystemPasswordChar = true;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(246, 66);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.PasswordChar = '*';
            this.txt_UserName.Size = new System.Drawing.Size(100, 21);
            this.txt_UserName.TabIndex = 5;
            this.txt_UserName.UseSystemPasswordChar = true;
            // 
            // txt_TelNo
            // 
            this.txt_TelNo.Location = new System.Drawing.Point(246, 39);
            this.txt_TelNo.Name = "txt_TelNo";
            this.txt_TelNo.Size = new System.Drawing.Size(100, 21);
            this.txt_TelNo.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "تائید";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "رمز عبور";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "نام کاربری";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "شماره مرکز";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(507, 183);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "شرایط خاص";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(333, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "دریافت آخرین ردیف پیام کوتاه";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tmr_schadualSmsGroup
            // 
            this.tmr_schadualSmsGroup.Enabled = true;
            this.tmr_schadualSmsGroup.Interval = 1000;
            this.tmr_schadualSmsGroup.Tick += new System.EventHandler(this.tmr_schadualSmsGroup_Tick);
            // 
            // mainDataModule
            // 
            this.mainDataModule.DataSetName = "MainDataModule";
            this.mainDataModule.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblsmssendBindingSource
            // 
            this.tblsmssendBindingSource.DataMember = "tbl_sms_send";
            this.tblsmssendBindingSource.DataSource = this.mainDataModule;
            // 
            // tbl_sms_sendTableAdapter
            // 
            this.tbl_sms_sendTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(515, 270);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سرور";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblsmssendBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr_soapclientRecived;
        private MainDataModule mainDataModule;
        private System.Windows.Forms.BindingSource tblsmssendBindingSource;
        private MainDataModuleTableAdapters.tbl_sms_sendTableAdapter tbl_sms_sendTableAdapter;
        private System.Windows.Forms.Timer tmr_InternetConnectionChecker;
        private System.Windows.Forms.Timer tmr_SMSConnectionChecker;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer tmr_logChecker;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer tmr_schadualSmsGroup;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.ListBox lb_logger;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_HostAddr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_TelNo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_LastRowIndex;
        private System.Windows.Forms.Label label10;
    }
}

