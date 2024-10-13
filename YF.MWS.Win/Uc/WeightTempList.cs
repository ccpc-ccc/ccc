using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;

namespace YF.MWS.Win.Uc
{
    public partial class WeightTempList : DevExpress.XtraEditors.XtraUserControl
    {
        private IWeightTempService weightTempService = new WeightTempService();

        public WeightTempList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfdFileSave.FileName;
                gvWeight.ExportToXls(filePath);
            }
        }

        public void LoadData() 
        {
            int topN = 10;
            if (combRecordCount.SelectedIndex != 3)
            {
                topN = 10 * (combRecordCount.SelectedIndex + 1);
            }
            else
            {
                topN = 10 * (combRecordCount.SelectedIndex + 2);
            }
            List<BWeightTemp> lstWeight = weightTempService.GetList(teStartDate.Time, teEndDate.Time, topN);
            gcWeight.DataSource = lstWeight;
            gcWeight.RefreshDataSource(); 
        }

        private void WeightTempList_Load(object sender, EventArgs e)
        {
            teStartDate.Time = DateTime.Now;
            teEndDate.Time = DateTime.Now;
            LoadData();
        }
    }
}
