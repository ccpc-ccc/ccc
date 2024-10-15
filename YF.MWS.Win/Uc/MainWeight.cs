using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using YF.MWS.Win.Uc.Weight;
using System.Reflection;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using DevExpress.XtraEditors.DXErrorProvider;
using YF.Utility;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Core;
using YF.MWS.Metadata.Event;
using YF.Utility.Log;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.View.Weight;
using YF.MWS.Util.Dynamic;
using YF.MWS.Db.Server;

namespace YF.MWS.Win.Uc
{
    public partial class MainWeight : UserControl
    {
        private Dictionary<string, IField> fields = new Dictionary<string, IField>();
        private Dictionary<string, IField> cardFields = new Dictionary<string, IField>();
        private Dictionary<string, IField> extendFields = new Dictionary<string, IField>();
        private List<IField> lstField = new List<IField>();
        private List<CalculateField> lstCalculateField = new List<CalculateField>();
        private List<Control> lstValidateControl = new List<Control>();
        private IWeightViewService viewService = new WeightViewService();
        private IWarehService warehService = new WarehService();
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private SWeightView view = null;
        private List<SModule> lstModule = new List<SModule>();
        private FontCfg fontCfg=new FontCfg();
        public string CurrentSubjectId;
        public string CurrentViewId;
        private List<SAttribute> lstAttribute = new List<SAttribute>();

        public List<SAttribute> LstAttribute
        {
            get { return lstAttribute; }
            set { lstAttribute = value; }
        }
        /// <summary>
        /// 软件称重计量单位
        /// </summary>
        public string SoftOneUnit;
        /// <summary>
        /// 系统配置
        /// </summary>
        public SysCfg Cfg { get; set; }

        private OrderSource boundSource = OrderSource.Additional;
        private ViewType currentViewType= ViewType.Weight;

        public ViewType CurrentViewType
        {
            get { return currentViewType; }
            set { currentViewType = value; }
        }
        /// <summary>
        /// 磅单来源
        /// </summary>
        public OrderSource BoundSource
        {
            get { return boundSource; }
            set { boundSource = value; }
        }

