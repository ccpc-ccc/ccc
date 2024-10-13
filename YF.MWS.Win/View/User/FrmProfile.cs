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
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.View.User
{
    public partial class FrmProfile : BaseForm
    {
        private IUserService userService = new UserService();
        private SUser user = null;
        public FrmProfile()
        {
            InitializeComponent();
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(CurrentUser.Instance.Id))
            {
                user = userService.GetById(CurrentUser.Instance.Id);
                if (user != null)
                {
                    txtUserName.Text = user.UserName;
                    txtUserName.Enabled = false;
                    txtEmail.Text = user.Email;
                    txtMobilePhone.Text = user.MobilePhone;
                    comboGender.SelectedItem = user.Gender;
                    txtFullName.Text = user.FullName;
                    teContactPhone.Text = user.ContactPhone;
                    DxHelper.BindComboBoxEdit(comboGender, SysCode.Gender, user.Gender);
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            else 
            {
                btnSave.Enabled = false;
            }
        }

        private bool ValidateForm()
        {
            bool isValidated = true; 
            if (txtFullName.Text.Length == 0)
            {
                txtFullName.ErrorText = "请输入真实姓名";
                txtFullName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            return isValidated;
        }

        private void Save()
        {
            if (this.ValidateForm())
            {
                try
                {
                    if (user != null)
                    {
                        user.Gender = DxHelper.GetCode(comboGender);
                        user.UserName = txtUserName.Text;
                        user.FullName = txtFullName.Text;
                        user.Email = txtEmail.Text;
                        user.MobilePhone = txtMobilePhone.Text;
                        user.ContactPhone = teContactPhone.Text;
                        userService.Save(user);
                        MessageDxUtil.ShowTips("成功保存个人信息.");
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                    MessageDxUtil.ShowError("保存个人信息时发生错误.");
                }
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Save();
        }

        private void btnChangePwd_Click(object sender, EventArgs e) {
            if (ValidateForm2()) {
                Save2();
            }
        }
        private bool ValidateForm2() {
            bool isValidated = true;
            if (teOldPwd.Text.Length == 0) {
                teOldPwd.ErrorText = "请输入原密码";
                isValidated = false;
            }
            if (teNewPwd.Text.Length == 0) {
                teNewPwd.ErrorText = "请输入新密码";
                isValidated = false;
            }
            if (teCfmPwd.Text.Length == 0) {
                teCfmPwd.ErrorText = "请输入确认新密码";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save2() {
            try {
                if (userService.Login(CurrentUser.Instance.UserName, teOldPwd.Text.ToMd5()) != null) {
                    userService.UpdatePassword(CurrentUser.Instance.Id, teNewPwd.Text.ToMd5());
                    MessageDxUtil.ShowTips("密码已经成功修改.");
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("修改密码时发生未知错误,请重试.");
            }
        }
    }
}