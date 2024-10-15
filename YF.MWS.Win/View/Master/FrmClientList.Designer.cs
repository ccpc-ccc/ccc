namespace YF.MWS.Win.View.Master
{
    partial class FrmClientList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.gcClient = new DevExpress.XtraGrid.GridControl();
            this.gvClient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClient)).BeginInit();
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
            this.btnItemSearch,
            this.btnItemEdit,
            this.barItemDelete});
            this.barManager.MaxItemId = 12;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelete)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Caption = "搜索";
            this.btnItemSearch.Id = 1;
            this.btnItemSearch.ImageIndex = 0;
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSearch_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 7;
            this.btnItemEdit.ImageIndex = 1;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1354, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 767);
            this.barDockControlBottom.Size = new System.Drawing.Size(1354, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 736);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1354, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 736);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "search_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // gcClient
            // 
            this.gcClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcClient.Location = new System.Drawing.Point(0, 31);
            this.gcClient.MainView = this.gvClient;
            this.gcClient.MenuManager = this.barManager;
            this.gcClient.Name = "gcClient";
            this.gcClient.Size = new System.Drawing.Size(1354, 736);
            this.gcClient.TabIndex = 23;
            this.gcClient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClient});
            // 
            // gvClient
            // 
            this.gvClient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineCode,
            this.colClientName,
            this.colRegisterDate,
            this.colCreateTime});
            this.gvClient.GridControl = this.gcClient;
            this.gvClient.Name = "gvClient";
            this.gvClient.NewItemRowText = "点此添加数据";
            this.gvClient.OptionsView.ShowGroupPanel = false;
            // 
            // colMachineCode
            // 
            this.colMachineCode.Caption = "机器码";
            this.colMachineCode.FieldName = "MachineCode";
            this.colMachineCode.Name = "colMachineCode";
            this.colMachineCode.OptionsColumn.AllowEdit = false;
            this.colMachineCode.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colMachineCode.Visible = true;
            this.colMachineCode.VisibleIndex = 0;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "客户端名称";
            this.colClientName.FieldName = "ClientName";
            this.colClientName.Name = "colClientName";
            this.colClientName.OptionsColumn.AllowEdit = false;
            this.colClientName.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colClientName.Visible = true;
            this.colClientName.VisibleIndex = 1;
            // 
            // colRegisterDate
            // 
            this.colRegisterDate.Caption = "注册日期";
            this.colRegisterDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colRegisterDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRegisterDate.FieldName = "RegisterDate";
            this.colRegisterDate.Name = "colRegisterDate";
            this.colRegisterDate.OptionsColumn.AllowEdit = false;
            this.colRegisterDate.Visible = true;
            this.colRegisterDate.VisibleIndex = 2;
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
            this.colCreateTime.VisibleIndex = 3;
            // 
            // barItemDelete
            // 
            this.barItemDelete.Caption = "删除";
            this.barItemDelete.Id = 11;
            this.barItemDelete.ImageIndex = 2;
            this.barItemDelete.Name = "barItemDelete";
            this.barItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelete_ItemClick);
            // 
            // FrmClientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 767);
            this.Controls.Add(this.gcClient);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmClientList";
            this.Text = "客户端管理";
            this.Load += new System.EventHandler(this.FrmClientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemSearch;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraGrid.GridControl gcClient;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClient;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClientName;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
    }
}