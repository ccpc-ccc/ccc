using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.CacheService;

namespace YF.MWS.Win.Uc
{
    public partial class FrmMaterialSelector : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        private List<SMaterial> lstMaterial = new List<SMaterial>();
        public string MaterialId;
        public string MaterialName;

        public FrmMaterialSelector()
        {
            InitializeComponent();
        }

        private void FrmMaterialSelector_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindData() 
        {
            lstMaterial = MaterialCacher.GetMaterialList();
            gcMaterial.DataSource = lstMaterial;
        }

        private void gvMaterial_RowClick(object sender, RowClickEventArgs e)
        {
            SetMaterial();
        }

        private void gvMaterial_DoubleClick(object sender, EventArgs e)
        {
            SetMaterial();
            this.DialogResult = DialogResult.OK;
        }

        private void SetMaterial() 
        {
            if (gvMaterial.GetFocusedRow() != null) 
            {
                SMaterial material = (SMaterial)gvMaterial.GetFocusedRow();
                if (material != null) 
                {
                    MaterialId = material.Id;
                    MaterialName = material.MaterialName;
                    teMaterialName.Text = material.MaterialName;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}