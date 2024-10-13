namespace YF.MWS.Win.View.Weight
{
    partial class FrmViewGraphic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewGraphic));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemFirst = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPrev = new DevExpress.XtraBars.BarButtonItem();
            this.barItemNext = new DevExpress.XtraBars.BarButtonItem();
            this.barItemLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.pcInfo = new DevExpress.XtraEditors.PanelControl();
            this.peView = new DevExpress.XtraEditors.PictureEdit();
            this.lblCreateTime = new DevExpress.XtraEditors.LabelControl();
            this.lblFileType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInfo)).BeginInit();
            this.pcInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peView.Properties)).BeginInit();
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
            this.btnItemClose,
            this.btnItemFirst,
            this.barItemNext,
            this.barItemPrev,
            this.barItemLast});
            this.barManager.MaxItemId = 13;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemFirst),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPrev),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemFirst
            // 
            this.btnItemFirst.Caption = "第一张";
            this.btnItemFirst.Id = 7;
            this.btnItemFirst.ImageIndex = 1;
            this.btnItemFirst.Name = "btnItemFirst";
            this.btnItemFirst.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemFirst_ItemClick);
            // 
            // barItemPrev
            // 
            this.barItemPrev.Caption = "上一张";
            this.barItemPrev.Id = 11;
            this.barItemPrev.ImageIndex = 4;
            this.barItemPrev.Name = "barItemPrev";
            this.barItemPrev.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPrev.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemPrev_ItemClick);
            // 
            // barItemNext
            // 
            this.barItemNext.Caption = "下一张";
            this.barItemNext.Id = 10;
            this.barItemNext.ImageIndex = 2;
            this.barItemNext.Name = "barItemNext";
            this.barItemNext.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemNext_ItemClick);
            // 
            // barItemLast
            // 
            this.barItemLast.Caption = "最后一张";
            this.barItemLast.Id = 12;
            this.barItemLast.ImageIndex = 3;
            this.barItemLast.Name = "barItemLast";
            this.barItemLast.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemLast_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 1;
            this.btnItemClose.ImageIndex = 0;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(916, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 419);
            this.barDockControlBottom.Size = new System.Drawing.Size(916, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 388);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(916, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 388);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "first_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "next_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "last_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "prev_16x16.png");
            // 
            // pcInfo
            // 
            this.pcInfo.Controls.Add(this.lblFileType);
            this.pcInfo.Controls.Add(this.lblCreateTime);
            this.pcInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcInfo.Location = new System.Drawing.Point(0, 31);
            this.pcInfo.Name = "pcInfo";
            this.pcInfo.Size = new System.Drawing.Size(916, 45);
            this.pcInfo.TabIndex = 9;
            // 
            // peView
            // 
            this.peView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peView.Location = new System.Drawing.Point(0, 76);
            this.peView.MenuManager = this.barManager;
            this.peView.Name = "peView";
            this.peView.Size = new System.Drawing.Size(916, 343);
            this.peView.TabIndex = 10;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Location = new System.Drawing.Point(16, 17);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(52, 14);
            this.lblCreateTime.TabIndex = 0;
            this.lblCreateTime.Text = "抓拍时间:";
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(765, 17);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(28, 14);
            this.lblFileType.TabIndex = 1;
            this.lblFileType.Text = "类型:";
            // 
            // FrmViewGraphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 419);
            this.Controls.Add(this.peView);
            this.Controls.Add(this.pcInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmViewGraphic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浏览图片";
            this.Load += new System.EventHandler(this.FrmViewGraphic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInfo)).EndInit();
            this.pcInfo.ResumeLayout(false);
            this.pcInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peView.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarButtonItem btnItemFirst;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem barItemPrev;
        private DevExpress.XtraBars.BarButtonItem barItemNext;
        private DevExpress.XtraBars.BarButtonItem barItemLast;
        private DevExpress.XtraEditors.PictureEdit peView;
        private DevExpress.XtraEditors.PanelControl pcInfo;
        private DevExpress.XtraEditors.LabelControl lblFileType;
        private DevExpress.XtraEditors.LabelControl lblCreateTime;
    }
}