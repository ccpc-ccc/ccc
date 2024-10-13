using YF.MWS.Win.View.Master;
namespace YF.MWS.Win.View.Manage
{
    partial class FrmCustomCodeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomCodeList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemRefreh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.bItemSave = new DevExpress.XtraBars.BarSubItem();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.tlCode = new DevExpress.XtraTreeList.TreeList();
            this.colItemCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colItemCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCreateTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUpdateTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCode)).BeginInit();
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
            this.btnItemAdd,
            this.bItemSave,
            this.btnItemSave,
            this.btnItemRefreh,
            this.btnItemCancel,
            this.btnItemAddSub,
            this.btnItemDelete,
            this.btnItemEdit});
            this.barManager.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAddSub),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRefreh)});
            this.bar1.Text = "Tools";
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "添加父类";
            this.btnItemAdd.Id = 4;
            this.btnItemAdd.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemAddSub
            // 
            this.btnItemAddSub.Caption = "添加子类";
            this.btnItemAddSub.Id = 5;
            this.btnItemAddSub.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAddSub.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAddSub_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 7;
            this.btnItemEdit.ImageIndex = 4;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 6;
            this.btnItemDelete.ImageIndex = 3;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDelete_ItemClick);
            // 
            // btnItemRefreh
            // 
            this.btnItemRefreh.Caption = "刷新";
            this.btnItemRefreh.Id = 2;
            this.btnItemRefreh.ImageIndex = 5;
            this.btnItemRefreh.Name = "btnItemRefreh";
            this.btnItemRefreh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemRefreh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemRefreh_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(875, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 474);
            this.barDockControlBottom.Size = new System.Drawing.Size(875, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 443);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(875, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 443);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "cancel_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "refresh_16x16.png");
            // 
            // bItemSave
            // 
            this.bItemSave.Caption = "保存";
            this.bItemSave.Id = 0;
            this.bItemSave.ImageIndex = 0;
            this.bItemSave.Name = "bItemSave";
            this.bItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // tlCode
            // 
            this.tlCode.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colItemCode,
            this.colItemCaption,
            this.colCreateTime,
            this.colUpdateTime});
            this.tlCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCode.KeyFieldName = "CodeId";
            this.tlCode.Location = new System.Drawing.Point(0, 31);
            this.tlCode.Name = "tlCode";
            this.tlCode.OptionsBehavior.Editable = false;
            this.tlCode.OptionsPrint.UsePrintStyles = true;
            this.tlCode.ParentFieldName = "ParentId";
            this.tlCode.Size = new System.Drawing.Size(875, 443);
            this.tlCode.TabIndex = 4;
            // 
            // colItemCode
            // 
            this.colItemCode.Caption = "编码";
            this.colItemCode.FieldName = "ItemCode";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 0;
            // 
            // colItemCaption
            // 
            this.colItemCaption.Caption = "说明";
            this.colItemCaption.FieldName = "ItemCaption";
            this.colItemCaption.Name = "colItemCaption";
            this.colItemCaption.Visible = true;
            this.colItemCaption.VisibleIndex = 1;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 2;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Caption = "更新时间";
            this.colUpdateTime.FieldName = "UpdateTime";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.Visible = true;
            this.colUpdateTime.VisibleIndex = 3;
            // 
            // FrmCustomCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 474);
            this.Controls.Add(this.tlCode);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmCustomCodeList";
            this.Text = "自定义编码";
            this.Load += new System.EventHandler(this.FrmCodeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemRefreh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem bItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraTreeList.TreeList tlCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemCaption;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCreateTime;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUpdateTime;
    }
}