using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Win.View.Report;
using YF.MWS.Win.View.Extend;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Win.Uc;
using YF.MWS.BaseMetadata;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using YF.Utility.IO;
using YF.Utility.Log;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Metadata.Event;
using YF.MWS.CacheService;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Metadata.Dto;
using YF.MWS.Win.View.Log;

namespace YF.MWS.Win.View.Weight {
    public partial class FrmWeightSearch : BaseForm {
        public DataTable Dt { get; set; }
        private IMasterService masterService = new MasterService();
        private IWebWeightService webWeightService = new WebWeightService();
        private IWeightViewService viewService = new WeightViewService();
        private ICardService cardService = new CardService();
        private ICarService carService = new CarService();
        private IPlanService planService = new PlanService();
        private IWeightService weightService = new WeightService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IWeightProcessService weightProcessService = new WeightProcessService();
        private IUserService userService = new UserService();
        private IReportService reportService = new ReportService();
        private IFileService fileService = new FileService();
        private ILogService logService = new LogService();
        private IStatementService statementSerivice = new StatementService();
        private WeightPrinter printer = new WeightPrinter();
        private List<LookupField> lstField = new List<LookupField>();
        private List<SWeightViewDtl> lstViewDetail = new List<SWeightViewDtl>();
        private List<Component> lstComponent = new List<Component>();
        private List<BarItem> lstItem = new List<BarItem>();
        private GridCheckMarksSelection chkWeight;
        private StringBuilder sbCondition = new StringBuilder();
        private string tableName = "B_Weight";
        private DateTime dtStart = DateTime.Now;
        private DateTime dtEnd = DateTime.Now;
        private string sql;
        private StringBuilder sbConditionTareTime = new StringBuilder();
        private StringBuilder sbConditionGrossTime = new StringBuilder();
        private List<QueryCondition> lstExtendCondition = new List<QueryCondition>();
        private QPage page = null;
        private bool startReWeightPrint = false;
        private bool startPage = false;
        private int pageSize = 25;
        private string supplierId;
        private bool canSaveLayout = false;
        /// <summary>
        /// 启用磅单打印次数限制
        /// </summary>
        public bool startPrintCountLimit = false;
        /// <summary>
        /// 每个磅单最多打印次数
        /// </summary>
        public int maxPrintCount = 0;
        private string weightPrinterName = string.Empty;
        /// <summary>
        /// 启用计划单限制功能
        /// </summary>
        private bool startPlan = false;
        private string layoutXmlPath = Path.Combine(Application.StartupPath, "Layerout", "WeightSearchNew.xml");

        public FrmWeightSearch() {
            InitializeComponent();
        }

        private void FrmWeightSearch_Load(object sender, EventArgs e) {
            using (Utility.GetWaitForm()) {
                BindData();
                teStartDate.Time=DateTime.Now.AddDays(-1);
                teEndDate.Time = DateTime.Now;
                InitRoleControl();
                InitControl();
                InitCommandBar();
                LoadEmpty();
            }
        }

        private void InitControl() {
            ucPage.PageChanged += ucPage_PageChanged;
            ucPage.Page.PageSize = pageSize;
            ucPage.Visible = startPage;
        }

        private void ucPage_PageChanged(object sender, PageChangedEventArgs e) {
            page.PageIndex = e.Page.PageIndex;
            Search();
            e.Page.TotalRows = page.TotalRows;
        }

        private void InitRoleControl() {
            lstItem.Add(barItemAdd);
            lstItem.Add(barItemDelete);
            lstItem.Add(barItemPreviewWeight);
            lstItem.Add(barItemRecover);
            lstItem.Add(barItemImport);
            lstItem.Add(barItemExport);
            lstItem.Add(barItemInvaild);
            lstItem.Add(barItemRePrintWeight);
            lstItem.Add(barItemRePrintWeight);
            lstItem.Add(barItemModify);
            lstItem.Add(barItemPreviewWeight);
            lstItem.Add(barSubItemPrint);
            RoleUtil.SetBarItem(lstItem, LstModule);
        }

