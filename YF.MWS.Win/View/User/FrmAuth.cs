using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.Utility.Security;
using YF.Utility;

namespace YF.MWS.Win.View.User {
    public partial class FrmAuth : DevExpress.XtraEditors.XtraForm {
        private AuthType auth;

        public AuthType Auth {
            get { return auth; }
            set { auth = value; }
        }

        public FrmAuth() {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e) {
            bool isVerify = false;
            if (teAuthCode.Text.Length > 0) {
                int authCode = CodeUtil.GetAuthCode(teRandCode.Text.ToInt());
                if (teAuthCode.Text.ToInt() == authCode) {
                    isVerify = true;
                }
                if (isVerify) {
                    this.DialogResult = DialogResult.OK;
                } else {
                    MessageDxUtil.ShowWarning("授权验证码错误,请重试.");
                }
            } else {
                MessageDxUtil.ShowWarning("请输入授权验证码.");
            }
        }

        private void FrmAuth_Load(object sender, EventArgs e) {
            teRandCode.Text = CodeUtil.GetRandCode().ToString();
        }
    }
}