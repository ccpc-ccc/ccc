using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using System.Runtime.InteropServices.ComTypes;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCompanyPayEdit : BaseForm
    {
        private ICompanyPayService payService = new CompanyPayService();
        private ICompanyService companyService = new CompanyService();
        public FrmCompanyPayEdit()
        {
            InitializeComponent();
        }

        private void FrmWarehEdit_Load(object sender, EventArgs e) {
            List<ListItem> list = companyService.GetListItem(CurrentUser.Instance.CompanyIds);
            wCustomer.BindComboBoxEdit(list, null);
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (txtPayNo.Text.ToInt()<= 0)
            {
                isValidated = false;
                txtPayNo.ErrorText = "数量不能为空";
            }
            if (wCustomer.Text.Length == 0)
            {
                isValidated = false;
                wCustomer.ErrorText = "商户不能为空";
            }
            return isValidated;
        }

        private void Save()
        {
            SCompanyPay pay = new SCompanyPay() {
                Id=YF.MWS.Util.Utility.GetGuid(),
                Quantity= txtPayNo.Text.ToInt(),
                CompanyId=wCustomer.GetStrValue(),
                Amount= txtPayAmount.Text.ToDecimal()
            };
            if (payService.SaveCompany(pay)) {
            MessageDxUtil.ShowTips("保存成功！");
                this.DialogResult= DialogResult.OK;
            } else {
            MessageDxUtil.ShowTips("保存失败！");
            }
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm()) 
            {
                Save();
            }
        }

        private void wCustomer_SelectedValueChanged(object sender, EventArgs e) {
        }

        private void wCustomer_TextChanged(object sender, EventArgs e) {
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e) {
            this.Close();
        }
    }
}