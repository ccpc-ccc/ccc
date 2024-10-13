namespace YF.MWS.Win.View.Master
{
    partial class FrmDepartmentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartmentList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.tlDepart = new DevExpress.XtraTreeList.TreeList();
            this.tlcDeptName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcCompanyName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcDeptTypeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcCreateTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlDepart)).BeginInit();
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
            this.btnItemAdd,
            this.btnItemAddSub,
            this.btnItemEdit,
            this.btnItemDelete,
            this.btnItemRefresh});
            this.barManager.MaxItemId = 6;
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAddSub),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRefresh)});
            this.bar.Text = "Tools";
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "添加部门";
            this.btnItemAdd.Id = 1;
            this.btnItemAdd.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemAddSub
            // 
            this.btnItemAddSub.Caption = "添加子部门";
            this.btnItemAddSub.Id = 2;
            this.btnItemAddSub.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAddSub.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAddSub_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 3;
            this.btnItemEdit.ImageIndex = 2;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 4;
            this.btnItemDelete.ImageIndex = 3;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDelete_ItemClick);
            // 
            // btnItemRefresh
            // 
            this.btnItemRefresh.Caption = "刷新";
            this.btnItemRefresh.Id = 5;
            this.btnItemRefresh.ImageIndex = 4;
            this.btnItemRefresh.Name = "btnItemRefresh";
            this.btnItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemRefresh_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(764, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 485);
            this.barDockControlBottom.Size = new System.Drawing.Size(764, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 454);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(764, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 454);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "refresh_16x16.png");
            // 
            // tlDepart
            // 
            this.tlDepart.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcDeptName,
            this.tlcCompanyName,
            this.tlcDeptTypeName,
            this.tlcCreateTime});
            this.tlDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDepart.KeyFieldName = "DeptId";
            this.tlDepart.Location = new System.Drawing.Point(0, 31);
            this.tlDepart.Name = "tlDepart";
            this.tlDepart.OptionsBehavior.Editable = false;
            this.tlDepart.OptionsPrint.UsePrintStyles = true;
            this.tlDepart.ParentFieldName = "ParentId";
            this.tlDepart.Size = new System.Drawing.Size(764, 454);
            this.tlDepart.TabIndex = 4;
            // 
            // tlcDeptName
            // 
            this.tlcDeptName.Caption = "部门";
            this.tlcDeptName.FieldName = "DeptName";
            this.tlcDeptName.Name = "tlcDeptName";
            this.tlcDeptName.Visible = true;
            this.tlcDeptName.VisibleIndex = 0;
            // 
            // tlcCompanyName
            // 
            this.tlcCompanyName.Caption = "所属公司";
            this.tlcCompanyName.FieldName = "CompanyName";
            this.tlcCompanyName.Name = "tlcCompanyName";
            this.tlcCompanyName.Visible = true;
            this.tlcCompanyName.VisibleIndex = 1;
            // 
            // tlcDeptTypeName
            // 
            this.tlcDeptTypeName.Caption = "部门类型";
            this.tlcDeptTypeName.FieldName = "DeptTypeName";
            this.tlcDeptTypeName.Name = "tlcDeptTypeName";
            this.tlcDeptTypeName.Visible = true;
            this.tlcDeptTypeName.VisibleIndex = 2;
            // 
            // tlcCreateTime
            // 
            this.tlcCreateTime.Caption = "创建时间";
            this.tlcCreateTime.FieldName = "CreateTime";
            this.tlcCreateTime.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.tlcCreateTime.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tlcCreateTime.Name = "tlcCreateTime";
            this.tlcCreateTime.Visible = true;
            this.tlcCreateTime.VisibleIndex = 3;
            // 
            // tlcParentId
            // 
            this.tlcParentId.Caption = "上级部门";
            this.tlcParentId.FieldName = "ParentId";
            this.tlcParentId.Name = "tlcParentId";
            this.tlcParentId.Visible = true;
            this.tlcParentId.VisibleIndex = 2;
            // 
            // FrmDepartmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 485);
            this.Controls.Add(this.tlDepart);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmDepartmentList";
            this.Text = "部门";
            this.Load += new System.EventHandler(this.FrmDepartmentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlDepart)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemRefresh;
        private DevExpress.XtraTreeList.TreeList tlDepart;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcDeptName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCompanyName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcDeptTypeName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCreateTime;
    }
}