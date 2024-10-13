namespace YF.MWS.Win.View.User
{
    partial class FrmSendEmail {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSendEmail));
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblAuthCode = new DevExpress.XtraEditors.LabelControl();
            this.cbEmailServer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtToAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtSendTime = new DevExpress.XtraEditors.TimeEdit();
            this.rdSendType = new DevExpress.XtraEditors.RadioGroup();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cbReportType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEmailServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtSendTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdSendType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbReportType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerify
            // 
            this.btnVerify.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVerify.ImageOptions.Image")));
            this.btnVerify.Location = new System.Drawing.Point(299, 267);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 18;
            this.btnVerify.Text = "保存设置";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(103, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(134, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.Location = new System.Drawing.Point(61, 102);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(36, 14);
            this.lblAuthCode.TabIndex = 16;
            this.lblAuthCode.Text = "密  码:";
            // 
            // cbEmailServer
            // 
            this.cbEmailServer.EditValue = "smtp.qq.com";
            this.cbEmailServer.Location = new System.Drawing.Point(103, 22);
            this.cbEmailServer.Name = "cbEmailServer";
            this.cbEmailServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEmailServer.Properties.Items.AddRange(new object[] {
            "smtp.qq.com",
            "smtp.163.com",
            "smtp.126.com",
            "smtp.sina.com.cn",
            "smtp.mail.yahoo.com",
            "smtp.sohu.com"});
            this.cbEmailServer.Size = new System.Drawing.Size(134, 20);
            this.cbEmailServer.TabIndex = 30;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "邮件服务器:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(57, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "用户名:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(103, 62);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(134, 20);
            this.txtUserName.TabIndex = 17;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 137);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 14);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "收件人:";
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(103, 134);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(134, 20);
            this.txtToAddress.TabIndex = 17;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(320, 23);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(165, 20);
            this.txtTitle.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(285, 25);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 14);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "标题:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(285, 62);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 14);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "正文:";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(319, 60);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(166, 94);
            this.txtContent.TabIndex = 31;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtSendTime);
            this.groupControl1.Controls.Add(this.rdSendType);
            this.groupControl1.Controls.Add(this.checkEdit1);
            this.groupControl1.Location = new System.Drawing.Point(12, 168);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(232, 173);
            this.groupControl1.TabIndex = 32;
            this.groupControl1.Text = "定时发送";
            // 
            // dtSendTime
            // 
            this.dtSendTime.EditValue = new System.DateTime(2023, 12, 16, 0, 0, 0, 0);
            this.dtSendTime.Location = new System.Drawing.Point(129, 72);
            this.dtSendTime.Name = "dtSendTime";
            this.dtSendTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSendTime.Size = new System.Drawing.Size(82, 20);
            this.dtSendTime.TabIndex = 2;
            // 
            // rdSendType
            // 
            this.rdSendType.EditValue = "day";
            this.rdSendType.Location = new System.Drawing.Point(20, 59);
            this.rdSendType.Name = "rdSendType";
            this.rdSendType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdSendType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("day", "每天定时发送"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("hour", "每小时自动发送")});
            this.rdSendType.Size = new System.Drawing.Size(205, 83);
            this.rdSendType.TabIndex = 1;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(20, 32);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "自动发送";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(400, 267);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "发送";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(277, 203);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "报表类型:";
            // 
            // cbReportType
            // 
            this.cbReportType.EditValue = "日明细报表";
            this.cbReportType.Location = new System.Drawing.Point(335, 200);
            this.cbReportType.Name = "cbReportType";
            this.cbReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbReportType.Properties.Items.AddRange(new object[] {
            "日明细报表",
            "周明细报表",
            "月明细报表",
            "年明细报表"});
            this.cbReportType.Size = new System.Drawing.Size(149, 20);
            this.cbReportType.TabIndex = 30;
            // 
            // FrmSendEmail
            // 
            this.AcceptButton = this.btnVerify;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 344);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cbReportType);
            this.Controls.Add(this.cbEmailServer);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtToAddress);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.lblAuthCode);
            this.Controls.Add(this.txtContent);
            this.IconOptions.LargeImage = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendEmail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件发送";
            this.Load += new System.EventHandler(this.FrmAuth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEmailServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtSendTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdSendType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbReportType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblAuthCode;
        private DevExpress.XtraEditors.ComboBoxEdit cbEmailServer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtToAddress;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.RadioGroup rdSendType;
        private DevExpress.XtraEditors.TimeEdit dtSendTime;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cbReportType;
    }
}