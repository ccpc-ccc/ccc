using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Metadata.Event;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Log
{
    public partial class FrmMLogList : DevExpress.XtraEditors.XtraForm
    {
        private ILogService logService = new LogService();
        private IUserService userService = new UserService();
        private List<LookupField> lstField = new List<LookupField>();
        private List<QLog> lstLog = new List<QLog>();
        private GridCheckMarksSelection chkLog;
        private QPage page = null;
        private int pageSize = 25;

        public FrmMLogList()
        {
            InitializeComponent();
            gvLog.IndicatorWidth = 60;
        }

        private void gvLog_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void BindData() 
        {
            var lstUser = userService.GetList(CurrentUser.Instance.CompanyIds);
            lstField.Clear();
            lstField.Add(new LookupField() { FieldName = "FullName", Caption = "姓名" }); 
            lstField.Add(new LookupField() { FieldName = "MobilePhone", Caption = "手机" });
            SearchLookupUtil.BindData(wLookupUser, lstUser, "UserId", "FullName", lstField);
            if (chkLog == null)
                chkLog = new GridCheckMarksSelection(gvLog);
            chkLog.ClearSelection();
        }

        private void FrmMLogList_Load(object sender, EventArgs e)
        {
            InitControl();
            BindData();
            page.PageIndex = 0;
            Search();
            ucPage.InitControl();
        }

        private void InitControl()
        {
            page = new QPage();
            page.PageSize = pageSize;
            ucPage.PageChanged += ucPage_PageChanged;
            ucPage.Page.PageSize = pageSize;
        }

        private void ucPage_PageChanged(object sender, PageChangedEventArgs e)
        {
            page.PageIndex = e.Page.PageIndex;
            Search();
            e.Page.TotalRows = page.TotalRows;
        }

        private LogQuery GetCondition()
        {
            LogQuery query = new LogQuery();
            query.PageIndex = page.PageIndex;
            query.PageSize = page.PageSize;
            deFilter.SetDate();
            query.StartTime = deFilter.DtStart;
            query.EndTime = deFilter.DtEnd;
            query.UserId = wLookupUser.CurrentValue.ToObjectString();
            if (combActionType.SelectedIndex > 0)
                query.ActionType = (combActionType.SelectedIndex - 1).ToEnum<LogActionType>();
            query.Key = teKey.Text;
            return query;
        }

        private void Search()
        {
            var result = logService.GetList(GetCondition());
            if (result != null)
            {
                page.TotalRows = result.Total;
                ucPage.Page.TotalRows = page.TotalRows;
                gcLog.DataSource = result.Models;
            }
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
           List<object> lstObj= chkLog.GetSelectedRow();
           if (lstObj == null || lstObj.Count == 0)
           {
               MessageDxUtil.ShowWarning("请选择要删除的日志.");
           }
           else 
           {
               if (MessageDxUtil.ShowYesNoAndTips("确实要删除所选的日志吗?此操作不可撤销.") == DialogResult.Yes) 
               {
                   List<string> lstLogId = new List<string>();
                   foreach (object obj in lstObj) 
                   {
                       BLog log = (BLog)obj;
                       lstLogId.Add(log.Id); 
                   }
                   logService.Delete(lstLogId); 
                   MessageDxUtil.ShowTips("成功删除日志.");
                   Search();
               }
           }
        }

        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            DxHelper.ExportXlsx(gvLog);
        }

        private void barItemSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            page.PageIndex = 0;
            Search();
            ucPage.InitControl();
        }
         
    }
}