using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Metadata;
using YF.MWS.Util.Dynamic;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCompanyPayList : DevExpress.XtraEditors.XtraForm
    {
        private ICompanyService companyService = new CompanyService();
        private ICompanyPayService payService = new CompanyPayService();
        public FrmCompanyPayList()
        {
            InitializeComponent();
        }

        private void FrmWarehList_Load(object sender, EventArgs e)
        {
            startDate.DateTime= DateTime.Now.AddMonths(-1);
            endDate.DateTime= DateTime.Now;
            List<ListItem> companys= companyService.GetListItem(CurrentUser.Instance.CompanyIds);
            cmbCompany.BindComboBoxEdit(companys, null);
            BindData();
        }

        private void BindData()
        {
            string where = string.Format(" and a.CreateTime>='{0}' and a.CreateTime<='{1}'", startDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),endDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string companyId = cmbCompany.GetStrValue();
            if (companyId != null&& companyId != "") { where += string.Format(" and a.CompanyId='{0}'", companyId); }
            DataTable listCompany = payService.GetTable(where);
            gcWareh.DataSource = listCompany;
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCompanyPayEdit frmDetail = new FrmCompanyPayEdit())
            {
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvWareh.GetFocusedRow() != null)
            {
                SCompanyPay wareh = (SCompanyPay)gvWareh.GetFocusedRow();
                using (FrmCompanyPayEdit frmDetail = new FrmCompanyPayEdit())
                {
                    frmDetail.RecId = wareh.Id;
                    if (frmDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvWareh.GetFocusedRow() != null)
            {
                DataRow row= ((System.Data.DataRowView)gvWareh.GetFocusedRow()).Row;
                SCompanyPay wareh = payService.GetCompany(row);
                bool isDelete = payService.Delete(wareh);
                if (isDelete)
                {
                    MessageDxUtil.ShowTips("操作成功.");
                    BindData();
                }
                else 
                {
                    MessageDxUtil.ShowWarning("操作失败.");
                }
                
            }
        }

        private void btnItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            BindData();
        }
    }
}