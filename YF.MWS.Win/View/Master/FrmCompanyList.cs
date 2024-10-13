using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCompanyList : DevExpress.XtraEditors.XtraForm
    {
        private ICompanyService companyService = new CompanyService();
        public FrmCompanyList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
            }
        }

        private void FrmCompanyList_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCompanyDetail frmDetail = new FrmCompanyDetail())
            {
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCompanyDetail frmDetail = new FrmCompanyDetail())
            {
                //获取公司Id
                if (this.gvCompany.FocusedRowHandle >= 0)
                {
                    frmDetail.CompanyId = this.gvCompany.GetRowCellValue(this.gvCompany.FocusedRowHandle, "Id").ToString();
                }

                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gvCompany.FocusedRowHandle >= 0)
            {
                string companyId = this.gvCompany.GetRowCellValue(this.gvCompany.FocusedRowHandle, "Id").ToString();
                //删除公司信息
                if (companyService.DeleteCompany(companyId))
                {
                    MessageDxUtil.ShowTips("删除公司信息成功。");
                    this.BindData();
                }
                else
                {
                    MessageDxUtil.ShowTips("删除公司信息失败。");
                }
            }
        }

        private void btnItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.BindData();
        }

        private void BindData() {
            if (CurrentUser.Instance.CompanyId != null && CurrentUser.Instance.CompanyId != "") {
                CurrentUser.Instance.CompanyIds = companyService.GetCompanys(CurrentUser.Instance.CompanyId).ToArray();
            }
            var listCompany = companyService.GetCompanyList(CurrentUser.Instance.CompanyIds);
            this.gcCompany.DataSource = listCompany;
        }

        private void gvCompany_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //if (e.Info.IsRowIndicator)
            //{
            //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //}
        }
    }
}