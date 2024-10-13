using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Dto;
using YF.MWS.BaseMetadata;
using YF.Utility.Log;
using YF.Utility.Security;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Win.View.Master;
using YF.MWS.Db;
using YF.Utility;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmTrialExpiredHandle : DevExpress.XtraEditors.XtraForm
    {
        private IWebMessageService messageService = new WebMessageService();
        private IWebClientService webClientService = new WebClientService();
        private IClientService clientService = new ClientService();
        private int authCode = 0;
        private SmsCfg cfg;

        public FrmTrialExpiredHandle()
        {
            InitializeComponent();
        }

        private void FrmTrialExpiredHandle_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetSmsCfg();
            teRandCode.Text = CodeUtil.GetRandCode().ToString();
        }

        private void FrmTrialExpiredHandle_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSmsCfg();
        }

        private void SaveSmsCfg() 
        {
            if (cfg == null)
                cfg = new SmsCfg();
            CfgUtil.SaveSmsCfg(cfg);
        }

        private bool IsCellphone(string cellphone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cellphone, @"^1[3456789]\d{9}");
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string authCode = CodeUtil.GetAuthCode(teRandCode.Text.ToInt()).ToString();
            bool isSuccess = false;
            if (authCode == teAuthCode.Text)
            {
                ExtendProbation();
            }
            else
            {
                MessageDxUtil.ShowWarning("授权码错误,请重试.");
            }
        }

        private void ExtendProbation()
        {
            string machineCode = CurrentClient.Instance.MachineCode;
            SClient client = clientService.Get(machineCode);
            if (client == null)
            {
                string clientName = YF.MWS.Util.Utility.GetComputerName();
                clientService.RegisterProbation(machineCode, clientName);
                client = clientService.Get(machineCode);
            }
            bool isSuccess = clientService.UpdateProbation(CurrentClient.Instance.MachineCode, 7);
            if (isSuccess)
            {
                if (client != null) 
                {
                    client.ExpireDate = DateTime.Now.AddDays(7);
                    webClientService.Save(client);
                }
                MessageDxUtil.ShowTips("成功延长试用期.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageDxUtil.ShowError("延长试用期时发生未知错误,请重试.");
            }
        }
    }
}