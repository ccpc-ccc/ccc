namespace YF.MWS.Win.View.Master
{
    partial class FrmReadCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReadCard));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemRead = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.lblCardNo = new DevExpress.XtraEditors.LabelControl();
            this.txtCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblCardId = new DevExpress.XtraEditors.LabelControl();
            this.txtCardId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCarNo = new DevExpress.XtraEditors.TextEdit();
            this.teCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.teSN = new DevExpress.XtraEditors.TextEdit();
            this.lblSN = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSN.Properties)).BeginInit();
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
            this.btnItemRead,
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRead),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.bar1.Text = "Tools";
            // 
            // btnItemRead
            // 
            this.btnItemRead.Caption = "读取";
            this.btnItemRead.Id = 0;
            this.btnItemRead.ImageIndex = 0;
            this.btnItemRead.Name = "btnItemRead";
            this.btnItemRead.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemRead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemRead_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 1;
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
            this.barDockControlTop.Size = new System.Drawing.Size(472, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 278);
            this.barDockControlBottom.Size = new System.Drawing.Size(472, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 247);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(472, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 247);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "info_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // lblCardNo
            // 
            this.lblCardNo.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblCardNo.Location = new System.Drawing.Point(62, 147);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(48, 12);
            this.lblCardNo.TabIndex = 4;
            this.lblCardNo.Text = "IC卡号：";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(131, 144);
            this.txtCardNo.MenuManager = this.barManager;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCardNo.Properties.Appearance.Options.UseFont = true;
            this.txtCardNo.Properties.ReadOnly = true;
            this.txtCardNo.Size = new System.Drawing.Size(266, 18);
            this.txtCardNo.TabIndex = 5;
            // 
            // lblCardId
            // 
            this.lblCardId.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblCardId.Location = new System.Drawing.Point(62, 182);
            this.lblCardId.Name = "lblCardId";
            this.lblCardId.Size = new System.Drawing.Size(48, 12);
            this.lblCardId.TabIndex = 6;
            this.lblCardId.Text = "IC卡值：";
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(131, 179);
            this.txtCardId.MenuManager = this.barManager;
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCardId.Properties.Appearance.Options.UseFont = true;
            this.txtCardId.Properties.ReadOnly = true;
            this.txtCardId.Size = new System.Drawing.Size(266, 18);
            this.txtCardId.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl3.Location = new System.Drawing.Point(62, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 12);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "车牌号：";
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(131, 109);
            this.txtCarNo.MenuManager = this.barManager;
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCarNo.Properties.Appearance.Options.UseFont = true;
            this.txtCarNo.Properties.ReadOnly = true;
            this.txtCarNo.Size = new System.Drawing.Size(266, 18);
            this.txtCarNo.TabIndex = 13;
            // 
            // teCustomerName
            // 
            this.teCustomerName.Location = new System.Drawing.Point(131, 76);
            this.teCustomerName.MenuManager = this.barManager;
            this.teCustomerName.Name = "teCustomerName";
            this.teCustomerName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teCustomerName.Properties.Appearance.Options.UseFont = true;
            this.teCustomerName.Properties.ReadOnly = true;
            this.teCustomerName.Size = new System.Drawing.Size(266, 18);
            this.teCustomerName.TabIndex = 19;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblCustomer.Location = new System.Drawing.Point(62, 79);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(60, 12);
            this.lblCustomer.TabIndex = 18;
            this.lblCustomer.Text = "所属单位：";
            // 
            // teSN
            // 
            this.teSN.Location = new System.Drawing.Point(131, 215);
            this.teSN.MenuManager = this.barManager;
            this.teSN.Name = "teSN";
            this.teSN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teSN.Properties.Appearance.Options.UseFont = true;
            this.teSN.Properties.ReadOnly = true;
            this.teSN.Size = new System.Drawing.Size(266, 18);
            this.teSN.TabIndex = 25;
            // 
            // lblSN
            // 
            this.lblSN.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblSN.Location = new System.Drawing.Point(62, 218);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(48, 12);
            this.lblSN.TabIndex = 24;
            this.lblSN.Text = "序列号：";
            // 
            // FrmReadCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 278);
            this.Controls.Add(this.teSN);
            this.Controls.Add(this.lblSN);
            this.Controls.Add(this.teCustomerName);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCarNo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtCardId);
            this.Controls.Add(this.lblCardId);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.lblCardNo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmReadCard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "读取IC卡信息";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSN.Properties)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnItemRead;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.LabelControl lblCardNo;
        private DevExpress.XtraEditors.TextEdit txtCardNo;
        private DevExpress.XtraEditors.LabelControl lblCardId;
        private DevExpress.XtraEditors.TextEdit txtCardId;
        private DevExpress.XtraEditors.TextEdit txtCarNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit teCustomerName;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.TextEdit teSN;
        private DevExpress.XtraEditors.LabelControl lblSN;
    }
}