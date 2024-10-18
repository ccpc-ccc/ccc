using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.Utility.Log;
using YF.Utility;
using YF.Utility.Language;
using YF.MWS.CacheService;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.Utility.Data;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCustomerDetail : BaseForm
    {
        private IMasterService masterService = new MasterService();
        private ISeqNoService seqNoService = new SeqNoService();
        private IWebCustomerService webCustomerService = new WebCustomerService();
        private IWebUserService webUserService = new WebUserService();
        private SCustomer customer = null;
        private bool startAutoUpload = false;
        private string currentType = "";

        public FrmCustomerDetail(string type)
        {
            InitializeComponent();
            currentType = type;
        }

        private void FrmCustomerDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            List<ListItem> list = ClassUtil.CumtomerList();
            if (!string.IsNullOrEmpty(RecId))
            {
                customer = masterService.GetCustomer(RecId);
                if (customer != null) 
                {
                    combCustomerType.Enabled = false;
                }
                FormHelper.BindControl<SCustomer>(this, customer);
                DxHelper.BindComboBoxEdit(combCustomerType, list, customer.CustomerType);
            }
            else 
            {
                DxHelper.BindComboBoxEdit(combCustomerType, list, currentType);
                teCustomerCode.Text = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
            }
        }

        private void Save()
        {
            try
            {
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
                FormHelper.ControlToEntity<SCustomer>(this, ref customer);
                customer.CustomerName = teCustomerName.Text;
                customer.CustomerType = combCustomerType.GetStrValue();
                if (string.IsNullOrEmpty(customer.CustomerCode))
                    customer.CustomerCode = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
                if (masterService.CustomerExist(customer.CustomerType, customer.CustomerName, customer.Id))
                {
                    MessageDxUtil.ShowWarning(string.Format("客户类型为({0})的客户({1})已经存在,请勿重复添加.", combCustomerType.Text,customer.CustomerName));
                }
                else
                {
                    bool isSaved=masterService.SaveCustomer(customer);
                    if (isSaved)
                    {
                        if (FrmMain != null)
                        {
                            FrmMain.LoadCustomer(customer.CustomerType.ToEnum<CustomerType>());
                        }
                    }
                    if (isSaved && startAutoUpload)
                    {
                        CustomerCacher.UpdateCustomer(customer.Id);
                        isSaved = webCustomerService.Save(customer);
                        if (isSaved)
                            masterService.UpdateCustomerSyncState((int)SyncState.Synced, customer.Id);
                    }
                    CustomerCacher.Remove();
                    MessageDxUtil.ShowTips("成功保存客户信息");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存客户信息时发生未知错误,请重试.");
            }
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (combCustomerType.Text.Length == 0)
            {
                combCustomerType.ErrorText = "请选择客户类型";
                isValidated = false;
            }
            if (teCustomerName.Text.Length == 0)
            {
                teCustomerName.ErrorText = "请输入客户名称"; 
                isValidated = false;
            }
            return isValidated;
        }

        private void teCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            tePYCustomerName.Text = PinYinUtil.GetInitial(teCustomerName.Text);
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}