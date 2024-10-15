namespace YF.MWS.Win.View.User
{
    partial class FrmUpPwd {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpPwd));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teCfmPwd = new DevExpress.XtraEditors.TextEdit();
            this.teOldPwd = new DevExpress.XtraEditors.TextEdit();
            this.teNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.lblCfmPwd = new DevExpress.XtraEditors.LabelControl();
            this.lblNewPwd = new DevExpress.XtraEditors.LabelControl();
            this.btnChangePwd = new DevExpress.XtraEditors.SimpleButton();
            this.lblOldPwd = new DevExpress.XtraEditors.LabelControl();
            this.lbUser = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCfmPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOldPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teCfmPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teCfmPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teCfmPwd.Location = new System.Drawing.Point(133, 125);
            this.teCfmPwd.Name = "teCfmPwd";
            this.teCfmPwd.Size = new System.Drawing.Size(154, 20);
            this.teCfmPwd.TabIndex = 50;
            // 
            // teOldPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teOldPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teOldPwd.Location = new System.Drawing.Point(133, 55);
            this.teOldPwd.Name = "teOldPwd";
            this.teOldPwd.Size = new System.Drawing.Size(154, 20);
            this.teOldPwd.TabIndex = 48;
            this.teOldPwd.Tag = "";
            // 
            // teNewPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teNewPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teNewPwd.Location = new System.Drawing.Point(133, 90);
            this.teNewPwd.Name = "teNewPwd";
            this.teNewPwd.Size = new System.Drawing.Size(154, 20);
            this.teNewPwd.TabIndex = 45;
            // 
            // lblCfmPwd
            // 
            this.lblCfmPwd.Location = new System.Drawing.Point(38, 128);
            this.lblCfmPwd.Name = "lblCfmPwd";
            this.lblCfmPwd.Size = new System.Drawing.Size(64, 14);
            this.lblCfmPwd.TabIndex = 49;
            this.lblCfmPwd.Text = "确认新密码:";
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.Location = new System.Drawing.Point(38, 93);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(40, 14);
            this.lblNewPwd.TabIndex = 44;
            this.lblNewPwd.Text = "新密码:";
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(133, 167);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangePwd.TabIndex = 46;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.Location = new System.Drawing.Point(38, 58);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(40, 14);
            this.lblOldPwd.TabIndex = 47;
            this.lblOldPwd.Text = "原密码:";
            // 
            // lbUser
            // 
            this.lbUser.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbUser.Location = new System.Drawing.Point(0, 243);
            this.lbUser.Name = "lbUser";
            this.lbUser.Padding = new System.Windows.Forms.Padding(3);
            this.lbUser.Size = new System.Drawing.Size(358, 26);
            this.lbUser.TabIndex = 49;
            this.lbUser.Text = "你的用户身份是:";
            // 
            // FrmUpPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 269);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.lblCfmPwd);
            this.Controls.Add(this.teCfmPwd);
            this.Controls.Add(this.teOldPwd);
            this.Controls.Add(this.lblOldPwd);
            this.Controls.Add(this.lblNewPwd);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.teNewPwd);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 387);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 300);
            this.Name = "FrmUpPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.FrmProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCfmPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOldPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.LabelControl lblCfmPwd;
        private DevExpress.XtraEditors.TextEdit teCfmPwd;
        private DevExpress.XtraEditors.TextEdit teOldPwd;
        private DevExpress.XtraEditors.LabelControl lblNewPwd;
        private DevExpress.XtraEditors.TextEdit teNewPwd;
        private DevExpress.XtraEditors.SimpleButton btnChangePwd;
        private DevExpress.XtraEditors.LabelControl lblOldPwd;
        private DevExpress.XtraEditors.LabelControl lbUser;
    }
}