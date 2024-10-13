namespace YF.MWS.Win.View.User
{
    partial class FrmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfile));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teContactPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtMobilePhone = new DevExpress.XtraEditors.TextEdit();
            this.lblMobilePhone = new DevExpress.XtraEditors.LabelControl();
            this.comboGender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblContactPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblGender = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lblCfmPwd = new DevExpress.XtraEditors.LabelControl();
            this.teCfmPwd = new DevExpress.XtraEditors.TextEdit();
            this.teOldPwd = new DevExpress.XtraEditors.TextEdit();
            this.lblNewPwd = new DevExpress.XtraEditors.LabelControl();
            this.teNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.btnChangePwd = new DevExpress.XtraEditors.SimpleButton();
            this.lblOldPwd = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teContactPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobilePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
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
            // teContactPhone
            // 
            this.teContactPhone.Location = new System.Drawing.Point(99, 189);
            this.teContactPhone.Name = "teContactPhone";
            this.teContactPhone.Size = new System.Drawing.Size(154, 20);
            this.teContactPhone.TabIndex = 27;
            this.teContactPhone.Tag = "ContactPhone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(99, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 20);
            this.txtEmail.TabIndex = 26;
            this.txtEmail.Tag = "Email";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(28, 233);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 14);
            this.lblEmail.TabIndex = 25;
            this.lblEmail.Text = "电子邮箱:";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(99, 144);
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(154, 20);
            this.txtMobilePhone.TabIndex = 24;
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.Location = new System.Drawing.Point(28, 147);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(52, 14);
            this.lblMobilePhone.TabIndex = 23;
            this.lblMobilePhone.Text = "手机号码:";
            // 
            // comboGender
            // 
            this.comboGender.Location = new System.Drawing.Point(99, 103);
            this.comboGender.Name = "comboGender";
            this.comboGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboGender.Size = new System.Drawing.Size(154, 20);
            this.comboGender.TabIndex = 22;
            this.comboGender.Tag = "Gender";
            // 
            // lblContactPhone
            // 
            this.lblContactPhone.Location = new System.Drawing.Point(28, 189);
            this.lblContactPhone.Name = "lblContactPhone";
            this.lblContactPhone.Size = new System.Drawing.Size(52, 14);
            this.lblContactPhone.TabIndex = 21;
            this.lblContactPhone.Text = "联系电话:";
            // 
            // lblGender
            // 
            this.lblGender.Location = new System.Drawing.Point(28, 103);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(28, 14);
            this.lblGender.TabIndex = 20;
            this.lblGender.Text = "性别:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(99, 60);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(154, 20);
            this.txtFullName.TabIndex = 19;
            this.txtFullName.Tag = "FullName";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(28, 63);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(28, 14);
            this.lblFullName.TabIndex = 18;
            this.lblFullName.Text = "姓名:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(99, 19);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(154, 20);
            this.txtUserName.TabIndex = 17;
            this.txtUserName.Tag = "UserName";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(28, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(40, 14);
            this.lblUserName.TabIndex = 16;
            this.lblUserName.Text = "用户名:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(486, 355);
            this.xtraTabControl1.TabIndex = 32;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnSave);
            this.xtraTabPage1.Controls.Add(this.teContactPhone);
            this.xtraTabPage1.Controls.Add(this.lblUserName);
            this.xtraTabPage1.Controls.Add(this.txtEmail);
            this.xtraTabPage1.Controls.Add(this.txtUserName);
            this.xtraTabPage1.Controls.Add(this.lblEmail);
            this.xtraTabPage1.Controls.Add(this.lblFullName);
            this.xtraTabPage1.Controls.Add(this.txtMobilePhone);
            this.xtraTabPage1.Controls.Add(this.txtFullName);
            this.xtraTabPage1.Controls.Add(this.lblMobilePhone);
            this.xtraTabPage1.Controls.Add(this.lblGender);
            this.xtraTabPage1.Controls.Add(this.comboGender);
            this.xtraTabPage1.Controls.Add(this.lblContactPhone);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(484, 329);
            this.xtraTabPage1.Text = "个人资料";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lblCfmPwd);
            this.xtraTabPage2.Controls.Add(this.teCfmPwd);
            this.xtraTabPage2.Controls.Add(this.teOldPwd);
            this.xtraTabPage2.Controls.Add(this.lblNewPwd);
            this.xtraTabPage2.Controls.Add(this.teNewPwd);
            this.xtraTabPage2.Controls.Add(this.btnChangePwd);
            this.xtraTabPage2.Controls.Add(this.lblOldPwd);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(484, 305);
            this.xtraTabPage2.Text = "修改密码";
            // 
            // lblCfmPwd
            // 
            this.lblCfmPwd.Location = new System.Drawing.Point(26, 95);
            this.lblCfmPwd.Name = "lblCfmPwd";
            this.lblCfmPwd.Size = new System.Drawing.Size(64, 14);
            this.lblCfmPwd.TabIndex = 49;
            this.lblCfmPwd.Text = "确认新密码:";
            // 
            // teCfmPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teCfmPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teCfmPwd.Location = new System.Drawing.Point(121, 92);
            this.teCfmPwd.Name = "teCfmPwd";
            this.teCfmPwd.Size = new System.Drawing.Size(154, 20);
            this.teCfmPwd.TabIndex = 50;
            // 
            // teOldPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teOldPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teOldPwd.Location = new System.Drawing.Point(121, 22);
            this.teOldPwd.Name = "teOldPwd";
            this.teOldPwd.Size = new System.Drawing.Size(154, 20);
            this.teOldPwd.TabIndex = 48;
            this.teOldPwd.Tag = "";
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.Location = new System.Drawing.Point(26, 60);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(40, 14);
            this.lblNewPwd.TabIndex = 44;
            this.lblNewPwd.Text = "新密码:";
            // 
            // teNewPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teNewPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teNewPwd.Location = new System.Drawing.Point(121, 57);
            this.teNewPwd.Name = "teNewPwd";
            this.teNewPwd.Size = new System.Drawing.Size(154, 20);
            this.teNewPwd.TabIndex = 45;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(121, 134);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangePwd.TabIndex = 46;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.Location = new System.Drawing.Point(26, 25);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(40, 14);
            this.lblOldPwd.TabIndex = 47;
            this.lblOldPwd.Text = "原密码:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(169, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "保存修改";
            this.btnSave.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 355);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.Image= global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 387);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(474, 380);
            this.Name = "FrmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人信息";
            this.Load += new System.EventHandler(this.FrmProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teContactPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobilePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCfmPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOldPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPwd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit teContactPhone;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtMobilePhone;
        private DevExpress.XtraEditors.LabelControl lblMobilePhone;
        private DevExpress.XtraEditors.ComboBoxEdit comboGender;
        private DevExpress.XtraEditors.LabelControl lblContactPhone;
        private DevExpress.XtraEditors.LabelControl lblGender;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl lblCfmPwd;
        private DevExpress.XtraEditors.TextEdit teCfmPwd;
        private DevExpress.XtraEditors.TextEdit teOldPwd;
        private DevExpress.XtraEditors.LabelControl lblNewPwd;
        private DevExpress.XtraEditors.TextEdit teNewPwd;
        private DevExpress.XtraEditors.SimpleButton btnChangePwd;
        private DevExpress.XtraEditors.LabelControl lblOldPwd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}