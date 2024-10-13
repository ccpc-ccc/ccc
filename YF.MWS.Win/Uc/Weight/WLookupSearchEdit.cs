using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.Db;
using YF.MWS.CacheService;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata.Dto;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public partial class WLookupSearchEdit : SearchLookUpEdit,IField
    {
        private IClientService clientService = new ClientService();
        private ILocationService locationService = new LocationService();
        private IMasterService masterService = new MasterService();
        private IWeightViewService weightViewService = new WeightViewService();
        private List<LookupField> lstField = new List<LookupField>();
        #region private methods

        private static Control GetFindControlLayoutItem(PopupBaseForm Form, string strName)
        {
            if (Form != null)
            {
                foreach (Control FormC in Form.Controls)
                {
                    if (FormC is SearchEditLookUpPopup)
                    {
                        SearchEditLookUpPopup SearchPopup = FormC as SearchEditLookUpPopup;
                        foreach (Control SearchPopupC in SearchPopup.Controls)
                        {
                            if (SearchPopupC is LayoutControl)
                            {
                                LayoutControl FormLayout = SearchPopupC as LayoutControl;
                                Control Button = FormLayout.GetControlByName(strName);
                                if (Button != null)
                                {
                                    return Button;
                                }

                            }
                        }
                    }
                }
            }
            return null;
        }

        void WLookupSearchEdit_QueryPopUp(object sender, EventArgs e)
        {
            DevExpress.Utils.Win.IPopupControl control = sender as DevExpress.Utils.Win.IPopupControl;
            DevExpress.XtraEditors.Popup.PopupBaseForm Form = control.PopupWindow as DevExpress.XtraEditors.Popup.PopupBaseForm;
            Control btFindLCI = GetFindControlLayoutItem(Form, "btFind");
            if (btFindLCI != null)
            {
                btFindLCI.Text = "查找";
            }
            Control btClear = GetFindControlLayoutItem(Form, "btClear");
            if (btClear != null)
            {
                btClear.Text = "清除";
            }
        }

        #endregion

        public WLookupSearchEdit()
        {
            this.Properties.NullText = string.Empty;
            this.Popup += WLookupSearchEdit_QueryPopUp;
        }

        #region IField 成员
        public string ActionName
        {
            get;
            set;
        }

        public void InitData()
        {
            this.Font = CfgUtil.GetFont();
            if (FieldName == "ClientId")
            {
                lstField.Clear();
                List<SClient> clients = clientService.GetList();
                lstField.Add(new LookupField() { FieldName = "ClientName", Caption = "名称" });
                SearchLookupUtil.BindData(this, clients, "MachineCode", "ClientName", lstField);
            }
            if (FieldName == "LocationId")
            {
                lstField.Clear();
                List<LocationFull> locations = locationService.GetLocationList();
                lstField.Add(new LookupField() { FieldName = "LocationName", Caption = "名称" });
                lstField.Add(new LookupField() { FieldName = "LocationCode", Caption = "编码" });
                SearchLookupUtil.BindData(this, locations, "Id", "LocationName", lstField);
            }
            if (FieldName == "WarehId")
            {
                lstField.Clear();
                List<SWareh> lstWareh = WarehCacher.GetWarehList();
                lstField.Add(new LookupField() { FieldName = "WarehName", Caption = "名称" });
                lstField.Add(new LookupField() { FieldName = "WarehCode", Caption = "编码" });
                SearchLookupUtil.BindData(this, lstWareh, "Id", "WarehName", lstField);
            }
            if (FieldName == "WeightControlId")
            {
                lstField.Clear();
                var lst = weightViewService.GetDetailList(CurrentClient.Instance.ViewId);
                lstField.Add(new LookupField() { FieldName = "ControlName", Caption = "名称" });
                SearchLookupUtil.BindData(this, lst, "Id", "ControlName", lstField);
            }
            if (FieldName == "CustomerId")
            {
                lstField.Clear();
                var lst = masterService.GetCustomerList(CustomerType.Customer);
                lstField.Add(new LookupField() { FieldName = "PYCustomerName", Caption = "客户简称" });
                lstField.Add(new LookupField() { FieldName = "CustomerName", Caption = "客户名称" });
                SearchLookupUtil.BindData(this, lst, "Id", "CustomerName", lstField);
            }
        }

        public void InitDataNew()
        {
            if (FieldName == "ClientId")
            {
                lstField.Clear();
                List<SClient> clients = clientService.GetList();
                lstField.Add(new LookupField() { FieldName = "ClientName", Caption = "名称" });
                SearchLookupUtil.BindData(this, clients, "MachineCode", "ClientName", lstField);
            }
            if (FieldName == "LocationId")
            {
                lstField.Clear();
                List<LocationFull> locations = locationService.GetLocationList();
                lstField.Add(new LookupField() { FieldName = "LocationName", Caption = "名称" });
                lstField.Add(new LookupField() { FieldName = "LocationCode", Caption = "编码" });
                SearchLookupUtil.BindData(this, locations, "Id", "LocationName", lstField);
            }
            if (FieldName == "WarehId")
            {
                lstField.Clear();
                List<SWareh> lstWareh = WarehCacher.GetWarehList();
                lstField.Add(new LookupField() { FieldName = "WarehName", Caption = "名称" });
                lstField.Add(new LookupField() { FieldName = "WarehCode", Caption = "编码" });
                SearchLookupUtil.BindData(this, lstWareh, "Id", "WarehName", lstField);
            }
            if (FieldName == "WeightControlId") 
            {
                lstField.Clear();
                var lst = weightViewService.GetDetailList(CurrentClient.Instance.ViewId);
                lstField.Add(new LookupField() { FieldName = "ControlName", Caption = "名称" });
                SearchLookupUtil.BindData(this, lst, "Id", "ControlName", lstField);
            }
            if (FieldName == "CustomerId")
            {
                lstField.Clear();
                var lst = masterService.GetCustomerList(CustomerType.Customer);
                lstField.Add(new LookupField() { FieldName = "PYCustomerName", Caption = "客户简称" });
                lstField.Add(new LookupField() { FieldName = "CustomerName", Caption = "客户名称" });
                SearchLookupUtil.BindData(this, lst, "Id", "CustomerName", lstField);
            }
        }
        public string Caption
        {
            get;
            set;
        }
        public string ErrorTipText
        {
            get;
            set;
        }
        public object CurrentValue
        {
            get { return EditValue; }
            set { EditValue = value; }
        }

        public string FieldName
        {
            get;
            set;
        } 

        public bool IsRequired
        {
            get;
            set;
        }

        public int DecimalDigits
        {
            get;
            set;
        }
        public void Clear()
        {
            try
            {
                CurrentValue = null;
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        Text = "";
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
        public string t1 { get; set; }

        public void SetEnabled(bool enable)
        {
            this.Enabled = enable;
        }

        public string ControlName
        {
            get;
            set;
        }

        /// <summary>
        /// 启用驻留
        /// </summary>
        public bool StartStay { get; set; }
        /// <summary>
        /// 启用自动保存
        /// </summary>
        public bool StartAutoSave { get; set; }

        public string Expression
        {
            get;
            set;
        }

        public int AutoCalcNo
        {
            get;
            set;
        } 

        public Metadata.Event.WeightVauleChangedEventHandler WeightVauleChanged
        {
            get;
            set;
        }

        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }

        public void SetReadonly()
        {
            this.Properties.ReadOnly = true;
        }

        public Point ParentLocation
        {
            get;
            set;
        }
        public void SaveInputItem()
        {

        }
        public void setValue(object value) { }
        #endregion
    }
}
