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

namespace YF.MWS.Win.View.Master
{
    public partial class FrmPayList : DevExpress.XtraEditors.XtraForm
    {
        private IWarehService wareService = new WarehService();
        private IPayService payService = new PayService();
        private IWebCompanyService webCompanyService = new WebCompanyService();
        private GridCheckMarksSelection chkWareh;
        public FrmPayList()
        {
            InitializeComponent();
        }

        private void FrmWarehList_Load(object sender, EventArgs e)
        {
            startDate.DateTime= DateTime.Now.AddMonths(-1);
            endDate.DateTime= DateTime.Now;
            BindData();
        }

        private void BindData()
        {
            PageQueryCondition qc = new PageQueryCondition();
            qc.ExtendCondition = string.Format(" and a.PayTime>='{0}' and a.PayTime<='{1}'",startDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),endDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            if (wCustomer.CurrentValue != null) { qc.ExtendCondition += string.Format(" and a.CustomerId='{0}'", wCustomer.CurrentValue); }
            TPageResult tp = payService.GetPayList(qc);
            var listCompany = tp.Rows;
            gcWareh.DataSource = listCompany;
            if (chkWareh == null) 
            {
                chkWareh = new GridCheckMarksSelection(gvWareh);
            }
            chkWareh.ClearSelection();
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmPayEdit frmDetail = new FrmPayEdit())
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
                QPay wareh = (QPay)gvWareh.GetFocusedRow();
                using (FrmPayEdit frmDetail = new FrmPayEdit())
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
                SWareh wareh = (SWareh)gvWareh.GetFocusedRow();
                bool isDelete = wareService.Delete(wareh.Id);
                string message;
                if (isDelete)
                {
                    webCompanyService.DeleteWareh(wareh.Id);
                    message = "成功删除仓库信息.";
                    MessageDxUtil.ShowTips(message);
                }
                else 
                {
                    message = "删除仓库信息时发生未知错误,请重试.";
                    MessageDxUtil.ShowWarning(message);
                }
                
            }
        }

        private void btnItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            BindData();
        }
    }
}