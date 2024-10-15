namespace YF.MWS.Win.View.Master
{
    partial class FrmCodeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodeEdit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.teItemValue = new DevExpress.XtraEditors.TextEdit();
            this.lblItemValue = new DevExpress.XtraEditors.LabelControl();
            this.teOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.teParent = new DevExpress.XtraEditors.TextEdit();
            this.lblParent = new DevExpress.XtraEditors.LabelControl();
            this.teItemCaption = new DevExpress.XtraEditors.TextEdit();
            this.lblItemCaption = new DevExpress.XtraEditors.LabelControl();
            this.teItemCode = new DevExpress.XtraEditors.TextEdit();
            this.lblItemCode = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teItemValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teItemCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(350, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 244);
            this.barDockControlBottom.Size = new System.Drawing.Size(350, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 213);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(350, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 213);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.teItemValue);
            this.panelControl1.Controls.Add(this.lblItemValue);
            this.panelControl1.Controls.Add(this.teOrderNo);
            this.panelControl1.Controls.Add(this.lblOrderNo);
            this.panelControl1.Controls.Add(this.teParent);
            this.panelControl1.Controls.Add(this.lblParent);
            this.panelControl1.Controls.Add(this.teItemCaption);
            this.panelControl1.Controls.Add(this.lblItemCaption);
            this.panelControl1.Controls.Add(this.teItemCode);
            this.panelControl1.Controls.Add(this.lblItemCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(350, 213);
            this.panelControl1.TabIndex = 5;
            // 
            // teItemValue
            // 
            this.dxErrorProvider.SetIconAlignment(this.teItemValue, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teItemValue.Location = new System.Drawing.Point(87, 118);
            this.teItemValue.MenuManager = this.barManager;
            this.teItemValue.Name = "teItemValue";
            this.teItemValue.Size = new System.Drawing.Size(228, 20);
            this.teItemValue.TabIndex = 44;
            this.teItemValue.Tag = "ItemValue";
            // 
            // lblItemValue
            // 
            this.lblItemValue.Location = new System.Drawing.Point(14, 121);
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(40, 14);
            this.lblItemValue.TabIndex = 45;
            this.lblItemValue.Text = "对应值:";
            // 
            // teOrderNo
            // 
            this.teOrderNo.Location = new System.Drawing.Point(87, 152);
            this.teOrderNo.MenuManager = this.barManager;
            this.teOrderNo.Name = "teOrderNo";
            this.teOrderNo.Properties.Mask.EditMask = "\\d{1,}";
            this.teOrderNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teOrderNo.Size = new System.Drawing.Size(98, 20);
            this.teOrderNo.TabIndex = 42;
            this.teOrderNo.Tag = "OrderNo";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(14, 155);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(40, 14);
            this.lblOrderNo.TabIndex = 43;
            this.lblOrderNo.Text = "排序号:";
            // 
            // teParent
            // 
            this.teParent.Enabled = false;
            this.teParent.Location = new System.Drawing.Point(87, 15);
            this.teParent.MenuManager = this.barManager;
            this.teParent.Name = "teParent";
            this.teParent.Size = new System.Drawing.Size(228, 20);
            this.teParent.TabIndex = 41;
            this.teParent.Tag = "";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(14, 18);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(40, 14);
            this.lblParent.TabIndex = 40;
            this.lblParent.Text = "父编码:";
            // 
            // teItemCaption
            // 
            this.dxErrorProvider.SetIconAlignment(this.teItemCaption, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teItemCaption.Location = new System.Drawing.Point(87, 84);
            this.teItemCaption.MenuManager = this.barManager;
            this.teItemCaption.Name = "teItemCaption";
            this.teItemCaption.Size = new System.Drawing.Size(228, 20);
            this.teItemCaption.TabIndex = 37;
            this.teItemCaption.Tag = "ItemCaption";
            // 
            // lblItemCaption
            // 
            this.lblItemCaption.Location = new System.Drawing.Point(14, 87);
            this.lblItemCaption.Name = "lblItemCaption";
            this.lblItemCaption.Size = new System.Drawing.Size(52, 14);
            this.lblItemCaption.TabIndex = 39;
            this.lblItemCaption.Text = "文字说明:";
            // 
            // teItemCode
            // 
            this.dxErrorProvider.SetIconAlignment(this.teItemCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teItemCode.Location = new System.Drawing.Point(87, 50);
            this.teItemCode.MenuManager = this.barManager;
            this.teItemCode.Name = "teItemCode";
            this.teItemCode.Size = new System.Drawing.Size(228, 20);
            this.teItemCode.TabIndex = 36;
            this.teItemCode.Tag = "ItemCode";
            // 
            // lblItemCode
            // 
            this.lblItemCode.Location = new System.Drawing.Point(14, 50);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(28, 14);
            this.lblItemCode.TabIndex = 38;
            this.lblItemCode.Text = "编码:";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmCodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 244);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmCodeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统编码详情";
            this.Load += new System.EventHandler(this.FrmCodeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teItemValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teItemCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit teOrderNo;
        private DevExpress.XtraEditors.LabelControl lblOrderNo;
        private DevExpress.XtraEditors.TextEdit teParent;
        private DevExpress.XtraEditors.LabelControl lblParent;
        private DevExpress.XtraEditors.TextEdit teItemCaption;
        private DevExpress.XtraEditors.LabelControl lblItemCaption;
        private DevExpress.XtraEditors.TextEdit teItemCode;
        private DevExpress.XtraEditors.LabelControl lblItemCode;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit teItemValue;
        private DevExpress.XtraEditors.LabelControl lblItemValue;
    }
}