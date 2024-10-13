namespace YF.MWS.Win.View.Extend
{
    partial class FrmWeightQcList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightQcList));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDesign = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.combFinishState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblWeightDate = new DevExpress.XtraEditors.LabelControl();
            this.gcWeightQc = new DevExpress.XtraGrid.GridControl();
            this.gvWeightQc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeightQc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeightQc)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "preview_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "template_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "design_16x16.png");
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
            this.btnItemEdit,
            this.barItemAdd,
            this.barItemPrint,
            this.barItemDesign});
            this.barManager.MaxItemId = 14;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDesign)});
            this.barTop.Text = "Tools";
            // 
            // barItemAdd
            // 
            this.barItemAdd.Caption = "新增质检单";
            this.barItemAdd.Id = 11;
            this.barItemAdd.ImageIndex = 0;
            this.barItemAdd.Name = "barItemAdd";
            this.barItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAdd_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "完善质检单";
            this.btnItemEdit.Id = 1;
            this.btnItemEdit.ImageIndex = 3;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // barItemPrint
            // 
            this.barItemPrint.Caption = "打印";
            this.barItemPrint.Id = 12;
            this.barItemPrint.ImageIndex = 2;
            this.barItemPrint.Name = "barItemPrint";
            this.barItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemPrint_ItemClick);
            // 
            // barItemDesign
            // 
            this.barItemDesign.Caption = "设计报表模板";
            this.barItemDesign.Id = 13;
            this.barItemDesign.ImageIndex = 4;
            this.barItemDesign.Name = "barItemDesign";
            this.barItemDesign.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDesign_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(817, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 509);
            this.barDockControlBottom.Size = new System.Drawing.Size(817, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 478);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(817, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 478);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExportExcel);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.teEndDate);
            this.panelControl1.Controls.Add(this.lblRange);
            this.panelControl1.Controls.Add(this.combFinishState);
            this.panelControl1.Controls.Add(this.teStartDate);
            this.panelControl1.Controls.Add(this.lblWeightDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(817, 44);
            this.panelControl1.TabIndex = 7;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::YF.MWS.Win.Properties.Resources.exportexcel_16x16;
            this.btnExportExcel.Location = new System.Drawing.Point(602, 14);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 90;
            this.btnExportExcel.Text = "导出";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::YF.MWS.Win.Properties.Resources.search_16x16;
            this.btnSearch.Location = new System.Drawing.Point(508, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 89;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // teEndDate
            // 
            this.teEndDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndDate.Location = new System.Drawing.Point(217, 15);
            this.teEndDate.Name = "teEndDate";
            this.teEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teEndDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teEndDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.teEndDate.Size = new System.Drawing.Size(100, 20);
            this.teEndDate.TabIndex = 88;
            // 
            // lblRange
            // 
            this.lblRange.Location = new System.Drawing.Point(189, 18);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(12, 14);
            this.lblRange.TabIndex = 87;
            this.lblRange.Text = "至";
            // 
            // combFinishState
            // 
            this.combFinishState.EditValue = "所有磅单";
            this.combFinishState.Location = new System.Drawing.Point(333, 15);
            this.combFinishState.Name = "combFinishState";
            this.combFinishState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combFinishState.Properties.Items.AddRange(new object[] {
            "未检验磅单",
            "已检验磅单",
            "所有磅单"});
            this.combFinishState.Size = new System.Drawing.Size(157, 20);
            this.combFinishState.TabIndex = 86;
            // 
            // teStartDate
            // 
            this.teStartDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartDate.Location = new System.Drawing.Point(76, 15);
            this.teStartDate.Name = "teStartDate";
            this.teStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teStartDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teStartDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.teStartDate.Size = new System.Drawing.Size(100, 20);
            this.teStartDate.TabIndex = 63;
            // 
            // lblWeightDate
            // 
            this.lblWeightDate.Location = new System.Drawing.Point(14, 17);
            this.lblWeightDate.Name = "lblWeightDate";
            this.lblWeightDate.Size = new System.Drawing.Size(52, 14);
            this.lblWeightDate.TabIndex = 40;
            this.lblWeightDate.Text = "磅单日期:";
            // 
            // gcWeightQc
            // 
            this.gcWeightQc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeightQc.Location = new System.Drawing.Point(0, 75);
            this.gcWeightQc.MainView = this.gvWeightQc;
            this.gcWeightQc.Name = "gcWeightQc";
            this.gcWeightQc.Size = new System.Drawing.Size(817, 434);
            this.gcWeightQc.TabIndex = 8;
            this.gcWeightQc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeightQc});
            // 
            // gvWeightQc
            // 
            this.gvWeightQc.GridControl = this.gcWeightQc;
            this.gvWeightQc.Name = "gvWeightQc";
            this.gvWeightQc.OptionsBehavior.Editable = false;
            this.gvWeightQc.OptionsBehavior.ReadOnly = true;
            this.gvWeightQc.OptionsPrint.AutoWidth = false;
            this.gvWeightQc.OptionsView.ShowFooter = true;
            this.gvWeightQc.OptionsView.ShowGroupPanel = false;
            this.gvWeightQc.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvWeightQc_CustomColumnDisplayText);
            this.gvWeightQc.DoubleClick += new System.EventHandler(this.gvWeightQc_DoubleClick);
            // 
            // sfdFileSave
            // 
            this.sfdFileSave.Filter = "Excel 文件|*.xls";
            // 
            // FrmWeightQcList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 509);
            this.Controls.Add(this.gcWeightQc);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmWeightQcList";
            this.Text = "质量检测";
            this.Load += new System.EventHandler(this.FrmWeightQcList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeightQc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeightQc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit; 
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.ComboBoxEdit combFinishState;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.LabelControl lblWeightDate;
        private DevExpress.XtraGrid.GridControl gcWeightQc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeightQc;
        private System.Windows.Forms.SaveFileDialog sfdFileSave;
        private DevExpress.XtraBars.BarButtonItem barItemAdd;
        private DevExpress.XtraBars.BarButtonItem barItemPrint;
        private DevExpress.XtraBars.BarButtonItem barItemDesign; 
    }
}