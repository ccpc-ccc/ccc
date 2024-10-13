namespace YF.MWS.Win.View.User
{
    partial class FrmRoleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoleEdit));
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
            this.tabRole = new DevExpress.XtraTab.XtraTabControl();
            this.pageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.memRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.lblRemarks = new DevExpress.XtraEditors.LabelControl();
            this.teRoleName = new DevExpress.XtraEditors.TextEdit();
            this.lblRoleName = new DevExpress.XtraEditors.LabelControl();
            this.pageModule = new DevExpress.XtraTab.XtraTabPage();
            this.treeModule = new DevExpress.XtraTreeList.TreeList();
            this.colModuleName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabRole)).BeginInit();
            this.tabRole.SuspendLayout();
            this.pageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRoleName.Properties)).BeginInit();
            this.pageModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(625, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 447);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(625, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 423);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(625, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 423);
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
            // tabRole
            // 
            this.tabRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRole.Location = new System.Drawing.Point(0, 24);
            this.tabRole.Name = "tabRole";
            this.tabRole.SelectedTabPage = this.pageDetail;
            this.tabRole.Size = new System.Drawing.Size(625, 423);
            this.tabRole.TabIndex = 5;
            this.tabRole.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageDetail,
            this.pageModule});
            // 
            // pageDetail
            // 
            this.pageDetail.Controls.Add(this.memRemarks);
            this.pageDetail.Controls.Add(this.lblRemarks);
            this.pageDetail.Controls.Add(this.teRoleName);
            this.pageDetail.Controls.Add(this.lblRoleName);
            this.pageDetail.Name = "pageDetail";
            this.pageDetail.Size = new System.Drawing.Size(623, 397);
            this.pageDetail.Text = "详情";
            // 
            // memRemarks
            // 
            this.memRemarks.Location = new System.Drawing.Point(100, 58);
            this.memRemarks.MenuManager = this.barManager;
            this.memRemarks.Name = "memRemarks";
            this.memRemarks.Size = new System.Drawing.Size(507, 210);
            this.memRemarks.TabIndex = 43;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(27, 58);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(28, 14);
            this.lblRemarks.TabIndex = 42;
            this.lblRemarks.Text = "备注:";
            // 
            // teRoleName
            // 
            this.teRoleName.Location = new System.Drawing.Point(100, 24);
            this.teRoleName.MenuManager = this.barManager;
            this.teRoleName.Name = "teRoleName";
            this.teRoleName.Size = new System.Drawing.Size(507, 20);
            this.teRoleName.TabIndex = 40;
            this.teRoleName.Tag = "ModuleName";
            // 
            // lblRoleName
            // 
            this.lblRoleName.Location = new System.Drawing.Point(27, 24);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(52, 14);
            this.lblRoleName.TabIndex = 41;
            this.lblRoleName.Text = "角色名称:";
            // 
            // pageModule
            // 
            this.pageModule.Controls.Add(this.treeModule);
            this.pageModule.Name = "pageModule";
            this.pageModule.Size = new System.Drawing.Size(623, 397);
            this.pageModule.Text = "模块";
            // 
            // treeModule
            // 
            this.treeModule.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colModuleName});
            this.treeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModule.KeyFieldName = "Id";
            this.treeModule.Location = new System.Drawing.Point(0, 0);
            this.treeModule.Name = "treeModule";
            this.treeModule.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeModule.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.treeModule.ParentFieldName = "ParentId";
            this.treeModule.Size = new System.Drawing.Size(623, 397);
            this.treeModule.TabIndex = 6;
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
            // FrmRoleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 447);
            this.Controls.Add(this.tabRole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmRoleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色详情";
            this.Load += new System.EventHandler(this.FrmRoleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabRole)).EndInit();
            this.tabRole.ResumeLayout(false);
            this.pageDetail.ResumeLayout(false);
            this.pageDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRoleName.Properties)).EndInit();
            this.pageModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).EndInit();
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
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraTab.XtraTabControl tabRole;
        private DevExpress.XtraTab.XtraTabPage pageDetail;
        private DevExpress.XtraEditors.MemoEdit memRemarks;
        private DevExpress.XtraEditors.LabelControl lblRemarks;
        private DevExpress.XtraEditors.TextEdit teRoleName;
        private DevExpress.XtraEditors.LabelControl lblRoleName;
        private DevExpress.XtraTab.XtraTabPage pageModule;
        private DevExpress.XtraTreeList.TreeList treeModule;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuleName;
    }
}