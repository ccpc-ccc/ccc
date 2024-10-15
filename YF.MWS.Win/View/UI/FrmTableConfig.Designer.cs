namespace YF.MWS.Win.View.UI
{
    partial class FrmTableConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableConfig));
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
            this.gpDetail = new DevExpress.XtraEditors.GroupControl();
            this.gpControlList = new DevExpress.XtraEditors.GroupControl();
            this.gcViewDetailSource = new DevExpress.XtraGrid.GridControl();
            this.gvViewDetailSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSourceControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpControlShowList = new DevExpress.XtraEditors.GroupControl();
            this.gcViewDetail = new DevExpress.XtraGrid.GridControl();
            this.gvViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
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
            this.btnItemClose});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
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
            this.barDockControlTop.Size = new System.Drawing.Size(1132, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 730);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1132, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 706);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1132, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 706);
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
            // gpDetail
            // 
            this.gpDetail.Controls.Add(this.gpControlList);
            this.gpDetail.Controls.Add(this.gpControlShowList);
            this.gpDetail.Controls.Add(this.btnAdd);
            this.gpDetail.Controls.Add(this.btnRemove);
            this.gpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpDetail.Location = new System.Drawing.Point(0, 24);
            this.gpDetail.Name = "gpDetail";
            this.gpDetail.Size = new System.Drawing.Size(1132, 706);
            this.gpDetail.TabIndex = 5;
            this.gpDetail.Text = "显示设置";
            // 
            // gpControlList
            // 
            this.gpControlList.Controls.Add(this.gcViewDetailSource);
            this.gpControlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpControlList.Location = new System.Drawing.Point(2, 23);
            this.gpControlList.Name = "gpControlList";
            this.gpControlList.Size = new System.Drawing.Size(385, 681);
            this.gpControlList.TabIndex = 31;
            this.gpControlList.Text = "界面备选项目库";
            // 
            // gcViewDetailSource
            // 
            this.gcViewDetailSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewDetailSource.Location = new System.Drawing.Point(2, 23);
            this.gcViewDetailSource.MainView = this.gvViewDetailSource;
            this.gcViewDetailSource.MenuManager = this.barManager;
            this.gcViewDetailSource.Name = "gcViewDetailSource";
            this.gcViewDetailSource.Size = new System.Drawing.Size(381, 656);
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
            this.gvViewDetailSource.OptionsBehavior.Editable = false;
            this.gvViewDetailSource.OptionsBehavior.ReadOnly = true;
            this.gvViewDetailSource.OptionsView.ShowGroupPanel = false;
            this.gvViewDetailSource.DoubleClick += new System.EventHandler(this.gvViewDetailSource_DoubleClick);
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
            this.gpControlShowList.Location = new System.Drawing.Point(731, 23);
            this.gpControlShowList.Name = "gpControlShowList";
            this.gpControlShowList.Size = new System.Drawing.Size(399, 681);
            this.gpControlShowList.TabIndex = 30;
            this.gpControlShowList.Text = "界面显示项目";
            // 
            // gcViewDetail
            // 
            this.gcViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewDetail.Location = new System.Drawing.Point(2, 23);
            this.gcViewDetail.MainView = this.gvViewDetail;
            this.gcViewDetail.MenuManager = this.barManager;
            this.gcViewDetail.Name = "gcViewDetail";
            this.gcViewDetail.Size = new System.Drawing.Size(395, 656);
            this.gcViewDetail.TabIndex = 27;
            this.gcViewDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewDetail});
            // 
            // gvViewDetail
            // 
            this.gvViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colControlName});
            this.gvViewDetail.GridControl = this.gcViewDetail;
            this.gvViewDetail.Name = "gvViewDetail";
            this.gvViewDetail.NewItemRowText = "点此添加数据";
            this.gvViewDetail.OptionsBehavior.Editable = false;
            this.gvViewDetail.OptionsBehavior.ReadOnly = true;
            this.gvViewDetail.OptionsView.ShowGroupPanel = false;
            this.gvViewDetail.DoubleClick += new System.EventHandler(this.gvViewDetail_DoubleClick);
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
            // FrmTableConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 730);
            this.Controls.Add(this.gpDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTableConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "界面简单配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewConfig_FormClosing);
            this.Load += new System.EventHandler(this.FrmViewConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl gpDetail;
        private DevExpress.XtraGrid.GridControl gcViewDetailSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewDetailSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceControlName;
        private DevExpress.XtraGrid.GridControl gcViewDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colControlName;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.GroupControl gpControlList;
        private DevExpress.XtraEditors.GroupControl gpControlShowList;
    }
}