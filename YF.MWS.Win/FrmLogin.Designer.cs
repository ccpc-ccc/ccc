namespace YF.MWS.Win
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.chkRememberPwd = new DevExpress.XtraEditors.CheckEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.peWaitting = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.combUserName = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtPassword.Location = new System.Drawing.Point(170, 126);
            this.txtPassword.Name = "txtPassword";
            // 
            // 
            // 
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorFocused | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtPassword.Size = new System.Drawing.Size(210, 26);
            this.txtPassword.TabIndex = 14;
            // 
            // lblPassword
            // 
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Appearance.Options.UseFont = true;
            this.lblPassword.Location = new System.Drawing.Point(104, 127);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(55, 19);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "密   码:";
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Location = new System.Drawing.Point(104, 61);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 19);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Text = "用户名:";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // chkRememberPwd
            // 
            this.chkRememberPwd.Location = new System.Drawing.Point(305, 158);
            this.chkRememberPwd.Name = "chkRememberPwd";
            // 
            // 
            // 
            this.chkRememberPwd.Properties.Caption = "记住密码";
            this.chkRememberPwd.Size = new System.Drawing.Size(75, 20);
            this.chkRememberPwd.TabIndex = 33;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.btnLogin.AppearanceDisabled.Options.UseBackColor = true;
            this.btnLogin.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogin.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLogin.Location = new System.Drawing.Point(104, 197);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(276, 39);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "登    录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // peWaitting
            // 
            this.peWaitting.Dock = System.Windows.Forms.DockStyle.Top;
            this.peWaitting.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.peWaitting.Location = new System.Drawing.Point(0, 0);
            this.peWaitting.Name = "peWaitting";
            // 
            // 
            // 
            this.peWaitting.Properties.AllowFocused = false;
            this.peWaitting.Properties.AnimatedImageLoopMode = DevExpress.Utils.AnimatedImageLoopMode.UseSourceImageLoopCount;
            this.peWaitting.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peWaitting.Properties.Appearance.Options.UseBackColor = true;
            this.peWaitting.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peWaitting.Properties.ReadOnly = true;
            this.peWaitting.Properties.ShowMenu = false;
            this.peWaitting.Size = new System.Drawing.Size(517, 166);
            this.peWaitting.TabIndex = 16;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblUserName);
            this.panelControl1.Controls.Add(this.txtPassword);
            this.panelControl1.Controls.Add(this.btnLogin);
            this.panelControl1.Controls.Add(this.chkRememberPwd);
            this.panelControl1.Controls.Add(this.lblPassword);
            this.panelControl1.Controls.Add(this.combUserName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 165);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(517, 310);
            this.panelControl1.TabIndex = 37;
            // 
            // combUserName
            // 
            this.combUserName.EditValue = "";
            this.combUserName.Location = new System.Drawing.Point(170, 60);
            this.combUserName.Name = "combUserName";
            // 
            // 
            // 
            this.combUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.Appearance.Options.UseFont = true;
            this.combUserName.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.combUserName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.combUserName.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceFocused.Options.UseFont = true;
            this.combUserName.Properties.AppearanceItemDisabled.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceItemDisabled.Options.UseFont = true;
            this.combUserName.Properties.AppearanceItemHighlight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceItemHighlight.Options.UseFont = true;
            this.combUserName.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.combUserName.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combUserName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.combUserName.Properties.AutoComplete = false;
            this.combUserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.combUserName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)(((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorFocused) 
            | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.combUserName.Size = new System.Drawing.Size(210, 26);
            this.combUserName.TabIndex = 34;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(517, 475);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.peWaitting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(428, 494);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PictureEdit peWaitting;
        private DevExpress.XtraEditors.CheckEdit chkRememberPwd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combUserName;
    }
}