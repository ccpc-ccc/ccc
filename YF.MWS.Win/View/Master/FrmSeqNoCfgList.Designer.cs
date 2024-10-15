namespace YF.MWS.Win.View.Master
{
    partial class FrmSeqNoCfgList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeqNoCfgList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.gcCar = new DevExpress.XtraGrid.GridControl();
            this.gvCar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeqCodeCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFomart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuningNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFixedLen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCar)).BeginInit();
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
            this.btnItemPreview,
            this.btnItemCancel,
            this.btnItemAddSub,
            this.btnItemEdit});
            this.barManager.MaxItemId = 10;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemPreview, true)});
            this.bar1.Text = "Tools";
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "新增";
            this.btnItemAdd.Id = 4;
            this.btnItemAdd.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 8;
            this.btnItemEdit.ImageIndex = 4;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemPreview
            // 
            this.btnItemPreview.Caption = "预览序列号";
            this.btnItemPreview.Id = 2;
            this.btnItemPreview.ImageIndex = 6;
            this.btnItemPreview.Name = "btnItemPreview";
            this.btnItemPreview.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemPreview_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(936, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 495);
            this.barDockControlBottom.Size = new System.Drawing.Size(936, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 464);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(936, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 464);
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
            this.imgListSmall.Images.SetKeyName(6, "preview_16x16.png");
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemAddSub
            // 
            this.btnItemAddSub.Caption = "添加子类";
            this.btnItemAddSub.Id = 5;
            this.btnItemAddSub.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gcCar
            // 
            this.gcCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCar.Location = new System.Drawing.Point(0, 31);
            this.gcCar.MainView = this.gvCar;
            this.gcCar.MenuManager = this.barManager;
            this.gcCar.Name = "gcCar";
            this.gcCar.Size = new System.Drawing.Size(936, 464);
            this.gcCar.TabIndex = 23;
            this.gcCar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCar});
            // 
            // gvCar
            // 
            this.gvCar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeqCodeCaption,
            this.colPrefix,
            this.colDateFomart,
            this.colRuningNo,
            this.colFixedLen,
            this.colCreateTime});
            this.gvCar.GridControl = this.gcCar;
            this.gvCar.Name = "gvCar";
            this.gvCar.NewItemRowText = "点此添加数据";
            this.gvCar.OptionsView.ShowGroupPanel = false;
            this.gvCar.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSeqCodeCaption, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSeqCodeCaption
            // 
            this.colSeqCodeCaption.Caption = "名称";
            this.colSeqCodeCaption.FieldName = "SeqCodeCaption";
            this.colSeqCodeCaption.Name = "colSeqCodeCaption";
            this.colSeqCodeCaption.OptionsColumn.AllowEdit = false;
            this.colSeqCodeCaption.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSeqCodeCaption.Visible = true;
            this.colSeqCodeCaption.VisibleIndex = 0;
            // 
            // colPrefix
            // 
            this.colPrefix.Caption = "前缀";
            this.colPrefix.FieldName = "Prefix";
            this.colPrefix.Name = "colPrefix";
            this.colPrefix.OptionsColumn.AllowEdit = false;
            this.colPrefix.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPrefix.Visible = true;
            this.colPrefix.VisibleIndex = 3;
            // 
            // colDateFomart
            // 
            this.colDateFomart.Caption = "日期格式";
            this.colDateFomart.FieldName = "DateFomart";
            this.colDateFomart.Name = "colDateFomart";
            this.colDateFomart.Visible = true;
            this.colDateFomart.VisibleIndex = 2;
            // 
            // colRuningNo
            // 
            this.colRuningNo.Caption = "当前值";
            this.colRuningNo.FieldName = "RuningNo";
            this.colRuningNo.Name = "colRuningNo";
            this.colRuningNo.OptionsColumn.AllowEdit = false;
            this.colRuningNo.Visible = true;
            this.colRuningNo.VisibleIndex = 1;
            // 
            // colFixedLen
            // 
            this.colFixedLen.Caption = "序列号总长度";
            this.colFixedLen.FieldName = "FixedLen";
            this.colFixedLen.Name = "colFixedLen";
            this.colFixedLen.Visible = true;
            this.colFixedLen.VisibleIndex = 4;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsColumn.AllowEdit = false;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 5;
            // 
            // FrmSeqNoCfgList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 495);
            this.Controls.Add(this.gcCar);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmSeqNoCfgList";
            this.Text = "序列号设置";
            this.Load += new System.EventHandler(this.FrmSeqNoCfgList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemPreview;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraGrid.GridControl gcCar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCar;
        private DevExpress.XtraGrid.Columns.GridColumn colSeqCodeCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFomart;
        private DevExpress.XtraGrid.Columns.GridColumn colRuningNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colFixedLen;
    }
}