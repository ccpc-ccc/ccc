using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmClientList : DevExpress.XtraEditors.XtraForm
    {
        private IClientService clientService = new ClientService();

        public FrmClientList()
        {
            InitializeComponent();
        }

        private void FrmClientList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            var lst = clientService.GetList();
            gcClient.DataSource = lst;
            gcClient.RefreshDataSource();
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvClient.GetFocusedRow() != null) 
            {
                SClient client = (SClient)gvClient.GetFocusedRow();
                FrmClientEdit frmEdit = new FrmClientEdit();
                frmEdit.RecId = client.Id;
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    btnItemSearch.PerformClick();
            }
        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvClient.GetFocusedRow() != null)
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除此客户端吗?") == System.Windows.Forms.DialogResult.Yes)
                {
                    SClient client = (SClient)gvClient.GetFocusedRow();
                    clientService.DeleteById(client.Id);
                    btnItemSearch.PerformClick();
                }
            }
        }
    }
}