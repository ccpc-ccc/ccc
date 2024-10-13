namespace YF.MWS.Win.View.Master
{
    partial class FrmViewEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewEdit));
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
            this.teColumnsCount = new DevExpress.XtraEditors.TextEdit();
            this.lookupSubject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.teViewName = new DevExpress.XtraEditors.TextEdit();
            this.comboViewType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblViewType = new DevExpress.XtraEditors.LabelControl();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblViewName = new DevExpress.XtraEditors.LabelControl();
            this.lblItemCode = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColumnsCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teViewName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboViewType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(467, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 237);
            this.barDockControlBottom.Size = new System.Drawing.Size(467, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 206);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(467, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 206);
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
            // teColumnsCount
            // 
            this.dxErrorProvider.SetIconAlignment(this.teColumnsCount, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teColumnsCount.Location = new System.Drawing.Point(121, 144);
            this.teColumnsCount.MenuManager = this.barManager;
            this.teColumnsCount.Name = "teColumnsCount";
            this.teColumnsCount.Properties.Mask.EditMask = "N0";
            this.teColumnsCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teColumnsCount.Size = new System.Drawing.Size(106, 20);
            this.teColumnsCount.TabIndex = 36;
            this.teColumnsCount.Tag = "ColumnsCount";
            // 
            // lookupSubject
            // 
            this.lookupSubject.EditValue = "";
            this.dxErrorProvider.SetIconAlignment(this.lookupSubject, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.lookupSubject.Location = new System.Drawing.Point(121, 69);
            this.lookupSubject.MenuManager = this.barManager;
            this.lookupSubject.Name = "lookupSubject";
            this.lookupSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupSubject.Properties.NullText = "";
            this.lookupSubject.Properties.View = this.gridView1;
            this.lookupSubject.Size = new System.Drawing.Size(291, 20);
            this.lookupSubject.TabIndex = 56;
            this.lookupSubject.Tag = "ControlId";
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // teViewName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teViewName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teViewName.Location = new System.Drawing.Point(121, 109);
            this.teViewName.MenuManager = this.barManager;
            this.teViewName.Name = "teViewName";
            this.teViewName.Size = new System.Drawing.Size(291, 20);
            this.teViewName.TabIndex = 41;
            this.teViewName.Tag = "ViewName";
            // 
            // comboViewType
            // 
            this.dxErrorProvider.SetIconAlignment(this.comboViewType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.comboViewType.Location = new System.Drawing.Point(121, 27);
            this.comboViewType.MenuManager = this.barManager;
            this.comboViewType.Name = "comboViewType";
            this.comboViewType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboViewType.Size = new System.Drawing.Size(106, 20);
            this.comboViewType.TabIndex = 58;
            this.comboViewType.Tag = "ViewType";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboViewType);
            this.panelControl1.Controls.Add(this.lblViewType);
            this.panelControl1.Controls.Add(this.lookupSubject);
            this.panelControl1.Controls.Add(this.lblSubject);
            this.panelControl1.Controls.Add(this.teViewName);
            this.panelControl1.Controls.Add(this.lblViewName);
            this.panelControl1.Controls.Add(this.teColumnsCount);
            this.panelControl1.Controls.Add(this.lblItemCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(467, 206);
            this.panelControl1.TabIndex = 6;
            // 
            // lblViewType
            // 
            this.lblViewType.Location = new System.Drawing.Point(24, 30);
            this.lblViewType.Name = "lblViewType";
            this.lblViewType.Size = new System.Drawing.Size(52, 14);
            this.lblViewType.TabIndex = 57;
            this.lblViewType.Text = "界面类型:";
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(24, 70);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(52, 14);
            this.lblSubject.TabIndex = 55;
            this.lblSubject.Text = "界面主题:";
            // 
            // lblViewName
            // 
            this.lblViewName.Location = new System.Drawing.Point(24, 112);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(52, 14);
            this.lblViewName.TabIndex = 40;
            this.lblViewName.Text = "界面名称:";
            // 
            // lblItemCode
            // 
            this.lblItemCode.Location = new System.Drawing.Point(24, 147);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(52, 14);
            this.lblItemCode.TabIndex = 38;
            this.lblItemCode.Text = "显示列数:";
            // 
            // FrmViewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 237);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmViewEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "界面编辑";
            this.Load += new System.EventHandler(this.FrmViewEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teColumnsCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teViewName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboViewType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit teViewName;
        private DevExpress.XtraEditors.LabelControl lblViewName;
        private DevExpress.XtraEditors.TextEdit teColumnsCount;
        private DevExpress.XtraEditors.LabelControl lblItemCode;
        private DevExpress.XtraEditors.SearchLookUpEdit lookupSubject;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lblSubject;
        private DevExpress.XtraEditors.ComboBoxEdit comboViewType;
        private DevExpress.XtraEditors.LabelControl lblViewType;
    }
}