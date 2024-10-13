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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmTableConfig : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private IWeightViewService weightViewService = new WeightViewService();
        private List<SWeightViewDtl> effectiveDtls = null;
        private List<SWeightViewDtl> dtls = null;

        public FrmTableConfig()
        {
            InitializeComponent();
        }

        private void FrmViewConfig_Load(object sender, EventArgs e)
        {
            SWeightView view = null;
            if (this.RecId == null || this.RecId.Length == 0) {
                view = viewService.GetDefaultView(Metadata.ViewType.Weight);
                this.RecId = view.Id;
            } else {
                view = viewService.GetView(RecId);
            }
            dtls = viewService.GetUnShow2DetailList(RecId);
            gcViewDetailSource.DataSource = dtls;
            gcViewDetailSource.RefreshDataSource();
            effectiveDtls = viewService.GetShow2DetailList(RecId);
            gcViewDetail.DataSource = effectiveDtls;
            gcViewDetail.RefreshDataSource();
            if (effectiveDtls == null)
                effectiveDtls = new List<SWeightViewDtl>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addData();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            removeData();
        }
        private void removeData() {
            object selectObjs = gvViewDetail.GetFocusedRow();
            if (selectObjs == null) {
                MessageDxUtil.ShowWarning("请选择要移除的项目");
                return;
            }
            SWeightViewDtl detail = (SWeightViewDtl)selectObjs;
            detail.Show2 = 0;
            if (effectiveDtls.Exists(c => c.Id == detail.Id)) {
                effectiveDtls.Remove(detail);
            }
            if (!dtls.Exists(c => c.Id == detail.Id)) {
                dtls.Add(detail);
            }
            gcViewDetail.RefreshDataSource();
            gcViewDetailSource.RefreshDataSource();

        }
        private void addData() {
            object selectObjs = gvViewDetailSource.GetFocusedRow();
            if (selectObjs == null) {
                MessageDxUtil.ShowWarning("请选择要添加的项目");
                return;
            }
            SWeightViewDtl detail = (SWeightViewDtl)selectObjs;
            detail.Show2 = 1;
            if (!effectiveDtls.Exists(c => c.Id == detail.Id)) {
                effectiveDtls.Add(detail);
            }
            if (dtls.Exists(c => c.Id == detail.Id)) {
                dtls.Remove(detail);
            }
            gcViewDetail.RefreshDataSource();
            gcViewDetailSource.RefreshDataSource();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DxHelper.CommitRow(gvViewDetail);
            foreach (SWeightViewDtl detail in effectiveDtls) 
            {
                viewService.UpdateShow2(detail.Id, detail.Show2);
            }
            foreach (SWeightViewDtl detail in dtls) 
            {
                viewService.UpdateShow2(detail.Id, detail.Show2);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void FrmViewConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void gvViewDetail_DoubleClick(object sender, EventArgs e) {
            removeData();
        }

        private void gvViewDetailSource_DoubleClick(object sender, EventArgs e) {
            addData();
        }
    }
}