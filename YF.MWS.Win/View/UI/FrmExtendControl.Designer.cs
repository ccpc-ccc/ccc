namespace YF.MWS.Win.View.UI
{
    partial class FrmExtendControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExtendControl));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAddControl = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemModify = new DevExpress.XtraBars.BarButtonItem();
            this.barItemEditControl = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDeleteSubject = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDeleteControl = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.barItemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.gpViewDetail = new DevExpress.XtraEditors.GroupControl();
            this.gcAttribute = new DevExpress.XtraGrid.GridControl();
            this.gvAttribute = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAttributeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpList = new DevExpress.XtraEditors.GroupControl();
            this.gcSubjectList = new DevExpress.XtraGrid.GridControl();
            this.gvSubjectList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSubjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpViewDetail)).BeginInit();
            this.gpViewDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpList)).BeginInit();
            this.gpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubjectList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjectList)).BeginInit();
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
            this.btnItemModify,
            this.btnItemSetting,
            this.barItemNew,
            this.barItemEditControl,
            this.barItemAddControl,
            this.barItemSetting,
            this.barItemDeleteControl,
            this.barItemDeleteSubject});
            this.barManager.MaxItemId = 16;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAddControl, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemModify, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemEditControl),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDeleteSubject, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDeleteControl)});
            this.barTop.Text = "Tools";
            // 
            // barItemNew
            // 
            this.barItemNew.Caption = "新建";
            this.barItemNew.Id = 10;
            this.barItemNew.ImageOptions.ImageIndex = 3;
            this.barItemNew.Name = "barItemNew";
            this.barItemNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemNew_ItemClick);
            // 
            // barItemAddControl
            // 
            this.barItemAddControl.Caption = "添加控件";
            this.barItemAddControl.Id = 12;
            this.barItemAddControl.ImageOptions.ImageIndex = 5;
            this.barItemAddControl.Name = "barItemAddControl";
            this.barItemAddControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAddControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAddControl_ItemClick);
            // 
            // btnItemModify
            // 
            this.btnItemModify.Caption = "编辑分类";
            this.btnItemModify.Id = 1;
            this.btnItemModify.ImageOptions.ImageIndex = 4;
            this.btnItemModify.Name = "btnItemModify";
            this.btnItemModify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemModify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnItemModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemModify_ItemClick);
            // 
            // barItemEditControl
            // 
            this.barItemEditControl.Caption = "编辑控件";
            this.barItemEditControl.Id = 11;
            this.barItemEditControl.ImageOptions.ImageIndex = 4;
            this.barItemEditControl.Name = "barItemEditControl";
            this.barItemEditControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemEditControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemEditControl_ItemClick);
            // 
            // barItemDeleteSubject
            // 
            this.barItemDeleteSubject.Caption = "删除分类";
            this.barItemDeleteSubject.Id = 15;
            this.barItemDeleteSubject.ImageOptions.ImageIndex = 6;
            this.barItemDeleteSubject.Name = "barItemDeleteSubject";
            this.barItemDeleteSubject.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDeleteSubject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barItemDeleteSubject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDeleteSubject_ItemClick);
            // 
            // barItemDeleteControl
            // 
            this.barItemDeleteControl.Caption = "删除控件";
            this.barItemDeleteControl.Id = 14;
            this.barItemDeleteControl.ImageOptions.ImageIndex = 6;
            this.barItemDeleteControl.Name = "barItemDeleteControl";
            this.barItemDeleteControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDeleteControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDeleteControl_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(906, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(906, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 473);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(906, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 473);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "setup_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "design_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "delete_16x16.png");
            // 
            // btnItemSetting
            // 
            this.btnItemSetting.Caption = "设为默认界面";
            this.btnItemSetting.Id = 7;
            this.btnItemSetting.ImageOptions.ImageIndex = 1;
            this.btnItemSetting.Name = "btnItemSetting";
            this.btnItemSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemSetting
            // 
            this.barItemSetting.Caption = "设计基础控件";
            this.barItemSetting.Id = 13;
            this.barItemSetting.ImageOptions.ImageIndex = 2;
            this.barItemSetting.Name = "barItemSetting";
            this.barItemSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gpViewDetail
            // 
            this.gpViewDetail.Controls.Add(this.gcAttribute);
            this.gpViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpViewDetail.Location = new System.Drawing.Point(321, 24);
            this.gpViewDetail.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gpViewDetail.Name = "gpViewDetail";
            this.gpViewDetail.Size = new System.Drawing.Size(585, 473);
            this.gpViewDetail.TabIndex = 9;
            this.gpViewDetail.Text = "扩展控件列表";
            // 
            // gcAttribute
            // 
            this.gcAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAttribute.Location = new System.Drawing.Point(2, 23);
            this.gcAttribute.MainView = this.gvAttribute;
            this.gcAttribute.MenuManager = this.barManager;
            this.gcAttribute.Name = "gcAttribute";
            this.gcAttribute.Size = new System.Drawing.Size(581, 448);
            this.gcAttribute.TabIndex = 25;
            this.gcAttribute.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttribute});
            // 
            // gvAttribute
            // 
            this.gvAttribute.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAttributeName,
            this.colFieldName,
            this.colCreateTime});
            this.gvAttribute.GridControl = this.gcAttribute;
            this.gvAttribute.Name = "gvAttribute";
            this.gvAttribute.NewItemRowText = "点此添加数据";
            this.gvAttribute.OptionsView.ShowGroupPanel = false;
            this.gvAttribute.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAttributeName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAttributeName
            // 
            this.colAttributeName.Caption = "名称";
            this.colAttributeName.FieldName = "AttributeName";
            this.colAttributeName.Name = "colAttributeName";
            this.colAttributeName.OptionsColumn.AllowEdit = false;
            this.colAttributeName.OptionsFilter.AllowAutoFilter = false;
            this.colAttributeName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colAttributeName.Visible = true;
            this.colAttributeName.VisibleIndex = 0;
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "字段名称";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.OptionsColumn.AllowEdit = false;
            this.colFieldName.OptionsFilter.AllowAutoFilter = false;
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 1;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsColumn.AllowEdit = false;
            this.colCreateTime.OptionsFilter.AllowAutoFilter = false;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 2;
            // 
            // gpList
            // 
            this.gpList.Controls.Add(this.gcSubjectList);
            this.gpList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpList.Location = new System.Drawing.Point(0, 24);
            this.gpList.Name = "gpList";
            this.gpList.Size = new System.Drawing.Size(321, 473);
            this.gpList.TabIndex = 8;
            this.gpList.Text = "界面主题列表";
            // 
            // gcSubjectList
            // 
            this.gcSubjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSubjectList.Location = new System.Drawing.Point(2, 23);
            this.gcSubjectList.MainView = this.gvSubjectList;
            this.gcSubjectList.MenuManager = this.barManager;
            this.gcSubjectList.Name = "gcSubjectList";
            this.gcSubjectList.Size = new System.Drawing.Size(317, 448);
            this.gcSubjectList.TabIndex = 24;
            this.gcSubjectList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSubjectList});
            // 
            // gvSubjectList
            // 
            this.gvSubjectList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSubjectName});
            this.gvSubjectList.GridControl = this.gcSubjectList;
            this.gvSubjectList.Name = "gvSubjectList";
            this.gvSubjectList.NewItemRowText = "点此添加数据";
            this.gvSubjectList.OptionsView.ShowGroupPanel = false;
            this.gvSubjectList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSubjectName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvSubjectList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvSubjectList_FocusedRowChanged);
            // 
            // colSubjectName
            // 
            this.colSubjectName.Caption = "名称";
            this.colSubjectName.FieldName = "SubjectName";
            this.colSubjectName.Name = "colSubjectName";
            this.colSubjectName.OptionsColumn.AllowEdit = false;
            this.colSubjectName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSubjectName.Visible = true;
            this.colSubjectName.VisibleIndex = 0;
            // 
            // FrmExtendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 497);
            this.Controls.Add(this.gpViewDetail);
            this.Controls.Add(this.gpList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmExtendControl";
            this.Text = "扩展控件管理";
            this.Load += new System.EventHandler(this.FrmExtendControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpViewDetail)).EndInit();
            this.gpViewDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpList)).EndInit();
            this.gpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSubjectList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barItemNew;
        private DevExpress.XtraBars.BarButtonItem btnItemSetting;
        private DevExpress.XtraBars.BarButtonItem barItemAddControl;
        private DevExpress.XtraBars.BarButtonItem btnItemModify;
        private DevExpress.XtraBars.BarButtonItem barItemEditControl;
        private DevExpress.XtraBars.BarButtonItem barItemDeleteSubject;
        private DevExpress.XtraBars.BarButtonItem barItemDeleteControl;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem barItemSetting;
        private DevExpress.XtraEditors.GroupControl gpViewDetail;
        private DevExpress.XtraGrid.GridControl gcAttribute;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttribute;
        private DevExpress.XtraGrid.Columns.GridColumn colAttributeName;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraEditors.GroupControl gpList;
        private DevExpress.XtraGrid.GridControl gcSubjectList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSubjectList;
        private DevExpress.XtraGrid.Columns.GridColumn colSubjectName;
    }
}