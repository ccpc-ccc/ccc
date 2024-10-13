using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.View.User
{
    public partial class FrmPwd : BaseForm
    {
        private IUserService userService = new UserService();

        public FrmPwd()
        {
            InitializeComponent();
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmPwd_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (teOldPwd.Text.Length == 0)
            {
                teOldPwd.ErrorText = "请输入原密码"; 
                isValidated = false;
            }
            if (teNewPwd.Text.Length == 0)
            {
                teNewPwd.ErrorText = "请输入新密码";
                isValidated = false;
            }
            if (teCfmPwd.Text.Length == 0)
            {
                teCfmPwd.ErrorText = "请输入确认新密码";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save() 
        {
            try
            {
                if (userService.Login(CurrentUser.Instance.UserName, teOldPwd.Text.ToMd5()) != null)
                {
                    userService.UpdatePassword(CurrentUser.Instance.Id, teNewPwd.Text.ToMd5());
                    MessageDxUtil.ShowTips("密码已经成功修改.");
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("修改密码时发生未知错误,请重试.");
            }
        }
    }
}