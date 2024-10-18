using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.CacheService;
using YF.Utility.Log;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.Utility;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Language;
using YF.MWS.Metadata;

namespace YF.MWS.Win.Uc
{
    public partial class UcCustomer : DevExpress.XtraEditors.XtraUserControl
    {
        private IMasterService masterService = new MasterService();
        private ISeqNoService seqNoService = new SeqNoService();
        private ICustomerService customerService = new CustomerService();
        private IWebCustomerService webCustomerService = new WebCustomerService();
        private CustomerType customerType = CustomerType.Customer;
        private bool startAutoUpload = false;
        private SCustomer customer = null;

        public CustomerType CustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }

        public UcCustomer()
        {
            InitializeComponent();
            SysCfg cfg = CfgUtil.GetCfg();
        }

        public void BindData() 
        {
            List<SCustomer> customers = masterService.GetCustomerList(customerType);
            gcCustomer.DataSource = customers;
            gcCustomer.RefreshDataSource();
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (string.IsNullOrEmpty(teCustomerName.Text.Trim()) || teCustomerName.Text.Trim().Length == 0)
            {
                teCustomerName.ErrorText = "请输入客户名称";
                isValidated = false;
            }
            SCustomer find = customerService.GetCustomerByName(customerType, teCustomerName.Text.Trim());
            if (find != null)
            {
                string message = string.Format("客户类型为({0})的客户({1})已经存在,请勿重复添加.", customerType.ToDescription(), teCustomerName.Text.Trim());
                if (customer != null)
                {
                    if (find.Id != customer.Id)
                    {
                        isValidated = false;
                        MessageDxUtil.ShowWarning(message);
                    }
                }
                else 
                {
                    isValidated = false;
                    MessageDxUtil.ShowWarning(message);
                }
            }
            return isValidated;
        }

        private void Clear() 
        {
            customer = null;
            teContracter.Text = null;
            teCustomerCode.Text = null;
            teCustomerName.Text = null;
            teMobile.Text = null;
            tePYCustomerName.Text = null;
        }

        public void Delete()
        {
            if (gvCustomer.GetFocusedRow() != null)
            {
                SCustomer customer = (SCustomer)gvCustomer.GetFocusedRow();
                string message = string.Format("确实要彻底删除该单位信息({0})吗?此删除不可撤销,请谨慎操作.", customer.CustomerName);
                if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes)
                {
                    int weightCount = customerService.GetWeightCount(customer.CustomerType.ToEnum<CustomerType>(), customer.Id);
                    if (weightCount > 0)
                    {
                        message = string.Format("此单位({0})存在{1}个磅单,不能彻底被删除.", customer.CustomerName, weightCount);
                        MessageDxUtil.ShowWarning(message);
                        return;
                    }
                    int rechargeCount = customerService.GetRechargeCount(customer.Id);
                    if (rechargeCount > 0)
                    {
                        message = string.Format("此单位({0})存在{1}条充值记录,不能彻底被删除.", customer.CustomerName, rechargeCount);
                        MessageDxUtil.ShowWarning(message);
                        return;
                    }
                    bool isDeleted = customerService.DeleteCustomerPhysics(customer.Id);
                    if (isDeleted)
                    {
                        MessageDxUtil.ShowTips("成功删除此单位信息");
                        webCustomerService.DeletePhysics(customer.Id);
                        CustomerCacher.Remove();
                        BindData();
                    }
                }
            }
        }

        public bool Save()
        {
            bool isSaved = false;
            try
            {
                if (!ValidateForm()) 
                {
                    return isSaved;
                }
                if (customer == null)
                {
                    customer = new SCustomer();
                    customer.Id = YF.MWS.Util.Utility.GetGuid();
                    customer.RowState = (int)RowState.Add;
                }
                else
                {
                    customer.RowState = (int)RowState.Edit;
                }
                customer.CustomerType = customerType.ToString();
                customer.CustomerName = teCustomerName.Text;
                FormHelper.ControlToEntity<SCustomer>(this, ref customer);
                if(string.IsNullOrEmpty(customer.CustomerCode))
                    customer.CustomerCode = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
                if (masterService.CustomerExist(customer.CustomerType, customer.CustomerName, customer.Id))
                {
                    MessageDxUtil.ShowWarning(string.Format("客户类型为({0})的客户({1})已经存在,请勿重复添加.", customerType.ToDescription(), customer.CustomerName));
                }
                else
                {
                    isSaved = masterService.SaveCustomer(customer);
                    if (isSaved && startAutoUpload)
                    {
                        CustomerCacher.UpdateCustomer(customer.Id);
                        isSaved = webCustomerService.Save(customer);
                        if (isSaved)
                            masterService.UpdateCustomerSyncState((int)SyncState.Synced, customer.Id);
                    }
                    if (isSaved)
                    { 
                        BindData();
                        Clear();
                    }
                    CustomerCacher.Remove();
                    if (isSaved)
                    { 
                        MessageDxUtil.ShowTips("成功保存客户信息"); 
                    }
                    else
                        MessageDxUtil.ShowWarning("保存客户信息失败,请重试");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存客户信息时发生未知错误,请重试.");
            }
            return isSaved;
        }

        private void teCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            if(teCustomerName.Text.Length>0)
               tePYCustomerName.Text = PinYinUtil.GetInitial(teCustomerName.Text);
        }

    }
}
