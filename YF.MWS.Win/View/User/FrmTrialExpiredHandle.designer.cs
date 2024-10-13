namespace YF.MWS.Win.View.User
{
    partial class FrmTrialExpiredHandle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrialExpiredHandle));
            this.tabHandle = new DevExpress.XtraTab.XtraTabControl();
            this.pageQrCode = new DevExpress.XtraTab.XtraTabPage();
            this.pageAuth = new DevExpress.XtraTab.XtraTabPage();
            this.teAuthCode = new DevExpress.XtraEditors.TextEdit();
            this.teRandCode = new DevExpress.XtraEditors.TextEdit();
            this.lblRandCode = new DevExpress.XtraEditors.LabelControl();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.lblAuthCode = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabHandle)).BeginInit();
            this.tabHandle.SuspendLayout();
            this.pageAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabHandle
            // 
            this.tabHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHandle.Location = new System.Drawing.Point(0, 0);
            this.tabHandle.Name = "tabHandle";
            this.tabHandle.SelectedTabPage = this.pageQrCode;
            this.tabHandle.Size = new System.Drawing.Size(513, 298);
            this.tabHandle.TabIndex = 0;
            this.tabHandle.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageAuth,
            this.pageQrCode});
            // 
            // pageQrCode
            // 
            this.pageQrCode.Name = "pageQrCode";
            this.pageQrCode.Size = new System.Drawing.Size(507, 269);
            this.pageQrCode.Text = "二维码验证";
            // 
            // pageAuth
            // 
            this.pageAuth.Controls.Add(this.teAuthCode);
            this.pageAuth.Controls.Add(this.teRandCode);
            this.pageAuth.Controls.Add(this.lblRandCode);
            this.pageAuth.Controls.Add(this.btnVerify);
            this.pageAuth.Controls.Add(this.lblAuthCode);
            this.pageAuth.Name = "pageAuth";
            this.pageAuth.Size = new System.Drawing.Size(507, 269);
            this.pageAuth.Text = "授权码验证";
            // 
            // teAuthCode
            // 
            this.teAuthCode.Location = new System.Drawing.Point(101, 97);
            this.teAuthCode.Name = "teAuthCode";
            this.teAuthCode.Size = new System.Drawing.Size(239, 20);
            this.teAuthCode.TabIndex = 32;
            // 
            // teRandCode
            // 
            this.teRandCode.Location = new System.Drawing.Point(101, 55);
            this.teRandCode.Name = "teRandCode";
            this.teRandCode.Properties.ReadOnly = true;
            this.teRandCode.Size = new System.Drawing.Size(239, 20);
            this.teRandCode.TabIndex = 31;
            // 
            // lblRandCode
            // 
            this.lblRandCode.Location = new System.Drawing.Point(31, 58);
            this.lblRandCode.Name = "lblRandCode";
            this.lblRandCode.Size = new System.Drawing.Size(40, 14);
            this.lblRandCode.TabIndex = 30;
            this.lblRandCode.Text = "随机码:";
            // 
            // btnVerify
            // 
            this.btnVerify.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.security_16x16;
            this.btnVerify.Location = new System.Drawing.Point(101, 142);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(80, 30);
            this.btnVerify.TabIndex = 26;
            this.btnVerify.Text = "验证";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.Location = new System.Drawing.Point(31, 94);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(40, 14);
            this.lblAuthCode.TabIndex = 24;
            this.lblAuthCode.Text = "授权码:";
            // 
            // FrmTrialExpiredHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 298);
            this.Controls.Add(this.tabHandle);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmTrialExpiredHandle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "延长试用期";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTrialExpiredHandle_FormClosing);
            this.Load += new System.EventHandler(this.FrmTrialExpiredHandle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabHandle)).EndInit();
            this.tabHandle.ResumeLayout(false);
            this.pageAuth.ResumeLayout(false);
            this.pageAuth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabHandle;
        private DevExpress.XtraTab.XtraTabPage pageQrCode;
        private DevExpress.XtraTab.XtraTabPage pageAuth;
        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.LabelControl lblAuthCode;
        private DevExpress.XtraEditors.TextEdit teAuthCode;
        private DevExpress.XtraEditors.TextEdit teRandCode;
        private DevExpress.XtraEditors.LabelControl lblRandCode;
    }
}