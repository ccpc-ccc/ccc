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
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.Uc;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.SQliteService.Remote;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.CacheService;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmMaterialList : BaseForm
    {
        private IMaterialService materialService = new MaterialService();
        private ISyncService syncService = new SyncService();
        private IWebMaterialService webMaterialService = new WebMaterialService();
        private IWeightService weightService = new WeightService();
        private string serverUrl=string.Empty;
        private GridCheckMarksSelection chkMaterial;
        public FrmMaterialList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
            }
        }

        private void FrmMaterialList_Load(object sender, EventArgs e)
        {
            BindData();
            if (Program._cfg.Transfer != null)
            {
                serverUrl = Program._cfg.Transfer.ServerUrl;
            }
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmMaterialDetail frmDetail = new FrmMaterialDetail())
            {
                frmDetail.FrmMain = GetMain();
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmMaterialDetail frmDetail = new FrmMaterialDetail())
            {
                frmDetail.FrmMain = GetMain();
                //获取物资编号
                if (this.gvMaterial.FocusedRowHandle >= 0)
                {
                    frmDetail.MaterialId = this.gvMaterial.GetRowCellValue(this.gvMaterial.FocusedRowHandle, "MaterialId").ToString();
                }

                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void Delete() 
        {
            List<object> chkObjects = chkMaterial.GetSelectedRow();
            if (chkObjects == null || chkObjects.Count==0)
            {
                MessageDxUtil.ShowTips("请选择要删除的物资信息");
            }
            else
            {
                string message = string.Format("确实需要删除所选择的物资信息吗?{0}此操作不可撤销,请慎重操作.", Environment.NewLine);
                if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
                {
                    List<string> materialIds = new List<string>();
                    bool isDeleted = false;
                    foreach (object obj in chkObjects)
                    {
                        SMaterial m = (SMaterial)obj;
                        isDeleted = materialService.DeleteMaterial(m.Id);
                        if (isDeleted)
                        {
                            materialIds.Add(m.Id);
                        }
                    }
                    MaterialCacher.Refresh();
                    MessageDxUtil.ShowTips("成功删除物资信息.");
                    BindData();
                }
            }
        }

        private void btnItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            List<SMaterial> listMaterial = materialService.GetMaterialList();
            this.gcMaterial.DataSource = listMaterial;
            this.gvMaterial.ExpandAllGroups();
            if (chkMaterial == null)
                chkMaterial = new GridCheckMarksSelection(gvMaterial);
            chkMaterial.ClearSelection();
        }

        private void barItemExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = materialService.GetMaterialExport();
            if (dt != null && dt.Rows.Count > 0) 
            {
                DxHelper.ExportXls(dt, "Excel 文件|*.xls");
            }
        }

        private void barItemImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmImportMaterial frmDetail = new FrmImportMaterial())
            {
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void barItemSync_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<object> lstObj = chkMaterial.GetSelectedRow();
            if (lstObj == null || lstObj.Count == 0)
            {
                MessageDxUtil.ShowTips("请选择要同步的物资信息");
            }
            else
            {
                using (Utility.GetWaitForm("正在同步物资信息到服务器..."))
                {
                    foreach (object obj in lstObj)
                    {
                        SMaterial material = (SMaterial)obj;
                        bool isSynced = webMaterialService.Save(material);
                        if (isSynced)
                        {
                            materialService.UpdateMaterialSyncState(1, material.Id);
                        }
                    }
                }
                MessageDxUtil.ShowTips("成功同步物资信息.");
            }
        }

        private void gvMaterial_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}