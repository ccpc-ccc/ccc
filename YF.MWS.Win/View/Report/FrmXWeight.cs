using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Collections;
using YF.MWS.Win.Uc;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraPrinting;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Report
{
    public partial class FrmXWeight : BaseForm
    {
        private XtraReport report = new XtraReport();
        public object DataSource;
        public string DataMember { get; set; }
        public string ReportFilePath;
        public Hashtable Parameters { get; set; }
        public string DisplayName { get; set; }

        public FrmXWeight()
        {
            InitializeComponent();
        }

        private void btnItemDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            XRDesignRibbonForm form = new XRDesignRibbonForm();
            form.WindowState = FormWindowState.Maximized;
            form.OpenReport(report);
            form.Show();
        }

        private void BindReport()
        {
            if (System.IO.File.Exists(this.ReportFilePath))
                this.report.LoadLayout(this.ReportFilePath);
            if (!string.IsNullOrEmpty(DisplayName))
            {
                this.report.DisplayName = DisplayName;
            }
            this.report.DataSource = this.DataSource;
            if (!string.IsNullOrEmpty(DataMember))
            {
                this.report.DataMember = DataMember;
            }
            this.report.Parameters.Clear();
            if (this.Parameters != null)
            {
                foreach (string k in this.Parameters.Keys)
                {
                    var par = new DevExpress.XtraReports.Parameters.Parameter();
                    par.Name = k;
                    par.Value = this.Parameters[k];
                    par.Visible = false;
                    this.report.Parameters.Add(par);
                }
            }
            this.report.ShowPrintMarginsWarning = false;
            this.report.ReportUnit = ReportUnit.TenthsOfAMillimeter;
            pcReport.PrintingSystem = report.PrintingSystem;
            report.CreateDocument(true);
        }

        private void frmXReport_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm())
            { 
                BindReport();
            }
        }
    }
}