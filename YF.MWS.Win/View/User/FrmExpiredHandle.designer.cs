namespace YF.MWS.Win.View.User
{
    partial class FrmExpiredHandle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExpiredHandle));
            this.tabHandle = new DevExpress.XtraTab.XtraTabControl();
            this.pageSms = new DevExpress.XtraTab.XtraTabPage();
            this.teSmsRealName = new DevExpress.XtraEditors.TextEdit();
            this.lblSmsRealName = new DevExpress.XtraEditors.LabelControl();
            this.teSmsAuthCode = new DevExpress.XtraEditors.TextEdit();
            this.teSmsCellphone = new DevExpress.XtraEditors.TextEdit();
            this.btnSendSmsAuthCode = new DevExpress.XtraEditors.SimpleButton();
            this.btnVerifySmsAuthCode = new DevExpress.XtraEditors.SimpleButton();
            this.lblSmsAuthCode = new DevExpress.XtraEditors.LabelControl();
            this.lblSmsCellphone = new DevExpress.XtraEditors.LabelControl();
            this.pageAuth = new DevExpress.XtraTab.XtraTabPage();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.lblAuthCode = new DevExpress.XtraEditors.LabelControl();
            this.teRandCode = new DevExpress.XtraEditors.TextEdit();
            this.lblRandCode = new DevExpress.XtraEditors.LabelControl();
            this.teAuthCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabHandle)).BeginInit();
            this.tabHandle.SuspendLayout();
            this.pageSms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSmsRealName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSmsAuthCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSmsCellphone.Properties)).BeginInit();
            this.pageAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabHandle
            // 
            this.tabHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHandle.Location = new System.Drawing.Point(0, 0);
            this.tabHandle.Name = "tabHandle";
            this.tabHandle.SelectedTabPage = this.pageSms;
            this.tabHandle.Size = new System.Drawing.Size(513, 276);
            this.tabHandle.TabIndex = 1;
            this.tabHandle.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageSms,
            this.pageAuth});
            // 
            // pageSms
            // 
            this.pageSms.Controls.Add(this.teSmsRealName);
            this.pageSms.Controls.Add(this.lblSmsRealName);
            this.pageSms.Controls.Add(this.teSmsAuthCode);
            this.pageSms.Controls.Add(this.teSmsCellphone);
            this.pageSms.Controls.Add(this.btnSendSmsAuthCode);
            this.pageSms.Controls.Add(this.btnVerifySmsAuthCode);
            this.pageSms.Controls.Add(this.lblSmsAuthCode);
            this.pageSms.Controls.Add(this.lblSmsCellphone);
            this.pageSms.Name = "pageSms";
            this.pageSms.Size = new System.Drawing.Size(507, 247);
            this.pageSms.Text = "短息验证";
            // 
            // teSmsRealName
            // 
            this.teSmsRealName.Location = new System.Drawing.Point(105, 32);
            this.teSmsRealName.Name = "teSmsRealName";
            this.teSmsRealName.Size = new System.Drawing.Size(217, 20);
            this.teSmsRealName.TabIndex = 31;
            // 
            // lblSmsRealName
            // 
            this.lblSmsRealName.Location = new System.Drawing.Point(46, 35);
            this.lblSmsRealName.Name = "lblSmsRealName";
            this.lblSmsRealName.Size = new System.Drawing.Size(28, 14);
            this.lblSmsRealName.TabIndex = 30;
            this.lblSmsRealName.Text = "姓名:";
            // 
            // teSmsAuthCode
            // 
            this.teSmsAuthCode.Location = new System.Drawing.Point(105, 113);
            this.teSmsAuthCode.Name = "teSmsAuthCode";
            this.teSmsAuthCode.Size = new System.Drawing.Size(217, 20);
            this.teSmsAuthCode.TabIndex = 29;
            // 
            // teSmsCellphone
            // 
            this.teSmsCellphone.Location = new System.Drawing.Point(105, 74);
            this.teSmsCellphone.Name = "teSmsCellphone";
            this.teSmsCellphone.Size = new System.Drawing.Size(217, 20);
            this.teSmsCellphone.TabIndex = 28;
            // 
            // btnSendSmsAuthCode
            // 
            this.btnSendSmsAuthCode.Image = global::YF.MWS.Win.Properties.Resources.send_16x16;
            this.btnSendSmsAuthCode.Location = new System.Drawing.Point(358, 68);
            this.btnSendSmsAuthCode.Name = "btnSendSmsAuthCode";
            this.btnSendSmsAuthCode.Size = new System.Drawing.Size(115, 30);
            this.btnSendSmsAuthCode.TabIndex = 27;
            this.btnSendSmsAuthCode.Text = "发送验证码";
            this.btnSendSmsAuthCode.Click += new System.EventHandler(this.btnSendSmsAuthCode_Click);
            // 
            // btnVerifySmsAuthCode
            // 
            this.btnVerifySmsAuthCode.Image = global::YF.MWS.Win.Properties.Resources.security_16x16;
            this.btnVerifySmsAuthCode.Location = new System.Drawing.Point(105, 160);
            this.btnVerifySmsAuthCode.Name = "btnVerifySmsAuthCode";
            this.btnVerifySmsAuthCode.Size = new System.Drawing.Size(80, 30);
            this.btnVerifySmsAuthCode.TabIndex = 26;
            this.btnVerifySmsAuthCode.Text = "验证";
            this.btnVerifySmsAuthCode.Click += new System.EventHandler(this.btnVerifySmsAuthCode_Click);
            // 
            // lblSmsAuthCode
            // 
            this.lblSmsAuthCode.Location = new System.Drawing.Point(46, 113);
            this.lblSmsAuthCode.Name = "lblSmsAuthCode";
            this.lblSmsAuthCode.Size = new System.Drawing.Size(40, 14);
            this.lblSmsAuthCode.TabIndex = 24;
            this.lblSmsAuthCode.Text = "验证码:";
            // 
            // lblSmsCellphone
            // 
            this.lblSmsCellphone.Location = new System.Drawing.Point(46, 77);
            this.lblSmsCellphone.Name = "lblSmsCellphone";
            this.lblSmsCellphone.Size = new System.Drawing.Size(40, 14);
            this.lblSmsCellphone.TabIndex = 23;
            this.lblSmsCellphone.Text = "手机号:";
            // 
            // pageAuth
            // 
            this.pageAuth.Controls.Add(this.teAuthCode);
            this.pageAuth.Controls.Add(this.teRandCode);
            this.pageAuth.Controls.Add(this.lblRandCode);
            this.pageAuth.Controls.Add(this.btnVerify);
            this.pageAuth.Controls.Add(this.lblAuthCode);
            this.pageAuth.Name = "pageAuth";
            this.pageAuth.Size = new System.Drawing.Size(507, 247);
            this.pageAuth.Text = "授权码验证";
            // 
            // btnVerify
            // 
            this.btnVerify.Image = global::YF.MWS.Win.Properties.Resources.security_16x16;
            this.btnVerify.Location = new System.Drawing.Point(110, 130);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(80, 30);
            this.btnVerify.TabIndex = 26;
            this.btnVerify.Text = "验证";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.Location = new System.Drawing.Point(40, 85);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(40, 14);
            this.lblAuthCode.TabIndex = 24;
            this.lblAuthCode.Text = "授权码:";
            // 
            // teRandCode
            // 
            this.teRandCode.Location = new System.Drawing.Point(110, 40);
            this.teRandCode.Name = "teRandCode";
            this.teRandCode.Properties.ReadOnly = true;
            this.teRandCode.Size = new System.Drawing.Size(239, 20);
            this.teRandCode.TabIndex = 28;
            // 
            // lblRandCode
            // 
            this.lblRandCode.Location = new System.Drawing.Point(40, 43);
            this.lblRandCode.Name = "lblRandCode";
            this.lblRandCode.Size = new System.Drawing.Size(40, 14);
            this.lblRandCode.TabIndex = 27;
            this.lblRandCode.Text = "随机码:";
            // 
            // teAuthCode
            // 
            this.teAuthCode.Location = new System.Drawing.Point(110, 82);
            this.teAuthCode.Name = "teAuthCode";
            this.teAuthCode.Size = new System.Drawing.Size(239, 20);
            this.teAuthCode.TabIndex = 29;
            // 
            // FrmExpiredHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 276);
            this.Controls.Add(this.tabHandle);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmExpiredHandle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件升级维护";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExpiredHandle_FormClosing);
            this.Load += new System.EventHandler(this.FrmExpiredHandle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabHandle)).EndInit();
            this.tabHandle.ResumeLayout(false);
            this.pageSms.ResumeLayout(false);
            this.pageSms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSmsRealName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSmsAuthCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSmsCellphone.Properties)).EndInit();
            this.pageAuth.ResumeLayout(false);
            this.pageAuth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabHandle;
        private DevExpress.XtraTab.XtraTabPage pageSms;
        private DevExpress.XtraEditors.TextEdit teSmsRealName;
        private DevExpress.XtraEditors.LabelControl lblSmsRealName;
        private DevExpress.XtraEditors.TextEdit teSmsAuthCode;
        private DevExpress.XtraEditors.TextEdit teSmsCellphone;
        private DevExpress.XtraEditors.SimpleButton btnSendSmsAuthCode;
        private DevExpress.XtraEditors.SimpleButton btnVerifySmsAuthCode;
        private DevExpress.XtraEditors.LabelControl lblSmsAuthCode;
        private DevExpress.XtraEditors.LabelControl lblSmsCellphone;
        private DevExpress.XtraTab.XtraTabPage pageAuth;
        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.LabelControl lblAuthCode;
        private DevExpress.XtraEditors.TextEdit teAuthCode;
        private DevExpress.XtraEditors.TextEdit teRandCode;
        private DevExpress.XtraEditors.LabelControl lblRandCode;
    }
}