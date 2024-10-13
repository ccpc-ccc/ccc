using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Event;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using System.Drawing;
using YF.MWS.CacheService;
using YF.MWS.BaseMetadata;
using YF.Utility.Language;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WCustomerEdit : ComboBoxEdit, IField
    {
        private object currentValue;
        private IMasterService masterService=new MasterService();
        private ISeqNoService seqNoService = new SeqNoService();
        private CustomerType type;

        public CustomerType Type
        {
            get
            {
                if (type == CustomerType.Customer && FieldName == "TransferId")
                    type = CustomerType.Transfer;
                return type;
            }
            set 
            { 
                type = value;
                if (!DesignMode)
                {
                    if (this.Properties.Buttons != null && this.Properties.Buttons.Count >= 2)
                    {
                        this.Properties.Buttons[0].ToolTip = "下拉选择" + type.ToDescription();
                        this.Properties.Buttons[1].ToolTip = "窗口选择" + type.ToDescription();
                    }
                }
            }
        }
        private List<SCustomer> customers;
        private List<SCustomer> tempCustomers;

        public WCustomerEdit()
        {
            this.Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown;
            this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton() { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis });
            this.Properties.AutoComplete = false;
        }

        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            base.OnClickButton(buttonInfo);
            if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                using (FrmCustomerSelector frm = new FrmCustomerSelector())
                {
                    frm.Type = Type;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.currentValue = frm.CustomerId;
                        this.Text = frm.CustomerName;
                        SelectedItem = new ListItem() { Text = frm.CustomerName, Value = frm.CustomerId };
                    }
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            LoadData();
            ShowPopup();
            SelectionStart = Text.Length;
        }

        public void LoadCustomer()
        {
            customers = masterService.GetCustomerList(Type);
            LoadData(true);
        }

        private void LoadData(bool loadAll=false)
        {
            Properties.Items.Clear();
            tempCustomers = new List<SCustomer>();
            if (customers == null)
                customers = masterService.GetCustomerList(Type);
            if (customers != null && customers.Count > 0 && Text.Length > 0 && !loadAll)
            {
                tempCustomers = customers.FindAll(c => c.CustomerName.Contains(Text.Trim()) || (!string.IsNullOrEmpty(c.PYCustomerName) && c.PYCustomerName.ToLower().Contains(Text.Trim().ToLower())));
            }
            else
            {
                tempCustomers = customers;
            }
            if (tempCustomers != null && tempCustomers.Count > 0)
            {
                List<ListItem> items = new List<ListItem>();
                foreach (SCustomer customer in tempCustomers)
                {
                    items.Add(new ListItem() { Value = customer.Id, Text = customer.CustomerName });
                }
                DxHelper.BindComboBoxEdit(this, items, null);
            }
        }

        public void SetCustomer() 
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                SCustomer customer = masterService.GetCustomerByName(Type, this.Text);
                if (customer == null) 
                {
                    customer = new SCustomer();
                    customer.Id = YF.MWS.Util.Utility.GetGuid();
                    customer.CustomerType = Type.ToString();
                    customer.CustomerName = this.Text;
                    customer.PYCustomerName = PinYinUtil.GetInitial(customer.CustomerName);
                    customer.CustomerCode = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
                    masterService.SaveCustomer(customer);
                    CustomerCacher.Remove();
                    customers = masterService.GetCustomerList(Type);
                    LoadData(true);
                }
                this.currentValue = customer.Id;
            }
        }

        #region IField 成员
        public string ActionName
        {
            get;
            set;
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
            get
            {
                try {
                string selectedValue = DxHelper.GetStrValue(this);
                if (!string.IsNullOrEmpty(selectedValue))
                    return selectedValue;
                    if (currentValue != null && currentValue.ToString().Length > 0)
                    return currentValue;
                    if (string.IsNullOrEmpty(currentValue.ToObjectString()) && Text.Length > 0 && customers != null && customers.Count > 0)
                {
                    SCustomer customer = customers.Find(c => c.CustomerName == Text);
                    if (customer != null)
                        currentValue = customer.Id;
                }
                    if (currentValue == null) currentValue = "";
                }catch(Exception ex) {
                    Logger.WriteException(ex);
                }
                return currentValue;
            }
            set
            {
                currentValue = value;
                if (currentValue != null && currentValue.ToObjectString().Length>0) {
                    if (Properties.Items != null && Properties.Items.Count > 0)
                        SelectedItem = Properties.Items.Cast<ListItem>().FirstOrDefault(c => c.Value == Convert.ToString(currentValue));
                    if (SelectedItem == null || SelectedItem.ToObjectString().Length == 0) {
                        SCustomer customer = CustomerCacher.Get(currentValue.ToString());
                        if (customer != null)
                        {
                            Text = customer.CustomerName;
                        }
                    }
                }
            }
        }

        public string t1 { get; set; }
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

        /// <summary>
        /// 启用驻留
        /// </summary>
        public bool StartStay { get; set; }
        /// <summary>
        /// 启用自动保存
        /// </summary>
        public bool StartAutoSave { get; set; }

        public void Clear()
        {
            try
            {
                CurrentValue = null;
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        Text = null;
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void SetEnabled(bool enable)
        {
            this.Enabled = enable;
        }

        public string ControlName
        {
            get;
            set;
        }

        public int DecimalDigits
        {
            get;
            set;
        }

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

        public void InitData()
        {
            this.Font = CfgUtil.GetFont();
            customers = masterService.GetCustomerList(Type);
            LoadData();
        }

        public WeightVauleChangedEventHandler WeightVauleChanged
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
            SetCustomer();
        }
        public void setValue(object value) { }
        #endregion
    }
}
