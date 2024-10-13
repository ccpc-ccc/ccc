namespace YF.MWS.Win.View.Order
{
    partial class FrmCarPlanEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarPlanEdit));
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
            this.wCarLookup = new YF.MWS.Win.Uc.Weight.WCarLookup();
            this.weMaterial = new YF.MWS.Win.Uc.Weight.WMaterialEdit();
            this.tePlanCarCount = new DevExpress.XtraEditors.TextEdit();
            this.wCustomer = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.weWarehBizType = new YF.MWS.Win.Uc.Weight.WComboBoxEnumEdit();
            this.weLimitType = new YF.MWS.Win.Uc.Weight.WComboBoxEnumEdit();
            this.tePlanWeight = new DevExpress.XtraEditors.TextEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.teRemark = new DevExpress.XtraEditors.TextEdit();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.rgPlanType = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblPlanWeight = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblPlanType = new DevExpress.XtraEditors.LabelControl();
            this.teEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.teStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.lblPlanCarCount = new DevExpress.XtraEditors.LabelControl();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCarLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePlanCarCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weWarehBizType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weLimitType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePlanWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgPlanType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTime.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(416, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 477);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(416, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 446);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(416, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 446);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // wCarLookup
            // 
            this.wCarLookup.ActionName = null;
            this.wCarLookup.AutoCalcNo = 0;
            this.wCarLookup.Caption = null;
            this.wCarLookup.ControlName = null;
            this.wCarLookup.CurrentValue = "";
            this.wCarLookup.DecimalDigits = 0;
            this.wCarLookup.EditText = "";
            this.wCarLookup.EditValue = "";
            this.wCarLookup.ErrorTipText = null;
            this.wCarLookup.Expression = null;
            this.wCarLookup.FieldName = null;
            this.dxErrorProvider.SetIconAlignment(this.wCarLookup, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.wCarLookup.IsRequired = false;
            this.wCarLookup.Location = new System.Drawing.Point(117, 207);
            this.wCarLookup.Name = "wCarLookup";
            this.wCarLookup.ParentLocation = new System.Drawing.Point(0, 0);
            this.wCarLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.wCarLookup.Size = new System.Drawing.Size(213, 20);
            this.wCarLookup.StartAutoSave = false;
            this.wCarLookup.StartStay = false;
            this.wCarLookup.TabIndex = 1;
            this.wCarLookup.WeightVauleChanged = null;
            // 
            // weMaterial
            // 
            this.weMaterial.ActionName = null;
            this.weMaterial.AutoCalcNo = 0;
            this.weMaterial.Caption = null;
            this.weMaterial.ControlName = null;
            this.weMaterial.CurrentValue = "";
            this.weMaterial.DecimalDigits = 0;
            this.weMaterial.EditText = "";
            this.weMaterial.EditValue = "";
            this.weMaterial.ErrorTipText = null;
            this.weMaterial.Expression = null;
            this.weMaterial.FieldName = null;
            this.dxErrorProvider.SetIconAlignment(this.weMaterial, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weMaterial.IsRequired = false;
            this.weMaterial.Location = new System.Drawing.Point(117, 175);
            this.weMaterial.MenuManager = this.barManager;
            this.weMaterial.Name = "weMaterial";
            this.weMaterial.ParentLocation = new System.Drawing.Point(0, 0);
            this.weMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.weMaterial.Size = new System.Drawing.Size(213, 20);
            this.weMaterial.StartAutoSave = false;
            this.weMaterial.StartStay = false;
            this.weMaterial.TabIndex = 98;
            this.weMaterial.WeightVauleChanged = null;
            // 
            // tePlanCarCount
            // 
            this.tePlanCarCount.EditValue = 0;
            this.dxErrorProvider.SetIconAlignment(this.tePlanCarCount, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.tePlanCarCount.Location = new System.Drawing.Point(117, 244);
            this.tePlanCarCount.MenuManager = this.barManager;
            this.tePlanCarCount.Name = "tePlanCarCount";
            this.tePlanCarCount.Properties.Mask.EditMask = "n0";
            this.tePlanCarCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tePlanCarCount.Properties.MaxLength = 8;
            this.tePlanCarCount.Size = new System.Drawing.Size(213, 20);
            this.tePlanCarCount.TabIndex = 82;
            // 
            // wCustomer
            // 
            this.wCustomer.ActionName = null;
            this.wCustomer.AutoCalcNo = 0;
            this.wCustomer.Caption = null;
            this.wCustomer.ControlName = null;
            this.wCustomer.CurrentValue = "";
            this.wCustomer.DecimalDigits = 0;
            this.wCustomer.EditText = "";
            this.wCustomer.EditValue = "";
            this.wCustomer.ErrorTipText = null;
            this.wCustomer.Expression = null;
            this.wCustomer.FieldName = null;
            this.dxErrorProvider.SetIconAlignment(this.wCustomer, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.wCustomer.IsRequired = false;
            this.wCustomer.Location = new System.Drawing.Point(117, 139);
            this.wCustomer.Name = "wCustomer";
            this.wCustomer.ParentLocation = new System.Drawing.Point(0, 0);
            this.wCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.wCustomer.Size = new System.Drawing.Size(213, 20);
            this.wCustomer.StartAutoSave = false;
            this.wCustomer.StartStay = false;
            this.wCustomer.TabIndex = 0;
            this.wCustomer.Type = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.wCustomer.WeightVauleChanged = null;
            // 
            // weWarehBizType
            // 
            this.weWarehBizType.ActionName = null;
            this.weWarehBizType.AutoCalcNo = 0;
            this.weWarehBizType.Caption = null;
            this.weWarehBizType.ControlName = null;
            this.weWarehBizType.CurrentValue = -1;
            this.weWarehBizType.DecimalDigits = 0;
            this.weWarehBizType.EditText = "";
            this.weWarehBizType.EditValue = "";
            this.weWarehBizType.ErrorTipText = null;
            this.weWarehBizType.Expression = null;
            this.weWarehBizType.FieldName = "WarehBizType";
            this.dxErrorProvider.SetIconAlignment(this.weWarehBizType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weWarehBizType.IsRequired = false;
            this.weWarehBizType.Location = new System.Drawing.Point(117, 68);
            this.weWarehBizType.MenuManager = this.barManager;
            this.weWarehBizType.Name = "weWarehBizType";
            this.weWarehBizType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weWarehBizType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weWarehBizType.Size = new System.Drawing.Size(213, 20);
            this.weWarehBizType.StartAutoSave = false;
            this.weWarehBizType.StartStay = false;
            this.weWarehBizType.TabIndex = 103;
            this.weWarehBizType.WeightVauleChanged = null;
            // 
            // weLimitType
            // 
            this.weLimitType.ActionName = null;
            this.weLimitType.AutoCalcNo = 0;
            this.weLimitType.Caption = null;
            this.weLimitType.ControlName = null;
            this.weLimitType.CurrentValue = -1;
            this.weLimitType.DecimalDigits = 0;
            this.weLimitType.EditText = "";
            this.weLimitType.EditValue = "";
            this.weLimitType.ErrorTipText = null;
            this.weLimitType.Expression = null;
            this.weLimitType.FieldName = "PlanLimitType";
            this.dxErrorProvider.SetIconAlignment(this.weLimitType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weLimitType.IsRequired = false;
            this.weLimitType.Location = new System.Drawing.Point(117, 105);
            this.weLimitType.MenuManager = this.barManager;
            this.weLimitType.Name = "weLimitType";
            this.weLimitType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weLimitType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weLimitType.Size = new System.Drawing.Size(213, 20);
            this.weLimitType.StartAutoSave = false;
            this.weLimitType.StartStay = false;
            this.weLimitType.TabIndex = 104;
            this.weLimitType.WeightVauleChanged = null;
            // 
            // tePlanWeight
            // 
            this.tePlanWeight.EditValue = 0;
            this.dxErrorProvider.SetIconAlignment(this.tePlanWeight, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.tePlanWeight.Location = new System.Drawing.Point(117, 283);
            this.tePlanWeight.Name = "tePlanWeight";
            this.tePlanWeight.Properties.Mask.EditMask = "n";
            this.tePlanWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tePlanWeight.Properties.MaxLength = 8;
            this.tePlanWeight.Size = new System.Drawing.Size(213, 20);
            this.tePlanWeight.TabIndex = 82;
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.weLimitType);
            this.plDetail.Controls.Add(this.weWarehBizType);
            this.plDetail.Controls.Add(this.teRemark);
            this.plDetail.Controls.Add(this.lblRemark);
            this.plDetail.Controls.Add(this.rgPlanType);
            this.plDetail.Controls.Add(this.weMaterial);
            this.plDetail.Controls.Add(this.labelControl6);
            this.plDetail.Controls.Add(this.lblPlanWeight);
            this.plDetail.Controls.Add(this.labelControl8);
            this.plDetail.Controls.Add(this.labelControl9);
            this.plDetail.Controls.Add(this.lblPlanType);
            this.plDetail.Controls.Add(this.teEndTime);
            this.plDetail.Controls.Add(this.teStartTime);
            this.plDetail.Controls.Add(this.tePlanWeight);
            this.plDetail.Controls.Add(this.tePlanCarCount);
            this.plDetail.Controls.Add(this.wCustomer);
            this.plDetail.Controls.Add(this.lblCustomer);
            this.plDetail.Controls.Add(this.wCarLookup);
            this.plDetail.Controls.Add(this.lblEndTime);
            this.plDetail.Controls.Add(this.lblStartTime);
            this.plDetail.Controls.Add(this.lblPlanCarCount);
            this.plDetail.Controls.Add(this.lblCarNo);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 31);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(416, 446);
            this.plDetail.TabIndex = 7;
            // 
            // teRemark
            // 
            this.teRemark.EditValue = "";
            this.teRemark.Location = new System.Drawing.Point(117, 398);
            this.teRemark.MenuManager = this.barManager;
            this.teRemark.Name = "teRemark";
            this.teRemark.Properties.MaxLength = 8;
            this.teRemark.Size = new System.Drawing.Size(213, 20);
            this.teRemark.TabIndex = 102;
            this.teRemark.Tag = "Remark";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(31, 399);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(28, 14);
            this.lblRemark.TabIndex = 101;
            this.lblRemark.Text = "备注:";
            // 
            // rgPlanType
            // 
            this.rgPlanType.EditValue = 1;
            this.rgPlanType.Location = new System.Drawing.Point(117, 27);
            this.rgPlanType.MenuManager = this.barManager;
            this.rgPlanType.Name = "rgPlanType";
            this.rgPlanType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgPlanType.Properties.Appearance.Options.UseBackColor = true;
            this.rgPlanType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "派车计划"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "客户计划")});
            this.rgPlanType.Size = new System.Drawing.Size(213, 24);
            this.rgPlanType.TabIndex = 100;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 177);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(28, 14);
            this.labelControl6.TabIndex = 96;
            this.labelControl6.Text = "物资:";
            // 
            // lblPlanWeight
            // 
            this.lblPlanWeight.Location = new System.Drawing.Point(30, 284);
            this.lblPlanWeight.Name = "lblPlanWeight";
            this.lblPlanWeight.Size = new System.Drawing.Size(52, 14);
            this.lblPlanWeight.TabIndex = 91;
            this.lblPlanWeight.Text = "计划吨位:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(30, 104);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 14);
            this.labelControl8.TabIndex = 92;
            this.labelControl8.Text = "限制类型:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(31, 67);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 14);
            this.labelControl9.TabIndex = 93;
            this.labelControl9.Text = "业务类型:";
            // 
            // lblPlanType
            // 
            this.lblPlanType.Location = new System.Drawing.Point(31, 29);
            this.lblPlanType.Name = "lblPlanType";
            this.lblPlanType.Size = new System.Drawing.Size(28, 14);
            this.lblPlanType.TabIndex = 94;
            this.lblPlanType.Text = "类型:";
            // 
            // teEndTime
            // 
            this.teEndTime.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndTime.Location = new System.Drawing.Point(117, 358);
            this.teEndTime.Name = "teEndTime";
            this.teEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teEndTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teEndTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.teEndTime.Size = new System.Drawing.Size(213, 20);
            this.teEndTime.TabIndex = 90;
            // 
            // teStartTime
            // 
            this.teStartTime.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartTime.Location = new System.Drawing.Point(117, 320);
            this.teStartTime.Name = "teStartTime";
            this.teStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teStartTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teStartTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.teStartTime.Size = new System.Drawing.Size(213, 20);
            this.teStartTime.TabIndex = 90;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(31, 141);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(52, 14);
            this.lblCustomer.TabIndex = 81;
            this.lblCustomer.Text = "客户单位:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(31, 358);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 14);
            this.lblEndTime.TabIndex = 79;
            this.lblEndTime.Text = "截止时间:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(31, 321);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(52, 14);
            this.lblStartTime.TabIndex = 79;
            this.lblStartTime.Text = "开始时间:";
            // 
            // lblPlanCarCount
            // 
            this.lblPlanCarCount.Location = new System.Drawing.Point(31, 245);
            this.lblPlanCarCount.Name = "lblPlanCarCount";
            this.lblPlanCarCount.Size = new System.Drawing.Size(52, 14);
            this.lblPlanCarCount.TabIndex = 79;
            this.lblPlanCarCount.Text = "计划车数:";
            // 
            // lblCarNo
            // 
            this.lblCarNo.Location = new System.Drawing.Point(31, 208);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(40, 14);
            this.lblCarNo.TabIndex = 79;
            this.lblCarNo.Text = "车牌号:";
            // 
            // FrmCarPlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 477);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(432, 299);
            this.Name = "FrmCarPlanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计划单编辑";
            this.Load += new System.EventHandler(this.FrmCarEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCarLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePlanCarCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weWarehBizType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weLimitType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePlanWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgPlanType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartTime.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl plDetail;
        private Uc.Weight.WCustomerEdit wCustomer;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private Uc.Weight.WCarLookup wCarLookup;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private DevExpress.XtraEditors.LabelControl lblEndTime;
        private DevExpress.XtraEditors.LabelControl lblStartTime;
        private DevExpress.XtraEditors.LabelControl lblPlanCarCount;
        private DevExpress.XtraEditors.TextEdit tePlanCarCount;
        private DevExpress.XtraEditors.TimeEdit teStartTime;
        private DevExpress.XtraEditors.TimeEdit teEndTime;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblPlanWeight;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lblPlanType;
        private DevExpress.XtraEditors.TextEdit tePlanWeight;
        private Uc.Weight.WMaterialEdit weMaterial;
        private DevExpress.XtraEditors.RadioGroup rgPlanType;
        private DevExpress.XtraEditors.TextEdit teRemark;
        private DevExpress.XtraEditors.LabelControl lblRemark;
        private Uc.Weight.WComboBoxEnumEdit weLimitType;
        private Uc.Weight.WComboBoxEnumEdit weWarehBizType;
    }
}