        private void barItemVedio_ItemClick(object sender, ItemClickEventArgs e) {
            string weightId = gvWeight.GetFocusedRowCellValue("WeightId").ToObjectString();
            if (string.IsNullOrEmpty(weightId)) {
                MessageDxUtil.ShowWarning("请选择要浏览的磅单.");
                return;
            }
            int count = fileService.GetCount(weightId, tableName, FileBusinessType.Video);
            if (count == 0) {
                MessageDxUtil.ShowWarning("该磅单没有视频文件.");
                return;
            }
            using (FrmViewVideo frmVideo = new FrmViewVideo()) {
                frmVideo.RecId = weightId;
                frmVideo.ShowDialog();
            }
        }

        private void barItemGraphic_ItemClick(object sender, ItemClickEventArgs e) {
            string weightId = gvWeight.GetFocusedRowCellValue("Id").ToObjectString();
            if (string.IsNullOrEmpty(weightId)) {
                MessageDxUtil.ShowWarning("请选择要浏览的磅单.");
                return;
            }
            /*int count = fileService.GetCount(weightId, tableName, BusinessType.Graphic);
            if (count == 0)
            {
                MessageDxUtil.ShowWarning("该磅单没有图片文件.");
                return;
            }*/
            using (FrmViewGraphic frmGraphic = new FrmViewGraphic()) {
                frmGraphic.RecId = weightId;
                frmGraphic.ShowDialog();
            }
        }

        private void BindData() {
            if (Cfg != null) {
                if (Cfg.Print != null) {
                    startPrintCountLimit = Cfg.Print.StartPrintCountLimit;
                    maxPrintCount = Cfg.Print.MaxPrintCount;
                    weightPrinterName = Cfg.Print.WeightPrinterName;
                }
                if (Cfg.Weight != null) {
                    startPlan = Cfg.Weight.StartPlan;
                }
            }
            DataSet ds = new DataSet();
            ds.ReadXml(Path.Combine(Application.StartupPath, "Config", "SearchCondition.xml"));
            List<QueryCondition> lst = new List<QueryCondition>();
            if (Cfg != null) {
                if (Cfg.Print != null && Cfg.Print.StartReWeightTemplate) {
                    startReWeightPrint = Cfg.Print.StartReWeightTemplate;
                }
                if (Cfg.Page != null) {
                    startPage = Cfg.Page.Start;
                    if (Cfg.Page.PageSize > 0) {
                        pageSize = Cfg.Page.PageSize;
                    }
                }
            }
            page = new QPage(pageSize);
        }

        private WeightQueryCondition GetCondition() {
            WeightQueryCondition qc = new WeightQueryCondition();
            qc.Columns = viewService.GetShow2DetailList(ViewType.Weight);
            if (rgRecordType.SelectedIndex == 0) {
                qc.RowState = RowState.Add;
            }
            if (rgRecordType.SelectedIndex == 1) {
                qc.RowState = RowState.Delete;
            }
            if (rgSearchType.SelectedIndex == 0) {
                qc.FinishState = FinishState.Finished;
            }
            if (rgSearchType.SelectedIndex == 1) {
                qc.FinishState = FinishState.Unfinished;
            }
            if (rgPayType.SelectedIndex == 0) {
                qc.PayType = "UnSettled";
            }else if (rgPayType.SelectedIndex == 1) {
                qc.PayType = "Settled";
            }
            if (rdBizType.SelectedIndex == 0) {
                qc.WarehBizType = "ChuKu";
            }else if (rdBizType.SelectedIndex == 1) {
                qc.WarehBizType = "RuKu";
            }
            qc.StartTime = teStartDate.Time;
            qc.EndTime = teEndDate.Time;
            qc.CustomerName=txtCustomerName.Text;
            qc.CarNo = txtCar.Text;
            return qc;
        }

