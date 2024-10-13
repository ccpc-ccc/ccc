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
using YF.MWS.Db;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmLocationList : DevExpress.XtraEditors.XtraForm
    {
        private ILocationService locationService = new LocationService();
        public FrmLocationList()
        {
            InitializeComponent();
        }

        private void FrmLocationList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            var lst = locationService.GetLocationList();
            gcLocation.DataSource = lst;
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmLocationEdit frmDetail = new FrmLocationEdit())
            {
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvLocation.GetFocusedRow() != null)
            {
                SLocation location = (SLocation)gvLocation.GetFocusedRow();
                using (FrmLocationEdit frmEdit = new FrmLocationEdit())
                {
                    frmEdit.RecId = location.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void btnItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindData();
        }
    }
}