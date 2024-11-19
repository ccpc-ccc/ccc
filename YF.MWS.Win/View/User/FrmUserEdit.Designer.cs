namespace YF.MWS.Win.View.User
{
    partial class FrmUserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserEdit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.tabUser = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.plAdmin = new DevExpress.XtraEditors.PanelControl();
            this.lblIsAdmin = new DevExpress.XtraEditors.LabelControl();
            this.chkIsAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.gpRole = new DevExpress.XtraEditors.GroupControl();
            this.treeModule = new DevExpress.XtraTreeList.TreeList();
            this.colModuleName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lblActive = new DevExpress.XtraEditors.LabelControl();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtMobilePhone = new DevExpress.XtraEditors.TextEdit();
            this.lblMobilePhone = new DevExpress.XtraEditors.LabelControl();
            this.comboGender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblGender = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.tabPagePassword = new DevExpress.XtraTab.XtraTabPage();
            this.btnChangePwd = new DevExpress.XtraEditors.SimpleButton();
            this.txtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.lblNewPwd = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabUser)).BeginInit();
            this.tabUser.SuspendLayout();
            this.tabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plAdmin)).BeginInit();
            this.plAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpRole)).BeginInit();
            this.gpRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobilePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.tabPagePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnItemSave,
            this.btnItemClose});
            this.barManager.MaxItemId = 10;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageOptions.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(676, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 709);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(676, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 685);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(676, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 685);
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
            // tabUser
            // 
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUser.Location = new System.Drawing.Point(0, 24);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedTabPage = this.tabPageDetail;
            this.tabUser.Size = new System.Drawing.Size(676, 685);
            this.tabUser.TabIndex = 6;
            this.tabUser.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageDetail,
            this.tabPagePassword});
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.plAdmin);
            this.tabPageDetail.Controls.Add(this.gpRole);
            this.tabPageDetail.Controls.Add(this.lblActive);
            this.tabPageDetail.Controls.Add(this.chkActive);
            this.tabPageDetail.Controls.Add(this.txtMobilePhone);
            this.tabPageDetail.Controls.Add(this.lblMobilePhone);
            this.tabPageDetail.Controls.Add(this.comboGender);
            this.tabPageDetail.Controls.Add(this.lblGender);
            this.tabPageDetail.Controls.Add(this.txtFullName);
            this.tabPageDetail.Controls.Add(this.lblFullName);
            this.tabPageDetail.Controls.Add(this.txtUserName);
            this.tabPageDetail.Controls.Add(this.lblUserName);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Size = new System.Drawing.Size(674, 659);
            this.tabPageDetail.Text = "基本信息";
            // 
            // plAdmin
            // 
            this.plAdmin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plAdmin.Controls.Add(this.lblIsAdmin);
            this.plAdmin.Controls.Add(this.chkIsAdmin);
            this.plAdmin.Location = new System.Drawing.Point(335, 91);
            this.plAdmin.Name = "plAdmin";
            this.plAdmin.Size = new System.Drawing.Size(200, 23);
            this.plAdmin.TabIndex = 23;
            // 
            // lblIsAdmin
            // 
            this.lblIsAdmin.Location = new System.Drawing.Point(12, 3);
            this.lblIsAdmin.Name = "lblIsAdmin";
            this.lblIsAdmin.Size = new System.Drawing.Size(40, 14);
            this.lblIsAdmin.TabIndex = 13;
            this.lblIsAdmin.Text = "管理员:";
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.Location = new System.Drawing.Point(71, 2);
            this.chkIsAdmin.MenuManager = this.barManager;
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Properties.Caption = "";
            this.chkIsAdmin.Size = new System.Drawing.Size(20, 20);
            this.chkIsAdmin.TabIndex = 14;
            this.chkIsAdmin.Tag = "IsAdmin";
            this.chkIsAdmin.ToolTipTitle = "如果是管理员,整个系统都有权限访问,请慎重设置";
            // 
            // gpRole
            // 
            this.gpRole.Controls.Add(this.treeModule);
            this.gpRole.Location = new System.Drawing.Point(25, 120);
            this.gpRole.Name = "gpRole";
            this.gpRole.Size = new System.Drawing.Size(623, 504);
            this.gpRole.TabIndex = 20;
            this.gpRole.Text = "权限设置";
            // 
            // treeModule
            // 
            this.treeModule.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colModuleName});
            this.treeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModule.KeyFieldName = "Id";
            this.treeModule.Location = new System.Drawing.Point(2, 23);
            this.treeModule.Name = "treeModule";
            this.treeModule.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeModule.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.treeModule.ParentFieldName = "ParentId";
            this.treeModule.Size = new System.Drawing.Size(619, 479);
            this.treeModule.TabIndex = 7;
            this.treeModule.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeModule_AfterCheckNode);
            // 
            // colModuleName
            // 
            this.colModuleName.Caption = "模块名称";
            this.colModuleName.FieldName = "ModuleName";
            this.colModuleName.MinWidth = 32;
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 0;
            this.colModuleName.Width = 91;
            // 
            // lblActive
            // 
            this.lblActive.Location = new System.Drawing.Point(25, 94);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(52, 14);
            this.lblActive.TabIndex = 17;
            this.lblActive.Text = "激活账户:";
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(94, 92);
            this.chkActive.MenuManager = this.barManager;
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "";
            this.chkActive.Size = new System.Drawing.Size(20, 20);
            this.chkActive.TabIndex = 16;
            this.chkActive.Tag = "Active";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(406, 55);
            this.txtMobilePhone.MenuManager = this.barManager;
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(169, 20);
            this.txtMobilePhone.TabIndex = 10;
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.Location = new System.Drawing.Point(335, 58);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(52, 14);
            this.lblMobilePhone.TabIndex = 9;
            this.lblMobilePhone.Text = "手机号码:";
            // 
            // comboGender
            // 
            this.comboGender.Location = new System.Drawing.Point(406, 18);
            this.comboGender.MenuManager = this.barManager;
            this.comboGender.Name = "comboGender";
            this.comboGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboGender.Size = new System.Drawing.Size(193, 20);
            this.comboGender.TabIndex = 7;
            this.comboGender.Tag = "Gender";
            // 
            // lblGender
            // 
            this.lblGender.Location = new System.Drawing.Point(335, 18);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(28, 14);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "性别:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(96, 58);
            this.txtFullName.MenuManager = this.barManager;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(169, 20);
            this.txtFullName.TabIndex = 3;
            this.txtFullName.Tag = "FullName";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(25, 61);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(28, 14);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "姓名:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 19);
            this.txtUserName.MenuManager = this.barManager;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(169, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Tag = "UserName";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(25, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(40, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名:";
            // 
            // tabPagePassword
            // 
            this.tabPagePassword.Controls.Add(this.btnChangePwd);
            this.tabPagePassword.Controls.Add(this.txtNewPwd);
            this.tabPagePassword.Controls.Add(this.lblNewPwd);
            this.tabPagePassword.Name = "tabPagePassword";
            this.tabPagePassword.Size = new System.Drawing.Size(674, 659);
            this.tabPagePassword.Text = "修改密码";
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(94, 73);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangePwd.TabIndex = 6;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(94, 27);
            this.txtNewPwd.MenuManager = this.barManager;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(154, 20);
            this.txtNewPwd.TabIndex = 5;
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.Location = new System.Drawing.Point(23, 30);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(40, 14);
            this.lblNewPwd.TabIndex = 4;
            this.lblNewPwd.Text = "新密码:";
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 709);
            this.Controls.Add(this.tabUser);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户详情";
            this.Load += new System.EventHandler(this.FrmUserEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabUser)).EndInit();
            this.tabUser.ResumeLayout(false);
            this.tabPageDetail.ResumeLayout(false);
            this.tabPageDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plAdmin)).EndInit();
            this.plAdmin.ResumeLayout(false);
            this.plAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpRole)).EndInit();
            this.gpRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobilePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.tabPagePassword.ResumeLayout(false);
            this.tabPagePassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl tabUser;
        private DevExpress.XtraTab.XtraTabPage tabPageDetail;
        private DevExpress.XtraEditors.LabelControl lblActive;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.CheckEdit chkIsAdmin;
        private DevExpress.XtraEditors.LabelControl lblIsAdmin;
        private DevExpress.XtraEditors.TextEdit txtMobilePhone;
        private DevExpress.XtraEditors.LabelControl lblMobilePhone;
        private DevExpress.XtraEditors.ComboBoxEdit comboGender;
        private DevExpress.XtraEditors.LabelControl lblGender;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraTab.XtraTabPage tabPagePassword;
        private DevExpress.XtraEditors.SimpleButton btnChangePwd;
        private DevExpress.XtraEditors.TextEdit txtNewPwd;
        private DevExpress.XtraEditors.LabelControl lblNewPwd;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl gpRole;
        private DevExpress.XtraTreeList.TreeList treeModule;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuleName;
        private DevExpress.XtraEditors.PanelControl plAdmin;
    }
}