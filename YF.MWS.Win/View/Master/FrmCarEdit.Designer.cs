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
            this.teCarNo = new DevExpress.XtraEditors.TextEdit();
            this.teTare = new DevExpress.XtraEditors.TextEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.chkLimitState = new DevExpress.XtraEditors.CheckEdit();
            this.lblLimitWeightUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblTareWeightUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblDriverName = new DevExpress.XtraEditors.LabelControl();
            this.teLimitWeight = new DevExpress.XtraEditors.TextEdit();
            this.teDriverName = new DevExpress.XtraEditors.TextEdit();
            this.lblLimitWeight = new DevExpress.XtraEditors.LabelControl();
            this.lblTare = new DevExpress.XtraEditors.LabelControl();
            this.lblCarType = new DevExpress.XtraEditors.LabelControl();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combCarType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTare.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(416, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 261);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(416, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 237);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(416, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 237);
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
            // teCarNo
            // 
            this.dxErrorProvider.SetIconAlignment(this.teCarNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teCarNo.Location = new System.Drawing.Point(107, 60);
            this.teCarNo.MenuManager = this.barManager;
            this.teCarNo.Name = "teCarNo";
            this.teCarNo.Size = new System.Drawing.Size(230, 20);
            this.teCarNo.TabIndex = 36;
            this.teCarNo.Tag = "CarNo";
            // 
            // teTare
            // 
            this.dxErrorProvider.SetIconAlignment(this.teTare, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teTare.Location = new System.Drawing.Point(107, 159);
            this.teTare.MenuManager = this.barManager;
            this.teTare.Name = "teTare";
            this.teTare.Size = new System.Drawing.Size(108, 20);
            this.teTare.TabIndex = 42;
            this.teTare.Tag = "Tare";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.chkLimitState);
            this.plDetail.Controls.Add(this.lblLimitWeightUnit);
            this.plDetail.Controls.Add(this.lblTareWeightUnit);
            this.plDetail.Controls.Add(this.lblDriverName);
            this.plDetail.Controls.Add(this.teLimitWeight);
            this.plDetail.Controls.Add(this.teDriverName);
            this.plDetail.Controls.Add(this.lblLimitWeight);
            this.plDetail.Controls.Add(this.teTare);
            this.plDetail.Controls.Add(this.lblTare);
            this.plDetail.Controls.Add(this.combCarType);
            this.plDetail.Controls.Add(this.lblCarType);
            this.plDetail.Controls.Add(this.teCarNo);
            this.plDetail.Controls.Add(this.lblCarNo);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 24);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(416, 237);
            this.plDetail.TabIndex = 7;
            // 
            // chkLimitState
            // 
            this.chkLimitState.Location = new System.Drawing.Point(107, 91);
            this.chkLimitState.MenuManager = this.barManager;
            this.chkLimitState.Name = "chkLimitState";
            this.chkLimitState.Properties.Caption = "限制识别入场";
            this.chkLimitState.Size = new System.Drawing.Size(108, 20);
            this.chkLimitState.TabIndex = 64;
            // 
            // lblLimitWeightUnit
            // 
            this.lblLimitWeightUnit.Location = new System.Drawing.Point(222, 196);
            this.lblLimitWeightUnit.Name = "lblLimitWeightUnit";
            this.lblLimitWeightUnit.Size = new System.Drawing.Size(12, 14);
            this.lblLimitWeightUnit.TabIndex = 61;
            this.lblLimitWeightUnit.Text = "吨";
            // 
            // lblTareWeightUnit
            // 
            this.lblTareWeightUnit.Location = new System.Drawing.Point(222, 160);
            this.lblTareWeightUnit.Name = "lblTareWeightUnit";
            this.lblTareWeightUnit.Size = new System.Drawing.Size(12, 14);
            this.lblTareWeightUnit.TabIndex = 60;
            this.lblTareWeightUnit.Text = "吨";
            // 
            // lblDriverName
            // 
            this.lblDriverName.Location = new System.Drawing.Point(19, 123);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(28, 14);
            this.lblDriverName.TabIndex = 59;
            this.lblDriverName.Text = "司机:";
            // 
            // teLimitWeight
            // 
            this.teLimitWeight.Location = new System.Drawing.Point(107, 194);
            this.teLimitWeight.MenuManager = this.barManager;
            this.teLimitWeight.Name = "teLimitWeight";
            this.teLimitWeight.Size = new System.Drawing.Size(108, 20);
            this.teLimitWeight.TabIndex = 44;
            this.teLimitWeight.Tag = "LimitWeight";
            // 
            // teDriverName
            // 
            this.teDriverName.Location = new System.Drawing.Point(107, 123);
            this.teDriverName.MenuManager = this.barManager;
            this.teDriverName.Name = "teDriverName";
            this.teDriverName.Size = new System.Drawing.Size(230, 20);
            this.teDriverName.TabIndex = 58;
            this.teDriverName.Tag = "DriverName";
            // 
            // lblLimitWeight
            // 
            this.lblLimitWeight.Location = new System.Drawing.Point(19, 194);
            this.lblLimitWeight.Name = "lblLimitWeight";
            this.lblLimitWeight.Size = new System.Drawing.Size(52, 14);
            this.lblLimitWeight.TabIndex = 45;
            this.lblLimitWeight.Text = "限载重量:";
            // 
            // lblTare
            // 
            this.lblTare.Location = new System.Drawing.Point(19, 157);
            this.lblTare.Name = "lblTare";
            this.lblTare.Size = new System.Drawing.Size(28, 14);
            this.lblTare.TabIndex = 43;
            this.lblTare.Text = "皮重:";
            // 
            // lblCarType
            // 
            this.lblCarType.Location = new System.Drawing.Point(19, 27);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Size = new System.Drawing.Size(52, 14);
            this.lblCarType.TabIndex = 40;
            this.lblCarType.Text = "车辆类型:";
            // 
            // lblCarNo
            // 
            this.lblCarNo.Location = new System.Drawing.Point(19, 60);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(40, 14);
            this.lblCarNo.TabIndex = 38;
            this.lblCarNo.Text = "车牌号:";
            // 
            // FrmCarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 261);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(432, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(418, 293);
            this.Name = "FrmCarEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "车辆详情";
            this.Load += new System.EventHandler(this.FrmCarEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combCarType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTare.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit teCarNo;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private DevExpress.XtraEditors.ComboBoxEdit combCarType;
        private DevExpress.XtraEditors.TextEdit teLimitWeight;
        private DevExpress.XtraEditors.LabelControl lblLimitWeight;
        private DevExpress.XtraEditors.TextEdit teTare;
        private DevExpress.XtraEditors.LabelControl lblTare;
        private DevExpress.XtraEditors.LabelControl lblDriverName;
        private DevExpress.XtraEditors.TextEdit teDriverName;
        private DevExpress.XtraEditors.LabelControl lblLimitWeightUnit;
        private DevExpress.XtraEditors.LabelControl lblTareWeightUnit;
        private DevExpress.XtraEditors.CheckEdit chkLimitState; 
    }
}