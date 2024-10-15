using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Win.View.Report;
using YF.MWS.BaseMetadata;
using System.IO;
using YF.MWS.Metadata;
using YF.Utility;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.Log;
using YF.MWS.Win.Uc; 

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmFinanceBatchAudit : BaseForm
    {
        private DataTable dtSource;
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IReportService reportService = new ReportService();
        private IWeightExtService weightExtService = new WeightExtService();
        private GridCheckMarksSelection chkWeight;
        private List<string> lstWeightId = new List<string>();

        public List<string> LstWeightId
        {
            get { return lstWeightId; }
            set { lstWeightId = value; }
        }
         

        public FrmFinanceBatchAudit()
        {
            InitializeComponent();
        }

        private void FrmFinanceBatchAudit_Load(object sender, EventArgs e)
        {
            BindData();
            SetSummaryField();
        }

        private void SetSummaryField() 
        {
            if (Program._cfg.FinanceSettle == null || string.IsNullOrEmpty(Program._cfg.FinanceSettle.SummaryFieldNames))
            {
                return;
            }
            string[] fields = Program._cfg.FinanceSettle.SummaryFieldNames.Split(';');
            foreach (string f in fields) 
            {
                if (DxHelper.ContainsField(gvWeight, f))
                {
                    gvWeight.Columns[f].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                         new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, f, "{0:f2}")});
                } 
            }
        }

        private void BindData() 
        {
            dtSource = weightQueryService.GetFinanceList(lstWeightId,CurrentClient.Instance.ViewId);
            gcWeight.DataSource = dtSource;
            gcWeight.RefreshDataSource();
            gvWeight.OptionsView.ColumnAutoWidth = false;
            gvWeight.BestFitColumns();
            gvWeight.Columns[0].Visible = false;
            gvWeight.Columns[1].Visible = false;
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();
            
        }

        private void barItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barItemPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要打印的磅单");
            }
            else
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                string weightId = dr["WeightId"].ToObjectString();
                DataSet dsReport = new DataSet();
                SReportTemplate template = reportService.GetDefaultTemplate(DocumentType.FinanceSettle);
                dsReport = reportService.GetFinance(CurrentClient.Instance.ViewId, weightId);
                FrmXReport frmReport = new FrmXReport();
                if (template != null)
                {
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        if (!string.IsNullOrEmpty(template.TemplateUrl))
                        {
                            frmReport.ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                        }
                    }
                    else
                    {
                        SReportTemplate templateFind = reportService.Get(template.Id);
                        frmReport.ReportFilePath = Utility.GetReportTemplate(templateFind);
                    }
                }
                else
                {
                    frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptFinanceSettle.repx";
                }
                frmReport.DataSource = dsReport;
                frmReport.DisplayName = "财务结算单";
                frmReport.Text = "财务结算单";
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
            }
        }

        private void barItemFreightSettle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmSettle(SettleType.Freight))
            {
                Settle(SettleType.Freight);
            }
        }

        private void barItemPaymentSettle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmSettle(SettleType.Payment))
            {
                Settle(SettleType.Payment);
            }
        }

        private void barItemSettle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmSettle(SettleType.Finance))
            {
                Settle(SettleType.Finance);
            }
        }

        private bool ConfirmSettle(SettleType type) 
        {
            bool isConfirmed = false;
            string message = string.Empty;
            switch (type)
            {
                case SettleType.Finance:
                    message = "确实要结算财务吗?";
                    break;
                case SettleType.Freight:
                    message = "确实要结算运费吗?";
                    break;
                case SettleType.Payment:
                    message = "确实要结算货款吗?";
                    break;
            }
            if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes) 
            {
                isConfirmed = true;
            }
            return isConfirmed;
        }

        private void Settle(SettleType type) 
        {
            int state=1;
            BWeightExt weightExt=null;
            string message = string.Empty;
            switch (type)
            {
                case SettleType.Finance: 
                    message = "已经成功结算财务信息.";
                    break;
                case SettleType.Freight: 
                    message = "已经成功结算运费信息.";
                    break;
                case SettleType.Payment: 
                    message = "已经成功结算货款信息.";
                    break;
            }
            foreach (DataRow dr in dtSource.Rows) 
            {
                string recId= dr["WeightId"].ToObjectString();
                weightExt = weightExtService.Get(recId);
                try
                {
                    if (weightExt == null)
                    {
                        weightExt = new BWeightExt();
                        weightExt.Id = recId;
                    }
                    switch (type)
                    {
                        case SettleType.Finance:
                            weightExt.SettleState = state; 
                            break;
                        case SettleType.Freight:
                            weightExt.FreightSettleState = state; 
                            break;
                        case SettleType.Payment:
                            weightExt.PaymentSettleState = state; 
                            break;
                    }
                    weightExtService.Save(weightExt); 
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex); 
                }
            }
            MessageDxUtil.ShowTips(message);
            BindData();
        }
    }
}