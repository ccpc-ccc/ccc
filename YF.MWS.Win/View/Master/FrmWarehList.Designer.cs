namespace YF.MWS.Win.View.Master
{
    partial class FrmWarehList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWarehList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.gcWareh = new DevExpress.XtraGrid.GridControl();
            this.gvWareh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWarehCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).BeginInit();
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
            this.btnItemEdit,
            this.btnItemDelete,
            this.btnItemRefresh});
            this.barManager.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete)});
            this.bar1.Text = "Tools";
            // 
            // btnItemRefresh
            // 
            this.btnItemRefresh.Caption = "刷新";
            this.btnItemRefresh.Id = 3;
            this.btnItemRefresh.ImageOptions.ImageIndex = 3;
            this.btnItemRefresh.Name = "btnItemRefresh";
            this.btnItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "添加";
            this.btnItemAdd.Id = 0;
            this.btnItemAdd.ImageOptions.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 1;
            this.btnItemEdit.ImageOptions.ImageIndex = 1;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 2;
            this.btnItemDelete.ImageOptions.ImageIndex = 2;
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
            this.barDockControlTop.Size = new System.Drawing.Size(844, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 488);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(844, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 464);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(844, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 464);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "upload_16x16.png");
            // 
            // gcWareh
            // 
            this.gcWareh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWareh.Location = new System.Drawing.Point(0, 24);
            this.gcWareh.MainView = this.gvWareh;
            this.gcWareh.MenuManager = this.barManager;
            this.gcWareh.Name = "gcWareh";
            this.gcWareh.Size = new System.Drawing.Size(844, 464);
            this.gcWareh.TabIndex = 5;
            this.gcWareh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWareh});
            // 
            // gvWareh
            // 
            this.gvWareh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWarehCode,
            this.colWarehName,
            this.colCreateDate});
            this.gvWareh.GridControl = this.gcWareh;
            this.gvWareh.Name = "gvWareh";
            this.gvWareh.OptionsBehavior.Editable = false;
            this.gvWareh.OptionsView.ShowGroupPanel = false;
            // 
            // colWarehCode
            // 
            this.colWarehCode.Caption = "仓库编码";
            this.colWarehCode.FieldName = "WarehCode";
            this.colWarehCode.Name = "colWarehCode";
            this.colWarehCode.Visible = true;
            this.colWarehCode.VisibleIndex = 1;
            // 
            // colWarehName
            // 
            this.colWarehName.Caption = "仓库名称";
            this.colWarehName.FieldName = "WarehName";
            this.colWarehName.Name = "colWarehName";
            this.colWarehName.Visible = true;
            this.colWarehName.VisibleIndex = 0;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建时间";
            this.colCreateDate.DisplayFormat.FormatString = "d";
            this.colCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateDate.FieldName = "CreateTime";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 2;
            // 
            // FrmWarehList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 488);
            this.Controls.Add(this.gcWareh);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmWarehList";
            this.Text = "仓库管理";
            this.Load += new System.EventHandler(this.FrmWarehList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemRefresh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraGrid.GridControl gcWareh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWareh;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
    }
}