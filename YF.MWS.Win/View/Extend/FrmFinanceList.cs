using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using DevExpress.XtraBars;
using YF.MWS.Metadata.Enum;
using YF.Utility.Log;
using YF.MWS.Win.View.Report;
using System.IO;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.Uc;
using DevExpress.XtraGrid.Columns;
using YF.Utility.IO;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmFinanceList : BaseForm
    {
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IWeightExtService weightExtService = new WeightExtService();
        private IReportService reportService = new ReportService();
        private GridCheckMarksSelection chkWeight;
        private DataTable dtWeight = new DataTable();
        private List<BarItem> lstItem = new List<BarItem>();
        private BWeightExt weightExt;
        private string RecId;
        public FrmFinanceList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gcWeight.DataSource;
            DataTable dtExport = dt.Copy();
            if (dtExport != null && dtExport.Rows.Count > 0 && dtExport.Columns.Count >= 2)
            {
                dtExport.Columns.RemoveAt(0);
                dtExport.Columns.RemoveAt(0);
                sfdFileSave.Filter = "Excel 文件|*.xls";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfdFileSave.FileName;
                    NPOIHelper.DataTableToExcel(dtExport, filePath, null);
                }
            }
            else
            {
                MessageDxUtil.ShowTips("没有数据可以导出.");
            }
        }

        private void SetSummaryField()
        {
            if (Program._cfg.FinanceSettle == null || string.IsNullOrEmpty(Program._cfg.FinanceSettle.SummaryFieldNames))
            {
                return;
            }
            GridColumn col = null;
            string fieldName = string.Empty;

            string[] fields = Program._cfg.FinanceSettle.SummaryFieldNames.Split(';');
            string displayFormat = "{0:F2}";
            string countDisplayFormat = "{0:F0}";
            foreach (string f in fields)
            {
                col = DxHelper.FindColumn(gvWeight, f);

                if (col != null)
                {
                    fieldName = col.FieldName;
                    gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    gvWeight.Columns[fieldName].DisplayFormat.FormatString = displayFormat;
                    if (col.ColumnType.Name == "Decimal")
                    {
                        gvWeight.Columns[fieldName].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                         new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, displayFormat)});
                        gvWeight.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, fieldName, col, displayFormat);
                    }
                    else
                    {
                        gvWeight.Columns[fieldName].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                         new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, fieldName, countDisplayFormat)});
                        gvWeight.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, fieldName, col, countDisplayFormat);
                    }
                }
            }

            gvWeight.ExpandAllGroups();
        }

        private void InitRoleControl()
        {
            lstItem.Add(barItemFreightSettle);
            lstItem.Add(barItemPaymentSettle);
            lstItem.Add(barItemAuth);
            lstItem.Add(barItemSettle);
            RoleUtil.SetBarItem(lstItem, LstModule);
        }
        private void FrmFinanceList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                teEndDate.Time = DateTime.Now;
                teStartDate.Time = DateTime.Now;
                DxHelper.BindComboBoxEdit(combFinaSettlement, SysCode.FinaSettlement, "All");
                LoadData();
                SetSummaryField();
                InitRoleControl();
            }
        }

        private void btnItemPaymentSettle_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barItemFreightSettle_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Export()
        {
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfdFileSave.FileName;
                gvWeight.ExportToXls(filePath);
            }
        }

        public void InitWeightDate()
        {
            teEndDate.Time = DateTime.Now;
            teStartDate.Time = DateTime.Now;
        }

        public void LoadData()
        {
            FinaSettlement settlement = FinaSettlement.All;
            DateType type = combDateType.SelectedIndex.ToEnum<DateType>();
            if (combFinaSettlement.EditValue != null) 
            {
                settlement = DxHelper.GetCode(combFinaSettlement).ToEnum<FinaSettlement>();
            }
            dtWeight = weightQueryService.GetFinanceList(teStartDate.Time, teEndDate.Time, settlement, type);
            gcWeight.DataSource = dtWeight;
            gcWeight.RefreshDataSource();
            
            string fieldName = "完成日期";
            if (DxHelper.ContainsField(gvWeight, fieldName))
            {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd";
                gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            fieldName = "结算日期";
            if (DxHelper.ContainsField(gvWeight, fieldName))
            {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd";
                gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            gvWeight.OptionsView.ColumnAutoWidth = false;
            gvWeight.BestFitColumns();
            gvWeight.Columns[0].Visible = false;
            gvWeight.Columns[1].Visible = false;
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();
        }

        private void barItemSettle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                using (FrmWeightSettle frmSettle = new FrmWeightSettle())
                {
                    frmSettle.RecId = dr["WeightId"].ToObjectString();
                    if (frmSettle.ShowDialog() == DialogResult.Cancel)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void barItemAuth_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() == null) 
            {
                MessageDxUtil.ShowWarning("请选择要核算的磅单.");
            }
            else
            {
                if (ConfirmSettle(SettleType.Finance))
                {
                    GetExt();
                    SaveExt(1, SettleType.Finance);
                }
            }
        }

        private void barItemFreightSettle_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要核算的磅单.");
            }
            else
            {
                if (ConfirmSettle(SettleType.Freight))
                {
                    GetExt();
                    SaveExt(1, SettleType.Freight);
                }
            }
        }

        private void barItemPaymentSettle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要核算的磅单.");
            }
            else
            {
                if (ConfirmSettle(SettleType.Payment))
                {
                    GetExt();
                    SaveExt(1, SettleType.Payment);
                }
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

        private bool ValidateSettle()
        { 
            bool isValidated = true;
            GetExt();
            if (weightExt != null)
            {
                if (weightExt.FreightSettleState == 0)
                {
                    MessageDxUtil.ShowWarning("运费尚未结清,请先完成运费结算工作.");
                    isValidated = false;
                    return isValidated;
                }
                if (weightExt.PaymentSettleState == 0)
                {
                    MessageDxUtil.ShowWarning("货款尚未结清,请先完成货款结算工作.");
                    isValidated = false;
                    return isValidated;
                }
            }
            return isValidated;
        }

        private void GetExt()
        {
            if (gvWeight.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                RecId = dr["WeightId"].ToObjectString();
                weightExt = weightExtService.Get(RecId);
            }
        }
        private void SaveExt(int state, SettleType type)
        {
            string message = string.Empty;
            try
            {
                if (weightExt == null)
                {
                    weightExt = new BWeightExt();
                    weightExt.Id = RecId;
                }
                switch (type)
                {
                    case SettleType.Finance:
                        weightExt.SettleState = state;
                        message = "已经成功结算财务信息.";
                        break;
                    case SettleType.Freight:
                        weightExt.FreightSettleState = state;
                        message = "已经成功结算运费信息.";
                        break;
                    case SettleType.Payment:
                        weightExt.PaymentSettleState = state;
                        message = "已经成功结算货款信息.";
                        break;
                }
                weightExtService.Save(weightExt);
                LoadData();
                MessageDxUtil.ShowTips(message);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存财务结算信息时发生未知错误,请重试.");
            }
        }

        private void gvWeight_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit() 
        {
            if (gvWeight.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                using (FrmWeightSettle frmSettle = new FrmWeightSettle())
                {
                    frmSettle.RecId = dr["WeightId"].ToObjectString();
                    if (frmSettle.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void barItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要打印的磅单"); 
            }
            else
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                string weightId=dr["WeightId"].ToObjectString();
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

        private void barItemBatchAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
             
        }

        private void combDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWeightDate.Text = combDateType.Text;
        }

        private void btnExortWithGV_Click(object sender, EventArgs e)
        {
            DxHelper.ExportXlsx(gvWeight);
        }
    }
}