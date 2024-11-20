namespace YF.MWS.Win.View.Setting
{
    partial class FrmTransferCfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransferCfg));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.plMain = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.gpRuiJieYun = new DevExpress.XtraEditors.GroupControl();
            this.lblRemoteServerUrl = new DevExpress.XtraEditors.LabelControl();
            this.txtServerIn = new DevExpress.XtraEditors.TextEdit();
            this.txtServerOut = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).BeginInit();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpRuiJieYun)).BeginInit();
            this.gpRuiJieYun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerOut.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(437, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 249);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(437, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 225);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(437, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 225);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.checkEdit1);
            this.plMain.Controls.Add(this.gpRuiJieYun);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 24);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(437, 225);
            this.plMain.TabIndex = 5;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(25, 13);
            this.checkEdit1.MenuManager = this.barManager;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "开启服务";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 19;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // gpRuiJieYun
            // 
            this.gpRuiJieYun.Controls.Add(this.labelControl1);
            this.gpRuiJieYun.Controls.Add(this.lblRemoteServerUrl);
            this.gpRuiJieYun.Controls.Add(this.txtServerOut);
            this.gpRuiJieYun.Controls.Add(this.txtServerIn);
            this.gpRuiJieYun.Enabled = false;
            this.gpRuiJieYun.Location = new System.Drawing.Point(12, 39);
            this.gpRuiJieYun.Name = "gpRuiJieYun";
            this.gpRuiJieYun.Size = new System.Drawing.Size(415, 174);
            this.gpRuiJieYun.TabIndex = 60;
            this.gpRuiJieYun.Text = "云磅服务器设置";
            // 
            // lblRemoteServerUrl
            // 
            this.lblRemoteServerUrl.Location = new System.Drawing.Point(7, 60);
            this.lblRemoteServerUrl.Name = "lblRemoteServerUrl";
            this.lblRemoteServerUrl.Size = new System.Drawing.Size(52, 14);
            this.lblRemoteServerUrl.TabIndex = 11;
            this.lblRemoteServerUrl.Text = "入库连接:";
            // 
            // txtServerIn
            // 
            this.txtServerIn.Location = new System.Drawing.Point(64, 58);
            this.txtServerIn.Name = "txtServerIn";
            this.txtServerIn.Size = new System.Drawing.Size(346, 20);
            this.txtServerIn.TabIndex = 12;
            this.txtServerIn.Tag = "ServerUrl";
            // 
            // txtServerOut
            // 
            this.txtServerOut.Location = new System.Drawing.Point(64, 109);
            this.txtServerOut.Name = "txtServerOut";
            this.txtServerOut.Size = new System.Drawing.Size(346, 20);
            this.txtServerOut.TabIndex = 12;
            this.txtServerOut.Tag = "ServerUrl";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 111);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "出库连接:";
            // 
            // FrmTransferCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 249);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransferCfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联网设置";
            this.Load += new System.EventHandler(this.FrmTransferCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).EndInit();
            this.plMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpRuiJieYun)).EndInit();
            this.gpRuiJieYun.ResumeLayout(false);
            this.gpRuiJieYun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerOut.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl plMain;
        private DevExpress.XtraEditors.GroupControl gpRuiJieYun;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LabelControl lblRemoteServerUrl;
        private DevExpress.XtraEditors.TextEdit txtServerIn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtServerOut;
    }
}