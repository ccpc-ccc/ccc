using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;
using YF.MWS.Win.Uc;

namespace YF.MWS.Win.View.Customer
{
    public partial class FrmPriceEdit : BaseForm
    {
        private IMasterService masterService = new MasterService();
        private ICustomerService customerService = new CustomerService();
        private SCustomerPrice price = null;
        private List<LookupField> lstField = new List<LookupField>();

        public FrmPriceEdit()
        {
            InitializeComponent();
        }

        private void FrmPriceEdit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                price = customerService.Get(RecId);
                weMaterial.CurrentValue = price.MaterialId;
                weMaterial.Text = price.MaterialName;
                wCustomer.CurrentValue = price.CustomerId;
                tePrice.Text = price.Price.ToString();
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
            if (wCustomer.CurrentValue.ToObjectString().Length == 0)
            {
                wCustomer.ErrorText = "请选择客户";
                isValidated = false;
            }
            if (tePrice.Text.ToDecimal() <= 0)
            {
                tePrice.ErrorText = "请输入单价";
                isValidated = false;
            }
            if (weMaterial.Text.Length == 0)
            {
                weMaterial.ErrorText = "请选择物资";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save()
        {
            try
            {
                if (price == null)
                {
                    price = new SCustomerPrice();
                    price.Id = YF.MWS.Util.Utility.GetGuid();
                }
                price.MaterialId = weMaterial.CurrentValue.ToObjectString();
                price.MaterialName = weMaterial.Text;
                price.CustomerName = wCustomer.Text;
                price.Price = tePrice.Text.ToDecimal();
                price.CustomerId = wCustomer.CurrentValue.ToObjectString();
                bool isSaved = customerService.Save(price);
                MessageDxUtil.ShowTips("成功保存价格信息");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存价格信息时发生未知错误,请重试.");
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}