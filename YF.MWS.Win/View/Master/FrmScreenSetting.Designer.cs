namespace YF.MWS.Win.View.Master
{
    partial class FrmScreenSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScreenSetting));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.barItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnClean = new DevExpress.XtraEditors.SimpleButton();
            this.txtSend = new DevExpress.XtraEditors.TextEdit();
            this.checkAuto = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioDigit = new DevExpress.XtraEditors.RadioGroup();
            this.memoReceive = new DevExpress.XtraEditors.MemoEdit();
            this.gcCom = new DevExpress.XtraEditors.GroupControl();
            this.cmbParity = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbStopBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDataBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbBaudRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbCom = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtShotCut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioDigit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoReceive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCom)).BeginInit();
            this.gcCom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStopBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaudRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShotCut.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemSave,
            this.barItemClose});
            this.barManager.MaxItemId = 2;
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemClose)});
            this.bar.Text = "Tools";
            // 
            // barItemSave
            // 
            this.barItemSave.Caption = "保存";
            this.barItemSave.Id = 0;
            this.barItemSave.ImageIndex = 0;
            this.barItemSave.Name = "barItemSave";
            this.barItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSave_ItemClick);
            // 
            // barItemClose
            // 
            this.barItemClose.Caption = "关闭";
            this.barItemClose.Id = 1;
            this.barItemClose.ImageIndex = 1;
            this.barItemClose.Name = "barItemClose";
            this.barItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(672, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 459);
            this.barDockControlBottom.Size = new System.Drawing.Size(672, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 428);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(672, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 428);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSend);
            this.panelControl1.Controls.Add(this.btnClean);
            this.panelControl1.Controls.Add(this.txtSend);
            this.panelControl1.Controls.Add(this.checkAuto);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.memoReceive);
            this.panelControl1.Location = new System.Drawing.Point(204, 37);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(456, 203);
            this.panelControl1.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Location = new System.Drawing.Point(380, 165);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClean
            // 
            this.btnClean.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClean.Appearance.Options.UseFont = true;
            this.btnClean.Location = new System.Drawing.Point(288, 165);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(70, 23);
            this.btnClean.TabIndex = 6;
            this.btnClean.Text = "清空";
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(241, 130);
            this.txtSend.MenuManager = this.barManager;
            this.txtSend.Name = "txtSend";
            this.txtSend.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtSend.Properties.Appearance.Options.UseFont = true;
            this.txtSend.Size = new System.Drawing.Size(209, 18);
            this.txtSend.TabIndex = 5;
            // 
            // checkAuto
            // 
            this.checkAuto.Location = new System.Drawing.Point(242, 96);
            this.checkAuto.MenuManager = this.barManager;
            this.checkAuto.Name = "checkAuto";
            this.checkAuto.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.checkAuto.Properties.Appearance.Options.UseFont = true;
            this.checkAuto.Properties.Caption = "自动发送";
            this.checkAuto.Size = new System.Drawing.Size(75, 19);
            this.checkAuto.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.radioDigit);
            this.groupControl1.Location = new System.Drawing.Point(241, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(210, 76);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "数据显示 进制转换";
            // 
            // radioDigit
            // 
            this.radioDigit.EditValue = 0;
            this.radioDigit.Location = new System.Drawing.Point(5, 28);
            this.radioDigit.MenuManager = this.barManager;
            this.radioDigit.Name = "radioDigit";
            this.radioDigit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.radioDigit.Properties.Appearance.Options.UseFont = true;
            this.radioDigit.Properties.Columns = 2;
            this.radioDigit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "十进制"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "十六进制")});
            this.radioDigit.Size = new System.Drawing.Size(200, 39);
            this.radioDigit.TabIndex = 1;
            // 
            // memoReceive
            // 
            this.memoReceive.Location = new System.Drawing.Point(6, 6);
            this.memoReceive.MenuManager = this.barManager;
            this.memoReceive.Name = "memoReceive";
            this.memoReceive.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.memoReceive.Properties.Appearance.Options.UseFont = true;
            this.memoReceive.Size = new System.Drawing.Size(229, 192);
            this.memoReceive.TabIndex = 0;
            // 
            // gcCom
            // 
            this.gcCom.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcCom.Appearance.Options.UseFont = true;
            this.gcCom.Controls.Add(this.cmbParity);
            this.gcCom.Controls.Add(this.cmbStopBits);
            this.gcCom.Controls.Add(this.cmbDataBits);
            this.gcCom.Controls.Add(this.cmbBaudRate);
            this.gcCom.Controls.Add(this.cmbCom);
            this.gcCom.Controls.Add(this.labelControl5);
            this.gcCom.Controls.Add(this.labelControl4);
            this.gcCom.Controls.Add(this.labelControl3);
            this.gcCom.Controls.Add(this.labelControl2);
            this.gcCom.Controls.Add(this.labelControl1);
            this.gcCom.Location = new System.Drawing.Point(7, 37);
            this.gcCom.Name = "gcCom";
            this.gcCom.Size = new System.Drawing.Size(191, 203);
            this.gcCom.TabIndex = 10;
            this.gcCom.Text = "COM端口设置";
            // 
            // cmbParity
            // 
            this.cmbParity.Location = new System.Drawing.Point(79, 162);
            this.cmbParity.MenuManager = this.barManager;
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbParity.Properties.Appearance.Options.UseFont = true;
            this.cmbParity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbParity.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbParity.Size = new System.Drawing.Size(92, 18);
            this.cmbParity.TabIndex = 14;
            this.cmbParity.Tag = "ParityVerifyBit";
            this.cmbParity.SelectedIndexChanged += new System.EventHandler(this.cmbParity_SelectedIndexChanged);
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Location = new System.Drawing.Point(79, 130);
            this.cmbStopBits.MenuManager = this.barManager;
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbStopBits.Properties.Appearance.Options.UseFont = true;
            this.cmbStopBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbStopBits.Size = new System.Drawing.Size(92, 18);
            this.cmbStopBits.TabIndex = 13;
            this.cmbStopBits.Tag = "StopBit";
            this.cmbStopBits.SelectedIndexChanged += new System.EventHandler(this.cmbStopBits_SelectedIndexChanged);
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Location = new System.Drawing.Point(79, 98);
            this.cmbDataBits.MenuManager = this.barManager;
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbDataBits.Properties.Appearance.Options.UseFont = true;
            this.cmbDataBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDataBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDataBits.Size = new System.Drawing.Size(92, 18);
            this.cmbDataBits.TabIndex = 12;
            this.cmbDataBits.Tag = "DataBit";
            this.cmbDataBits.SelectedIndexChanged += new System.EventHandler(this.cmbDataBits_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Location = new System.Drawing.Point(79, 66);
            this.cmbBaudRate.MenuManager = this.barManager;
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaudRate.Properties.Appearance.Options.UseFont = true;
            this.cmbBaudRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBaudRate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBaudRate.Size = new System.Drawing.Size(92, 18);
            this.cmbBaudRate.TabIndex = 11;
            this.cmbBaudRate.Tag = "BaundRate";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged);
            // 
            // cmbCom
            // 
            this.cmbCom.Location = new System.Drawing.Point(79, 35);
            this.cmbCom.MenuManager = this.barManager;
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCom.Properties.Appearance.Options.UseFont = true;
            this.cmbCom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCom.Size = new System.Drawing.Size(92, 18);
            this.cmbCom.TabIndex = 10;
            this.cmbCom.SelectedIndexChanged += new System.EventHandler(this.cmbCom_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl5.Location = new System.Drawing.Point(15, 165);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 12);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "奇偶校验：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(15, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 12);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "停 止 位：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(15, 101);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 12);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "数 据 位：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(15, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 12);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "波 特 率：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(15, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 12);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "端    口：";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtShotCut);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Location = new System.Drawing.Point(7, 250);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(653, 200);
            this.panelControl2.TabIndex = 16;
            // 
            // txtShotCut
            // 
            this.txtShotCut.EditValue = "F1";
            this.txtShotCut.Location = new System.Drawing.Point(15, 42);
            this.txtShotCut.MenuManager = this.barManager;
            this.txtShotCut.Name = "txtShotCut";
            this.txtShotCut.Properties.ReadOnly = true;
            this.txtShotCut.Size = new System.Drawing.Size(100, 20);
            this.txtShotCut.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl6.Location = new System.Drawing.Point(15, 23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(186, 12);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "显示 / 屏蔽快捷键（F1 - F12）：";
            // 
            // FrmScreenSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 459);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcCom);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmScreenSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "大屏幕设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScreenSetting_FormClosed);
            this.Load += new System.EventHandler(this.FrmScreenSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmScreenSetting_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioDigit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoReceive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCom)).EndInit();
            this.gcCom.ResumeLayout(false);
            this.gcCom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStopBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaudRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShotCut.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem barItemSave;
        private DevExpress.XtraBars.BarButtonItem barItemClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnClean;
        private DevExpress.XtraEditors.TextEdit txtSend;
        private DevExpress.XtraEditors.CheckEdit checkAuto;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioDigit;
        private DevExpress.XtraEditors.MemoEdit memoReceive;
        private DevExpress.XtraEditors.GroupControl gcCom;
        private DevExpress.XtraEditors.ComboBoxEdit cmbParity;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStopBits;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDataBits;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBaudRate;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCom;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtShotCut;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}