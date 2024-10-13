using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmDepartmentList : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();

        public FrmDepartmentList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
                BindData();
            }
        }

        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            //this.BindData();
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmDepartmentDetail frmDetail = new FrmDepartmentDetail())
            {
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void btnItemAddSub_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmDepartmentDetail frmDetail = new FrmDepartmentDetail())
            {
                if (this.tlDepart.FocusedNode != null)
                {
                    frmDetail.ParentId = this.tlDepart.FocusedNode["DeptId"].ToString();
                }

                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmDepartmentDetail frmDetail = new FrmDepartmentDetail())
            {
                if (this.tlDepart.FocusedNode != null)
                {
                    frmDetail.DeptId = this.tlDepart.FocusedNode["DeptId"].ToString();
                }

                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.tlDepart.FocusedNode != null)
            {
                string deptId = this.tlDepart.FocusedNode["DeptId"].ToString();
                //删除部门信息
                if (masterService.DeleteDepart(deptId))
                {
                    MessageDxUtil.ShowTips("删除部门信息成功。");
                    this.BindData();
                }
                else
                {
                    MessageDxUtil.ShowTips("删除部门信息失败。");
                }
            }
        }

        private void btnItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            var listDept = masterService.GetDeptList();
            this.tlDepart.DataSource = listDept;
            this.tlDepart.ExpandAll();
        }
    }
}