        private void LoadEmpty() {
            WeightQueryCondition qc = new WeightQueryCondition() { IsEmpty = true };
            qc.Columns = viewService.GetShow2DetailList(ViewType.Weight);
            WeightQueryResult result = weightQueryService.Query(qc, startPage);
            if (result != null) {
                page.TotalRows = result.Total;
                ucPage.Page.TotalRows = page.TotalRows;
                gcWeight.DataSource = result.Weight;
                gcWeight.RefreshDataSource();
            }
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();
            gvWeight.OptionsView.ColumnAutoWidth = false;
            gvWeight.BestFitColumns();
            string fieldName = "CreateTime";
            if (DxHelper.ContainsField(gvWeight, fieldName)) {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            fieldName = "FinishTime";
            if (DxHelper.ContainsField(gvWeight, fieldName)) {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            if (File.Exists(layoutXmlPath)) {
                gvWeight.RestoreLayoutFromXml(layoutXmlPath);
            }
            gvWeight.Columns[0].Visible = false;
            gvWeight.Columns[1].Visible = false;

        }

        private void Search() {
            using (Utility.GetWaitForm("正在查询磅单,请稍后...")) {
                WeightQueryResult result = weightQueryService.Query(GetCondition(), startPage);
                if (result != null) {
                    page.TotalRows = result.Total;
                    ucPage.Page.TotalRows = page.TotalRows;
                    gcWeight.DataSource = result.Weight;
                    gcWeight.RefreshDataSource();
                    string fieldName = "CreateTime";
                    if (DxHelper.ContainsField(gvWeight, fieldName)) {
                        gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gvWeight.Columns[fieldName].Width = 200;
                    }
                    fieldName = "FinishTime";
                    if (DxHelper.ContainsField(gvWeight, fieldName)) {
                        gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gvWeight.Columns[fieldName].Width = 200;
                    }
                    fieldName = "TareTime";
                    if (DxHelper.ContainsField(gvWeight, fieldName)) {
                        gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gvWeight.Columns[fieldName].Width = 200;
                    }
                    fieldName = "GrossTime";
                    if (DxHelper.ContainsField(gvWeight, fieldName)) {
                        gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gvWeight.Columns[fieldName].Width = 200;
                    }
                    fieldName = "AdditionalTime";
                    if (DxHelper.ContainsField(gvWeight, fieldName)) {
                        gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gvWeight.Columns[fieldName].Width = 200;
                    }
                    gvWeight.OptionsView.ColumnAutoWidth = false;
                    gvWeight.BestFitColumns();
                }
                chkWeight.ClearSelection();
                if (File.Exists(layoutXmlPath)) {
                    gvWeight.RestoreLayoutFromXml(layoutXmlPath);
                }
                getTotal();
            }
        }
        private void getTotal() {
            decimal total = 0;
            decimal totalMoney = 0;
            for (int i = 0; i < gvWeight.RowCount; i++) {
                DataRow row = gvWeight.GetDataRow(i);
                if (!row.Table.isColumns(new string[] { "WarehBizType", "SuttleWeight", "d2", "UnitMoney" })) return;
                if (row["WarehBizType"].ToString() == WarehBizType.RuKu.ToDescription()) {
                     total += row["SuttleWeight"].ToDecimal();
                    totalMoney += row["UnitMoney"].ToDecimal();
                } else if (row["WarehBizType"].ToString() == WarehBizType.ChuKu.ToDescription()) {
                    total -= row["SuttleWeight"].ToDecimal();
                    totalMoney -= row["UnitMoney"].ToDecimal();
                }
            }
                lbTotalSuttleWeight.Text = total.ToString();
                lbTotalMoney.Text = totalMoney.ToString();
        }

        private void InitCommandBar() {
            var lstTemplate = reportService.GetTemplateList(TemplateType.Report, SummaryReportType.Weight.ToString());
            var lstBarItem = new List<BarButtonItem>();
            BarButtonItem item;
            foreach (var template in lstTemplate) {
                item = new BarButtonItem();
                item.Caption = template.TemplateName;
                item.Tag = template.Id;
                item.ItemClick += item_ItemClick;
                lstBarItem.Add(item);
            }
            barSubItemPrint.AddItems(lstBarItem.ToArray());
        }

        void item_ItemClick(object sender, ItemClickEventArgs e) {
            if (e.Item.Tag != null) {
                PrintAmountReport(e.Item.Tag.ToObjectString());
            }
        }

        private Hashtable GetParameter() {
            Hashtable hash = new Hashtable();
            hash.Add("开始时间", dtStart);
            hash.Add("结束时间", dtEnd);
            hash.Add("报表日期", DateTime.Now);
            return hash;
        }

        private void PrintAmountReport(string templateId) {
            SReportTemplate template = reportService.Get(templateId);
            DataSet dsReport = new DataSet();
            dsReport = reportService.GetWeightSearch(CurrentClient.Instance.ViewId, GetCondition());
            DataTable dt = null;
            if (!string.IsNullOrEmpty(supplierId) && supplierId.Length > 0) {
                dt = masterService.GetCustomerTable(supplierId);
                if (dt != null) {
                    dsReport.Tables.Add(dt);
                    if (dsReport.Tables.Count > 1) {
                        dsReport.Tables[1].TableName = "供货商";
                    }
                }
            }
            if (template != null && !string.IsNullOrEmpty(template.SubReportType)) {
                WeightSubReportType subType = template.SubReportType.ToEnum<WeightSubReportType>();
                if (subType != WeightSubReportType.Weight && subType != WeightSubReportType.WeightDay && subType != WeightSubReportType.WeightMonth) {
                    dsReport.Tables.Clear();
                    dt = statementSerivice.GetWeightDataSource(subType, GetCondition());
                    if (dt != null) {
                        dsReport.Tables.Add(dt);
                    }
                }
            }
            FrmXReport frmReport = new FrmXReport();
            string reportPath = Application.StartupPath + "\\Report\\Weight\\rptWeightSummary.repx";
            if (template != null) {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                    reportPath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                } else {
                    reportPath = Utility.GetReportTemplate(template);
                }
            }
            frmReport.Parameters = GetParameter();
            frmReport.ReportFilePath = reportPath;
            if (dsReport != null && dsReport.Tables.Count > 0) {
                frmReport.DataMember = dsReport.Tables[0].TableName;
            }
            frmReport.DataSource = dsReport;
            frmReport.DisplayName = "磅单统计报表";
            frmReport.Text = "磅单统计报表";
            frmReport.WindowState = FormWindowState.Maximized;
            frmReport.StartPosition = FormStartPosition.CenterScreen;
            frmReport.ShowDialog();
        }

        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e) {
            DataTable dtExport = weightQueryService.Query(GetCondition(),false).Weight;
            if (dtExport != null) {
                if (dtExport.Columns.Contains("ViewId")) dtExport.Columns.Remove("ViewId");
                if (dtExport.Columns.Contains("WeightId")) dtExport.Columns.Remove("WeightId");
                sfdFileSave.Filter = "Excel 文件|*.xls";
                if (sfdFileSave.ShowDialog() == DialogResult.OK) {
                    string filePath = sfdFileSave.FileName;
                    bool isSuccess = NPOIHelper.DataTableToExcel(dtExport, filePath, null);
                    if (isSuccess) {
                        MessageDxUtil.ShowTips("磅单成功导出.");
                    } else {
                        MessageDxUtil.ShowError("磅单导出失败.");
                    }
                }
            } else {
                MessageDxUtil.ShowTips("没有磅单可以导出.");
            }
        }

