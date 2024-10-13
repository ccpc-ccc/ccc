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
using YF.Utility;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmModuleSelect : DevExpress.XtraEditors.XtraForm
    {
        private IRoleService roleService = new RoleService();
        public string ParentId { get; set; }
        public string ParentName { get; set; }

        public FrmModuleSelect()
        {
            InitializeComponent();
        }

        private void FrmModuleSelect_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            List<SModule> lstModule = roleService.GetModuleList();
            treeModule.DataSource = lstModule;
            treeModule.ExpandAll();
        }

        private void treeModule_Click(object sender, EventArgs e)
        {
            if (treeModule.FocusedNode != null)
            {
                ParentId = treeModule.FocusedNode["Id"].ToString();
                ParentName = treeModule.FocusedNode["ModuleName"].ToObjectString();
                teParentName.Text = ParentName;
            }
        }

        private void treeModule_DoubleClick(object sender, EventArgs e)
        {
            if (treeModule.FocusedNode != null)
            {
                ParentId = treeModule.FocusedNode["Id"].ToString();
                ParentName = treeModule.FocusedNode["ModuleName"].ToObjectString();
                teParentName.Text = ParentName;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ParentId))
            {
                MessageDxUtil.ShowWarning("请选择模块");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}