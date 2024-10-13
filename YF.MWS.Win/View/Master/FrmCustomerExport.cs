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
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.IO;
using YF.Utility;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCustomerExport : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();

        public FrmCustomerExport()
        {
            InitializeComponent();
        }

        private void FrmCustomerExport_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            DxHelper.BindComboBoxEdit(combCustomerType, SysCode.CustomerType, null);
        }

        private void barItemExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string customerType = DxHelper.GetCode(combCustomerType);
            if (string.IsNullOrEmpty(customerType)) 
            {
                MessageDxUtil.ShowWarning("请选择客户类别.");
                return;
            }
            if (sfdFileSave.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                string filePath = sfdFileSave.FileName;
                DataTable dt = masterService.GetCustomerByCustomerType(customerType.ToEnum<CustomerType>());
                NPOIHelper.DataTableToExcel(dt, filePath, null);
                MessageDxUtil.ShowTips("成功导出客户数据.");
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}