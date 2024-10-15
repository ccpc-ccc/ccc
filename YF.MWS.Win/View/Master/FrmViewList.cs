using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.Win.View.UI;
using YF.Utility;
using YF.MWS.Metadata.Dto;
using YF.MWS.Win.Uc;
using YF.Utility.Log;
using YF.MWS.SQliteService.Remote;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmViewList : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private static IReportService reportService = new ReportService();
        private ISyncService syncService = new SyncService();
        private List<QWeightView> lstView = new List<QWeightView>();
        private List<SWeightViewDtl> lstViewDetail = new List<SWeightViewDtl>(); 
        private GridCheckMarksSelection chkViewDetail;
        private SWeightView currentView;
        private List<SCode> lstCode = new List<SCode>();

        public FrmViewList()
        {
            InitializeComponent();
        }

        private void FrmViewList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private string GetViewCaption(string viewType) 
        {
            string caption = string.Empty;
            SCode code = null;
            if (lstCode != null && lstCode.Count > 0)
            {
                code = lstCode.Find(c => c.ItemCode == viewType);
                if (code != null)
                {
                    caption = code.ItemCaption;
                }
            }
            if (string.IsNullOrEmpty(caption))
            {
                caption = viewType;
            }
            return caption;
        }

        private int GetFocusRowIndex() 
        {
            int index = 0;
            if (lstView != null && lstView.Count > 0)
            {
                int length = lstView.Count;
                for (int i = 0; i < length; i++)
                {
                    if (lstView[i].IsDefault == 1)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        private void BindData() 
        {
            lstCode = MasterCacher.GetSubCodeList(SysCode.ViewType.ToString());
            lstView = viewService.GetViewList();
            foreach (QWeightView view in lstView) 
            {
                view.ViewTypeCaption = GetViewCaption(view.ViewType);
            }
            gcViewList.DataSource = lstView;
            gcViewList.RefreshDataSource();
            gvViewList.FocusedRowHandle = GetFocusRowIndex();
        }

        private void BindDetail(string viewId) 
        {
            lstViewDetail = viewService.GetAllDetailList(viewId);
            gcViewDetail.DataSource = lstViewDetail;//.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
            gcViewDetail.RefreshDataSource();
            if (chkViewDetail == null)
                chkViewDetail = new GridCheckMarksSelection(gvViewDetail);
            chkViewDetail.ClearSelection(); 
        }

        private void barItemNew_ItemClick(object sender, ItemClickEventArgs e) {
            using (FrmViewShow frmEdit = new FrmViewShow()) {
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    BindData();
                }
            }
        }

        private void btnItemModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvViewList.GetFocusedRow() != null) 
            {
                QWeightView view = (QWeightView)gvViewList.GetFocusedRow();
                /*using (FrmViewEdit frmEdit = new FrmViewEdit())
                {
                    frmEdit.RecId = view.Id;
                    if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindData();
                    }
                }*/
                using(FrmViewShow frm=new FrmViewShow()) {
                    frm.ViewId = view.Id;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void barItemSetControl_ItemClick(object sender, ItemClickEventArgs e)
        {
                SWeightViewDtl detail = (SWeightViewDtl)gvViewDetail.GetFocusedRow();
                if (detail == null)
                {
                    return;
                }
                using (FrmViewDetail frmEdit = new FrmViewDetail())
                {
                    frmEdit.RecId = detail.Id;
                    frmEdit.ViewId = detail.ViewId;
                    if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindDetail(currentView.Id);
                    }
                }
        }

        private void gvViewList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvViewList.GetFocusedRow() != null)
            {
                currentView = (QWeightView)gvViewList.GetFocusedRow();
                BindDetail(currentView.Id);
            }
        }

        private void barItemAddControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvViewList.GetFocusedRow() != null)
            {
                QWeightView view = (QWeightView)gvViewList.GetFocusedRow();
                using (FrmViewDetail frmEdit = new FrmViewDetail())
                {
                    frmEdit.ViewId = view.Id;
                    if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (currentView != null)
                        {
                            BindDetail(currentView.Id);
                        }
                    }
                }
            }
        }

        private void barItemSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmControlList frmList = new FrmControlList()) 
            {
                frmList.ShowDialog();
            }
        }

        private void barItemDeleteView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvViewList.GetFocusedRow() != null) 
            {
                QWeightView view = (QWeightView)gvViewList.GetFocusedRow();
                string message = string.Format(@"确实要删除所选界面({0})吗?{1}此删除不可恢复,请慎重操作.", view.ViewName, Environment.NewLine);
                if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes) 
                {
                    viewService.DeleteView(view.Id);
                    BindData();
                } 
            }
        }

        private void barItemDeleteControl_ItemClick(object sender, ItemClickEventArgs e)
        {
                if (gvViewDetail.GetFocusedRow() != null)
                {
                    SWeightViewDtl detail = (SWeightViewDtl)gvViewDetail.GetFocusedRow();
                    if (MessageDxUtil.ShowYesNoAndTips(string.Format("确实要删除所选控件({0})吗?此操作不可撤销.", detail.ControlName)) == DialogResult.Yes)
                    {
                        if (detail != null)
                        {
                            viewService.DeleteViewDetail(detail.Id);
                            if (currentView != null)
                            {
                                BindDetail(currentView.Id);
                            }
                        }
                    }
                }
        }
         

        private void barItemAddExtendControl_ItemClick(object sender, ItemClickEventArgs e) {
            if (!Program._cfg.Transfer.isOpen) {
                MessageDxUtil.ShowTips("请先开启远程服务！");
                return;
            }

            bool isSyn = WebWeightService.synWeightViewDtl(lstViewDetail);
            if (isSyn) {
                MessageDxUtil.ShowTips("同步成功");
            } else {
                MessageDxUtil.ShowError("同步失败");
            }
        }

        private void btnItemSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvViewList.GetFocusedRow() != null)
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要更改默认界面吗?") ==  DialogResult.Yes)
                {
                    QWeightView view = (QWeightView)gvViewList.GetFocusedRow();
                    if (view != null)
                    {
                        bool isSetted=viewService.SetDefaultView(view.ViewType.ToEnum<ViewType>(),view.Id);
                        if (isSetted)
                        {
                            BindData();
                            CurrentClient.Instance.ViewId = view.Id;
                            reportService.UpdateDefaultView(view.Id);
                        }
                    }
                }
            }
        }

        private void barItemCarViewSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvViewList.GetFocusedRow() != null)
            {
                QWeightView view = (QWeightView)gvViewList.GetFocusedRow();
                if (view != null)
                {
                    using (FrmCardView frmView = new FrmCardView())
                    {
                        frmView.ViewId = view.Id;
                        frmView.ShowDialog();
                    }
                }
            }
        }

        private void barItemShow_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool isUpdated = false;
                SWeightViewDtl detail = (SWeightViewDtl)gvViewDetail.GetFocusedRow();
                if (detail == null)
                {
                    return;
                }
                isUpdated = viewService.UpdateState(detail.Id, RowState.Edit);
                if(isUpdated)
                    BindDetail(currentView.Id);
        }

        private void barItemHiden_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool isUpdated = false;
                SWeightViewDtl detail = (SWeightViewDtl)gvViewDetail.GetFocusedRow();
                if (detail == null)
                {
                    return;
                }
                isUpdated = viewService.UpdateState(detail.Id, RowState.Delete);
                if (isUpdated)
                    BindDetail(currentView.Id);
        }

        private void gvViewDetail_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
            if (e.Column.FieldName == "Show1" || e.Column.FieldName == "Show2") {
                switch(e.DisplayText) {
                    case "0":
                        e.DisplayText = "否";
                        break;
                    case "1":
                        e.DisplayText = "是";
                        break;
                }
            }
            if (e.Column.FieldName == "RowState") {
                if (e.Value.ToInt() == 3) {
                    e.DisplayText = "隐藏";
                } else {
                    e.DisplayText = "显示";
                }
            }
        }
    }
}