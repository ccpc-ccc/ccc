namespace YF.MWS.Win.View.Master
{
    partial class FrmMaterialDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialDetail));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblPYMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.tePYMaterialName = new DevExpress.XtraEditors.TextEdit();
            this.teMaterialName = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.teUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.lblUnitPrice = new DevExpress.XtraEditors.LabelControl();
            this.chkState = new DevExpress.XtraEditors.CheckEdit();
            this.cmbMaterialType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.lblState = new DevExpress.XtraEditors.LabelControl();
            this.cmbUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUnit = new DevExpress.XtraEditors.LabelControl();
            this.txtSpecName = new DevExpress.XtraEditors.TextEdit();
            this.lblSpecName = new DevExpress.XtraEditors.LabelControl();
            this.teMaterialCode = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterialCode = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterialType = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tePYMaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaterialType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpecName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.btnItemClose});
            this.barManager.MaxItemId = 2;
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
            this.btnItemSave.Id = 0;
            this.btnItemSave.ImageOptions.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 1;
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
            this.barDockControlTop.Size = new System.Drawing.Size(677, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 380);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(677, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 356);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(677, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 356);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblPYMaterialName);
            this.panelControl1.Controls.Add(this.tePYMaterialName);
            this.panelControl1.Controls.Add(this.teMaterialName);
            this.panelControl1.Controls.Add(this.lblMaterialName);
            this.panelControl1.Controls.Add(this.txtQuantity);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.teUnitPrice);
            this.panelControl1.Controls.Add(this.lblUnitPrice);
            this.panelControl1.Controls.Add(this.chkState);
            this.panelControl1.Controls.Add(this.cmbMaterialType);
            this.panelControl1.Controls.Add(this.memoRemark);
            this.panelControl1.Controls.Add(this.lblRemark);
            this.panelControl1.Controls.Add(this.lblState);
            this.panelControl1.Controls.Add(this.cmbUnit);
            this.panelControl1.Controls.Add(this.lblUnit);
            this.panelControl1.Controls.Add(this.txtSpecName);
            this.panelControl1.Controls.Add(this.lblSpecName);
            this.panelControl1.Controls.Add(this.teMaterialCode);
            this.panelControl1.Controls.Add(this.lblMaterialCode);
            this.panelControl1.Controls.Add(this.lblMaterialType);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(677, 356);
            this.panelControl1.TabIndex = 4;
            // 
            // lblPYMaterialName
            // 
            this.lblPYMaterialName.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblPYMaterialName.Appearance.Options.UseFont = true;
            this.lblPYMaterialName.Location = new System.Drawing.Point(396, 57);
            this.lblPYMaterialName.Name = "lblPYMaterialName";
            this.lblPYMaterialName.Size = new System.Drawing.Size(54, 12);
            this.lblPYMaterialName.TabIndex = 55;
            this.lblPYMaterialName.Text = "物资简称:";
            // 
            // tePYMaterialName
            // 
            this.dxErrorProvider.SetIconAlignment(this.tePYMaterialName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.tePYMaterialName.Location = new System.Drawing.Point(460, 56);
            this.tePYMaterialName.Name = "tePYMaterialName";
            this.tePYMaterialName.Size = new System.Drawing.Size(168, 20);
            this.tePYMaterialName.TabIndex = 54;
            this.tePYMaterialName.Tag = "PYMaterialName";
            // 
            // teMaterialName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teMaterialName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teMaterialName.Location = new System.Drawing.Point(106, 56);
            this.teMaterialName.MenuManager = this.barManager;
            this.teMaterialName.Name = "teMaterialName";
            this.teMaterialName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teMaterialName.Properties.Appearance.Options.UseFont = true;
            this.teMaterialName.Size = new System.Drawing.Size(247, 18);
            this.teMaterialName.TabIndex = 17;
            this.teMaterialName.Tag = "MaterialName";
            this.teMaterialName.EditValueChanged += new System.EventHandler(this.teMaterialName_EditValueChanged);
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblMaterialName.Appearance.Options.UseFont = true;
            this.lblMaterialName.Location = new System.Drawing.Point(40, 59);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(54, 12);
            this.lblMaterialName.TabIndex = 16;
            this.lblMaterialName.Text = "物资名称:";
            // 
            // teUnitPrice
            // 
            this.dxErrorProvider.SetIconAlignment(this.teUnitPrice, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teUnitPrice.Location = new System.Drawing.Point(106, 122);
            this.teUnitPrice.MenuManager = this.barManager;
            this.teUnitPrice.Name = "teUnitPrice";
            this.teUnitPrice.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teUnitPrice.Properties.Appearance.Options.UseFont = true;
            this.teUnitPrice.Size = new System.Drawing.Size(247, 18);
            this.teUnitPrice.TabIndex = 15;
            this.teUnitPrice.Tag = "UnitPrice";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblUnitPrice.Appearance.Options.UseFont = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(40, 125);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(54, 12);
            this.lblUnitPrice.TabIndex = 14;
            this.lblUnitPrice.Text = "物资单价:";
            // 
            // chkState
            // 
            this.chkState.EditValue = true;
            this.chkState.Location = new System.Drawing.Point(460, 150);
            this.chkState.MenuManager = this.barManager;
            this.chkState.Name = "chkState";
            this.chkState.Properties.Caption = "启用";
            this.chkState.Size = new System.Drawing.Size(57, 20);
            this.chkState.TabIndex = 13;
            // 
            // cmbMaterialType
            // 
            this.dxErrorProvider.SetIconAlignment(this.cmbMaterialType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.cmbMaterialType.Location = new System.Drawing.Point(106, 24);
            this.cmbMaterialType.MenuManager = this.barManager;
            this.cmbMaterialType.Name = "cmbMaterialType";
            this.cmbMaterialType.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbMaterialType.Properties.Appearance.Options.UseFont = true;
            this.cmbMaterialType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMaterialType.Size = new System.Drawing.Size(247, 18);
            this.cmbMaterialType.TabIndex = 12;
            // 
            // memoRemark
            // 
            this.dxErrorProvider.SetIconAlignment(this.memoRemark, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.memoRemark.Location = new System.Drawing.Point(106, 176);
            this.memoRemark.MenuManager = this.barManager;
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.memoRemark.Properties.Appearance.Options.UseFont = true;
            this.memoRemark.Size = new System.Drawing.Size(522, 118);
            this.memoRemark.TabIndex = 11;
            this.memoRemark.Tag = "Remark";
            // 
            // lblRemark
            // 
            this.lblRemark.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblRemark.Appearance.Options.UseFont = true;
            this.lblRemark.Location = new System.Drawing.Point(40, 178);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(54, 12);
            this.lblRemark.TabIndex = 10;
            this.lblRemark.Text = "备注说明:";
            // 
            // lblState
            // 
            this.lblState.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblState.Appearance.Options.UseFont = true;
            this.lblState.Location = new System.Drawing.Point(398, 152);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(54, 12);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "启用状态:";
            // 
            // cmbUnit
            // 
            this.dxErrorProvider.SetIconAlignment(this.cmbUnit, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.cmbUnit.Location = new System.Drawing.Point(460, 88);
            this.cmbUnit.MenuManager = this.barManager;
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbUnit.Properties.Appearance.Options.UseFont = true;
            this.cmbUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnit.Size = new System.Drawing.Size(168, 18);
            this.cmbUnit.TabIndex = 7;
            // 
            // lblUnit
            // 
            this.lblUnit.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblUnit.Appearance.Options.UseFont = true;
            this.lblUnit.Location = new System.Drawing.Point(396, 93);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(30, 12);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "单位:";
            // 
            // txtSpecName
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtSpecName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtSpecName.Location = new System.Drawing.Point(106, 90);
            this.txtSpecName.MenuManager = this.barManager;
            this.txtSpecName.Name = "txtSpecName";
            this.txtSpecName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtSpecName.Properties.Appearance.Options.UseFont = true;
            this.txtSpecName.Size = new System.Drawing.Size(247, 18);
            this.txtSpecName.TabIndex = 5;
            this.txtSpecName.Tag = "SpecName";
            // 
            // lblSpecName
            // 
            this.lblSpecName.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblSpecName.Appearance.Options.UseFont = true;
            this.lblSpecName.Location = new System.Drawing.Point(40, 94);
            this.lblSpecName.Name = "lblSpecName";
            this.lblSpecName.Size = new System.Drawing.Size(54, 12);
            this.lblSpecName.TabIndex = 4;
            this.lblSpecName.Text = "物资规格:";
            // 
            // teMaterialCode
            // 
            this.dxErrorProvider.SetIconAlignment(this.teMaterialCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teMaterialCode.Location = new System.Drawing.Point(460, 24);
            this.teMaterialCode.MenuManager = this.barManager;
            this.teMaterialCode.Name = "teMaterialCode";
            this.teMaterialCode.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teMaterialCode.Properties.Appearance.Options.UseFont = true;
            this.teMaterialCode.Size = new System.Drawing.Size(168, 18);
            this.teMaterialCode.TabIndex = 3;
            this.teMaterialCode.Tag = "MaterialCode";
            // 
            // lblMaterialCode
            // 
            this.lblMaterialCode.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblMaterialCode.Appearance.Options.UseFont = true;
            this.lblMaterialCode.Location = new System.Drawing.Point(396, 27);
            this.lblMaterialCode.Name = "lblMaterialCode";
            this.lblMaterialCode.Size = new System.Drawing.Size(54, 12);
            this.lblMaterialCode.TabIndex = 2;
            this.lblMaterialCode.Text = "物资编码:";
            // 
            // lblMaterialType
            // 
            this.lblMaterialType.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblMaterialType.Appearance.Options.UseFont = true;
            this.lblMaterialType.Location = new System.Drawing.Point(40, 27);
            this.lblMaterialType.Name = "lblMaterialType";
            this.lblMaterialType.Size = new System.Drawing.Size(54, 12);
            this.lblMaterialType.TabIndex = 0;
            this.lblMaterialType.Text = "物资类别:";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(394, 125);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 12);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "物资数量:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(460, 122);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtQuantity.Properties.Appearance.Options.UseFont = true;
            this.txtQuantity.Size = new System.Drawing.Size(168, 18);
            this.txtQuantity.TabIndex = 15;
            this.txtQuantity.Tag = "Quantity";
            // 
            // FrmMaterialDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 380);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmMaterialDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物资详情";
            this.Load += new System.EventHandler(this.FrmMaterialDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tePYMaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaterialType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpecName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblMaterialType;
        private DevExpress.XtraEditors.TextEdit teMaterialCode;
        private DevExpress.XtraEditors.LabelControl lblMaterialCode;
        private DevExpress.XtraEditors.TextEdit txtSpecName;
        private DevExpress.XtraEditors.LabelControl lblSpecName;
        private DevExpress.XtraEditors.LabelControl lblUnit;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUnit;
        private DevExpress.XtraEditors.LabelControl lblState;
        private DevExpress.XtraEditors.LabelControl lblRemark;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMaterialType;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.CheckEdit chkState;
        private DevExpress.XtraEditors.TextEdit teUnitPrice;
        private DevExpress.XtraEditors.LabelControl lblUnitPrice;
        private DevExpress.XtraEditors.TextEdit teMaterialName;
        private DevExpress.XtraEditors.LabelControl lblMaterialName;
        private DevExpress.XtraEditors.LabelControl lblPYMaterialName;
        private DevExpress.XtraEditors.TextEdit tePYMaterialName;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}