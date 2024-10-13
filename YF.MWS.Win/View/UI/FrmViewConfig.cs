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
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using YF.Utility;
using YF.MWS.Metadata.Cfg;
using System.IO;
using YF.Utility.IO;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmViewConfig : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private IWeightViewService weightViewService = new WeightViewService();
        private List<SWeightViewDtl> effectiveDtls = null;
        private GridCheckMarksSelection chkView;
        private GridCheckMarksSelection chkViewSource;
        private List<string> deleteIds = new List<string>();
        private bool needSave = false;

        public FrmViewConfig()
        {
            InitializeComponent();
        }

        private void FrmViewConfig_Load(object sender, EventArgs e)
        {
            SWeightView view = viewService.GetView(RecId);
            if (view != null) 
            {
                teColumnsCount.Text = view.ColumnsCount.ToString();
            }
            List<SWeightViewDtl> dtls = viewService.GetAllDetailList(RecId);
            gcViewDetailSource.DataSource = dtls;
            gcViewDetailSource.RefreshDataSource();
            effectiveDtls = viewService.GetDetailList(RecId);
            gcViewDetail.DataSource = effectiveDtls;
            gcViewDetail.RefreshDataSource();
            if (effectiveDtls == null)
                effectiveDtls = new List<SWeightViewDtl>();
            chkView = new GridCheckMarksSelection(gvViewDetail);
            chkViewSource = new GridCheckMarksSelection(gvViewDetailSource);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<object> selectObjs = chkViewSource.GetSelectedRow();
            if (selectObjs == null || selectObjs.Count==0) 
            {
                MessageDxUtil.ShowWarning("请选择要添加的项目");
                return;
            }
            foreach (object obj in selectObjs) 
            {
                SWeightViewDtl detail = (SWeightViewDtl)obj;
                if (!effectiveDtls.Exists(c => c.Id == detail.Id)) 
                {
                    effectiveDtls.Add(detail);
                }
            }
            chkView.ClearSelection();
            gcViewDetail.RefreshDataSource();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<object> selectObjs = chkView.GetSelectedRow();
            if (selectObjs == null || selectObjs.Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要移除的项目");
                return;
            }
            foreach (object obj in selectObjs)
            {
                SWeightViewDtl detail = (SWeightViewDtl)obj;
                effectiveDtls.Remove(detail);
                if (!deleteIds.Exists(c => c == detail.Id))
                {
                    deleteIds.Add(detail.Id);
                }
            }
            chkView.ClearSelection();
            gcViewDetail.RefreshDataSource();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int columnsCount = teColumnsCount.Text.ToInt();
            if (columnsCount < 1) 
            {
                MessageDxUtil.ShowWarning("界面显示列数不能为0");
                return;
            }
            DxHelper.CommitRow(gvViewDetail);
            foreach (string detailId in deleteIds) 
            {
                viewService.UpdateState(detailId, RowState.Delete);
            }
            foreach (SWeightViewDtl detail in effectiveDtls) 
            {
                viewService.UpdateState(detail.Id, RowState.Edit,detail.OrderNo);
            }
            viewService.UpdateColumns(RecId, teColumnsCount.Text.ToInt());
            needSave = false;
            SaveSearchColumns();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SaveSearchColumns() 
        {
            SysCfg cfg = CfgUtil.GetCfg();
            if (cfg == null)
                cfg = new SysCfg();
            WeightSearchCfg weightSearch = cfg.WeightSearch;
            CfgUtil.SaveCfg(cfg);
            string dirPath = Path.Combine(Application.StartupPath, "Layerout");
            FileHelper.DeleteDir(dirPath);
        }

        private List<WeightColumn> GetWeightColumns()
        {
            List<WeightColumn> columns = new List<WeightColumn>();
            List<SWeightViewDtl> viewDtls = weightViewService.GetDetailList(CurrentClient.Instance.ViewId);
            if (viewDtls == null || viewDtls.Count == 0)
                return columns;
            SWeightViewDtl find = null;
            for (int i = 0; i < viewDtls.Count; i++)
            {
                if (viewDtls[i].FieldName != "ViewId" && viewDtls[i].FieldName != "WeightId")
                {
                    find = viewDtls.Find(c => c.ControlId == viewDtls[i].ControlId);
                    if (find != null)
                    {
                        WeightColumn column = new WeightColumn();
                        column.ControlId = find.ControlId;
                        column.ControlName = find.ControlName;
                        column.FieldName = find.FieldName;
                        column.FullName = find.FullName;
                        columns.Add(column);
                    }
                }
            }
            return columns;
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barItemFormulaCfg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvViewDetail.GetFocusedRow() != null) 
            {
                SWeightViewDtl dtl = (SWeightViewDtl)gvViewDetail.GetFocusedRow();
                FrmFormulaCfg frmCfg = new FrmFormulaCfg();
                frmCfg.RecId = dtl.Id;
                if (frmCfg.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    needSave = true;
                }
            }
        }

        private void FrmViewConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needSave) 
            {
                btnItemSave.PerformClick();
            }
        }

    }
}