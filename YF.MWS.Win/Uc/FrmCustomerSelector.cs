using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.Uc
{
    public partial class FrmCustomerSelector : DevExpress.XtraEditors.XtraForm
    {
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public CustomerType Type{ get;set; } 
        private GridCheckMarksSelection chkCustomer;
        private IMasterService masterService = new MasterService();
        private List<SCustomer> lstCustomer = new List<SCustomer>();
        private List<SCode> lstCustomerType = new List<SCode>();

        public FrmCustomerSelector()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetCustomer();
            this.DialogResult = DialogResult.OK;
        }

        private void SetCustomer() 
        {
            if (gvCustomer.GetFocusedRow() != null)
            {
                SCustomer customer = (SCustomer)gvCustomer.GetFocusedRow();
                CustomerName = customer.CustomerName;
                CustomerId = customer.Id;
                teCustomerName.Text = customer.CustomerName;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvCustomer_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvCustomer.GetFocusedRow() != null)
            {
                SCustomer customer = (SCustomer)gvCustomer.GetFocusedRow();
                CustomerName = customer.CustomerName;
                CustomerId = customer.Id;
                teCustomerName.Text = customer.CustomerName;
            }
        }

        private void FrmCustomerSelector_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            lstCustomer = masterService.GetCustomerList(Type);
            gcCustomer.DataSource = lstCustomer;
            lstCustomerType = MasterCacher.GetSubCodeList(SysCode.CustomerType.ToString());
            gvCustomer.Columns["CustomerType"].ColumnEdit = DxHelper.SetItemComboBox("repItemCustomerType", lstCustomerType);
            if (chkCustomer == null)
                chkCustomer = new GridCheckMarksSelection(gvCustomer);
            chkCustomer.ClearSelection();
        }

        private void gvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (gvCustomer.GetFocusedRow() != null)
            {
                SCustomer customer = (SCustomer)gvCustomer.GetFocusedRow();
                CustomerName = customer.CustomerName;
                CustomerId = customer.Id;
                teCustomerName.Text = customer.CustomerName;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}