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
    public partial class FrmPayEdit : BaseForm
    {
        private IPayService payService = new PayService();
        private IWeightService weightService = new WeightService();
        private IMasterService masterService = new MasterService();
        public FrmPayEdit()
        {
            InitializeComponent();
        }

        private void FrmWarehEdit_Load(object sender, EventArgs e) {
                if (!string.IsNullOrEmpty(RecId)) {
                   BPay wareh = payService.GetPay(RecId);
                    FormHelper.BindControl<BPay>(this, wareh);
                wCustomer.Enabled = false;
                btnItemSave.Enabled = false;
                }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (txtPayNo.Text.Length == 0)
            {
                isValidated = false;
                txtPayNo.ErrorText = "编码不能为空";
            }
            if (wCustomer.Text.Length == 0)
            {
                isValidated = false;
                wCustomer.ErrorText = "客户不能为空";
            }
            return isValidated;
        }

        private void Save()
        {
            BPay pay = new BPay() {
                Id=YF.MWS.Util.Utility.GetGuid(),
                PayNo= txtPayNo.Text,
                CustomerName=wCustomer.Text,
                CustomerId = wCustomer.CurrentValue.ToString(),
                PayAmount= txtPayAmount.Text.ToDecimal()
            };
            List<BPayDetail> bPays = new List<BPayDetail>();
            int[] il=gvWareh.GetSelectedRows();
            for(int i=0;i<il.Length; i++) {
                BPayDetail bd = new BPayDetail() {
                    Id = YF.MWS.Util.Utility.GetGuid(),
                    PayId = pay.Id,
                    WeightId = gvWareh.GetDataRow(i)["WeightId"].ToString(),
                    CustomerId = pay.CustomerId
                };
                bPays.Add(bd);
            }
            if(payService.save(pay, bPays)) {
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
        private void BindData() {
            if(wCustomer.CurrentValue==null) {
                gcWareh.DataSource = null;
                return;
            }
            SCustomer customer= masterService.GetCustomer(wCustomer.CurrentValue.ToString());
            if (customer==null) {
                gcWareh.DataSource = null;
                return;
            }
            DataTable dt = null;
            string where = string.Format(" and a.CustomerId='{0}' and a.FinishState=1 and a.PayType='{1}'",customer.Id, "UnSettled");
            if (this.RecId != null && this.RecId != ""){
                where = string.Format(" and a.WeightId in (select WeightId from B_PayDetail where PayId='{0}')", this.RecId);
            }
                dt= weightService.GetList(where);
            gcWareh.DataSource= dt;
        }

        private void wCustomer_TextChanged(object sender, EventArgs e) {
            BindData();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e) {
            this.Close();
        }
    }
}