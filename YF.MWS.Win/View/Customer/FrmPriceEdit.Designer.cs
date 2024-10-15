namespace YF.MWS.Win.View.Customer
{
    partial class FrmPriceEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPriceEdit));
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.wCustomer = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.tePrice = new DevExpress.XtraEditors.TextEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.weMaterial = new YF.MWS.Win.Uc.Weight.WMaterialEdit();
            this.lblMaterial = new DevExpress.XtraEditors.LabelControl();
            this.lblRechargeAmount = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weMaterial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // wCustomer
            // 
            this.wCustomer.ActionName = null;
            this.wCustomer.AutoCalcNo = 0;
            this.wCustomer.Caption = null;
            this.wCustomer.ControlName = null;
            this.wCustomer.CurrentValue = null;
            this.wCustomer.DecimalDigits = 0;
            this.wCustomer.EditText = "";
            this.wCustomer.EditValue = "";
            this.wCustomer.Expression = null;
            this.wCustomer.FieldName = null;
            this.dxErrorProvider.SetIconAlignment(this.wCustomer, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.wCustomer.IsRequired = false;
            this.wCustomer.Location = new System.Drawing.Point(72, 36);
            this.wCustomer.MenuManager = this.barManager;
            this.wCustomer.Name = "wCustomer";
            this.wCustomer.ParentLocation = new System.Drawing.Point(0, 0);
            this.wCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.wCustomer.Size = new System.Drawing.Size(232, 20);
            this.wCustomer.TabIndex = 66;
            this.wCustomer.Type = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.wCustomer.WeightVauleChanged = null;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnItemSave,
            this.btnItemClose,
            this.btnItemCancel,
            this.btnItemAddSub,
            this.btnItemDelete,
            this.btnItemEdit});
            this.barManager.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.bar1.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 4;
            this.btnItemSave.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 2;
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
            this.barDockControlTop.Size = new System.Drawing.Size(351, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 214);
            this.barDockControlBottom.Size = new System.Drawing.Size(351, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 183);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(351, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 183);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemAddSub
            // 
            this.btnItemAddSub.Caption = "添加子类";
            this.btnItemAddSub.Id = 5;
            this.btnItemAddSub.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 6;
            this.btnItemDelete.ImageIndex = 3;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 7;
            this.btnItemEdit.ImageIndex = 4;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // tePrice
            // 
            this.dxErrorProvider.SetIconAlignment(this.tePrice, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.tePrice.Location = new System.Drawing.Point(72, 125);
            this.tePrice.MenuManager = this.barManager;
            this.tePrice.Name = "tePrice";
            this.tePrice.Size = new System.Drawing.Size(232, 20);
            this.tePrice.TabIndex = 64;
            this.tePrice.Tag = "Price";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.weMaterial);
            this.plDetail.Controls.Add(this.lblMaterial);
            this.plDetail.Controls.Add(this.wCustomer);
            this.plDetail.Controls.Add(this.tePrice);
            this.plDetail.Controls.Add(this.lblRechargeAmount);
            this.plDetail.Controls.Add(this.lblCustomer);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 31);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(351, 183);
            this.plDetail.TabIndex = 12;
            // 
            // weMaterial
            // 
            this.weMaterial.ActionName = null;
            this.weMaterial.AutoCalcNo = 0;
            this.weMaterial.Caption = null;
            this.weMaterial.ControlName = null;
            this.weMaterial.CurrentValue = null;
            this.weMaterial.DecimalDigits = 0;
            this.weMaterial.EditText = "";
            this.weMaterial.EditValue = "";
            this.weMaterial.Expression = null;
            this.weMaterial.FieldName = null;
            this.weMaterial.IsRequired = false;
            this.weMaterial.Location = new System.Drawing.Point(72, 80);
            this.weMaterial.MenuManager = this.barManager;
            this.weMaterial.Name = "weMaterial";
            this.weMaterial.ParentLocation = new System.Drawing.Point(0, 0);
            this.weMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.weMaterial.Size = new System.Drawing.Size(232, 20);
            this.weMaterial.TabIndex = 96;
            this.weMaterial.WeightVauleChanged = null;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Location = new System.Drawing.Point(19, 80);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(28, 14);
            this.lblMaterial.TabIndex = 68;
            this.lblMaterial.Text = "物资:";
            // 
            // lblRechargeAmount
            // 
            this.lblRechargeAmount.Location = new System.Drawing.Point(19, 126);
            this.lblRechargeAmount.Name = "lblRechargeAmount";
            this.lblRechargeAmount.Size = new System.Drawing.Size(28, 14);
            this.lblRechargeAmount.TabIndex = 65;
            this.lblRechargeAmount.Text = "单价:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(19, 36);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(28, 14);
            this.lblCustomer.TabIndex = 38;
            this.lblCustomer.Text = "客户:";
            // 
            // FrmPriceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 214);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmPriceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户物资价格设置";
            this.Load += new System.EventHandler(this.FrmPriceEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weMaterial.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private Uc.Weight.WMaterialEdit weMaterial;
        private DevExpress.XtraEditors.LabelControl lblMaterial;
        private Uc.Weight.WCustomerEdit wCustomer;
        private DevExpress.XtraEditors.TextEdit tePrice;
        private DevExpress.XtraEditors.LabelControl lblRechargeAmount;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
    }
}