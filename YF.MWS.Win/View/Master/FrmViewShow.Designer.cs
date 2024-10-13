namespace YF.MWS.Win.View.Master
{
    partial class FrmViewShow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewShow));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.txtViewName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pcControls = new DevExpress.XtraEditors.PanelControl();
            this.lblControlName = new DevExpress.XtraEditors.LabelControl();
            this.txtColumnConut = new DevExpress.XtraEditors.TextEdit();
            this.lblFieldName = new DevExpress.XtraEditors.LabelControl();
            this.chkDefual = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViewName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumnConut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefual.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(878, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 633);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(878, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 609);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(878, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 609);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // txtViewName
            // 
            this.txtViewName.Location = new System.Drawing.Point(89, 14);
            this.txtViewName.MenuManager = this.barManager;
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(173, 20);
            this.txtViewName.TabIndex = 41;
            this.txtViewName.Tag = "";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkDefual);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.pcControls);
            this.panelControl1.Controls.Add(this.txtViewName);
            this.panelControl1.Controls.Add(this.lblControlName);
            this.panelControl1.Controls.Add(this.txtColumnConut);
            this.panelControl1.Controls.Add(this.lblFieldName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(878, 609);
            this.panelControl1.TabIndex = 8;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(793, 11);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(80, 23);
            this.simpleButton2.TabIndex = 43;
            this.simpleButton2.Text = "删除列";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(708, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(79, 23);
            this.simpleButton1.TabIndex = 43;
            this.simpleButton1.Text = "添加列";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pcControls
            // 
            this.pcControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcControls.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcControls.Location = new System.Drawing.Point(5, 40);
            this.pcControls.Name = "pcControls";
            this.pcControls.Size = new System.Drawing.Size(868, 564);
            this.pcControls.TabIndex = 42;
            this.pcControls.SizeChanged += new System.EventHandler(this.pcControls_SizeChanged);
            // 
            // lblControlName
            // 
            this.lblControlName.Location = new System.Drawing.Point(31, 17);
            this.lblControlName.Name = "lblControlName";
            this.lblControlName.Size = new System.Drawing.Size(52, 14);
            this.lblControlName.TabIndex = 40;
            this.lblControlName.Text = "界面名称:";
            // 
            // txtColumnConut
            // 
            this.txtColumnConut.EditValue = "3";
            this.txtColumnConut.Location = new System.Drawing.Point(385, 14);
            this.txtColumnConut.MenuManager = this.barManager;
            this.txtColumnConut.Name = "txtColumnConut";
            this.txtColumnConut.Size = new System.Drawing.Size(77, 20);
            this.txtColumnConut.TabIndex = 36;
            this.txtColumnConut.Tag = "FieldName";
            this.txtColumnConut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColumnConut_KeyDown);
            this.txtColumnConut.Leave += new System.EventHandler(this.txtColumnConut_Leave);
            // 
            // lblFieldName
            // 
            this.lblFieldName.Location = new System.Drawing.Point(327, 17);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(52, 14);
            this.lblFieldName.TabIndex = 38;
            this.lblFieldName.Text = "显示列数:";
            // 
            // chkDefual
            // 
            this.chkDefual.EditValue = true;
            this.chkDefual.Location = new System.Drawing.Point(468, 14);
            this.chkDefual.MenuManager = this.barManager;
            this.chkDefual.Name = "chkDefual";
            this.chkDefual.Properties.Caption = "立即使用";
            this.chkDefual.Size = new System.Drawing.Size(75, 20);
            this.chkDefual.TabIndex = 44;
            // 
            // FrmViewShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 633);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(602, 400);
            this.Name = "FrmViewShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   ";
            this.Load += new System.EventHandler(this.FrmViewDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViewName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumnConut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefual.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtViewName;
        private DevExpress.XtraEditors.LabelControl lblControlName;
        private DevExpress.XtraEditors.TextEdit txtColumnConut;
        private DevExpress.XtraEditors.LabelControl lblFieldName;
        private DevExpress.XtraEditors.PanelControl pcControls;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit chkDefual;
    }
}