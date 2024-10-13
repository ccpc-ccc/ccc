using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmConfirmExit : DevExpress.XtraEditors.XtraForm
    {
        public FrmConfirmExit()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tePassword.Text.Length == 0)
            {
                lblStatus.Text = "请输入密码";
            }
            else
            {
                if (tePassword.Text != "123123")
                {
                    lblStatus.Text = "密码错误,请重新输入";
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}