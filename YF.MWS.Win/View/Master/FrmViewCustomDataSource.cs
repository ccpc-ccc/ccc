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
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmViewCustomDataSource : DevExpress.XtraEditors.XtraForm
    {
        private IStatementService statementService = new StatementService();
        private SummaryReportType reportType;

        public SummaryReportType ReportType
        {
            get { return reportType; }
            set { reportType = value; }
        }
        private DataSet dataSource;

        public DataSet DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }
        private SReportTemplate template;

        public SReportTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        public FrmViewCustomDataSource()
        {
            InitializeComponent();
        }

        private void FrmViewCustomDataSource_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            if (reportType == SummaryReportType.Custom)
            {
                if (template != null)
                {
                    DataSet ds = statementService.GetCustomSummaryDesignResource(template);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        gcWeight.DataSource = ds.Tables[0];
                    }
                }
            }
            else 
            {
                if (dataSource != null && dataSource.Tables.Count > 0)
                {
                    gcWeight.DataSource = dataSource.Tables[0];
                }
            }
        }
    }
}