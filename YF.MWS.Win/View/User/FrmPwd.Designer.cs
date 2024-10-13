namespace YF.MWS.Win.View.User
{
    partial class FrmPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPwd));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.teNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.teCfmPwd = new DevExpress.XtraEditors.TextEdit();
            this.teOldPwd = new DevExpress.XtraEditors.TextEdit();
            this.btnChangePwd = new DevExpress.XtraEditors.SimpleButton();
            this.lblNewPwd = new DevExpress.XtraEditors.LabelControl();
            this.plMain = new DevExpress.XtraEditors.PanelControl();
            this.lblCfmPwd = new DevExpress.XtraEditors.LabelControl();
            this.lblOldPwd = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCfmPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOldPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).BeginInit();
            this.plMain.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(342, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 238);
            this.barDockControlBottom.Size = new System.Drawing.Size(342, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 207);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(342, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 207);
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
            // teNewPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teNewPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teNewPwd.Location = new System.Drawing.Point(126, 66);
            this.teNewPwd.MenuManager = this.barManager;
            this.teNewPwd.Name = "teNewPwd";
            this.teNewPwd.Size = new System.Drawing.Size(154, 20);
            this.teNewPwd.TabIndex = 8;
            // 
            // teCfmPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teCfmPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teCfmPwd.Location = new System.Drawing.Point(126, 101);
            this.teCfmPwd.MenuManager = this.barManager;
            this.teCfmPwd.Name = "teCfmPwd";
            this.teCfmPwd.Size = new System.Drawing.Size(154, 20);
            this.teCfmPwd.TabIndex = 43;
            // 
            // teOldPwd
            // 
            this.dxErrorProvider.SetIconAlignment(this.teOldPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teOldPwd.Location = new System.Drawing.Point(126, 31);
            this.teOldPwd.MenuManager = this.barManager;
            this.teOldPwd.Name = "teOldPwd";
            this.teOldPwd.Size = new System.Drawing.Size(154, 20);
            this.teOldPwd.TabIndex = 41;
            this.teOldPwd.Tag = "";
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(126, 143);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangePwd.TabIndex = 9;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.Location = new System.Drawing.Point(31, 69);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(40, 14);
            this.lblNewPwd.TabIndex = 7;
            this.lblNewPwd.Text = "新密码:";
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.lblCfmPwd);
            this.plMain.Controls.Add(this.teCfmPwd);
            this.plMain.Controls.Add(this.teOldPwd);
            this.plMain.Controls.Add(this.lblNewPwd);
            this.plMain.Controls.Add(this.teNewPwd);
            this.plMain.Controls.Add(this.btnChangePwd);
            this.plMain.Controls.Add(this.lblOldPwd);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 31);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(342, 207);
            this.plMain.TabIndex = 10;
            // 
            // lblCfmPwd
            // 
            this.lblCfmPwd.Location = new System.Drawing.Point(31, 104);
            this.lblCfmPwd.Name = "lblCfmPwd";
            this.lblCfmPwd.Size = new System.Drawing.Size(64, 14);
            this.lblCfmPwd.TabIndex = 42;
            this.lblCfmPwd.Text = "确认新密码:";
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.Location = new System.Drawing.Point(31, 34);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(40, 14);
            this.lblOldPwd.TabIndex = 40;
            this.lblOldPwd.Text = "原密码:";
            // 
            // FrmPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 238);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 277);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 277);
            this.Name = "FrmPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改";
            this.Load += new System.EventHandler(this.FrmPwd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCfmPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOldPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).EndInit();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
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
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.SimpleButton btnChangePwd;
        private DevExpress.XtraEditors.TextEdit teNewPwd;
        private DevExpress.XtraEditors.LabelControl lblNewPwd;
        private DevExpress.XtraEditors.PanelControl plMain;
        private DevExpress.XtraEditors.LabelControl lblCfmPwd;
        private DevExpress.XtraEditors.TextEdit teCfmPwd;
        private DevExpress.XtraEditors.TextEdit teOldPwd;
        private DevExpress.XtraEditors.LabelControl lblOldPwd;
    }
}