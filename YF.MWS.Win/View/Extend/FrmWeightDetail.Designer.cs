namespace YF.MWS.Win.View.Extend
{
    partial class FrmWeightDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightDetail));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.gpMainWeight = new DevExpress.XtraEditors.GroupControl();
            this.scWeight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.mainWeight = new YF.MWS.Win.Uc.MainWeight();
            this.plHeader = new DevExpress.XtraEditors.PanelControl();
            this.deTareTime = new DevExpress.XtraEditors.DateEdit();
            this.lblTareTime = new DevExpress.XtraEditors.LabelControl();
            this.deGrossTime = new DevExpress.XtraEditors.DateEdit();
            this.lblGrossTime = new DevExpress.XtraEditors.LabelControl();
            this.deFinishTime = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deCreateTime = new DevExpress.XtraEditors.DateEdit();
            this.lblFinishTime = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).BeginInit();
            this.gpMainWeight.SuspendLayout();
            this.scWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).BeginInit();
            this.plHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTareTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTareTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGrossTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGrossTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
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
            this.btnItemPrint,
            this.barItemClose,
            this.barButtonItem1});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
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
            // barItemClose
            // 
            this.barItemClose.Caption = "关闭";
            this.barItemClose.Id = 10;
            this.barItemClose.ImageOptions.ImageIndex = 1;
            this.barItemClose.Name = "barItemClose";
            this.barItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClose_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "保存并打印";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(929, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(929, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 481);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(929, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 481);
            // 
            // btnItemPrint
            // 
            this.btnItemPrint.Caption = "打印";
            this.btnItemPrint.Id = 7;
            this.btnItemPrint.ImageOptions.ImageIndex = 1;
            this.btnItemPrint.Name = "btnItemPrint";
            this.btnItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gpMainWeight
            // 
            this.gpMainWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMainWeight.Controls.Add(this.scWeight);
            this.gpMainWeight.Controls.Add(this.plHeader);
            this.gpMainWeight.Location = new System.Drawing.Point(0, 30);
            this.gpMainWeight.Name = "gpMainWeight";
            this.gpMainWeight.Size = new System.Drawing.Size(929, 475);
            this.gpMainWeight.TabIndex = 40;
            this.gpMainWeight.Text = "磅单信息";
            // 
            // scWeight
            // 
            this.scWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scWeight.Controls.Add(this.mainWeight);
            this.scWeight.Location = new System.Drawing.Point(2, 85);
            this.scWeight.Name = "scWeight";
            this.scWeight.Size = new System.Drawing.Size(925, 388);
            this.scWeight.TabIndex = 46;
            // 
            // mainWeight
            // 
            this.mainWeight.BoundSource = YF.MWS.BaseMetadata.OrderSource.Additional;
            this.mainWeight.Cfg = null;
            this.mainWeight.CurrentViewType = YF.MWS.Metadata.ViewType.Weight;
            this.mainWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWeight.FrmWeight = null;
            this.mainWeight.Location = new System.Drawing.Point(0, 0);
            //this.mainWeight.LstAttribute = null;
            this.mainWeight.Margin = new System.Windows.Forms.Padding(4);
            this.mainWeight.Name = "mainWeight";
            this.mainWeight.Size = new System.Drawing.Size(925, 388);
            this.mainWeight.TabIndex = 0;
            // 
            // plHeader
            // 
            this.plHeader.Controls.Add(this.deTareTime);
            this.plHeader.Controls.Add(this.lblTareTime);
            this.plHeader.Controls.Add(this.deGrossTime);
            this.plHeader.Controls.Add(this.lblGrossTime);
            this.plHeader.Controls.Add(this.deFinishTime);
            this.plHeader.Controls.Add(this.labelControl1);
            this.plHeader.Controls.Add(this.deCreateTime);
            this.plHeader.Controls.Add(this.lblFinishTime);
            this.plHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHeader.Location = new System.Drawing.Point(2, 23);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(925, 62);
            this.plHeader.TabIndex = 2;
            // 
            // deTareTime
            // 
            this.deTareTime.EditValue = null;
            this.deTareTime.Location = new System.Drawing.Point(385, 36);
            this.deTareTime.MenuManager = this.barManager;
            this.deTareTime.Name = "deTareTime";
            this.deTareTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTareTime.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.deTareTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTareTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deTareTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTareTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deTareTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTareTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.deTareTime.Size = new System.Drawing.Size(181, 20);
            this.deTareTime.TabIndex = 11;
            this.deTareTime.Tag = "FinishTime";
            // 
            // lblTareTime
            // 
            this.lblTareTime.Location = new System.Drawing.Point(318, 39);
            this.lblTareTime.Name = "lblTareTime";
            this.lblTareTime.Size = new System.Drawing.Size(52, 14);
            this.lblTareTime.TabIndex = 10;
            this.lblTareTime.Text = "皮重时间:";
            // 
            // deGrossTime
            // 
            this.deGrossTime.EditValue = null;
            this.deGrossTime.Location = new System.Drawing.Point(385, 10);
            this.deGrossTime.MenuManager = this.barManager;
            this.deGrossTime.Name = "deGrossTime";
            this.deGrossTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deGrossTime.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.deGrossTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deGrossTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deGrossTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGrossTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deGrossTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deGrossTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.deGrossTime.Size = new System.Drawing.Size(181, 20);
            this.deGrossTime.TabIndex = 9;
            this.deGrossTime.Tag = "FinishTime";
            // 
            // lblGrossTime
            // 
            this.lblGrossTime.Location = new System.Drawing.Point(318, 13);
            this.lblGrossTime.Name = "lblGrossTime";
            this.lblGrossTime.Size = new System.Drawing.Size(52, 14);
            this.lblGrossTime.TabIndex = 8;
            this.lblGrossTime.Text = "毛重时间:";
            // 
            // deFinishTime
            // 
            this.deFinishTime.EditValue = null;
            this.deFinishTime.Location = new System.Drawing.Point(98, 36);
            this.deFinishTime.Name = "deFinishTime";
            this.deFinishTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFinishTime.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.deFinishTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFinishTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deFinishTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFinishTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deFinishTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFinishTime.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.deFinishTime.Size = new System.Drawing.Size(181, 20);
            this.deFinishTime.TabIndex = 7;
            this.deFinishTime.Tag = "FinishTime";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "完成日期:";
            // 
            // deCreateTime
            // 
            this.deCreateTime.EditValue = null;
            this.deCreateTime.Location = new System.Drawing.Point(98, 10);
            this.deCreateTime.MenuManager = this.barManager;
            this.deCreateTime.Name = "deCreateTime";
            this.deCreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreateTime.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.deCreateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deCreateTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deCreateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deCreateTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.deCreateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deCreateTime.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.deCreateTime.Size = new System.Drawing.Size(181, 20);
            this.deCreateTime.TabIndex = 7;
            this.deCreateTime.Tag = "FinishTime";
            // 
            // lblFinishTime
            // 
            this.lblFinishTime.Location = new System.Drawing.Point(31, 13);
            this.lblFinishTime.Name = "lblFinishTime";
            this.lblFinishTime.Size = new System.Drawing.Size(52, 14);
            this.lblFinishTime.TabIndex = 6;
            this.lblFinishTime.Text = "开始日期:";
            // 
            // FrmWeightDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 505);
            this.Controls.Add(this.gpMainWeight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmWeightDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "磅单编辑";
            this.Load += new System.EventHandler(this.FrmWeightDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).EndInit();
            this.gpMainWeight.ResumeLayout(false);
            this.scWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).EndInit();
            this.plHeader.ResumeLayout(false);
            this.plHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTareTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTareTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGrossTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deGrossTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreateTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem barItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnItemPrint;
        private DevExpress.XtraEditors.GroupControl gpMainWeight;
        private DevExpress.XtraEditors.XtraScrollableControl scWeight;
        private Uc.MainWeight mainWeight;
        private DevExpress.XtraEditors.PanelControl plHeader;
        private DevExpress.XtraEditors.DateEdit deTareTime;
        private DevExpress.XtraEditors.LabelControl lblTareTime;
        private DevExpress.XtraEditors.DateEdit deGrossTime;
        private DevExpress.XtraEditors.LabelControl lblGrossTime;
        private DevExpress.XtraEditors.DateEdit deCreateTime;
        private DevExpress.XtraEditors.LabelControl lblFinishTime;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.DateEdit deFinishTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}