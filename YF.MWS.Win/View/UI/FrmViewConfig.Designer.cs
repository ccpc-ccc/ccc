namespace YF.MWS.Win.View.UI
{
    partial class FrmViewConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewConfig));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemFormulaCfg = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teColumnsCount = new DevExpress.XtraEditors.TextEdit();
            this.gpBasic = new DevExpress.XtraEditors.GroupControl();
            this.lblItemCode = new DevExpress.XtraEditors.LabelControl();
            this.gpDetail = new DevExpress.XtraEditors.GroupControl();
            this.gpControlList = new DevExpress.XtraEditors.GroupControl();
            this.gcViewDetailSource = new DevExpress.XtraGrid.GridControl();
            this.gvViewDetailSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSourceControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpControlShowList = new DevExpress.XtraEditors.GroupControl();
            this.gcViewDetail = new DevExpress.XtraGrid.GridControl();
            this.gvViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColumnsCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpBasic)).BeginInit();
            this.gpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpDetail)).BeginInit();
            this.gpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpControlList)).BeginInit();
            this.gpControlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcViewDetailSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewDetailSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpControlShowList)).BeginInit();
            this.gpControlShowList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewDetail)).BeginInit();
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
            this.btnItemClose,
            this.barItemFormulaCfg});
            this.barManager.MaxItemId = 12;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemFormulaCfg),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // barItemFormulaCfg
            // 
            this.barItemFormulaCfg.Caption = "公式设置";
            this.barItemFormulaCfg.Id = 11;
            this.barItemFormulaCfg.ImageIndex = 3;
            this.barItemFormulaCfg.Name = "barItemFormulaCfg";
            this.barItemFormulaCfg.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemFormulaCfg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemFormulaCfg_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1132, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 730);
            this.barDockControlBottom.Size = new System.Drawing.Size(1132, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 699);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1132, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 699);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "customization_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teColumnsCount
            // 
            this.dxErrorProvider.SetIconAlignment(this.teColumnsCount, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teColumnsCount.Location = new System.Drawing.Point(121, 41);
            this.teColumnsCount.MenuManager = this.barManager;
            this.teColumnsCount.Name = "teColumnsCount";
            this.teColumnsCount.Properties.Mask.EditMask = "N0";
            this.teColumnsCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teColumnsCount.Size = new System.Drawing.Size(106, 20);
            this.teColumnsCount.TabIndex = 39;
            this.teColumnsCount.Tag = "ColumnsCount";
            // 
            // gpBasic
            // 
            this.gpBasic.Controls.Add(this.teColumnsCount);
            this.gpBasic.Controls.Add(this.lblItemCode);
            this.gpBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpBasic.Location = new System.Drawing.Point(0, 31);
            this.gpBasic.Name = "gpBasic";
            this.gpBasic.Size = new System.Drawing.Size(1132, 85);
            this.gpBasic.TabIndex = 4;
            this.gpBasic.Text = "基础设置";
            // 
            // lblItemCode
            // 
            this.lblItemCode.Location = new System.Drawing.Point(24, 44);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(52, 14);
            this.lblItemCode.TabIndex = 40;
            this.lblItemCode.Text = "显示列数:";
            // 
            // gpDetail
            // 
            this.gpDetail.Controls.Add(this.gpControlList);
            this.gpDetail.Controls.Add(this.gpControlShowList);
            this.gpDetail.Controls.Add(this.btnAdd);
            this.gpDetail.Controls.Add(this.btnRemove);
            this.gpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpDetail.Location = new System.Drawing.Point(0, 116);
            this.gpDetail.Name = "gpDetail";
            this.gpDetail.Size = new System.Drawing.Size(1132, 614);
            this.gpDetail.TabIndex = 5;
            this.gpDetail.Text = "显示设置";
            // 
            // gpControlList
            // 
            this.gpControlList.Controls.Add(this.gcViewDetailSource);
            this.gpControlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpControlList.Location = new System.Drawing.Point(2, 22);
            this.gpControlList.Name = "gpControlList";
            this.gpControlList.Size = new System.Drawing.Size(385, 590);
            this.gpControlList.TabIndex = 31;
            this.gpControlList.Text = "界面备选项目库";
            // 
            // gcViewDetailSource
            // 
            this.gcViewDetailSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewDetailSource.Location = new System.Drawing.Point(2, 22);
            this.gcViewDetailSource.MainView = this.gvViewDetailSource;
            this.gcViewDetailSource.MenuManager = this.barManager;
            this.gcViewDetailSource.Name = "gcViewDetailSource";
            this.gcViewDetailSource.Size = new System.Drawing.Size(381, 566);
            this.gcViewDetailSource.TabIndex = 26;
            this.gcViewDetailSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewDetailSource});
            // 
            // gvViewDetailSource
            // 
            this.gvViewDetailSource.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSourceControlName});
            this.gvViewDetailSource.GridControl = this.gcViewDetailSource;
            this.gvViewDetailSource.Name = "gvViewDetailSource";
            this.gvViewDetailSource.NewItemRowText = "点此添加数据";
            this.gvViewDetailSource.OptionsView.ShowGroupPanel = false;
            // 
            // colSourceControlName
            // 
            this.colSourceControlName.Caption = "名称";
            this.colSourceControlName.FieldName = "ControlName";
            this.colSourceControlName.Name = "colSourceControlName";
            this.colSourceControlName.OptionsColumn.AllowEdit = false;
            this.colSourceControlName.OptionsFilter.AllowAutoFilter = false;
            this.colSourceControlName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSourceControlName.Visible = true;
            this.colSourceControlName.VisibleIndex = 0;
            // 
            // gpControlShowList
            // 
            this.gpControlShowList.Controls.Add(this.gcViewDetail);
            this.gpControlShowList.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpControlShowList.Location = new System.Drawing.Point(731, 22);
            this.gpControlShowList.Name = "gpControlShowList";
            this.gpControlShowList.Size = new System.Drawing.Size(399, 590);
            this.gpControlShowList.TabIndex = 30;
            this.gpControlShowList.Text = "界面显示项目";
            // 
            // gcViewDetail
            // 
            this.gcViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewDetail.Location = new System.Drawing.Point(2, 22);
            this.gcViewDetail.MainView = this.gvViewDetail;
            this.gcViewDetail.MenuManager = this.barManager;
            this.gcViewDetail.Name = "gcViewDetail";
            this.gcViewDetail.Size = new System.Drawing.Size(395, 566);
            this.gcViewDetail.TabIndex = 27;
            this.gcViewDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewDetail});
            // 
            // gvViewDetail
            // 
            this.gvViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colControlName,
            this.colOrderNo});
            this.gvViewDetail.GridControl = this.gcViewDetail;
            this.gvViewDetail.Name = "gvViewDetail";
            this.gvViewDetail.NewItemRowText = "点此添加数据";
            this.gvViewDetail.OptionsView.ShowGroupPanel = false;
            this.gvViewDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOrderNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colControlName
            // 
            this.colControlName.Caption = "名称";
            this.colControlName.FieldName = "ControlName";
            this.colControlName.Name = "colControlName";
            this.colControlName.OptionsFilter.AllowAutoFilter = false;
            this.colControlName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colControlName.Visible = true;
            this.colControlName.VisibleIndex = 0;
            // 
            // colOrderNo
            // 
            this.colOrderNo.Caption = "序号";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(499, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 42);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(499, 226);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(116, 42);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "移除";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FrmViewConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 730);
            this.Controls.Add(this.gpDetail);
            this.Controls.Add(this.gpBasic);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmViewConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "界面简单配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewConfig_FormClosing);
            this.Load += new System.EventHandler(this.FrmViewConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColumnsCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpBasic)).EndInit();
            this.gpBasic.ResumeLayout(false);
            this.gpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpDetail)).EndInit();
            this.gpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpControlList)).EndInit();
            this.gpControlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcViewDetailSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewDetailSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpControlShowList)).EndInit();
            this.gpControlShowList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewDetail)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.GroupControl gpBasic;
        private DevExpress.XtraEditors.GroupControl gpDetail;
        private DevExpress.XtraEditors.TextEdit teColumnsCount;
        private DevExpress.XtraEditors.LabelControl lblItemCode;
        private DevExpress.XtraGrid.GridControl gcViewDetailSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewDetailSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceControlName;
        private DevExpress.XtraGrid.GridControl gcViewDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colControlName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.GroupControl gpControlList;
        private DevExpress.XtraEditors.GroupControl gpControlShowList;
        private DevExpress.XtraBars.BarButtonItem barItemFormulaCfg;
    }
}