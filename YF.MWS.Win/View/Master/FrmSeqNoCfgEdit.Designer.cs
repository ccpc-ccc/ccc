namespace YF.MWS.Win.View.Master
{
    partial class FrmSeqNoCfgEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeqNoCfgEdit));
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
            this.teFixedLen = new DevExpress.XtraEditors.TextEdit();
            this.combDateFomart = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tePrefix = new DevExpress.XtraEditors.TextEdit();
            this.teSeqCodeCaption = new DevExpress.XtraEditors.TextEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblSeqCodeCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblFixedLen = new DevExpress.XtraEditors.LabelControl();
            this.lblDateFomart = new DevExpress.XtraEditors.LabelControl();
            this.lblPrefix = new DevExpress.XtraEditors.LabelControl();
            this.teRuningNo = new DevExpress.XtraEditors.TextEdit();
            this.lblRuningNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedLen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combDateFomart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePrefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSeqCodeCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRuningNo.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(302, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 248);
            this.barDockControlBottom.Size = new System.Drawing.Size(302, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 217);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(302, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 217);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teFixedLen
            // 
            this.dxErrorProvider.SetIconAlignment(this.teFixedLen, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teFixedLen.Location = new System.Drawing.Point(108, 142);
            this.teFixedLen.MenuManager = this.barManager;
            this.teFixedLen.Name = "teFixedLen";
            this.teFixedLen.Properties.Mask.EditMask = "N0";
            this.teFixedLen.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teFixedLen.Size = new System.Drawing.Size(108, 20);
            this.teFixedLen.TabIndex = 42;
            this.teFixedLen.Tag = "FixedLen";
            // 
            // combDateFomart
            // 
            this.dxErrorProvider.SetIconAlignment(this.combDateFomart, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combDateFomart.Location = new System.Drawing.Point(108, 69);
            this.combDateFomart.MenuManager = this.barManager;
            this.combDateFomart.Name = "combDateFomart";
            this.combDateFomart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combDateFomart.Size = new System.Drawing.Size(154, 20);
            this.combDateFomart.TabIndex = 41;
            this.combDateFomart.Tag = "DateFomart";
            // 
            // tePrefix
            // 
            this.dxErrorProvider.SetIconAlignment(this.tePrefix, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.tePrefix.Location = new System.Drawing.Point(108, 105);
            this.tePrefix.MenuManager = this.barManager;
            this.tePrefix.Name = "tePrefix";
            this.tePrefix.Size = new System.Drawing.Size(108, 20);
            this.tePrefix.TabIndex = 36;
            this.tePrefix.Tag = "Prefix";
            // 
            // teSeqCodeCaption
            // 
            this.teSeqCodeCaption.Enabled = false;
            this.dxErrorProvider.SetIconAlignment(this.teSeqCodeCaption, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teSeqCodeCaption.Location = new System.Drawing.Point(108, 29);
            this.teSeqCodeCaption.MenuManager = this.barManager;
            this.teSeqCodeCaption.Name = "teSeqCodeCaption";
            this.teSeqCodeCaption.Size = new System.Drawing.Size(154, 20);
            this.teSeqCodeCaption.TabIndex = 46;
            this.teSeqCodeCaption.Tag = "Prefix";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.teRuningNo);
            this.plDetail.Controls.Add(this.lblRuningNo);
            this.plDetail.Controls.Add(this.teSeqCodeCaption);
            this.plDetail.Controls.Add(this.lblSeqCodeCaption);
            this.plDetail.Controls.Add(this.teFixedLen);
            this.plDetail.Controls.Add(this.lblFixedLen);
            this.plDetail.Controls.Add(this.combDateFomart);
            this.plDetail.Controls.Add(this.lblDateFomart);
            this.plDetail.Controls.Add(this.tePrefix);
            this.plDetail.Controls.Add(this.lblPrefix);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 31);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(302, 217);
            this.plDetail.TabIndex = 8;
            // 
            // lblSeqCodeCaption
            // 
            this.lblSeqCodeCaption.Location = new System.Drawing.Point(37, 29);
            this.lblSeqCodeCaption.Name = "lblSeqCodeCaption";
            this.lblSeqCodeCaption.Size = new System.Drawing.Size(28, 14);
            this.lblSeqCodeCaption.TabIndex = 44;
            this.lblSeqCodeCaption.Text = "名称:";
            // 
            // lblFixedLen
            // 
            this.lblFixedLen.Location = new System.Drawing.Point(37, 140);
            this.lblFixedLen.Name = "lblFixedLen";
            this.lblFixedLen.Size = new System.Drawing.Size(40, 14);
            this.lblFixedLen.TabIndex = 43;
            this.lblFixedLen.Text = "总长度:";
            // 
            // lblDateFomart
            // 
            this.lblDateFomart.Location = new System.Drawing.Point(37, 69);
            this.lblDateFomart.Name = "lblDateFomart";
            this.lblDateFomart.Size = new System.Drawing.Size(48, 14);
            this.lblDateFomart.TabIndex = 40;
            this.lblDateFomart.Text = "日期格式";
            // 
            // lblPrefix
            // 
            this.lblPrefix.Location = new System.Drawing.Point(37, 105);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(28, 14);
            this.lblPrefix.TabIndex = 38;
            this.lblPrefix.Text = "前缀:";
            // 
            // teRuningNo
            // 
            this.dxErrorProvider.SetIconAlignment(this.teRuningNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teRuningNo.Location = new System.Drawing.Point(108, 177);
            this.teRuningNo.MenuManager = this.barManager;
            this.teRuningNo.Name = "teRuningNo";
            this.teRuningNo.Properties.Mask.EditMask = "N0";
            this.teRuningNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teRuningNo.Size = new System.Drawing.Size(108, 20);
            this.teRuningNo.TabIndex = 49;
            this.teRuningNo.Tag = "RuningNo";
            // 
            // lblRuningNo
            // 
            this.lblRuningNo.Location = new System.Drawing.Point(37, 177);
            this.lblRuningNo.Name = "lblRuningNo";
            this.lblRuningNo.Size = new System.Drawing.Size(40, 14);
            this.lblRuningNo.TabIndex = 50;
            this.lblRuningNo.Text = "初始值:";
            // 
            // FrmSeqNoCfgEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 248);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmSeqNoCfgEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "序列号规则设置";
            this.Load += new System.EventHandler(this.FrmSeqNoCfgEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedLen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combDateFomart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePrefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSeqCodeCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRuningNo.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl plDetail;
        private DevExpress.XtraEditors.TextEdit teFixedLen;
        private DevExpress.XtraEditors.LabelControl lblFixedLen;
        private DevExpress.XtraEditors.ComboBoxEdit combDateFomart;
        private DevExpress.XtraEditors.LabelControl lblDateFomart;
        private DevExpress.XtraEditors.TextEdit tePrefix;
        private DevExpress.XtraEditors.LabelControl lblPrefix;
        private DevExpress.XtraEditors.TextEdit teSeqCodeCaption;
        private DevExpress.XtraEditors.LabelControl lblSeqCodeCaption;
        private DevExpress.XtraEditors.TextEdit teRuningNo;
        private DevExpress.XtraEditors.LabelControl lblRuningNo;
    }
}