        private void barItempPrintWeight_ItemClick(object sender, ItemClickEventArgs e) {
            if (CurrentUser.Instance.Powers != null && CurrentUser.Instance.Powers.Contains("p2_5")) {
                MessageDxUtil.ShowError("权限不足，不允许打印");
            }
            if (gvWeight.GetFocusedRow() == null) {
                MessageDxUtil.ShowWarning("请选择要重印的磅单!");
            }
            string weightId = gvWeight.GetFocusedRowCellValue("WeightId").ToString();
            string viewId = gvWeight.GetFocusedRowCellValue("ViewId").ToString();

            Print(weightId, viewId);
        }

        private bool CanPrint(BWeight weight) {
            bool canPrint = true;
            if (startPrintCountLimit && weight != null && weight.PrintCount >= maxPrintCount) {
                canPrint = false;
            }
            return canPrint;
        }

        private void Print(string weightId, string viewId, bool isBatch = false) {
            if (gvWeight.GetFocusedRow() == null) {
                MessageDxUtil.ShowWarning("请选择要重印的磅单！");
            } else {
                BWeight weight = weightService.Get(weightId);
                bool isValidted = true;
                if (weight == null) {
                    if (!isBatch) {
                        MessageDxUtil.ShowWarning("磅单不存在无法打印");
                        return;
                    }
                    isValidted = false;
                }
                bool canPrint = CanPrint(weight);
                if (!canPrint) {
                    if (!isBatch) {
                        MessageDxUtil.ShowWarning("此磅单超过打印限制次数不能再次打印");
                        return;
                    }
                    isValidted = false;
                }
                Hashtable hashtable = GetParams();
                if (isValidted) {
                    if (startReWeightPrint) {
                        PrintUtil.PrintWeightReport(viewId, weightId, DocumentType.ReWeight, reportService, hashtable, weightPrinterName);
                    } else {
                        PrintUtil.PrintWeightReport(viewId, weightId, DocumentType.Weight, reportService, hashtable, weightPrinterName);
                    }
                    weightService.UpdatePrint(weightId);
                }
            }
        }

