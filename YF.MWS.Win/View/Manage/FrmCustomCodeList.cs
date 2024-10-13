using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Win.View.Master;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Manage
{
    public partial class FrmCustomCodeList : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        public FrmCustomCodeList()
        { 
                InitializeComponent(); 
        }

        private void FrmCodeList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                 BindData();
            }
        }

        private void BindData()
        {
            var lstCode = masterService.GetList(0);
            tlCode.DataSource = lstCode;
            tlCode.ExpandAll();
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCodeEdit frmEdit = new FrmCodeEdit())
            {
                frmEdit.SystemFlag = 0;
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemAddSub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCodeEdit frmEdit = new FrmCodeEdit())
            {
                frmEdit.SystemFlag = 0;
                if (tlCode.FocusedNode != null)
                {
                    frmEdit.ParentId = tlCode.FocusedNode["CodeId"].ToString();
                    frmEdit.ParentItemCaption = tlCode.FocusedNode["ItemCaption"].ToObjectString();
                }
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCodeEdit frmEdit = new FrmCodeEdit())
            {
                frmEdit.SystemFlag = 0;
                if (tlCode.FocusedNode != null)
                {
                    frmEdit.CodeId = tlCode.FocusedNode["CodeId"].ToString();
                }
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tlCode.FocusedNode != null)
            {
                string codeId = tlCode.FocusedNode["CodeId"].ToString();
                if (masterService.DeleteCode(codeId))
                {
                    MessageDxUtil.ShowTips("删除系统编码信息成功.");
                    BindData();
                }
                else
                {
                    MessageDxUtil.ShowTips("删除系统编码信息失败.");
                }
            }
        }

        private void btnItemRefreh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindData();
        }
    }
}