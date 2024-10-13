using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using DevExpress.XtraLayout;
using YF.MWS.Metadata.Query;
using YF.MWS.Win.Uc.Weight;
using DevExpress.XtraEditors;
using YF.Utility;
using YF.MWS.CacheService;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.Uc
{
    public partial class CardView : UserControl
    {
        private Dictionary<string, IField> fields = new Dictionary<string, IField>();
        private ICardService cardService = new CardService();
        private IWeightViewService viewService = new WeightViewService();
        private IMasterService masterService = new MasterService();
        private List<CardField> lstCardField = new List<CardField>();
        private SWeightView view = null;
        public string CurrentViewId;
        public CardView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode)
            {
                view = viewService.GetDefaultView(ViewType.Weight);
                InitControl();
                InitData();
            }
            base.OnLoad(e);
        }

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
                CurrentViewId = view.Id;
            }
            layGroup.Clear();
            List<QCardViewDtl> lstDtl = cardService.GetDetailList(CurrentViewId);
            List<LayoutControlItem> lstItem = new List<LayoutControlItem>();
            LayoutControlItem item = null;
            QCardViewDtl detail = null;
            IField field = null; 
            int columnsCount = 2;
            if (columnsCount <= 0)
            {
                columnsCount = 3;
            }
            int width = layGroup.Width;
            int rows = lstDtl.Count / columnsCount;
            int remainder = lstDtl.Count % columnsCount;
            int height = 24;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    detail = lstDtl[i * columnsCount + j]; 
                    field = GetControl(detail.FullName, detail.DecimalDigits);
                    if (field != null)
                    {
                        item = new LayoutControlItem();
                        item.Location = new Point(j * width / columnsCount, i * height);
                        item.Size = new Size(width / columnsCount, height);
                        item.Control = field as Control;
                        item.Text = detail.Caption;
                        lstItem.Add(item);
                        field.FieldName = detail.FieldName;
                        field.ControlName = detail.ControlName;  
                        field.InitData();
                        lstCardField.Add(new CardField() { ControlId=detail.ControlId, CVDetailId=detail.DetailId });
                        fields[detail.ControlId] = field;
                    }
                }
            }
            for (int k = 0; k < remainder; k++)
            {
                detail = lstDtl[rows * columnsCount + k]; 
                field = GetControl(detail.FullName, detail.DecimalDigits);
                if (field != null)
                {
                    item = new LayoutControlItem();
                    item.Location = new Point(k * width / columnsCount, rows * height);
                    item.Size = new Size(width / columnsCount, height);
                    item.Control = field as Control;
                    item.Text = detail.Caption;
                    lstItem.Add(item);
                    field.FieldName = detail.FieldName;
                    field.ControlName = detail.ControlName; 
                    field.InitData();
                    lstCardField.Add(new CardField() { ControlId = detail.ControlId, CVDetailId = detail.DetailId });
                    fields[detail.ControlId] = field;
                }
            }
            layGroup.Items.AddRange(lstItem.ToArray());
            layControl.EndUpdate();
        }

        private void InitData()
        {
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "CustomerName", Caption = "名称" });
            List<SCustomer> lstSupplier = CustomerCacher.GetCustomerList(CustomerType.Supplier);
            List<SCustomer> lstDelivery = CustomerCacher.GetCustomerList(CustomerType.Delivery);
            List<SCustomer> lstManufacturer = CustomerCacher.GetCustomerList(CustomerType.Manufacturer);
            List<SCustomer> lstReceiver = CustomerCacher.GetCustomerList(CustomerType.Receiver);
            List<SCustomer> lstCustomer = CustomerCacher.GetCustomerList(CustomerType.Customer);
            var lookupSupplier = this.FindControl<WCustomerEdit>("SupplierId");
            var lookupDelivery = this.FindControl<WCustomerEdit>("DeliveryId");
            var lookupManufacturer = this.FindControl<WCustomerEdit>("ManufacturerId");
            var lookupReceiver = this.FindControl<WCustomerEdit>("ReceiverId");
            var lookupCustomer = FindControl<WCustomerEdit>("CustomerId");
            var lookupMaterial = FindControl<SearchLookUpEdit>("MaterialId");
            var combMeasureType = FindControl<ComboBoxEdit>("MeasureType");
            var combImpurityMeaType = FindControl<ComboBoxEdit>("ImpurityMeaType");
            var combChargeType = FindControl<ComboBoxEdit>("ChargeType");
            var weTareWeight = FindControl<WNumbericEdit>("TareWeight");
            if (weTareWeight != null)
            {
            }
            if (lookupDelivery != null)
            {
                lookupDelivery.Type = CustomerType.Delivery;
                //SearchLookupUtil.BindData(lookupDelivery, lstDelivery, "CustomerId", "CustomerName", lstField);
            }
            if (lookupReceiver != null)
            {
                lookupReceiver.Type = CustomerType.Receiver;
                //SearchLookupUtil.BindData(lookupReceiver, lstReceiver, "CustomerId", "CustomerName", lstField);
            }
            if (lookupManufacturer != null)
            {
                lookupManufacturer.Type = CustomerType.Manufacturer;
                //SearchLookupUtil.BindData(lookupManufacturer, lstManufacturer, "CustomerId", "CustomerName", lstField);
            }
            if (lookupSupplier != null)
            {
                lookupSupplier.Type = CustomerType.Supplier;
                //SearchLookupUtil.BindData(lookupSupplier, lstSupplier, "CustomerId", "CustomerName", lstField);
            }
            if (lookupCustomer != null)
            {
                lookupCustomer.Type = CustomerType.Customer;
                //SearchLookupUtil.BindData(lookupCustomer, lstCustomer, "CustomerId", "CustomerName", lstField);
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
                lstField.Add(new LookupField() { FieldName = "MaterialName", Caption = "物资" });
                List<SMaterial> lstMaterial = MaterialCacher.GetMaterialList();
                SearchLookupUtil.BindData(lookupMaterial, lstMaterial, "Id", "MaterialName", lstField);
            }
        }

        private T FindControl<T>(string fieldName) where T : class
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

        private IField GetControl(string fullName, int decimalDigits)
        {
            Type type = Type.GetType(fullName);
            IField field = (IField)type.Assembly.CreateInstance(fullName);
            WNumbericEdit wNum = field as WNumbericEdit;
            if (wNum != null)
            {
                wNum.Properties.DisplayFormat.FormatString = string.Format("N{0}", decimalDigits);
                wNum.Properties.Mask.EditMask = string.Format("N{0}", decimalDigits);
                wNum.DecimalDigits = decimalDigits;
            }
            return field;
        }

        public void BindControl(List<BCardPreset> lstPreset)
        {
            BCardPreset preset;
            foreach (string key in fields.Keys)
            {
                preset = lstPreset.Find(c => c.ControlId == key);
                if (preset != null)
                {
                    fields[key].CurrentValue = preset.PresetValue;
                }
            }
        }

        public void Clear()
        {
            IField field = null;
            foreach (string key in fields.Keys)
            {
                field = fields[key];
                field.Clear();
            }
        }

        public List<BCardPreset> ControlToList(string cardId)
        {
            List<BCardPreset> lstPreset = new List<BCardPreset>();
            CardField field = null;
            BCardPreset preset;
            foreach (string key in fields.Keys)
            {
                preset = new BCardPreset();
                field = lstCardField.Find(c => c.ControlId == key);
                if (field != null) 
                {
                    preset.CvDetailId = field.CVDetailId;
                }
                fields[key].SaveInputItem();
                preset.Id = YF.MWS.Util.Utility.GetGuid();
                preset.CardId = cardId;
                preset.ControlId = key;
                preset.PresetValue = fields[key].CurrentValue.ToObjectString();
                lstPreset.Add(preset);
            }
            return lstPreset;
        }
    }
}
