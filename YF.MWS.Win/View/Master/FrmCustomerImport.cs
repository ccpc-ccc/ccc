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
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.Utility.IO;
using YF.MWS.Db;
using YF.Utility;
using YF.Utility.Language;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCustomerImport : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        private ISeqNoService seqNoService = new SeqNoService();
        public FrmCustomerImport()
        {
            InitializeComponent();
        }

        private void FrmCustomerImport_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData() 
        {
            DxHelper.BindComboBoxEdit(combCustomerType, SysCode.CustomerType, null);
        }

        private void beImportFile_Click(object sender, EventArgs e)
        {
            if (ofdImportFile.ShowDialog() == DialogResult.OK)
            {
                beImportFile.Text = ofdImportFile.FileName;
            }
        }

        private void barItemImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Import();
        }

        private void Import() 
        {
            using (Utility.GetWaitForm("正在导入,请稍后..."))
            {
                string filePath = beImportFile.Text;
                DataTable dt = NPOIHelper.GetDataTable(filePath);
                List<SCustomer> customers = masterService.GetCustomerList(DxHelper.GetCode(combCustomerType).ToEnum<CustomerType>());
                if (customers == null)
                    customers = new List<SCustomer>();
                SCustomer find = null;
                string customerName = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    customerName = dr[1].ToObjectString().Trim();
                    if (!string.IsNullOrEmpty(customerName))
                    {
                        find = customers.Find(c => c.CustomerName == dr[0].ToObjectString().Trim());
                        if (find == null)
                        {
                            SCustomer customer = new SCustomer();
                            customer.CustomerType = DxHelper.GetCode(combCustomerType);
                            customer.CustomerCode = dr[0].ToObjectString();
                            if (string.IsNullOrEmpty(customer.CustomerCode))
                                customer.CustomerCode = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
                            customer.CustomerName = customerName;
                            customer.PYCustomerName = PinYinUtil.GetPinYin(customer.CustomerName);
                            customer.Contracter = dr[2].ToObjectString();
                            customer.Tel = dr[3].ToObjectString();
                            customer.Addr = dr[4].ToObjectString();
                            masterService.SaveCustomer(customer);
                        }
                    }
                }
            }
            MessageDxUtil.ShowTips("成功导入数据");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}