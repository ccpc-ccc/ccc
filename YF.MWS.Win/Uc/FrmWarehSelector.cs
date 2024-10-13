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
using YF.MWS.CacheService;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.Uc
{
    public partial class FrmWarehSelector : DevExpress.XtraEditors.XtraForm
    {
        private IWarehService warehService = new WarehService();
        private List<SWareh> warehs = new List<SWareh>();
        public string WarehId;
        public string WarehName;

        public FrmWarehSelector()
        {
            InitializeComponent();
        }

        private void FrmWarehSelector_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            warehs = WarehCacher.GetWarehList();
            gcWareh.DataSource = warehs;
        }

        private void SetWareh()
        {
            if (gvWareh.GetFocusedRow() != null)
            {
                SWareh wareh = (SWareh)gvWareh.GetFocusedRow();
                if (wareh != null)
                {
                    WarehId = wareh.Id;
                    WarehName = wareh.WarehName;
                    teMaterialName.Text = WarehName;
                }
            }
        }

        private void gvWareh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SetWareh();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gvWareh_DoubleClick(object sender, EventArgs e)
        {
            SetWareh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(WarehId))
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                MessageDxUtil.ShowWarning("请选择仓库");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}