        private void Preview() {
            if (gvWeight.GetFocusedDataRow() == null) {
                MessageDxUtil.ShowWarning("请选择要预览的磅单！");
            } else {
                string weightId = gvWeight.GetFocusedRowCellValue("WeightId").ToString();
                string viewId = gvWeight.GetFocusedRowCellValue("ViewId").ToString();
                DataSet dsReport = new DataSet();
                SReportTemplate template = null;
                if (startReWeightPrint) {
                    template = reportService.GetDefaultTemplate(DocumentType.ReWeight);
                    if (template == null || template.Id == null || template.Id.Length == 0) {
                        template = reportService.GetDefaultTemplate(DocumentType.Weight);
                    }
                } else {
                    template = reportService.GetDefaultTemplate(DocumentType.Weight);
                }
                dsReport = reportService.GetWeight(viewId, weightId);
                FrmXWeight frmReport = new FrmXWeight();
                if (template != null) {
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                        if (!string.IsNullOrEmpty(template.TemplateUrl)) {
                            frmReport.ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                        }
                    } else {
                        SReportTemplate templateFind = reportService.Get(template.Id);
                        frmReport.ReportFilePath = Utility.GetReportTemplate(templateFind);
                    }
                } else {
                    frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
                }
                frmReport.Parameters= GetParams();
                frmReport.DataSource = dsReport;
                frmReport.DisplayName = "磅单报表";
                frmReport.Text = "磅单报表";
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
            }
        }
        private Hashtable GetParams() {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("当前时间", DateTime.Now);
            return hashtable;
        }
        private void barItemInvaild_ItemClick(object sender, ItemClickEventArgs e) {
            List<DataRow> listWeight = chkWeight.GetSelectedDataRow();
            if (listWeight == null || listWeight.Count == 0) {
                MessageDxUtil.ShowWarning("请选择要作废的磅单！");
            } else {
                string weightId;
                string weightNo = string.Empty;
                foreach (DataRow row in listWeight) {
                    weightId = row["Id"].ToObjectString();
                    weightNo = row["WeightNo"].ToObjectString();
                    bool isUpdated = weightService.UpdateWeight(weightId, RowState.Delete);
                    if (isUpdated) {
                        string desc = string.Format("作废磅单号:{0}", weightNo);
                        logService.Add(LogActionType.Weight, weightId, weightNo, desc);
                    }
                }
                MessageDxUtil.ShowTips("选择的磅单已经作废!");
                barItemQuery.PerformClick();
            }
        }

