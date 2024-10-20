namespace YF.MWS.Win.View.Master
{
    partial class FrmCarEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarEdit));
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
            this.combCarType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.mainWeight1 = new YF.MWS.Win.Uc.MainWeight();
            this.chkLimitState = new DevExpress.XtraEditors.CheckEdit();
            this.lblLimitWeightUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblDriverName = new DevExpress.XtraEditors.LabelControl();
            this.teLimitWeight = new DevExpress.XtraEditors.TextEdit();
            this.teDriverName = new DevExpress.XtraEditors.TextEdit();
            this.lblLimitWeight = new DevExpress.XtraEditors.LabelControl();
            this.lblCarType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combCarType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLimitState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLimitWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDriverName.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(398, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 568);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(398, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 544);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(398, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 544);
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
            // combCarType
            // 
            this.dxErrorProvider.SetIconAlignment(this.combCarType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combCarType.Location = new System.Drawing.Point(107, 24);
            this.combCarType.MenuManager = this.barManager;
            this.combCarType.Name = "combCarType";
            this.combCarType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combCarType.Size = new System.Drawing.Size(154, 20);
            this.combCarType.TabIndex = 41;
            this.combCarType.Tag = "CarType";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.mainWeight1);
            this.plDetail.Controls.Add(this.chkLimitState);
            this.plDetail.Controls.Add(this.lblLimitWeightUnit);
            this.plDetail.Controls.Add(this.lblDriverName);
            this.plDetail.Controls.Add(this.teLimitWeight);
            this.plDetail.Controls.Add(this.teDriverName);
            this.plDetail.Controls.Add(this.lblLimitWeight);
            this.plDetail.Controls.Add(this.combCarType);
            this.plDetail.Controls.Add(this.lblCarType);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 24);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(398, 544);
            this.plDetail.TabIndex = 7;
            // 
            // mainWeight1
            // 
            this.mainWeight1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainWeight1.BoundSource = YF.MWS.BaseMetadata.OrderSource.Additional;
            this.mainWeight1.Cfg = null;
            this.mainWeight1.CurrentViewType = YF.MWS.Metadata.ViewType.Car;
            this.mainWeight1.FrmWeight = null;
            this.mainWeight1.Location = new System.Drawing.Point(0, 105);
            this.mainWeight1.Margin = new System.Windows.Forms.Padding(4);
            this.mainWeight1.Name = "mainWeight1";
            this.mainWeight1.Size = new System.Drawing.Size(398, 439);
            this.mainWeight1.TabIndex = 65;
            // 
            // chkLimitState
            // 
            this.chkLimitState.Location = new System.Drawing.Point(267, 26);
            this.chkLimitState.MenuManager = this.barManager;
            this.chkLimitState.Name = "chkLimitState";
            this.chkLimitState.Properties.Caption = "限制识别入场";
            this.chkLimitState.Size = new System.Drawing.Size(108, 20);
            this.chkLimitState.TabIndex = 64;
            // 
            // lblLimitWeightUnit
            // 
            this.lblLimitWeightUnit.Location = new System.Drawing.Point(222, 80);
            this.lblLimitWeightUnit.Name = "lblLimitWeightUnit";
            this.lblLimitWeightUnit.Size = new System.Drawing.Size(12, 14);
            this.lblLimitWeightUnit.TabIndex = 61;
            this.lblLimitWeightUnit.Text = "吨";
            // 
            // lblDriverName
            // 
            this.lblDriverName.Location = new System.Drawing.Point(73, 55);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(28, 14);
            this.lblDriverName.TabIndex = 59;
            this.lblDriverName.Text = "司机:";
            // 
            // teLimitWeight
            // 
            this.teLimitWeight.Location = new System.Drawing.Point(107, 78);
            this.teLimitWeight.MenuManager = this.barManager;
            this.teLimitWeight.Name = "teLimitWeight";
            this.teLimitWeight.Size = new System.Drawing.Size(108, 20);
            this.teLimitWeight.TabIndex = 44;
            this.teLimitWeight.Tag = "LimitWeight";
            // 
            // teDriverName
            // 
            this.teDriverName.Location = new System.Drawing.Point(107, 52);
            this.teDriverName.MenuManager = this.barManager;
            this.teDriverName.Name = "teDriverName";
            this.teDriverName.Size = new System.Drawing.Size(230, 20);
            this.teDriverName.TabIndex = 58;
            this.teDriverName.Tag = "DriverName";
            // 
            // lblLimitWeight
            // 
            this.lblLimitWeight.Location = new System.Drawing.Point(49, 80);
            this.lblLimitWeight.Name = "lblLimitWeight";
            this.lblLimitWeight.Size = new System.Drawing.Size(52, 14);
            this.lblLimitWeight.TabIndex = 45;
            this.lblLimitWeight.Text = "限载重量:";
            // 
            // lblCarType
            // 
            this.lblCarType.Location = new System.Drawing.Point(49, 29);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Size = new System.Drawing.Size(52, 14);
            this.lblCarType.TabIndex = 40;
            this.lblCarType.Text = "车辆类型:";
            // 
            // FrmCarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 568);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "FrmCarEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车辆详情";
            this.Load += new System.EventHandler(this.FrmCarEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combCarType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLimitState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLimitWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDriverName.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl plDetail;
        private DevExpress.XtraEditors.LabelControl lblCarType;
        private DevExpress.XtraEditors.ComboBoxEdit combCarType;
        private DevExpress.XtraEditors.TextEdit teLimitWeight;
        private DevExpress.XtraEditors.LabelControl lblLimitWeight;
        private DevExpress.XtraEditors.LabelControl lblDriverName;
        private DevExpress.XtraEditors.TextEdit teDriverName;
        private DevExpress.XtraEditors.LabelControl lblLimitWeightUnit;
        private DevExpress.XtraEditors.CheckEdit chkLimitState;
        private Uc.MainWeight mainWeight1;
    }
}