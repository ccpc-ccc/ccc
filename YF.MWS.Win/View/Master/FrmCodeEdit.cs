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
using YF.MWS.Db;
using YF.Utility.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.CacheService;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCodeEdit : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        private string parentItemCaption;
        private string parentId;
        private string codeId;
        private SCode code;
        public int SystemFlag { get; set; }
        public string CodeId
        {
            get { return codeId; }
            set { codeId = value; }
        }
        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
        public string ParentItemCaption
        {
            get { return parentItemCaption; }
            set { parentItemCaption = value; }
        }
        public SCode Code
        {
            get { return code; }
            set { code = value; }
        }

        public FrmCodeEdit()
        {
            InitializeComponent();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(CodeId))
            {
                code = masterService.GetCode(CodeId);
                FormHelper.BindControl<SCode>(this, code);
                ParentId = code.ParentId;
                if (!string.IsNullOrEmpty(ParentId))
                {
                    SCode cp = masterService.GetCode(ParentId);
                    if (cp != null)
                    {
                        teParent.Text = cp.ItemCaption;
                    }
                }
            }
            else
            {
                teParent.Text = ParentItemCaption;
            }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (string.IsNullOrEmpty(teItemCode.Text.Trim()))
            {
                teItemCode.ErrorText = "请输入编码";
                isValidated = false;
            }
            if (string.IsNullOrEmpty(teItemCaption.Text.Trim()))
            {
                teItemCaption.ErrorText = "请输入文字说明";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save()
        {
            if (ValidateForm())
            {
                SCode c;
                if (!string.IsNullOrEmpty(CodeId))
                {
                    c = code;
                }
                else
                {
                    c = new SCode();
                    c.Id = CodeId;
                    c.ParentId = ParentId;
                }
                c.SystemFlag = SystemFlag;
                FormHelper.ControlToEntity<SCode>(this, ref c);
                bool isSaved=masterService.SaveCode(c);
                if (isSaved)
                    MasterCacher.Refresh();
                MessageDxUtil.ShowTips("成功保存系统编码信息.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmCodeEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}