using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.Utility;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmConsult : DevExpress.XtraEditors.XtraForm
    {
        private IWebClientService webClientService = new WebClientService();

        public FrmConsult()
        {
            InitializeComponent();
        }

        private void FrmConsult_Load(object sender, EventArgs e)
        {

        }

        private void btnItemOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateForm()) 
            {
                AddConsult();
            }
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (teFullName.Text.Length == 0) 
            {
                teFullName.ErrorText = "请输入姓名";
                isValidated = false;
            }
            if (teCellPhone.Text.Length == 0)
            {
                teCellPhone.ErrorText = "请输入手机号";
                isValidated = false;
            }
            //if (teCellPhone.Text.ToInt().ToString().Length!=11)
            //{
            //    teCellPhone.ErrorText = "手机号格式不正确";
            //    isValidated = false;
            //}
            if (memConsultContent.Text.Length == 0)
            {
                memConsultContent.ErrorText = "请输入问题描述";
                isValidated = false;
            }
            return isValidated;
        }

        private void AddConsult()
        {
            BConsult consult = new BConsult();
            consult.CellPhone = teCellPhone.Text;
            consult.ConsultContent = memConsultContent.Text;
            consult.ConsultState = BaseMetadata.ConsultStateType.WatingReply;
            consult.FullName = teFullName.Text;
            consult.SubmitTime = DateTime.Now;
            bool isAdded = webClientService.AddConsult(consult);
            if (isAdded)
            {
                MessageDxUtil.ShowTips("成功提交咨询,我们的售后支持人员将会尽快跟您联系");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else 
            {
                MessageDxUtil.ShowWarning("提交咨询失败,请重试");
            }
        }
    }
}