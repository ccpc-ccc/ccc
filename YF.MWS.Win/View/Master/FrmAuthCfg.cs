using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmAuthCfg : DevExpress.XtraEditors.XtraForm
    {
        public FrmAuthCfg()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (tePassword.Text == AuthUser.Instance.VerifyCode)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageDxUtil.ShowWarning("密码输入错误,请重试.");
            }
        }
    }
}