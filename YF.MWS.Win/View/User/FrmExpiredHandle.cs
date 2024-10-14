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
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using YF.Utility.Log;
using YF.Utility.Security;
using YF.MWS.Metadata.Dto;
using YF.MWS.Db;
using YF.Utility.Configuration;
using YF.Utility;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmExpiredHandle : DevExpress.XtraEditors.XtraForm
    {
        private IWebMessageService messageService = new WebMessageService();
        private IWebClientService webClientService = new WebClientService();
        private IClientService clientService = new ClientService();
        private int authCode = 0;
        private SmsCfg cfg;

        public FrmExpiredHandle()
        {
            InitializeComponent();
        }

        private void FrmExpiredHandle_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetSmsCfg();
            if (cfg != null)
            {
                teSmsRealName.Text = cfg.RealName;
                teSmsCellphone.Text = cfg.Cellphone;
            }
            teRandCode.Text = CodeUtil.GetRandCode().ToString();
        }

        private void FrmExpiredHandle_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSmsCfg();
        }

        private void SaveSmsCfg()
        {
            if (cfg == null)
                cfg = new SmsCfg();
            cfg.Cellphone = teSmsCellphone.Text;
            cfg.RealName = teSmsRealName.Text;
            CfgUtil.SaveSmsCfg(cfg);
        }

        private bool IsCellphone(string cellphone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cellphone, @"^1[3456789]\d{9}");
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (teSmsRealName.Text.Length == 0)
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("请输入您的姓名");
                return isValidated;
            }
            if (teSmsCellphone.Text.Length == 0)
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("请输入您的手机号");
                return isValidated;
            }
            if (teSmsCellphone.Text.Length > 0 && !IsCellphone(teSmsCellphone.Text))
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("您输入的手机号不正确");
                return isValidated;
            }
            return isValidated;
        }

        private void ExtendExpiredTime()
        {
            AppConfigUtil.SetConfigValue("version", VersionType.Probation.ToString());
            CurrentClient.Instance.CurrentVersion = VersionType.Probation;
            string machineCode=CurrentClient.Instance.MachineCode;
            SClient client = clientService.Get(machineCode);
            if (client == null)
            {
                string clientName = YF.MWS.Util.Utility.GetComputerName();
                //clientService.RegisterProbation(machineCode,clientName);
                client = clientService.Get(machineCode);
            }
            bool isSuccess = clientService.UpdateProbation(machineCode, 7);
            if (isSuccess)
            {
                if (client != null)
                {
                    client.ExpireDate = DateTime.Now.AddDays(7);
                    webClientService.Save(client);
                }
                MessageDxUtil.ShowTips("成功延长使用期限.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageDxUtil.ShowError("延长使用期限时发生未知错误,请重试.");
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string authCode = CodeUtil.GetAuthCode(teRandCode.Text.ToInt()).ToString();
            if (authCode == teAuthCode.Text)
            {
                ExtendExpiredTime();
            }
            else
            {
                MessageDxUtil.ShowWarning("授权码错误,请重试.");
            }
        }

        private void btnSendSmsAuthCode_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveSmsCfg();
                SmsAuthCode request = new SmsAuthCode();
                request.Cellphone = teSmsCellphone.Text;
                request.RealName = teSmsRealName.Text;
                SmsAuthCode code = messageService.SendAuthCode(request);
                if (code != null)
                {
                    if (code.Success)
                    {
                        authCode = code.AuthCode;
                        MessageDxUtil.ShowTips("短信验证码已经发送到您的手机上,请查看");
                    }
                    else
                    {
                        string message = "发送验证码发生未知错误,请重试";
                        if (!string.IsNullOrEmpty(code.Message))
                            message = code.Message;
                        MessageDxUtil.ShowWarning(message);
                    }
                }
            }
        }

        private void btnVerifySmsAuthCode_Click(object sender, EventArgs e)
        {
            if (teSmsAuthCode.Text == authCode.ToString())
            {
                ExtendExpiredTime();
            }
            else
            {
                MessageDxUtil.ShowWarning("验证码错误,请重试.");
            }
        }
    }
}