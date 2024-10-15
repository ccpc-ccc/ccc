namespace YF.MWS.Win.View.Master
{
    partial class FrmPlanCardEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanCardEdit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemComShort = new DevExpress.XtraBars.BarEditItem();
            this.combComShort = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barItemOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barItemOnlySave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.ucCardEdit = new YF.MWS.Win.Uc.UcCardEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combComShort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
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
            this.btnItemClose,
            this.barItemOpen,
            this.barItemSaveAndNew,
            this.barItemOnlySave,
            this.barItemComShort});
            this.barManager.MaxItemId = 14;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.combComShort});
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemComShort, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemOnlySave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSaveAndNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave)});
            this.barTop.Text = "Tools";
            // 
            // barItemComShort
            // 
            this.barItemComShort.Edit = this.combComShort;
            this.barItemComShort.Id = 13;
            this.barItemComShort.ImageIndex = 4;
            this.barItemComShort.Name = "barItemComShort";
            this.barItemComShort.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // combComShort
            // 
            this.combComShort.AutoHeight = false;
            this.combComShort.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combComShort.DisplayFormat.FormatString = "串口:{0}";
            this.combComShort.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.combComShort.EditFormat.FormatString = "串口:{0}";
            this.combComShort.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.combComShort.Name = "combComShort";
            this.combComShort.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.FrameResize;
            // 
            // barItemOpen
            // 
            this.barItemOpen.Caption = "打开串口";
            this.barItemOpen.Id = 10;
            this.barItemOpen.ImageIndex = 2;
            this.barItemOpen.Name = "barItemOpen";
            this.barItemOpen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemOpen_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭串口";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barItemOnlySave
            // 
            this.barItemOnlySave.Caption = "保存";
            this.barItemOnlySave.Id = 12;
            this.barItemOnlySave.ImageIndex = 0;
            this.barItemOnlySave.Name = "barItemOnlySave";
            this.barItemOnlySave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemOnlySave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemOnlySave_ItemClick);
            // 
            // barItemSaveAndNew
            // 
            this.barItemSaveAndNew.Caption = "保存并新建";
            this.barItemSaveAndNew.Id = 11;
            this.barItemSaveAndNew.ImageIndex = 3;
            this.barItemSaveAndNew.Name = "barItemSaveAndNew";
            this.barItemSaveAndNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSaveAndNew_ItemClick);
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存并关闭";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1081, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 530);
            this.barDockControlBottom.Size = new System.Drawing.Size(1081, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 499);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1081, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 499);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "scode_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // ucCardEdit
            // 
            this.ucCardEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCardEdit.IsVirtualCard = false;
            this.ucCardEdit.Location = new System.Drawing.Point(0, 31);
            this.ucCardEdit.Name = "ucCardEdit";
            this.ucCardEdit.Size = new System.Drawing.Size(1081, 499);
            this.ucCardEdit.StartAppCardRead = false;
            this.ucCardEdit.TabIndex = 18;
            // 
            // FrmPlanCardEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 530);
            this.Controls.Add(this.ucCardEdit);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(438, 242);
            this.Name = "FrmPlanCardEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IC卡编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlanCardEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmCardEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combComShort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
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
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraBars.BarButtonItem barItemOpen;
        private DevExpress.XtraBars.BarButtonItem barItemSaveAndNew;
        private Uc.UcCardEdit ucCardEdit;
        private DevExpress.XtraBars.BarButtonItem barItemOnlySave;
        private DevExpress.XtraBars.BarEditItem barItemComShort;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox combComShort;
    }
}