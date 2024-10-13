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
using YF.MWS.Win.Uc;
using YF.MWS.Metadata.Query;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Log
{
    public partial class FrmRecLogList : BaseForm
    {
        private ILogService logService = new LogService();

        public FrmRecLogList()
        {
            InitializeComponent();
        }

        private void FrmRecLogList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            List<QLog> logs = logService.GetList(RecId);
            gcLog.DataSource = logs;
            gcLog.RefreshDataSource();
        }

        private void btnItemExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DxHelper.ExportXlsx(gvLog);
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}