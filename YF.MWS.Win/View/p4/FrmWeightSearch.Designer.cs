namespace YF.MWS.Win.View.Weight
{
    partial class FrmWeightSearch {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightSearch));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barItemLog = new DevExpress.XtraBars.BarButtonItem();
            this.barItemGraphic = new DevExpress.XtraBars.BarButtonItem();
            this.barItemVedio = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColClose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).BeginInit();
            this.gpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
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
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemVedio,
            this.barItemGraphic,
            this.barItemQuery,
            this.barItemLog});
            this.barManager.MaxItemId = 31;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemQuery, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemLog, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemGraphic),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemVedio)});
            this.barTop.Text = "Tools";
            // 
            // barItemQuery
            // 
            this.barItemQuery.Caption = "连接";
            this.barItemQuery.Id = 20;
            this.barItemQuery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemQuery.ImageOptions.Image")));
            this.barItemQuery.ImageOptions.ImageIndex = 18;
            this.barItemQuery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barItemQuery.ImageOptions.LargeImage")));
            this.barItemQuery.Name = "barItemQuery";
            this.barItemQuery.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemQuery_ItemClick);
            // 
            // barItemLog
            // 
            this.barItemLog.Caption = "编辑";
            this.barItemLog.Id = 28;
            this.barItemLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemLog.ImageOptions.Image")));
            this.barItemLog.ImageOptions.ImageIndex = 13;
            this.barItemLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barItemLog.ImageOptions.LargeImage")));
            this.barItemLog.Name = "barItemLog";
            this.barItemLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemLog_ItemClick);
            // 
            // barItemGraphic
            // 
            this.barItemGraphic.Caption = "开仓门";
            this.barItemGraphic.Id = 11;
            this.barItemGraphic.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemGraphic.ImageOptions.Image")));
            this.barItemGraphic.ImageOptions.ImageIndex = 6;
            this.barItemGraphic.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barItemGraphic.ImageOptions.LargeImage")));
            this.barItemGraphic.Name = "barItemGraphic";
            this.barItemGraphic.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemGraphic.Tag = "";
            this.barItemGraphic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemGraphic_ItemClick);
            // 
            // barItemVedio
            // 
            this.barItemVedio.Caption = "关仓门";
            this.barItemVedio.Id = 10;
            this.barItemVedio.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemVedio.ImageOptions.Image")));
            this.barItemVedio.ImageOptions.ImageIndex = 5;
            this.barItemVedio.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barItemVedio.ImageOptions.LargeImage")));
            this.barItemVedio.Name = "barItemVedio";
            this.barItemVedio.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemVedio.Tag = "";
            this.barItemVedio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemVedio_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(848, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 678);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(848, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 654);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(848, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 654);
            // 
            // gpSearchResult
            // 
            this.gpSearchResult.Controls.Add(this.gcWeight);
            this.gpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSearchResult.Location = new System.Drawing.Point(0, 24);
            this.gpSearchResult.Name = "gpSearchResult";
            this.gpSearchResult.Size = new System.Drawing.Size(848, 654);
            this.gpSearchResult.TabIndex = 6;
            this.gpSearchResult.Text = "查询结果";
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.Location = new System.Drawing.Point(2, 23);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.gcWeight.Size = new System.Drawing.Size(844, 629);
            this.gcWeight.TabIndex = 14;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // gvWeight
            // 
            this.gvWeight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColName,
            this.ColCode,
            this.ColOpen,
            this.ColClose});
            this.gvWeight.DetailHeight = 300;
            this.gvWeight.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.IndicatorWidth = 39;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsEditForm.PopupEditFormWidth = 686;
            this.gvWeight.OptionsSelection.MultiSelect = true;
            this.gvWeight.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            this.gvWeight.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvWeight_CustomDrawRowIndicator);
            // 
            // ColName
            // 
            this.ColName.Caption = "仓库名称";
            this.ColName.FieldName = "WarehName";
            this.ColName.MinWidth = 17;
            this.ColName.Name = "ColName";
            this.ColName.Visible = true;
            this.ColName.VisibleIndex = 0;
            this.ColName.Width = 64;
            // 
            // ColCode
            // 
            this.ColCode.Caption = "仓库编码";
            this.ColCode.FieldName = "WarehCode";
            this.ColCode.MinWidth = 17;
            this.ColCode.Name = "ColCode";
            this.ColCode.Visible = true;
            this.ColCode.VisibleIndex = 1;
            this.ColCode.Width = 64;
            // 
            // ColOpen
            // 
            this.ColOpen.Caption = "开仓命令";
            this.ColOpen.FieldName = "OpenAddress";
            this.ColOpen.MinWidth = 17;
            this.ColOpen.Name = "ColOpen";
            this.ColOpen.Visible = true;
            this.ColOpen.VisibleIndex = 2;
            this.ColOpen.Width = 64;
            // 
            // ColClose
            // 
            this.ColClose.Caption = "关仓命令";
            this.ColClose.FieldName = "CloseAddress";
            this.ColClose.MinWidth = 17;
            this.ColClose.Name = "ColClose";
            this.ColClose.Visible = true;
            this.ColClose.VisibleIndex = 3;
            this.ColClose.Width = 64;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.checkEdit1);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.textEdit1);
            this.panelControl3.Location = new System.Drawing.Point(639, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(196, 21);
            this.panelControl3.TabIndex = 16;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(0, 2);
            this.checkEdit1.MenuManager = this.barManager;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "自动开仓门";
            this.checkEdit1.Size = new System.Drawing.Size(81, 20);
            this.checkEdit1.TabIndex = 2;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(95, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "间隔";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(153, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "秒";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(119, 3);
            this.textEdit1.MenuManager = this.barManager;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(30, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmWeightSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 678);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.gpSearchResult);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmWeightSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库阀门管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWeightYcSearch_FormClosing);
            this.Load += new System.EventHandler(this.FrmWeightSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).EndInit();
            this.gpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barItemVedio;
        private DevExpress.XtraBars.BarButtonItem barItemGraphic;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl gpSearchResult;
        private DevExpress.XtraBars.BarButtonItem barItemQuery;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarButtonItem barItemLog;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn ColName;
        private DevExpress.XtraGrid.Columns.GridColumn ColCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColOpen;
        private DevExpress.XtraGrid.Columns.GridColumn ColClose;
        private System.Windows.Forms.Timer timer1;
    }
}