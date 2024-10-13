namespace YF.MWS.Win.View.Master
{
    partial class FrmCompanyPayEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanyPayEdit));
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
            this.txtPayNo = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPayAmount = new DevExpress.XtraEditors.TextEdit();
            this.lblWarehCode = new DevExpress.XtraEditors.LabelControl();
            this.lblWarehName = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.wCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).BeginInit();
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
            this.barManager.MaxItemId = 10;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
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
            this.barDockControlTop.Size = new System.Drawing.Size(419, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 193);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(419, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 169);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(419, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 169);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // txtPayNo
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtPayNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtPayNo.Location = new System.Drawing.Point(92, 111);
            this.txtPayNo.MenuManager = this.barManager;
            this.txtPayNo.Name = "txtPayNo";
            this.txtPayNo.Size = new System.Drawing.Size(225, 20);
            this.txtPayNo.TabIndex = 59;
            this.txtPayNo.Tag = "Quantity";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtPayAmount);
            this.panelControl1.Controls.Add(this.txtPayNo);
            this.panelControl1.Controls.Add(this.lblWarehCode);
            this.panelControl1.Controls.Add(this.lblWarehName);
            this.panelControl1.Controls.Add(this.lblLocation);
            this.panelControl1.Controls.Add(this.wCustomer);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(419, 169);
            this.panelControl1.TabIndex = 7;
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(92, 64);
            this.txtPayAmount.MenuManager = this.barManager;
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Properties.EditFormat.FormatString = "0.00";
            this.txtPayAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPayAmount.Size = new System.Drawing.Size(225, 20);
            this.txtPayAmount.TabIndex = 61;
            this.txtPayAmount.Tag = "PayAmount";
            // 
            // lblWarehCode
            // 
            this.lblWarehCode.Location = new System.Drawing.Point(58, 114);
            this.lblWarehCode.Name = "lblWarehCode";
            this.lblWarehCode.Size = new System.Drawing.Size(28, 14);
            this.lblWarehCode.TabIndex = 57;
            this.lblWarehCode.Text = "数量:";
            // 
            // lblWarehName
            // 
            this.lblWarehName.Location = new System.Drawing.Point(58, 22);
            this.lblWarehName.Name = "lblWarehName";
            this.lblWarehName.Size = new System.Drawing.Size(28, 14);
            this.lblWarehName.TabIndex = 55;
            this.lblWarehName.Text = "客户:";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(58, 67);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(28, 14);
            this.lblLocation.TabIndex = 40;
            this.lblLocation.Text = "金额:";
            // 
            // wCustomer
            // 
            this.wCustomer.EditValue = "";
            this.wCustomer.Location = new System.Drawing.Point(92, 19);
            this.wCustomer.MenuManager = this.barManager;
            this.wCustomer.Name = "wCustomer";
            this.wCustomer.Properties.AutoComplete = false;
            this.wCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.wCustomer.Properties.ImmediatePopup = true;
            this.wCustomer.Size = new System.Drawing.Size(225, 20);
            this.wCustomer.TabIndex = 60;
            this.wCustomer.Tag = "CustomerId";
            this.wCustomer.SelectedValueChanged += new System.EventHandler(this.wCustomer_SelectedValueChanged);
            this.wCustomer.TextChanged += new System.EventHandler(this.wCustomer_TextChanged);
            // 
            // FrmCompanyPayEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 193);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyPayEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增付款信息";
            this.Load += new System.EventHandler(this.FrmWarehEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtPayNo;
        private DevExpress.XtraEditors.LabelControl lblWarehCode;
        private DevExpress.XtraEditors.LabelControl lblWarehName;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.TextEdit txtPayAmount;
        private DevExpress.XtraEditors.ComboBoxEdit wCustomer;
    }
}