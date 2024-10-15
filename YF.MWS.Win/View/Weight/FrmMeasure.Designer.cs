namespace YF.MWS.Win.View.Weight
{
    partial class FrmMeasure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMeasure));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.gpMainWeight = new DevExpress.XtraEditors.GroupControl();
            this.scWeight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.mainWeight = new YF.MWS.Win.Uc.MainWeight();
            this.plHeader = new DevExpress.XtraEditors.PanelControl();
            this.deFinishTime = new DevExpress.XtraEditors.DateEdit();
            this.lblFinishTime = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).BeginInit();
            this.gpMainWeight.SuspendLayout();
            this.scWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).BeginInit();
            this.plHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties)).BeginInit();
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
            this.barItemClose});
            this.barManager.MaxItemId = 11;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemClose)});
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
            // barItemClose
            // 
            this.barItemClose.Caption = "关闭";
            this.barItemClose.Id = 10;
            this.barItemClose.ImageIndex = 1;
            this.barItemClose.Name = "barItemClose";
            this.barItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(591, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 407);
            this.barDockControlBottom.Size = new System.Drawing.Size(591, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 376);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(591, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 376);
            // 
            // btnItemPrint
            // 
            this.btnItemPrint.Caption = "打印";
            this.btnItemPrint.Id = 7;
            this.btnItemPrint.ImageIndex = 1;
            this.btnItemPrint.Name = "btnItemPrint";
            this.btnItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gpMainWeight
            // 
            this.gpMainWeight.Controls.Add(this.scWeight);
            this.gpMainWeight.Controls.Add(this.plHeader);
            this.gpMainWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpMainWeight.Location = new System.Drawing.Point(0, 31);
            this.gpMainWeight.Name = "gpMainWeight";
            this.gpMainWeight.Size = new System.Drawing.Size(591, 376);
            this.gpMainWeight.TabIndex = 41;
            this.gpMainWeight.Text = "磅单信息";
            // 
            // scWeight
            // 
            this.scWeight.Controls.Add(this.mainWeight);
            this.scWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scWeight.Location = new System.Drawing.Point(2, 78);
            this.scWeight.Name = "scWeight";
            this.scWeight.Size = new System.Drawing.Size(587, 296);
            this.scWeight.TabIndex = 46;
            // 
            // mainWeight
            // 
            this.mainWeight.BoundSource = BaseMetadata.OrderSource.Measure;
            this.mainWeight.Cfg = null;
            this.mainWeight.CurrentViewType = YF.MWS.Metadata.ViewType.Measure;
            this.mainWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWeight.Location = new System.Drawing.Point(0, 0);
            this.mainWeight.LstAttribute = ((System.Collections.Generic.List<YF.MWS.Db.SAttribute>)(resources.GetObject("mainWeight.LstAttribute")));
            this.mainWeight.Name = "mainWeight";
            this.mainWeight.Size = new System.Drawing.Size(587, 296);
            this.mainWeight.TabIndex = 0;
            // 
            // plHeader
            // 
            this.plHeader.Controls.Add(this.deFinishTime);
            this.plHeader.Controls.Add(this.lblFinishTime);
            this.plHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHeader.Location = new System.Drawing.Point(2, 22);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(587, 56);
            this.plHeader.TabIndex = 2;
            // 
            // deFinishTime
            // 
            this.deFinishTime.EditValue = null;
            this.deFinishTime.Location = new System.Drawing.Point(89, 20);
            this.deFinishTime.MenuManager = this.barManager;
            this.deFinishTime.Name = "deFinishTime";
            this.deFinishTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFinishTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.deFinishTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFinishTime.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.deFinishTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFinishTime.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.deFinishTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFinishTime.Size = new System.Drawing.Size(224, 20);
            this.deFinishTime.TabIndex = 1;
            this.deFinishTime.Tag = "FinishTime";
            // 
            // lblFinishTime
            // 
            this.lblFinishTime.Location = new System.Drawing.Point(22, 23);
            this.lblFinishTime.Name = "lblFinishTime";
            this.lblFinishTime.Size = new System.Drawing.Size(28, 14);
            this.lblFinishTime.TabIndex = 0;
            this.lblFinishTime.Text = "日期:";
            // 
            // FrmMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 407);
            this.Controls.Add(this.gpMainWeight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmMeasure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑计量方详情";
            this.Load += new System.EventHandler(this.FrmMeasure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).EndInit();
            this.gpMainWeight.ResumeLayout(false);
            this.scWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).EndInit();
            this.plHeader.ResumeLayout(false);
            this.plHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinishTime.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.DateEdit deFinishTime;
        private DevExpress.XtraEditors.LabelControl lblFinishTime;
    }
}