        public MainWeight()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode)
            {
                view = viewService.GetDefaultView(currentViewType);
                InitControl();
                SetEvent();
                Cfg = CfgUtil.GetCfg();
                SetFontStyle();
            }
            InitData();
            base.OnLoad(e);
        }

        public void SetRole(List<SModule> lstModule)
        {
            this.lstModule = lstModule;
            IField field = null;
            Control c = null;
            foreach (string key in fields.Keys)
            {
                field = fields[key];
                c = field as Control;
                if (c!=null && c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()))
                {
                    bool enabled = RoleUtil.IsEnabled(c, lstModule);
                    field.SetEnabled(enabled);
                }
            }
        }

        public void SetFontStyle() 
        {
            layGroup.AppearanceItemCaption.Font = CfgUtil.GetFont();
            layGroup.AppearanceGroup.Font = CfgUtil.GetFont();
            layControl.Font = CfgUtil.GetFont();
        }

        public void AutoCalcuate()
        {
            /*lstCalculateField = lstCalculateField.OrderBy(c => c.AutoCalcNo).ToList();
            foreach (IField f in lstCalculateField)
            {
                f.CurrentValue = CalculateUtil.Calculate(f.Expression, lstField);
            }*/
        }

        public void LoadView(string viewId)
        {
            //fields.Clear();
            //extendFields.Clear();
            InitValidateControl();
            lstCalculateField.Clear();
            lstField.Clear();
            view = viewService.GetView(viewId); 
            InitControl();
            SetEvent();
            InitData();
        }
        /// <summary>
        /// 获取相关控件
        /// </summary>
        private void InitControl()
        {
            layControl.BeginUpdate();
            //Font f = new System.Drawing.Font(DefaultFont, FontStyle.Bold); 
            //layGroup.AppearanceItemCaption.Font = f;
            if (view == null)
            {
                return;
            }
            if (view != null)
            {
                CurrentSubjectId = view.SubjectId;
                CurrentViewId = view.Id;
            }
            layGroup.Clear();
            List<SWeightViewDtl> lstDtl = viewService.GetDetailList(view.Id);
            List<LayoutControlItem> lstItem = new List<LayoutControlItem>();
            LayoutControlItem item = null;
            SWeightViewDtl detail = null;
            IField field = null;
            ControlType ctlType;
            CalculateField calField = null;
            int columnsCount = view.ColumnsCount;
            if (columnsCount <= 0)
            {
                columnsCount = 3;
            }
            int width = layGroup.Width;
            int rows = lstDtl.Count / columnsCount;
            int remainder = lstDtl.Count % columnsCount;
            int height = 24;
            bool isReadonly=false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    detail = lstDtl[i * columnsCount + j];
                    ctlType = detail.ControlType.ToEnum<ControlType>();
                    field = GetControl(detail.FullName);
                    if (field != null)
                    {
                        item = new LayoutControlItem();
                        item.Location = new Point(j * width / columnsCount, i * height);
                        item.Size = new Size(width / columnsCount, height);
                        item.Control = field as Control;
                        if (!string.IsNullOrEmpty(detail.ActionName))
                        {
                            item.Control.Tag = detail.ActionName;
                        }
                        item.Text = detail.Caption;
                        lstItem.Add(item);
                        
                        field.ParentLocation = new Point(j * width / columnsCount, i * height);
                        field.FieldName = detail.FieldName;
                        field.AutoCalcNo = detail.AutoCalcNo;
                        field.ControlName = detail.ControlName;
                        field.t1=detail.t1;
                        field.Expression = detail.Expression;
                        field.ActionName = detail.ActionName;
                        field.StartAutoSave = detail.AutoSaveState == BoolValueType.True ? true : false;
                        field.StartStay = detail.StayState == BoolValueType.True ? true : false;
                        isReadonly = detail.Readonly == 1 ? true : false;
                        field.DecimalDigits = detail.DecimalDigits;
                        if (isReadonly) 
                        {
                            field.SetReadonly();
                        }
                        field.WeightVauleChanged += WeightVauleChanged;
                        field.InitData();
                        lstField.Add(field);
                        if (!string.IsNullOrEmpty(field.Expression))
                        {
                            calField = CalculateUtil.GetCalculateField(field.ControlName, field.Expression, field.AutoCalcNo);
                            if (calField != null)
                            {
                                lstCalculateField.Add(calField);
                            }
                        }
                        if (ctlType == ControlType.Extend)
                        { 
                            extendFields[detail.ControlId] = field;
                        }
                        if (ctlType == ControlType.Standard)
                        {
                            cardFields[detail.ControlId] = field;
                            fields[detail.FieldName] = field;
                        }
                        field.IsRequired = detail.IsRequired==1?true:false;
                        field.ErrorTipText = detail.ErrorText;
                        if (detail.IsRequired == 1)
                        {
                            SetValidationRule(field, detail.ErrorText);
                        }
                    }
                }
            }
            for (int k = 0; k < remainder; k++)
            {
                detail = lstDtl[rows * columnsCount + k];
                ctlType = detail.ControlType.ToEnum<ControlType>();
                field = GetControl(detail.FullName);
                if (field != null)
                {
                    item = new LayoutControlItem();
                    item.Location = new Point(k * width / columnsCount, rows * height);
                    item.Size = new Size(width / columnsCount, height);
                    item.Control = field as Control;
                    item.Text = detail.Caption;
                    
                    lstItem.Add(item);
                    field.ParentLocation = item.Location;
                    field.FieldName = detail.FieldName;
                    field.AutoCalcNo = detail.AutoCalcNo;
                    field.ControlName = detail.ControlName;
                    field.Expression = detail.Expression;
                    field.ActionName = detail.ActionName;
                    field.t1 = detail.t1;
                    field.DecimalDigits=detail.DecimalDigits;
                    field.IsRequired = detail.IsRequired == 1 ? true : false;
                    field.StartAutoSave = detail.AutoSaveState == BoolValueType.True ? true : false;
                    field.StartStay = detail.StayState == BoolValueType.True ? true : false;
                    field.ErrorTipText = detail.ErrorText;
                    isReadonly = detail.Readonly == 1 ? true : false;
                    if (isReadonly) 
                    {
                        field.SetReadonly();
                    }
                    //field.WeightVauleChanged += WeightVauleChanged;
                    field.InitData();
                    //lstField.Add(field);
                    if (!string.IsNullOrEmpty(field.Expression))
                    {
                        calField = CalculateUtil.GetCalculateField(field.ControlName, field.Expression, field.AutoCalcNo);
                        if (calField != null)
                        {
                            lstCalculateField.Add(calField);
                        }
                    }
                    if (ctlType == ControlType.Extend)
                    {
                        extendFields[detail.ControlId] = field;
                    }
                    if (ctlType == ControlType.Standard)
                    {
                        cardFields[detail.ControlId] = field;
                        fields[detail.FieldName] = field;
                    }
                    if (detail.IsRequired == 1)
                    {
                        SetValidationRule(field, detail.ErrorText);
                    }
                    field.WeightVauleChanged += WeightVauleChanged;
                    lstField.Add(field);
                    if (ctlType == ControlType.Extend)
                    {
                        extendFields[detail.ControlId] = field;
                    }
                    if (ctlType == ControlType.Standard)
                    {
                        fields[detail.FieldName] = field;
                    }
                }
            }
            layGroup.Items.AddRange(lstItem.ToArray());
            layControl.EndUpdate();
        }

        private void InitData()
        {
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "CustomerName", Caption = "名称" });
            var lookupSupplier = this.FindControl<WCustomerEdit>("SupplierId");
            var lookupDelivery = this.FindControl<WCustomerEdit>("DeliveryId");
            var lookupManufacturer = this.FindControl<WCustomerEdit>("ManufacturerId");
            var lookupReceiver = this.FindControl<WCustomerEdit>("ReceiverId");
            var lookupTransfer = this.FindControl<WCustomerEdit>("TransferId");
            var lookupCustomer = FindControl<WCustomerEdit>("CustomerId");
            var lookupMaterial = FindControl<WMaterialEdit>("MaterialId");
            var combMeasureType = FindControl<ComboBoxEdit>("MeasureType");
            var combImpurityMeaType = FindControl<ComboBoxEdit>("ImpurityMeaType");
            var combChargeType = FindControl<ComboBoxEdit>("ChargeType");
            var weTareWeight = FindControl<WNumbericEdit>("TareWeight");
            if (lookupTransfer != null) 
            {
                lookupTransfer.Type = CustomerType.Transfer;
                lookupTransfer.InitData();
            }
            if (lookupDelivery != null)
            {
                lookupDelivery.Type = CustomerType.Delivery;
                lookupDelivery.InitData();
            }
            if (lookupReceiver != null)
            {
                lookupReceiver.Type = CustomerType.Receiver;
                lookupReceiver.InitData();
            }
            if (lookupManufacturer != null)
            {
                lookupManufacturer.Type = CustomerType.Manufacturer;
                lookupManufacturer.InitData();
            }
            if (lookupSupplier != null)
            {
                lookupSupplier.Type = CustomerType.Supplier;
                lookupSupplier.InitData();
            }
            if (lookupCustomer != null)
            {
                lookupCustomer.Type = CustomerType.Customer;
                lookupCustomer.InitData();
            }
            if (combMeasureType != null)
            {
                DxHelper.BindComboBoxEdit(combMeasureType, SysCode.MeasureType, null);
            }
            if (combImpurityMeaType != null)
            {
                DxHelper.BindComboBoxEdit(combImpurityMeaType, SysCode.ImpurityMeaType, null);
            }
            if (combChargeType != null)
            {
                DxHelper.BindComboBoxEdit(combChargeType, SysCode.ChargeType, null);
            }
            if (lookupMaterial != null)
            {
                lstField.Clear();
                //lstField.Add(new LookupField() { FieldName = "MaterialName", Caption = "物资" });
                //List<SMaterial> lstMaterial = masterService.GetMaterialList();
                //SearchLookupUtil.BindData(lookupMaterial, lstMaterial, "MaterialId", "MaterialName", lstField);
            }
        }


        private void SetEvent()
        {
            foreach (IField f in lstField)
            {
                if (CalculateUtil.CanCalculatedEvent(lstCalculateField, f.ControlName))
                {
                    f.WeightVauleChanged += WeightVauleChanged;
                }
            }
        }

        private void WeightVauleChanged(object sender, WeightVauleChangedEventArgs args)
        {
            List<CalculateField> lst = CalculateUtil.GetCalculateList(lstCalculateField, args.ControlName);
            lst = lst.OrderBy(c => c.AutoCalNo).ToList();
            IField field = null;
            foreach (CalculateField f in lst)
            {
                field = lstField.Find(c => c.ControlName == f.ControlName);
                if (field != null)
                {
                    decimal val = CalculateUtil.Calculate(f.Expression, lstField);
                    field.CurrentValue = val.ToString(string.Format("N{0}", field.DecimalDigits));
                    //2022.04.11注释掉
                    //CalculateRelatedControl(field);
                }
            }
        }

        public T FindControl<T>(string fieldName) where T : class
        {
            if (fields.ContainsKey(fieldName))
            {
                IField field = fields[fieldName];
                return field as T;
            }
            else
            {
                return null;
            }
        } 

        public T FindExtendControl<T>(string fieldName, List<SAttribute> lstAttr) where T : class
        {
            SAttribute attr = lstAttr.Find(a => a.FieldName == fieldName);
            if (attr != null)
            {
                foreach (string key in extendFields.Keys)
                {
                    if (key == attr.Id)
                    {
                        return extendFields[key] as T;
                    }
                }
            }
            return null;
        }

        public T FindExtendControl<T>(string fieldName, List<BWeightAttribute> lstAttr) where T : class
        {
            BWeightAttribute attr;
            attr = lstAttr.Find(a => a.FieldName == fieldName);
            if (attr != null)
            {
                foreach (string key in extendFields.Keys)
                {
                    if (key == attr.AttributeId)
                    {
                        return extendFields[key] as T;
                    }
                }
            }
            return null;
        }

        private IField GetControl(string fullName)
        {
            IField field = null;
            Type type = Type.GetType(fullName);
            if (type == null)
                return field;
            field = (IField)type.Assembly.CreateInstance(fullName);
            return field;
        }

        private void MainWeight_Load(object sender, System.EventArgs e)
        {

        }

        private void InitValidateControl()
        {
            if (dxValidator != null)
            {
                dxValidator.Dispose();
            }
            dxValidator = new DXValidationProvider();
            //dxValidator.ValidationMode = ValidationMode.Auto;
            foreach (Control ctrl in lstValidateControl)
            {
               // dxValidator.RemoveControlError(ctrl);
            }
            //lstValidateControl.Clear();
        }

        private void SetValidationRule(IField field, string errorText)
        {
            var ctrl = field as BaseControl;
            //lstValidateControl.Add(ctrl);
            var rule = new ConditionValidationRule();
            rule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            rule.ErrorText = errorText;
            dxValidator.SetValidationRule(ctrl, rule);
            dxValidator.SetIconAlignment(ctrl, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        public void Clear(bool completelyClear = false)
        {
            try
            {
                BeginInvoke(new Action(() => 
                {
                    IField field = null;
                    foreach (string key in fields.Keys)
                    {
                        field = fields[key];
                        if (field != null)
                        {
                            if((!completelyClear && !field.StartStay)|| completelyClear) {
                                field.Clear();
                            }
                            /*if (completelyClear)
                                field.Clear();*/
                        }
                    }
                    foreach (string key in extendFields.Keys)
                    {
                        field = extendFields[key];
                        if (field != null) {
                            if ((!completelyClear && !field.StartStay) || completelyClear) {
                                field.Clear();
                            }
                            /*if (completelyClear)
                                field.Clear();*/
                        }
                    }
                }));
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 保存输入项
        /// </summary>
        public void SaveInputItem() 
        {
            try
            {
                IField field = null;
                foreach (string key in fields.Keys)
                {
                    field = fields[key];
                    if (field != null && field.StartAutoSave)
                    {
                        fields[key].SaveInputItem();
                    }
                }
                foreach (string key in extendFields.Keys)
                {
                    field = extendFields[key];
                    if (field != null && field.StartAutoSave)
                    {
                        fields[key].SaveInputItem();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void BindCardView(BPlanCard card, List<BCardPreset> lstPreset, WCardEdit wCardNo=null) 
        { 
            var lookupDelivery = FindControl<WCustomerEdit>("DeliveryId"); 
            var lookupReceiver = FindControl<WCustomerEdit>("ReceiverId");
            var lookupCustomer = FindControl<WCustomerEdit>("CustomerId");
            var driverName = FindControl<WTextEdit>("DriverName");
            var lookupMaterial = FindControl<WMaterialEdit>("MaterialId");
            var lookupCar = FindControl<WCarLookup>("CarId");
            WLookupSearchEdit weWareh = FindControl<WLookupSearchEdit>("WarehId");
            WComboBoxEdit wbWarehBizType = FindControl<WComboBoxEdit>("WarehBizType");
            if (driverName != null)
                driverName.CurrentValue = card.DriverName;
            if (weWareh != null)
                weWareh.CurrentValue = card.WarehId;
            if (wbWarehBizType != null)
                wbWarehBizType.CurrentValue = card.WarehBizType;
            if (lookupCar != null && !string.IsNullOrEmpty(card.CarId))
            {
                lookupCar.CurrentValue = card.CarId;
            }
            if (lookupDelivery != null && !string.IsNullOrEmpty(card.DeliveryId)) 
            {
                lookupDelivery.CurrentValue = card.DeliveryId;
            }
            if (lookupReceiver != null && !string.IsNullOrEmpty(card.ReceiverId))
            {
                lookupReceiver.CurrentValue = card.ReceiverId;
            }
            if (lookupCustomer != null && !string.IsNullOrEmpty(card.CustomerId))
            {
                lookupCustomer.CurrentValue = card.CustomerId;
            }
            if (lookupMaterial != null && !string.IsNullOrEmpty(card.MaterialId))
            {
                lookupMaterial.CurrentValue = card.MaterialId;
            }
            if (lstPreset != null && lstPreset.Count > 0)
            {
                BCardPreset preset;
                foreach (string key in extendFields.Keys)
                {
                    preset = lstPreset.Find(c => c.ControlId == key);
                    if (preset != null && !string.IsNullOrEmpty(preset.PresetValue) && preset.PresetValue.Length > 0)
                    {
                        extendFields[key].CurrentValue = preset.PresetValue;
                    }
                }
                foreach (string key in cardFields.Keys)
                {
                    preset = lstPreset.Find(c => c.ControlId == key);
                    if (preset != null && !string.IsNullOrEmpty(preset.PresetValue) && preset.PresetValue.Length > 0)
                    {
                        cardFields[key].CurrentValue = preset.PresetValue;
                    }
                }
                if (wCardNo != null)
                {
                    //Logger.Write("load-card-no2:" + card.CardNo);
                    //wCardNo.CurrentValue = card.CardNo;
                    //wCardNo.Text = card.CardNo;
                }
            }
        }
        public void BindServerView(ServerEntity card, WCardEdit wCardNo=null) 
        { 
            var lookupDelivery = FindControl<WCustomerEdit>("DeliveryId"); 
            var lookupReceiver = FindControl<WCustomerEdit>("ReceiverId");
            var lookupCustomer = FindControl<WCustomerEdit>("CustomerId");
            var driverName = FindControl<WTextEdit>("DriverName");
            var lookupMaterial = FindControl<WMaterialEdit>("MaterialId");
            var lookupCar = FindControl<WCarLookup>("CarId");
            WLookupSearchEdit weWareh = FindControl<WLookupSearchEdit>("WarehId");
            WComboBoxEdit wbWarehBizType = FindControl<WComboBoxEdit>("WarehBizType");
            if (lookupCar != null && !string.IsNullOrEmpty(card.carNo)) {
                SCar car= carService.GetByCarNo(card.carNo);
                if(car==null){
                    car=new SCar();
                    car.CarNo = card.carNo;
                    car.Id=YF.MWS.Util.Utility.GetGuid();
                    carService.Save(car);
                }
                lookupCar.CurrentValue = car.Id;
            }
            if (lookupDelivery != null && !string.IsNullOrEmpty(card.startDeliver)) {
               SCustomer customer = masterService.GetCustomerByName(CustomerType.Delivery,card.startDeliver);
                if (customer == null) {
                    customer = new SCustomer();
                    customer.CustomerName = card.startDeliver;
                    customer.Id= YF.MWS.Util.Utility.GetGuid();
                    customer.CustomerType = CustomerType.Delivery.ToString();
                    masterService.SaveCustomer(customer);
                }
                lookupDelivery.CurrentValue = customer.Id;
            }
            if (weWareh != null && !string.IsNullOrEmpty(card.endDeliver)) {
                SWareh wareh= warehService.GetByName(card.endDeliver);
                if (wareh == null) {
                    wareh = new SWareh();
                    wareh.WarehName = card.startDeliver;
                    wareh.Id = YF.MWS.Util.Utility.GetGuid();
                    warehService.Save(wareh);
                }
                weWareh.CurrentValue = wareh.Id;
            }
        }

        public void BindControl<T>(T t)
        {
            Type type = typeof(T);
            List<PropertyInfo> lstProperty = type.GetProperties().ToList();
            IField field = null;
            object obj = null;
            foreach (string key in fields.Keys)
            {
                if (key == "CustomerBalance") //客户余额需要另外设置,不能在这里设置
                    continue;
                field = fields[key];
                obj = YF.MWS.Util.Utility.GetValue<T>(t, lstProperty, field.FieldName);
                field.CurrentValue = obj;
               /* if (boundSource == OrderSource.Weight && !string.IsNullOrEmpty(field.FieldName)
                    && (field.FieldName == "GrossWeight" || field.FieldName == "TareWeight" || field.FieldName == "SuttleWeight" || field.FieldName == "NetWeight"))
                {
                    field.SetEnabled(false);
                } */
            }
        }

        public void BindControl<T>(T t, bool enabled)
        {
            Type type = typeof(T);
            List<PropertyInfo> lstProperty = type.GetProperties().ToList();
            IField field = null;
            object obj = null;
            foreach (string key in fields.Keys)
            {
                if (key == "CustomerBalance")
                    continue;
                field = fields[key];
                obj = YF.MWS.Util.Utility.GetValue<T>(t, lstProperty, field.FieldName);
                field.CurrentValue = obj;
                field.SetEnabled(enabled);
            }
        }

        public void BindExtendControl(List<BWeightAttribute> lstAttr, List<string> lstExecutedField)
        {
            BWeightAttribute attr;
            foreach (string key in extendFields.Keys)
            {
                attr = lstAttr.Find(c => c.AttributeId == key);
                if (attr != null)
                {
                    if (lstExecutedField!=null && !lstExecutedField.Exists(c => c == attr.FieldName))
                    {
                        extendFields[key].CurrentValue = attr.AttributeValue;
                    }
                }
            }
        }

        public void BindExtendControl(List<BWeightAttribute> lstAttr)
        {
            BWeightAttribute attr;
            foreach (string key in extendFields.Keys)
            {
                attr = lstAttr.Find(c => c.AttributeId == key);
                if (attr != null)
                {
                    extendFields[key].CurrentValue = attr.AttributeValue;
                }
            }
        }

        public void BindExtendControl(List<BWeightAttribute> lstAttr, bool enabled)
        {
            BWeightAttribute attr;
            foreach (string key in extendFields.Keys)
            {
                attr = lstAttr.Find(c => c.AttributeId == key);
                if (attr != null)
                {
                    extendFields[key].CurrentValue = attr.AttributeValue;
                    extendFields[key].SetEnabled(enabled);
                }
            }
        }

        public List<BWeightAttribute> ExtendControlToList(string weightId)
        {
            List<BWeightAttribute> lstAttr = new List<BWeightAttribute>();
            BWeightAttribute attr;
            foreach (string key in extendFields.Keys)
            {
                attr = new BWeightAttribute();
                attr.Id = YF.MWS.Util.Utility.GetGuid();
                attr.WeightId = weightId;
                attr.AttributeId = key;
                attr.AttributeValue = extendFields[key].CurrentValue.ToObjectString();
                lstAttr.Add(attr);
            }
            return lstAttr;
        }

        public void ControlToEntity<T>(ref T t)
        {
            Type type = typeof(T);
            List<PropertyInfo> lstProperty = type.GetProperties().ToList();
            PropertyInfo pi = null;
            object val = null;
            object obj = null;
            IField field = null;
            foreach (string key in fields.Keys)
            {
                field = fields[key];
                pi = lstProperty.Find(p => p.Name == field.FieldName);
                val = field.CurrentValue;
                if (pi != null && val != null)
                {
                    if (pi.PropertyType.Name == "Guid")
                    {
                        obj = new Guid(val.ToString());
                        pi.SetValue(t, obj, null);
                    }
                    else if (pi.PropertyType.Name == "String"&&val!=null)
                    {
                        obj = val.ToString();
                        pi.SetValue(t, obj, null);
                    }
                    else
                    {
                        obj = Convert.ChangeType(val, pi.PropertyType);
                        pi.SetValue(t, obj, null);
                    }
                }
            }
        }

    }
}
