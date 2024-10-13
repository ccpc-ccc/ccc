namespace YF.MWS.Win.View.Master
{
    partial class FrmCompanyDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanyDetail));
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
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.teAddr = new DevExpress.XtraEditors.TextEdit();
            this.memInfor = new DevExpress.XtraEditors.MemoEdit();
            this.lblAddr = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtOverNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtMobile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtTel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtContracter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCompany = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbChargeType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateOverTime = new DevExpress.XtraEditors.DateEdit();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memInfor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContracter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChargeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOverTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOverTime.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(958, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 608);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(958, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 584);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(958, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 584);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "open_16x16.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.teAddr);
            this.panelControl1.Controls.Add(this.memInfor);
            this.panelControl1.Controls.Add(this.lblAddr);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.txtOverNumber);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.txtMobile);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.txtFax);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.txtTel);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtEmail);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtContracter);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtCompany);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cmbChargeType);
            this.panelControl1.Controls.Add(this.dateOverTime);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(958, 584);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(57, 259);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 12);
            this.labelControl10.TabIndex = 24;
            this.labelControl10.Text = "公司简介：";
            // 
            // teAddr
            // 
            this.teAddr.Location = new System.Drawing.Point(125, 216);
            this.teAddr.MenuManager = this.barManager;
            this.teAddr.Name = "teAddr";
            this.teAddr.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teAddr.Properties.Appearance.Options.UseFont = true;
            this.teAddr.Size = new System.Drawing.Size(805, 18);
            this.teAddr.TabIndex = 20;
            this.teAddr.Tag = "Address";
            // 
            // memInfor
            // 
            this.memInfor.Location = new System.Drawing.Point(124, 256);
            this.memInfor.MenuManager = this.barManager;
            this.memInfor.Name = "memInfor";
            this.memInfor.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.memInfor.Properties.Appearance.Options.UseFont = true;
            this.memInfor.Size = new System.Drawing.Size(806, 276);
            this.memInfor.TabIndex = 18;
            this.memInfor.Tag = "Infor";
            // 
            // lblAddr
            // 
            this.lblAddr.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblAddr.Appearance.Options.UseFont = true;
            this.lblAddr.Location = new System.Drawing.Point(58, 219);
            this.lblAddr.Name = "lblAddr";
            this.lblAddr.Size = new System.Drawing.Size(60, 12);
            this.lblAddr.TabIndex = 17;
            this.lblAddr.Text = "公司地址：";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(504, 143);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 12);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "计费方式：";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(504, 181);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 12);
            this.labelControl11.TabIndex = 12;
            this.labelControl11.Text = "到期日期：";
            // 
            // txtOverNumber
            // 
            this.txtOverNumber.Location = new System.Drawing.Point(125, 181);
            this.txtOverNumber.Name = "txtOverNumber";
            this.txtOverNumber.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtOverNumber.Properties.Appearance.Options.UseFont = true;
            this.txtOverNumber.Size = new System.Drawing.Size(180, 18);
            this.txtOverNumber.TabIndex = 13;
            this.txtOverNumber.Tag = "OverNumber";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(59, 184);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 12);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "剩余次数：";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(124, 143);
            this.txtMobile.MenuManager = this.barManager;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtMobile.Properties.Appearance.Options.UseFont = true;
            this.txtMobile.Size = new System.Drawing.Size(180, 18);
            this.txtMobile.TabIndex = 13;
            this.txtMobile.Tag = "Mobile";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(58, 146);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 12);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "手    机：";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(570, 105);
            this.txtFax.MenuManager = this.barManager;
            this.txtFax.Name = "txtFax";
            this.txtFax.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtFax.Properties.Appearance.Options.UseFont = true;
            this.txtFax.Size = new System.Drawing.Size(180, 18);
            this.txtFax.TabIndex = 11;
            this.txtFax.Tag = "Fax";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(504, 110);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 12);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "传    真：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(124, 107);
            this.txtTel.MenuManager = this.barManager;
            this.txtTel.Name = "txtTel";
            this.txtTel.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtTel.Properties.Appearance.Options.UseFont = true;
            this.txtTel.Size = new System.Drawing.Size(180, 18);
            this.txtTel.TabIndex = 9;
            this.txtTel.Tag = "Tel";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(58, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 12);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "电    话：";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(570, 67);
            this.txtEmail.MenuManager = this.barManager;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Size = new System.Drawing.Size(180, 18);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Tag = "Email";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(504, 72);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 12);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "邮    箱：";
            // 
            // txtContracter
            // 
            this.txtContracter.Location = new System.Drawing.Point(124, 69);
            this.txtContracter.MenuManager = this.barManager;
            this.txtContracter.Name = "txtContracter";
            this.txtContracter.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtContracter.Properties.Appearance.Options.UseFont = true;
            this.txtContracter.Size = new System.Drawing.Size(180, 18);
            this.txtContracter.TabIndex = 5;
            this.txtContracter.Tag = "Contracter";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(58, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 12);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "联 系 人：";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(125, 34);
            this.txtCompany.MenuManager = this.barManager;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCompany.Properties.Appearance.Options.UseFont = true;
            this.txtCompany.Size = new System.Drawing.Size(625, 18);
            this.txtCompany.TabIndex = 3;
            this.txtCompany.Tag = "CompanyName";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(59, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 12);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "公司名称：";
            // 
            // cmbChargeType
            // 
            this.cmbChargeType.Location = new System.Drawing.Point(570, 140);
            this.cmbChargeType.Name = "cmbChargeType";
            this.cmbChargeType.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbChargeType.Properties.Appearance.Options.UseFont = true;
            this.cmbChargeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbChargeType.Size = new System.Drawing.Size(180, 18);
            this.cmbChargeType.TabIndex = 13;
            this.cmbChargeType.Tag = "ChargeType";
            // 
            // dateOverTime
            // 
            this.dateOverTime.EditValue = null;
            this.dateOverTime.Location = new System.Drawing.Point(570, 178);
            this.dateOverTime.Name = "dateOverTime";
            this.dateOverTime.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.dateOverTime.Properties.Appearance.Options.UseFont = true;
            this.dateOverTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOverTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOverTime.Properties.DisplayFormat.FormatString = "";
            this.dateOverTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateOverTime.Properties.EditFormat.FormatString = "";
            this.dateOverTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateOverTime.Properties.MaskSettings.Set("mask", "");
            this.dateOverTime.Size = new System.Drawing.Size(180, 18);
            this.dateOverTime.TabIndex = 13;
            this.dateOverTime.Tag = "OverTime";
            // 
            // ofdLogo
            // 
            this.ofdLogo.Filter = "JPG图片(*.jpg)|*.jpg";
            // 
            // FrmCompanyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 608);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公司详情";
            this.Load += new System.EventHandler(this.FrmCompanyDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memInfor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContracter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChargeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOverTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOverTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtTel;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtContracter;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtMobile;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit memInfor;
        private DevExpress.XtraEditors.LabelControl lblAddr;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit teAddr;
        private System.Windows.Forms.OpenFileDialog ofdLogo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cmbChargeType;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtOverNumber;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit dateOverTime;
    }
}