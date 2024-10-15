namespace YF.MWS.Win.View.Extend
{
    partial class FrmMeasureBatchAudit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMeasureBatchAudit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemFreightSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPaymentSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemPaymentSettle = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAuth = new DevExpress.XtraBars.BarButtonItem();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
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
            this.btnItemPaymentSettle,
            this.btnItemPrint,
            this.barItemSettle,
            this.barItemAuth,
            this.barItemFreightSettle,
            this.barItemPaymentSettle,
            this.barItemPrint,
            this.barItemClose});
            this.barManager.MaxItemId = 17;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemFreightSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPaymentSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemSettle
            // 
            this.barItemSettle.Caption = "财务结算";
            this.barItemSettle.Id = 11;
            this.barItemSettle.ImageIndex = 0;
            this.barItemSettle.Name = "barItemSettle";
            this.barItemSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSettle_ItemClick);
            // 
            // barItemFreightSettle
            // 
            this.barItemFreightSettle.Caption = "运费结算";
            this.barItemFreightSettle.Id = 13;
            this.barItemFreightSettle.ImageIndex = 1;
            this.barItemFreightSettle.Name = "barItemFreightSettle";
            this.barItemFreightSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemFreightSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemFreightSettle_ItemClick);
            // 
            // barItemPaymentSettle
            // 
            this.barItemPaymentSettle.Caption = "货款结算";
            this.barItemPaymentSettle.Id = 14;
            this.barItemPaymentSettle.ImageIndex = 1;
            this.barItemPaymentSettle.Name = "barItemPaymentSettle";
            this.barItemPaymentSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPaymentSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemPaymentSettle_ItemClick);
            // 
            // barItemPrint
            // 
            this.barItemPrint.AllowAllUp = true;
            this.barItemPrint.Caption = "打印";
            this.barItemPrint.Id = 15;
            this.barItemPrint.ImageIndex = 3;
            this.barItemPrint.Name = "barItemPrint";
            this.barItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barItemClose
            // 
            this.barItemClose.Caption = "关闭";
            this.barItemClose.Id = 16;
            this.barItemClose.ImageIndex = 5;
            this.barItemClose.Name = "barItemClose";
            this.barItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(956, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 490);
            this.barDockControlBottom.Size = new System.Drawing.Size(956, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 459);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(956, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 459);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "currency_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "summary_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "textbox_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "print_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "weight_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "close_16x16.png");
            // 
            // btnItemPaymentSettle
            // 
            this.btnItemPaymentSettle.Caption = "货款结算";
            this.btnItemPaymentSettle.Id = 1;
            this.btnItemPaymentSettle.ImageIndex = 0;
            this.btnItemPaymentSettle.Name = "btnItemPaymentSettle";
            this.btnItemPaymentSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemPrint
            // 
            this.btnItemPrint.Caption = "打印";
            this.btnItemPrint.Id = 7;
            this.btnItemPrint.ImageIndex = 1;
            this.btnItemPrint.Name = "btnItemPrint";
            this.btnItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemAuth
            // 
            this.barItemAuth.Caption = "财务审核";
            this.barItemAuth.Id = 12;
            this.barItemAuth.ImageIndex = 4;
            this.barItemAuth.Name = "barItemAuth";
            this.barItemAuth.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.Location = new System.Drawing.Point(0, 31);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.Size = new System.Drawing.Size(956, 459);
            this.gcWeight.TabIndex = 11;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // gvWeight
            // 
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsPrint.AutoWidth = false;
            this.gvWeight.OptionsView.ShowFooter = true;
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            // 
            // FrmMeasureBatchAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 490);
            this.Controls.Add(this.gcWeight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmMeasureBatchAudit";
            this.Text = "计量方财务审核";
            this.Load += new System.EventHandler(this.FrmMeasureBatchAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barItemSettle;
        private DevExpress.XtraBars.BarButtonItem barItemFreightSettle;
        private DevExpress.XtraBars.BarButtonItem barItemPaymentSettle;
        private DevExpress.XtraBars.BarButtonItem barItemPrint;
        private DevExpress.XtraBars.BarButtonItem barItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemPaymentSettle;
        private DevExpress.XtraBars.BarButtonItem btnItemPrint;
        private DevExpress.XtraBars.BarButtonItem barItemAuth;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
    }
}