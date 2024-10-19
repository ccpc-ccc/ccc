using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Metadata.Event;
using System.IO;
using YF.MWS.SQliteService;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Dto;
using DevExpress.XtraGrid.Columns;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.Utility.Log;
using YF.MWS.Win.View.Weight;
using YF.MWS.Win.View.UI;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraExport.Helpers;
using YF.MWS.Db.Server;

namespace YF.MWS.Win.Uc
{
    public partial class MainWeightList : UserControl
    {
        private IWeightService weightService;
        private IWebWeightService webWeightService=new WebWeightService();
        private ILogService logService = new LogService();
        private IWeightQueryService weightQueryService;
        private IWeightViewService viewService = new WeightViewService();
        private GridCheckMarksSelection chkWeight;
        public event EventHandler FinishWeight;
        public event EventHandler FocusRowChanged;
        private List<QWeight> lst=new List<QWeight>();
        public event WeightFocusedRowChangedEventHandler WeightFocusedRowChanged;
        public event WeightDoubleClickEventHandler WeightDoubleClick;
        private string layoutXmlPath = Path.Combine(Application.StartupPath, "Layerout", "MainWeightList.xml");
        //private List<SWeightViewDtl> columns = null;
        private SysCfg cfg = null;
        private bool startWeightPay = false;
        //private bool startBatchWeight = false;
        private bool canSaveLayout = false;
        /// <summary>
        /// 司磅员启用磅单过滤
        /// </summary>
        private bool startWeighterDataFilter = false;
        /// <summary>
        /// 是否显示治超模式
        /// </summary>
        public bool ShowOverWeightMode { get; set; }

        public IWeightService WeightService
        {
            get { return weightService; }
            set { weightService = value; }
        }
        public IWeightQueryService WeightQueryService
        {
            get { return weightQueryService; }
            set { weightQueryService = value; }
        }

        public string CurrentViewId
        {
            get
            {
                return CurrentClient.Instance.ViewId;
            }
        }

        public int CurrentWeightPrintCount
        {
            get
            {
                if (gvWeight.GetFocusedDataRow() != null)
                {
                    return gvWeight.GetFocusedRowCellValue("PrintCount").ToInt();
                }
                else
                {
                    return 0;
                }
            }
        }

