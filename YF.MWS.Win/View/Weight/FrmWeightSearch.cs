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
using YF.MWS.Metadata.Cfg;

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
        private StringBuilder sbCondition = new StringBuilder();
        private string tableName = "B_Weight";
        private DateTime dtStart = DateTime.Now;
        private DateTime dtEnd = DateTime.Now;
        private StringBuilder sbConditionTareTime = new StringBuilder();
        private StringBuilder sbConditionGrossTime = new StringBuilder();
        private List<QueryCondition> lstExtendCondition = new List<QueryCondition>();
        private string supplierId;
        private bool canSaveLayout = false;
        private int Index;
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

        public FrmWeightSearch(int index) {
            InitializeComponent();
            Index = index;
        }

        private void FrmWeightSearch_Load(object sender, EventArgs e) {
            using (Utility.GetWaitForm()) {
                BindData();
                teStartDate.Time=DateTime.Now.AddDays(-1);
                teEndDate.Time = DateTime.Now;
                LoadDevices();
                InitRoleControl();
                Search();
            }
        }

        private void InitRoleControl() {
            lstItem.Add(barItemAdd);
            //lstItem.Add(barItemExport);
            RoleUtil.SetBarItem(lstItem, LstModule);
        }
        private void LoadDevices() {
            List<ListItem> lstDevices = new List<ListItem>();
            lstDevices.Add(new ListItem() {
                Text = "全部",
                Value=""
            });
            int i = 0;
            foreach(DeviceCfg device in Program._cfg.Device) {
                if (device.StartDevice) {
                    lstDevices.Add(new ListItem() {
                        Text=device.Name,
                        Value=i.ToString()
                    });
                }
            }
           if(Index>=0) DxHelper.BindComboBoxEdit(cmbDevice, lstDevices, Index.ToString());

        }

        private void BindData() {
            if (Program._cfg != null) {
                if (Program._cfg.Print != null) {
                    startPrintCountLimit = Program._cfg.Print.StartPrintCountLimit;
                    maxPrintCount = Program._cfg.Print.MaxPrintCount;
                    weightPrinterName = Program._cfg.Print.WeightPrinterName;
                }
                if (Program._cfg.Weight != null) {
                    startPlan = Program._cfg.Weight.StartPlan;
                }
            }
            DataSet ds = new DataSet();
            ds.ReadXml(Path.Combine(Application.StartupPath, "Config", "SearchCondition.xml"));
        }

        private string GetCondition() {
            string where = $" and a.CreateTime>='{teStartDate.Time}' and a.CreateTime <='{teEndDate.Time}'";
            if (!string.IsNullOrEmpty(cmbDevice.GetStrValue())) {
                where += $" and a.CompanyId='{cmbDevice.GetStrValue()}'";
            }
            return where;
        }

        private void Search() {
            using (Utility.GetWaitForm("正在查询磅单,请稍后...")) {
                List<BWeight> result = weightQueryService.GetBWeights(GetCondition());
                if (result != null) {
                    gcWeight.DataSource = result;
                    gcWeight.RefreshDataSource();
                    string fieldName = "CreateTime";
                    if (DxHelper.ContainsField(gvWeight, fieldName)) {
                        gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        //gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gvWeight.Columns[fieldName].Width = 300;
                    }
                    gvWeight.OptionsView.ColumnAutoWidth = false;
                    gvWeight.BestFitColumns();
                }
            }
        }
        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e) {
            DataTable dtExport = weightQueryService.GetBWeightTable(GetCondition());
            if (dtExport != null) {
                foreach(DataColumn column in dtExport.Columns) {
                    column.Caption = "";
                }
                foreach (GridColumn col in gvWeight.Columns) {
                    if (dtExport.Columns.Contains(col.FieldName) && col.Visible) dtExport.Columns[col.FieldName].Caption = col.Caption;
                }
                for (int i = dtExport.Columns.Count - 1; i >= 0; i--) {
                    if (string.IsNullOrEmpty(dtExport.Columns[i].Caption)) dtExport.Columns.RemoveAt(i);
                }
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

        private void barItemQuery_ItemClick(object sender, ItemClickEventArgs e) {
            Search();
        }

        private void gvWeight_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e) {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0) {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void barItemAdd_ItemClick(object sender, ItemClickEventArgs e) {
            using (FrmWeightDetail frmDetail = new FrmWeightDetail()) {
                if (frmDetail.ShowDialog() == DialogResult.OK) {
                    barItemQuery.PerformClick();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            barItemQuery.PerformClick();
        }

        private void barItemExportWithGv_ItemClick(object sender, ItemClickEventArgs e) {
            DxHelper.ExportXlsx(gvWeight);
        }

        private void gvWeight_CustomColumnDisplayText_1(object sender, CustomColumnDisplayTextEventArgs e) {
        }
    }
}