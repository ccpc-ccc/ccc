using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.Uc;

namespace YF.MWS.Win.View.Customer
{
    public partial class FrmCustomerSimple : BaseForm
    {
        public FrmCustomerSimple()
        {
            InitializeComponent();
        }

        private void FrmCustomerSimple_Load(object sender, EventArgs e)
        {
            ucCustomer.BindData();
            ucDeliver.BindData();
            ucReceiver.BindData();
            ucSupplier.BindData();
            ucTransfer.BindData();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabCustomer.SelectedTabPageIndex;
            bool isSaved = false;
            CustomerType customerType = CustomerType.Customer;
            if (index == 0)
            {
                isSaved = ucCustomer.Save();
            }
            if (index == 1)
            {
                isSaved = ucDeliver.Save();
                customerType = CustomerType.Delivery;
            }
            if (index == 2)
            {
                isSaved = ucReceiver.Save();
                customerType = CustomerType.Receiver;
            }
            if (index == 3)
            {
                isSaved = ucSupplier.Save();
                customerType = CustomerType.Supplier;
            }
            if (index == 4)
            {
                isSaved = ucTransfer.Save();
                customerType = CustomerType.Transfer;
            }
        }

        private void barItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = tabCustomer.SelectedTabPageIndex;
            if (index == 0)
                ucCustomer.Delete();
            if (index == 1)
                ucDeliver.Delete();
            if (index == 2)
                ucReceiver.Delete();
            if (index == 3)
                ucSupplier.Delete();
            if (index == 4)
                ucTransfer.Delete();
        }
    }
}