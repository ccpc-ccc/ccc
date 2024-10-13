namespace YF.MWS.Win.View.Extend
{
    partial class FrmWeightSettle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightSettle));
            this.imgListSmall = new DevExpress.Utils.ImageCollection();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAuth = new DevExpress.XtraBars.BarButtonItem();
            this.barItemFreightSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPaymentSettle = new DevExpress.XtraBars.BarButtonItem();
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
            this.lblPaymentSettleCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblPaymentSettle = new DevExpress.XtraEditors.LabelControl();
            this.lblFreightSettleCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblFreightSettle = new DevExpress.XtraEditors.LabelControl();
            this.lblAuthCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblAuth = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).BeginInit();
            this.gpMainWeight.SuspendLayout();
            this.scWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).BeginInit();
            this.plHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "summary_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "currency_16x16.png");
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
            this.barItemAuth,
            this.btnItemPrint,
            this.barItemClose,
            this.barItemPaymentSettle,
            this.barItemFreightSettle,
            this.barItemSave});
            this.barManager.MaxItemId = 14;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAuth, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemFreightSettle, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPaymentSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemSave
            // 
            this.barItemSave.Caption = "保存原始单据";
            this.barItemSave.Id = 13;
            this.barItemSave.ImageIndex = 0;
            this.barItemSave.Name = "barItemSave";
            this.barItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSave.Tag = "Save";
            this.barItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
            // 
            // barItemAuth
            // 
            this.barItemAuth.Caption = "财务审核";
            this.barItemAuth.Id = 1;
            this.barItemAuth.ImageIndex = 3;
            this.barItemAuth.Name = "barItemAuth";
            this.barItemAuth.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAuth.Tag = "Auth";
            this.barItemAuth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSettle_ItemClick);
            // 
            // barItemFreightSettle
            // 
            this.barItemFreightSettle.Caption = "运费结算";
            this.barItemFreightSettle.Id = 12;
            this.barItemFreightSettle.ImageIndex = 1;
            this.barItemFreightSettle.Name = "barItemFreightSettle";
            this.barItemFreightSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemFreightSettle.Tag = "Freight";
            this.barItemFreightSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemFreightSettle_ItemClick);
            // 
            // barItemPaymentSettle
            // 
            this.barItemPaymentSettle.Caption = "货款结算";
            this.barItemPaymentSettle.Id = 11;
            this.barItemPaymentSettle.ImageIndex = 1;
            this.barItemPaymentSettle.Name = "barItemPaymentSettle";
            this.barItemPaymentSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPaymentSettle.Tag = "Payment";
            this.barItemPaymentSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemPaymentSettle_ItemClick);
            // 
            // barItemClose
            // 
            this.barItemClose.Caption = "关闭";
            this.barItemClose.Id = 10;
            this.barItemClose.ImageIndex = 2;
            this.barItemClose.Name = "barItemClose";
            this.barItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(813, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            this.barDockControlBottom.Size = new System.Drawing.Size(813, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 474);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(813, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 474);
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
            this.gpMainWeight.Size = new System.Drawing.Size(813, 474);
            this.gpMainWeight.TabIndex = 40;
            this.gpMainWeight.Text = "磅单信息";
            // 
            // scWeight
            // 
            this.scWeight.Controls.Add(this.mainWeight);
            this.scWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scWeight.Location = new System.Drawing.Point(2, 72);
            this.scWeight.Name = "scWeight";
            this.scWeight.Size = new System.Drawing.Size(809, 400);
            this.scWeight.TabIndex = 4;
            // 
            // mainWeight
            // 
            this.mainWeight.BoundSource = BaseMetadata.OrderSource.Additional;
            this.mainWeight.Cfg = null;
            this.mainWeight.CurrentViewType = YF.MWS.Metadata.ViewType.Weight;
            this.mainWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWeight.Location = new System.Drawing.Point(0, 0);
            this.mainWeight.LstAttribute = ((System.Collections.Generic.List<YF.MWS.Db.SAttribute>)(resources.GetObject("mainWeight.LstAttribute")));
            this.mainWeight.Name = "mainWeight";
            this.mainWeight.Size = new System.Drawing.Size(809, 400);
            this.mainWeight.TabIndex = 0;
            // 
            // plHeader
            // 
            this.plHeader.Controls.Add(this.lblPaymentSettleCaption);
            this.plHeader.Controls.Add(this.lblPaymentSettle);
            this.plHeader.Controls.Add(this.lblFreightSettleCaption);
            this.plHeader.Controls.Add(this.lblFreightSettle);
            this.plHeader.Controls.Add(this.lblAuthCaption);
            this.plHeader.Controls.Add(this.lblAuth);
            this.plHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHeader.Location = new System.Drawing.Point(2, 22);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(809, 50);
            this.plHeader.TabIndex = 3;
            // 
            // lblPaymentSettleCaption
            // 
            this.lblPaymentSettleCaption.Location = new System.Drawing.Point(418, 18);
            this.lblPaymentSettleCaption.Name = "lblPaymentSettleCaption";
            this.lblPaymentSettleCaption.Size = new System.Drawing.Size(36, 14);
            this.lblPaymentSettleCaption.TabIndex = 5;
            this.lblPaymentSettleCaption.Text = "未结算";
            // 
            // lblPaymentSettle
            // 
            this.lblPaymentSettle.Location = new System.Drawing.Point(336, 18);
            this.lblPaymentSettle.Name = "lblPaymentSettle";
            this.lblPaymentSettle.Size = new System.Drawing.Size(76, 14);
            this.lblPaymentSettle.TabIndex = 4;
            this.lblPaymentSettle.Text = "货款结算状态:";
            // 
            // lblFreightSettleCaption
            // 
            this.lblFreightSettleCaption.Location = new System.Drawing.Point(268, 18);
            this.lblFreightSettleCaption.Name = "lblFreightSettleCaption";
            this.lblFreightSettleCaption.Size = new System.Drawing.Size(36, 14);
            this.lblFreightSettleCaption.TabIndex = 3;
            this.lblFreightSettleCaption.Text = "未结算";
            // 
            // lblFreightSettle
            // 
            this.lblFreightSettle.Location = new System.Drawing.Point(186, 18);
            this.lblFreightSettle.Name = "lblFreightSettle";
            this.lblFreightSettle.Size = new System.Drawing.Size(76, 14);
            this.lblFreightSettle.TabIndex = 2;
            this.lblFreightSettle.Text = "运费结算状态:";
            // 
            // lblAuthCaption
            // 
            this.lblAuthCaption.Location = new System.Drawing.Point(105, 18);
            this.lblAuthCaption.Name = "lblAuthCaption";
            this.lblAuthCaption.Size = new System.Drawing.Size(36, 14);
            this.lblAuthCaption.TabIndex = 1;
            this.lblAuthCaption.Text = "未审核";
            // 
            // lblAuth
            // 
            this.lblAuth.Location = new System.Drawing.Point(23, 18);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(76, 14);
            this.lblAuth.TabIndex = 0;
            this.lblAuth.Text = "财务审核状态:";
            // 
            // FrmWeightSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 505);
            this.Controls.Add(this.gpMainWeight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmWeightSettle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "财务结算";
            this.Load += new System.EventHandler(this.FrmWeightSettle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).EndInit();
            this.gpMainWeight.ResumeLayout(false);
            this.scWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).EndInit();
            this.plHeader.ResumeLayout(false);
            this.plHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barItemAuth;
        private DevExpress.XtraBars.BarButtonItem barItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnItemPrint;
        private DevExpress.XtraEditors.GroupControl gpMainWeight;
        private DevExpress.XtraBars.BarButtonItem barItemPaymentSettle;
        private DevExpress.XtraBars.BarButtonItem barItemFreightSettle;
        private DevExpress.XtraBars.BarButtonItem barItemSave;
        private DevExpress.XtraEditors.XtraScrollableControl scWeight;
        private Uc.MainWeight mainWeight;
        private DevExpress.XtraEditors.PanelControl plHeader;
        private DevExpress.XtraEditors.LabelControl lblPaymentSettleCaption;
        private DevExpress.XtraEditors.LabelControl lblPaymentSettle;
        private DevExpress.XtraEditors.LabelControl lblFreightSettleCaption;
        private DevExpress.XtraEditors.LabelControl lblFreightSettle;
        private DevExpress.XtraEditors.LabelControl lblAuthCaption;
        private DevExpress.XtraEditors.LabelControl lblAuth;
    }
}