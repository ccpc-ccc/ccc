using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.SQliteService.Remote;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmControlList : DevExpress.XtraEditors.XtraForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private List<SControl> lstControl = new List<SControl>();
        public FrmControlList()
        {
            InitializeComponent();
        }

        private void FrmControlList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmControlEdit frmEdit = new FrmControlEdit()) 
            {
                if (frmEdit.ShowDialog() == DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvControl.GetFocusedRow() != null) 
            {
                SControl control = (SControl)gvControl.GetFocusedRow();
                using (FrmControlEdit frmEdit = new FrmControlEdit())
                {
                    frmEdit.RecId = control.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e) {
            try {
            if (gvControl.GetFocusedRow() == null) {
                MessageDxUtil.ShowWarning("请选择要删除的控件信息.");
            } else {
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除该控件信息吗?") == DialogResult.Yes) {
                    SControl control = (SControl)gvControl.GetFocusedRow();
                    bool startUpload= viewService.DeleteControl(control.Id);
                    MessageDxUtil.ShowTips("删除成功.");
                    BindData();
                }
            }
            }catch(Exception ex) {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("删除失败.");
            }
        }

        private void btnItemRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void BindData() 
        {
            lstControl = viewService.GetControlList();
            gcControl.DataSource = lstControl;
            gcControl.RefreshDataSource();
        }
    }
}