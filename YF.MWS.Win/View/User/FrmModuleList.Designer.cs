namespace YF.MWS.Win.View.User
{
    partial class FrmModuleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemRefreh = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAuthSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.bItemSave = new DevExpress.XtraBars.BarSubItem();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.treeModule = new DevExpress.XtraTreeList.TreeList();
            this.colModuleName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFullName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCreateTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnItemAdd,
            this.bItemSave,
            this.btnItemSave,
            this.btnItemRefreh,
            this.btnItemCancel,
            this.btnItemAddSub,
            this.btnItemDelete,
            this.btnItemEdit,
            this.barItemAuthSetting,
            this.barItemExport,
            this.barItemImport});
            this.barManager.MaxItemId = 11;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRefreh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAddSub),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAuthSetting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete)});
            this.bar1.Text = "Tools";
            // 
            // btnItemRefreh
            // 
            this.btnItemRefreh.Caption = "刷新";
            this.btnItemRefreh.Id = 2;
            this.btnItemRefreh.ImageOptions.ImageIndex = 5;
            this.btnItemRefreh.Name = "btnItemRefreh";
            this.btnItemRefreh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemRefreh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemRefreh_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "导出模块";
            this.barItemExport.Id = 9;
            this.barItemExport.ImageOptions.ImageIndex = 7;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // barItemImport
            // 
            this.barItemImport.Caption = "导入模块";
            this.barItemImport.Id = 10;
            this.barItemImport.ImageOptions.ImageIndex = 8;
            this.barItemImport.Name = "barItemImport";
            this.barItemImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemImport_ItemClick);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "添加父类";
            this.btnItemAdd.Id = 4;
            this.btnItemAdd.ImageOptions.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemAddSub
            // 
            this.btnItemAddSub.Caption = "添加子类";
            this.btnItemAddSub.Id = 5;
            this.btnItemAddSub.ImageOptions.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAddSub.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAddSub_ItemClick);
            // 
            // barItemAuthSetting
            // 
            this.barItemAuthSetting.Caption = "版本功能设置";
            this.barItemAuthSetting.Id = 8;
            this.barItemAuthSetting.ImageOptions.ImageIndex = 6;
            this.barItemAuthSetting.Name = "barItemAuthSetting";
            this.barItemAuthSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAuthSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAuthSetting_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 7;
            this.btnItemEdit.ImageOptions.ImageIndex = 4;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 6;
            this.btnItemDelete.ImageOptions.ImageIndex = 3;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1079, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 725);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1079, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 701);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1079, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 701);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "cancel_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "setup_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "export_16x16.png");
            this.imgListSmall.Images.SetKeyName(8, "import_16x16.png");
            // 
            // bItemSave
            // 
            this.bItemSave.Caption = "保存";
            this.bItemSave.Id = 0;
            this.bItemSave.ImageOptions.ImageIndex = 0;
            this.bItemSave.Name = "bItemSave";
            this.bItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // treeModule
            // 
            this.treeModule.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colModuleName,
            this.colFullName,
            this.colCreateTime});
            this.treeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModule.KeyFieldName = "Id";
            this.treeModule.Location = new System.Drawing.Point(0, 24);
            this.treeModule.Name = "treeModule";
            this.treeModule.OptionsBehavior.Editable = false;
            this.treeModule.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeModule.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.treeModule.ParentFieldName = "ParentId";
            this.treeModule.Size = new System.Drawing.Size(1079, 701);
            this.treeModule.TabIndex = 6;
            // 
            // colModuleName
            // 
            this.colModuleName.Caption = "模块名称";
            this.colModuleName.FieldName = "ModuleName";
            this.colModuleName.MinWidth = 32;
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.OptionsColumn.AllowEdit = false;
            this.colModuleName.OptionsColumn.ReadOnly = true;
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 0;
            this.colModuleName.Width = 91;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "权限编号";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.OptionsColumn.ReadOnly = true;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsColumn.AllowEdit = false;
            this.colCreateTime.OptionsColumn.ReadOnly = true;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 2;
            // 
            // FrmModuleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 725);
            this.Controls.Add(this.treeModule);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmModuleList";
            this.Text = "模块管理";
            this.Load += new System.EventHandler(this.FrmModuleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemRefreh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarSubItem bItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraTreeList.TreeList treeModule;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuleName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFullName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCreateTime;
        private DevExpress.XtraBars.BarButtonItem barItemAuthSetting;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarButtonItem barItemImport;
    }
}