        public string CurrentQcNo
        {
            get
            {
                if (gvWeight.GetFocusedDataRow() != null)
                {
                    string qcNo = gvWeight.GetFocusedRowCellValue("QcNo").ToObjectString();
                    return qcNo;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string CurrentWeightId 
        {
            get 
            {
                if (gvWeight.GetFocusedDataRow() != null)
                {
                    return gvWeight.GetFocusedRowCellValue("Id").ToObjectString();
                }
                else 
                {
                    return string.Empty;
                }
            }
        }

        public MainWeightList()
        {
            InitializeComponent();
            gcWeight.ContextMenuStrip = this.contextMenuStrip1;
            //gvWeight.HorzScrollVisibilly = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
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

        public void InitWeightDate()
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    teEndDate.Time = DateTime.Now;
                    teStartDate.Time = DateTime.Now.AddDays(-1);
                }));
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void LoadData()
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    Search();
                }));
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        private void Search()
        {
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.AppendFormat(" and a.RowState != {0} ", (int)RowState.Delete);
            int finishState = combFinishState.SelectedIndex;
            if (teStartDate.Time != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime>=datetime('{0}') ", teStartDate.Time.ToString("yyyy-MM-dd 00:00:00"));
                }
                else
                {
                    sbCondition.AppendFormat("and a.FinishTime>='{0}' ", teStartDate.Time.ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (teEndDate.Time != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime<datetime('{0}') ", teEndDate.Time.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
                else
                {
                    sbCondition.AppendFormat("and a.FinishTime<'{0}'", teEndDate.Time.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (finishState != 2)
            {
                sbCondition.AppendFormat("and a.FinishState='{0}'", finishState);
            }
            if (startWeighterDataFilter)
            {
                if (CurrentUser.Instance.UserType == UserType.Weighter)
                {
                    sbCondition.AppendFormat(" and a.WeighterId='{0}'", CurrentUser.Instance.Id);
                }
            }
            if (!cfg.Weight.ShareWeight) {
                sbCondition.AppendFormat(" and a.CompanyId='{0}'", CurrentUser.Instance.CompanyId);
            }
            if (txtCar.Text.ToTrim() != "") {
                sbCondition.AppendFormat("and a.CarNo like '%{0}%'", txtCar.Text.ToTrim());
            }
            TopWeightQuery query = new TopWeightQuery() { Condition=sbCondition.ToString(), TopN=0, StartWeightPay=startWeightPay};
            WeightQueryResult result = weightQueryService.GetTopList(query);
            if (result == null)
                result = new WeightQueryResult();
            gvWeight.Columns.Clear();
            gcWeight.DataSource = result.Weight;

            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();
            string fieldName = "CreateTime";
            if (DxHelper.ContainsField(gvWeight, fieldName))
            {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            fieldName = "FinishTime";
            if (DxHelper.ContainsField(gvWeight, fieldName))
            {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            fieldName = "TareTime";
            if (DxHelper.ContainsField(gvWeight, fieldName))
            {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                //gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            fieldName = "GrossTime";
            if (DxHelper.ContainsField(gvWeight, fieldName))
            {
                gvWeight.Columns[fieldName].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                //gvWeight.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            }
            //gvWeight.GridControl.ForceInitialize();
            gvWeight.Columns[0].Visible = false;
            gvWeight.Columns[1].Visible = false;
            gcWeight.RefreshDataSource();
            //gvWeight.OptionsView.ColumnAutoWidth = true;
            gvWeight.BestFitColumns();
            gvWeight.FocusedRowHandle = -1;
            if (File.Exists(layoutXmlPath))
            {
                gvWeight.RestoreLayoutFromXml(layoutXmlPath);
            }
            /* gvWeight.OptionsView.ShowFooter = true;
             gvWeight.Columns.ColumnByFieldName("GrossWeight").SummaryItem.SummaryType = SummaryItemType.Custom;
             gvWeight.CustomSummaryCalculate += (c, e) => {
                 if (e.Item != null && (e.Item as SummaryItem) != null) {
                     GridSummaryItem item =e.Item as GridSummaryItem;
                     if (item.FieldName == "GrossWeight") {
                         if (e.SummaryProcess == CustomSummaryProcess.Finalize) {
                             e.TotalValue = 1200;
                         }
                     }
                 }
                 //e.IsTotalSummary
             };*/
            getTotal();
            gvWeight.OptionsView.ShowFooter = false;
        }
        private void getTotal() {
            decimal total = 0;
            decimal totalMoney = 0;
            for (int i = 0; i < gvWeight.RowCount; i++) {
                DataRow row = gvWeight.GetDataRow(i);
                if(row.Table.isColumns(new string[]{ "UnitMoney", "d2", "SuttleWeight", "WarehBizType" })) {
                if (row["WarehBizType"].ToString() == "入库"){
                    if (row["d2"].ToDecimal() == 0) {
                        total += row["SuttleWeight"].ToDecimal();
                    } else {
                        total += row["d2"].ToDecimal();
                    }
                        totalMoney += row["UnitMoney"].ToDecimal();
                } else if(row["WarehBizType"].ToString() == "出库") {
                    if (row["d2"].ToDecimal() == 0) {
                        total -= row["SuttleWeight"].ToDecimal();
                    } else {
                        total -= row["d2"].ToDecimal();
                    }
                        totalMoney -= row["UnitMoney"].ToDecimal();
                }
                }
                lbTotalSuttleWeight.Text = total.ToString();
                lbTotalMoney.Text = totalMoney.ToString();
            }
        }
        private void MainWeightList_Load(object sender, EventArgs e)
        {
            RemoveEvent();
            teEndDate.Time = DateTime.Now;
            teStartDate.Time = DateTime.Now;
            if (!DesignMode)
            {
                InitControl();
                LoadData();
                LoadData();
            }
            //ActiveControl = btnSearch;
            AddEvent();
        }

        private void AddEvent()
        {
            gvWeight.Layout += new System.EventHandler(this.gvWeight_Layout);
        }

        private void RemoveEvent()
        {
            gvWeight.Layout -= new System.EventHandler(this.gvWeight_Layout);
        }

        public void InitControl()
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null)
            {
                if (cfg.Weight != null)
                {
                    startWeighterDataFilter = cfg.Weight.StartWeighterDataFilter;
                }
            }
            //columns = viewService.GetShow2DetailList(ViewType.Weight);
            gvWeight.Columns.Clear();
        }

        /// <summary>
        /// 作废磅单
        /// </summary>
        public bool InvalidWeight()
        {
            bool isInvalided = false;
            List<DataRow> lstWeight = chkWeight.GetSelectedDataRow();
            if (lstWeight == null && lstWeight.Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要作废的磅单.");
            }
            else
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要将所选的磅单作废吗?") == DialogResult.Yes)
                {
                    foreach (DataRow row in lstWeight)
                    {
                        string weightId=row["Id"].ToObjectString();
                        string weightNo = row["WeightNo"].ToObjectString();
                        string desc = string.Format("作废磅单号:{0}", weightNo);
                        logService.Add(LogActionType.Weight, weightId, weightNo, desc);
                        isInvalided = weightService.UpdateWeight(weightId, RowState.Delete);
                    }
                }
            }
            return isInvalided;
        }

        private void itemFinsihWeight_Click(object sender, EventArgs e)
        {
            if (FinishWeight != null) 
            {
                FinishWeight(sender, e);
            }
        }

        private void gvWeight_RowClick(object sender, RowClickEventArgs e)
        {
            if (WeightFocusedRowChanged != null)
            {
                WeightFocusedRowChanged(sender, new WeightFocusedRowChangedEventArgs(CurrentWeightId));
            }
        }

        private void gvWeight_DoubleClick(object sender, EventArgs e)
        {
            if (gvWeight.GetFocusedRow() != null && WeightDoubleClick != null)
            {
                string weightId = gvWeight.GetFocusedRowCellValue("Id").ToObjectString();
                if (!string.IsNullOrEmpty(weightId))
                {
                    WeightDoubleClickEventArgs args = new WeightDoubleClickEventArgs(weightId);
                    WeightDoubleClick(sender, args);
                }
            }
        }

        /// <summary>
        /// 保存控件布局配置
        /// </summary>
        public void SaveLayout() 
        {
            string dirPath = Path.Combine(Application.StartupPath, "Layerout");
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            gvWeight.SaveLayoutToXml(layoutXmlPath);
        }

        private void btnViewPhoto_Click(object sender, EventArgs e)
        {
            if (gvWeight.GetFocusedRow() != null)
            {
                string weightId = gvWeight.GetFocusedRowCellValue("Id").ToObjectString();
                using (FrmViewGraphic frmGraphic = new FrmViewGraphic())
                {
                    frmGraphic.RecId = weightId;
                    frmGraphic.ShowDialog();
                }
            }
            else
            {
                MessageDxUtil.ShowWarning("请选择磅单.");
            }
        }

        private void gvWeight_Layout(object sender, EventArgs e)
        {
            if (canSaveLayout)
            {
                SaveLayout();
            }
        }

        private void gvWeight_GotFocus(object sender, EventArgs e)
        {
            canSaveLayout = true;
        }

        private void gvWeight_LostFocus(object sender, EventArgs e)
        {
            canSaveLayout = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            FrmTableConfig frm=new FrmTableConfig();
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                LoadData();
                gcWeight.Refresh();
            }
        }

        private void gvWeight_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
            if (e.Column.FieldName == "SyncState") {
                switch (e.Value.ToString()) {
                    case "1":
                        e.DisplayText = "已同步";
                        break;
                    case "0":
                    case "":
                    case null:
                        e.DisplayText = "未同步";
                        break;
                }
            }
        }

        private void 上传数据ToolStripMenuItem_Click(object sender, EventArgs e) {
            string weightId = gvWeight.GetFocusedRowCellValue("Id").ToObjectString();
            if (string.IsNullOrEmpty(weightId)) {
                MessageBox.Show("请选择需要上传的数据");
                return;
            }
            ServerReturnEntity entity = webWeightService.serverSaveEnterWeightData(weightId);
            if (entity == null) {
                MessageBox.Show("上传数据失败");
            } else if (entity.success) {
                MessageBox.Show("上传数据成功");
            } else {
                MessageBox.Show(entity.msg);
            }
        }
    }
}
