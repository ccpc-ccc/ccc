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
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmWarehList : DevExpress.XtraEditors.XtraForm
    {
        private IWarehService wareService = new WarehService();
        private ISyncService syncService = new SyncService();
        private IWebCompanyService webCompanyService = new WebCompanyService();
        private GridCheckMarksSelection chkWareh;
        public FrmWarehList()
        {
            InitializeComponent();
        }

        private void FrmWarehList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            var listCompany = wareService.GetList();
            gcWareh.DataSource = listCompany;
            if (chkWareh == null) 
            {
                chkWareh = new GridCheckMarksSelection(gvWareh);
            }
            chkWareh.ClearSelection();
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmWarehEdit frmDetail = new FrmWarehEdit())
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
                SWareh wareh = (SWareh)gvWareh.GetFocusedRow();
                using (FrmWarehEdit frmDetail = new FrmWarehEdit())
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
                    message = "成功删除仓库信息.";
                    MessageDxUtil.ShowTips(message);
                    BindData();
                }
                else 
                {
                    message = "删除仓库信息时发生未知错误,请重试.";
                    MessageDxUtil.ShowWarning(message);
                }
                
            }
        }
    }
}