        private void barItemRecover_ItemClick(object sender, ItemClickEventArgs e) {
            List<DataRow> listWeight = chkWeight.GetSelectedDataRow();
            if (listWeight == null || listWeight.Count == 0) {
                MessageDxUtil.ShowWarning("请选择要恢复的磅单!");
            } else {
                string weightId;
                string weightNo = string.Empty;
                string desc;
                WeightUpdate update = new WeightUpdate();
                update.RowState = RowState.Edit;
                foreach (DataRow row in listWeight) {
                    weightId = row["WeightId"].ToObjectString();
                    weightNo = row["WeightNo"].ToObjectString();
                    bool isUpdated = weightService.UpdateWeight(weightId, RowState.Edit);
                    if (isUpdated) {
                        if (startPlan) {
                            BWeight weight = weightService.Get(weightId);
                            if (weight != null) {
                                planService.Update(weight);
                            }
                        }
                        update.WeightIds.Add(weightId);
                        desc = string.Format("恢复磅单号:{0}", weightNo);
                        logService.Add(LogActionType.Weight, weightId, weightNo, desc);
                    }
                }
                MessageDxUtil.ShowTips("选择的磅单已经恢复！");
                barItemQuery.PerformClick();
            }
        }

        private void barItemDelete_ItemClick(object sender, ItemClickEventArgs e) {
            List<DataRow> listWeight = chkWeight.GetSelectedDataRow();
            if (listWeight == null || listWeight.Count == 0) {
                MessageDxUtil.ShowWarning("请选择要删除的磅单!");
            } else {
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除所选磅单吗?此操作不可撤销,请慎重操作.") == DialogResult.Yes) {
                    string weightId;
                    string weightNo = string.Empty;
                    string desc;
                    foreach (DataRow row in listWeight) {
                        weightId = row["Id"].ToObjectString();
                        weightNo = row["WeightNo"].ToObjectString();
                        BWeight weight = weightService.Get(weightId);
                        bool isDeleted = weightService.DeleteWeight(weight);
                        if (isDeleted) {
                            if (startPlan) {
                                if (weight != null) {
                                    planService.Update(weight);
                                }
                            }
                            weightProcessService.Delete(weightId);
                            desc = string.Format("删除磅单号:{0}", weightNo);
                            logService.Add(LogActionType.Weight, weightId, weightNo, desc);
                        }
                    }
                    MessageDxUtil.ShowTips("选择的磅单已经删除！");
                    barItemQuery.PerformClick();
                }
            }
        }

        private void barItemModify_ItemClick(object sender, ItemClickEventArgs e) {
            DataRow listWeight = gvWeight.GetFocusedDataRow();
            if (listWeight==null) {
                MessageDxUtil.ShowError("请选择数据");
                return;
            }
            using (FrmWeightDetail frmDetail = new FrmWeightDetail()) {
                frmDetail.RecId = listWeight["Id"].ToObjectString();
                if (frmDetail.ShowDialog() == DialogResult.OK) {
                    Search();
                }
            }
        }

        private void barItemQuery_ItemClick(object sender, ItemClickEventArgs e) {
            page.PageIndex = 0;
            Search();
            ucPage.InitControl();
        }

        private void barItemImport_ItemClick(object sender, ItemClickEventArgs e) {
            try {
                ofdFileImport.Filter = "Excel 文件|*.xls";
                if (ofdFileImport.ShowDialog() == DialogResult.OK) {
                    string filePath = ofdFileImport.FileName;
                    DataTable dt = NPOIHelper.GetDataTable(filePath);
                    //weightService.Import(dt, CurrentClient.Instance.ViewId,Cfg.WeightNo);
                    weightService.ImportNew(dt, Cfg);
                    MessageDxUtil.ShowTips("成功导入磅单数据");
                    barItemQuery.PerformClick();
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError(string.Format("导入磅单数据过程中发生未知错误:{0}", ex.Message));
            }
        }

        private void barItemPreviewWeight_ItemClick(object sender, ItemClickEventArgs e) {
            Preview();
        }

        private void gvWeight_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e) {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0) {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void barItemExportGv_ItemClick(object sender, ItemClickEventArgs e) {
            DxHelper.ExportXlsx(gvWeight);
        }

        private void barItemAdd_ItemClick(object sender, ItemClickEventArgs e) {
            using (FrmWeightDetail frmDetail = new FrmWeightDetail()) {
                if (frmDetail.ShowDialog() == DialogResult.OK) {
                    barItemQuery.PerformClick();
                }
            }
        }

        private void FrmWeightYcSearch_FormClosing(object sender, FormClosingEventArgs e) {
            string dirPath = Path.Combine(Application.StartupPath, "Layerout");
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            gvWeight.SaveLayoutToXml(layoutXmlPath);
        }

        private void barItemDownloadTemplate_ItemClick(object sender, ItemClickEventArgs e) {
            if (sfdFileSave.ShowDialog() == DialogResult.OK) {
                string filePath = sfdFileSave.FileName;
                string templatePath = Path.Combine(Application.StartupPath, "Config", "template.xls");
                File.Copy(templatePath, filePath);
                MessageDxUtil.ShowTips("成功下载导入磅单模板,请按模板导入磅单");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            barItemQuery.PerformClick();
        }

        private void barItemLog_ItemClick(object sender, ItemClickEventArgs e) {
            if (gvWeight.GetFocusedRow() != null) {
                string weightId = gvWeight.GetFocusedRowCellValue("WeightId").ToString();
                FrmRecLogList frmLog = new FrmRecLogList();
                frmLog.RecId = weightId;
                frmLog.ShowDialog();
            }
        }

        private void barItemBatchPrint_ItemClick(object sender, ItemClickEventArgs e) {
            List<DataRow> listWeight = chkWeight.GetSelectedDataRow();
            if (listWeight == null || listWeight.Count == 0) {
                MessageDxUtil.ShowWarning("请选择要重印的磅单！");
            } else {
                foreach (DataRow row in listWeight) {
                    string weightId = row["WeightId"].ToObjectString();
                    string viewId = row["ViewId"].ToObjectString();
                    Print(weightId, viewId, true);
                }
            }
        }

        private void barItemExportWithGv_ItemClick(object sender, ItemClickEventArgs e) {
            DxHelper.ExportXlsx(gvWeight);
        }

        private void gvWeight_CustomColumnDisplayText_1(object sender, CustomColumnDisplayTextEventArgs e) {
            if (e.Column.FieldName == "PayType") {
                switch (e.Value.ToString()) {
                    case "Settled":
                        e.DisplayText = "已结算";
                        break;
                    case "UnSettled":
                        e.DisplayText = "未结算";
                        break;
                }
            }
        }

        private void gvWeight_Layout(object sender, EventArgs e) {
            if (canSaveLayout) {
                SaveLayout();
            }
        }
        /// <summary>
        /// 保存控件布局配置
        /// </summary>
        public void SaveLayout() {
            string dirPath = Path.Combine(Application.StartupPath, "Layerout");
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            gvWeight.SaveLayoutToXml(layoutXmlPath);
        }

        private void gvWeight_GotFocus(object sender, EventArgs e) {
            canSaveLayout = true;
        }

        private void gvWeight_LostFocus(object sender, EventArgs e) {
            canSaveLayout = false;
        }
    }
}