using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmSoundSetting : DevExpress.XtraEditors.XtraForm
    {
        public FrmSoundSetting()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtNum.Text.Trim()))
            {
                double num = Convert.ToDouble(this.txtNum.Text.Trim());
                if (num > 0)
                {
                    DigitConvertUtil digitConverter = new DigitConvertUtil(num);
                    this.txtNumWord.Text = digitConverter.ConvertToString();
                }
                else
                {
                    MessageDxUtil.ShowTips("输入的数字必须大于零！");
                }
            }
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtNumWord.Text.Trim()))
            {
                try
                {
                    MediaUtil.Play(this.txtNumWord.Text.Trim());
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
        }
    }
}