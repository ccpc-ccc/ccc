namespace YF.MWS.Win.View.User
{
    partial class FrmModuleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleEdit));
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
            this.memSuperTipContent = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSelectParent = new DevExpress.XtraEditors.SimpleButton();
            this.lblOrderNoNote = new DevExpress.XtraEditors.LabelControl();
            this.teOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.chkSuperTipState = new DevExpress.XtraEditors.CheckEdit();
            this.lblSuperTipContent = new DevExpress.XtraEditors.LabelControl();
            this.teActionName = new DevExpress.XtraEditors.TextEdit();
            this.lblActionName = new DevExpress.XtraEditors.LabelControl();
            this.teParent = new DevExpress.XtraEditors.TextEdit();
            this.lblParent = new DevExpress.XtraEditors.LabelControl();
            this.teFullName = new DevExpress.XtraEditors.TextEdit();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.teModuleName = new DevExpress.XtraEditors.TextEdit();
            this.lblModuleName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSuperTipContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSuperTipState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teActionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teModuleName.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(630, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 469);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(630, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 445);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(630, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 445);
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
            // memSuperTipContent
            // 
            this.dxErrorProvider.SetIconAlignment(this.memSuperTipContent, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.memSuperTipContent.Location = new System.Drawing.Point(107, 237);
            this.memSuperTipContent.MenuManager = this.barManager;
            this.memSuperTipContent.Name = "memSuperTipContent";
            this.memSuperTipContent.Size = new System.Drawing.Size(475, 180);
            this.memSuperTipContent.TabIndex = 46;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSelectParent);
            this.panelControl1.Controls.Add(this.lblOrderNoNote);
            this.panelControl1.Controls.Add(this.teOrderNo);
            this.panelControl1.Controls.Add(this.lblOrderNo);
            this.panelControl1.Controls.Add(this.chkSuperTipState);
            this.panelControl1.Controls.Add(this.memSuperTipContent);
            this.panelControl1.Controls.Add(this.lblSuperTipContent);
            this.panelControl1.Controls.Add(this.teActionName);
            this.panelControl1.Controls.Add(this.lblActionName);
            this.panelControl1.Controls.Add(this.teParent);
            this.panelControl1.Controls.Add(this.lblParent);
            this.panelControl1.Controls.Add(this.teFullName);
            this.panelControl1.Controls.Add(this.lblFullName);
            this.panelControl1.Controls.Add(this.teModuleName);
            this.panelControl1.Controls.Add(this.lblModuleName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(630, 445);
            this.panelControl1.TabIndex = 6;
            // 
            // btnSelectParent
            // 
            this.btnSelectParent.Location = new System.Drawing.Point(301, 23);
            this.btnSelectParent.Name = "btnSelectParent";
            this.btnSelectParent.Size = new System.Drawing.Size(98, 23);
            this.btnSelectParent.TabIndex = 51;
            this.btnSelectParent.Text = "选择上级模块";
            this.btnSelectParent.Click += new System.EventHandler(this.btnSelectParent_Click);
            // 
            // lblOrderNoNote
            // 
            this.lblOrderNoNote.Location = new System.Drawing.Point(291, 177);
            this.lblOrderNoNote.Name = "lblOrderNoNote";
            this.lblOrderNoNote.Size = new System.Drawing.Size(108, 14);
            this.lblOrderNoNote.TabIndex = 50;
            this.lblOrderNoNote.Text = "数字越小排名越靠前";
            // 
            // teOrderNo
            // 
            this.teOrderNo.Location = new System.Drawing.Point(107, 174);
            this.teOrderNo.MenuManager = this.barManager;
            this.teOrderNo.Name = "teOrderNo";
            this.teOrderNo.Size = new System.Drawing.Size(169, 20);
            this.teOrderNo.TabIndex = 48;
            this.teOrderNo.Tag = "OrderNo";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(19, 175);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(40, 14);
            this.lblOrderNo.TabIndex = 49;
            this.lblOrderNo.Text = "排序号:";
            // 
            // chkSuperTipState
            // 
            this.chkSuperTipState.Location = new System.Drawing.Point(105, 207);
            this.chkSuperTipState.MenuManager = this.barManager;
            this.chkSuperTipState.Name = "chkSuperTipState";
            this.chkSuperTipState.Properties.Caption = "开启提示";
            this.chkSuperTipState.Size = new System.Drawing.Size(75, 20);
            this.chkSuperTipState.TabIndex = 47;
            // 
            // lblSuperTipContent
            // 
            this.lblSuperTipContent.Location = new System.Drawing.Point(19, 231);
            this.lblSuperTipContent.Name = "lblSuperTipContent";
            this.lblSuperTipContent.Size = new System.Drawing.Size(52, 14);
            this.lblSuperTipContent.TabIndex = 45;
            this.lblSuperTipContent.Text = "提示内容:";
            // 
            // teActionName
            // 
            this.teActionName.Location = new System.Drawing.Point(107, 136);
            this.teActionName.MenuManager = this.barManager;
            this.teActionName.Name = "teActionName";
            this.teActionName.Size = new System.Drawing.Size(169, 20);
            this.teActionName.TabIndex = 42;
            this.teActionName.Tag = "ActionName";
            // 
            // lblActionName
            // 
            this.lblActionName.Location = new System.Drawing.Point(19, 137);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(52, 14);
            this.lblActionName.TabIndex = 43;
            this.lblActionName.Text = "操作名称:";
            // 
            // teParent
            // 
            this.teParent.Enabled = false;
            this.teParent.Location = new System.Drawing.Point(107, 24);
            this.teParent.MenuManager = this.barManager;
            this.teParent.Name = "teParent";
            this.teParent.Size = new System.Drawing.Size(169, 20);
            this.teParent.TabIndex = 41;
            this.teParent.Tag = "";
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(19, 25);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(52, 14);
            this.lblParent.TabIndex = 40;
            this.lblParent.Text = "上级模块:";
            // 
            // teFullName
            // 
            this.teFullName.Location = new System.Drawing.Point(107, 97);
            this.teFullName.MenuManager = this.barManager;
            this.teFullName.Name = "teFullName";
            this.teFullName.Size = new System.Drawing.Size(475, 20);
            this.teFullName.TabIndex = 37;
            this.teFullName.Tag = "FullName";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(19, 98);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(52, 14);
            this.lblFullName.TabIndex = 39;
            this.lblFullName.Text = "权限编号:";
            // 
            // teModuleName
            // 
            this.teModuleName.Location = new System.Drawing.Point(107, 60);
            this.teModuleName.MenuManager = this.barManager;
            this.teModuleName.Name = "teModuleName";
            this.teModuleName.Size = new System.Drawing.Size(169, 20);
            this.teModuleName.TabIndex = 36;
            this.teModuleName.Tag = "ModuleName";
            // 
            // lblModuleName
            // 
            this.lblModuleName.Location = new System.Drawing.Point(19, 60);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(52, 14);
            this.lblModuleName.TabIndex = 38;
            this.lblModuleName.Text = "模块名称:";
            // 
            // FrmModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 469);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmModuleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块详情";
            this.Load += new System.EventHandler(this.FrmModuleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSuperTipContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSuperTipState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teActionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teModuleName.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit teParent;
        private DevExpress.XtraEditors.LabelControl lblParent;
        private DevExpress.XtraEditors.TextEdit teFullName;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit teModuleName;
        private DevExpress.XtraEditors.LabelControl lblModuleName;
        private DevExpress.XtraEditors.TextEdit teActionName;
        private DevExpress.XtraEditors.LabelControl lblActionName;
        private DevExpress.XtraEditors.LabelControl lblSuperTipContent;
        private DevExpress.XtraEditors.CheckEdit chkSuperTipState;
        private DevExpress.XtraEditors.MemoEdit memSuperTipContent;
        private DevExpress.XtraEditors.LabelControl lblOrderNoNote;
        private DevExpress.XtraEditors.TextEdit teOrderNo;
        private DevExpress.XtraEditors.LabelControl lblOrderNo;
        private DevExpress.XtraEditors.SimpleButton btnSelectParent;
    }
}