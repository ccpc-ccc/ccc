using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using System.IO;
using YF.Utility.Security;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Win.View.Home;
using YF.MWS.Metadata;

namespace YF.MWS.Win
{
    public partial class FrmRepair : DevExpress.XtraEditors.XtraForm
    {
        private IClientService clientService = new ClientService();
        private IWebClientService webClientService = new WebClientService();
        private bool isExpired = false;
        private string machineCode = string.Empty;
        private bool isUpgrade = false;

        public bool IsUpgrade
        {
            get { return isUpgrade; }
            set { isUpgrade = value; }
        }
        public bool IsExpired
        {
            get { return isExpired; }
            set { isExpired = value; }
        }

        public FrmRepair()
        {
            InitializeComponent();
            machineCode = SoftValidator.GetMachineCode();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && ValidateRegisterFile())
            {
                if (Register())
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (beRepairFile.Text.Length == 0)
            {
                beRepairFile.ErrorText = "请选择程序修复文件.";
                isValidated = false;
            }
            return isValidated;
        }

        private bool ValidateRegisterFile()
        {
            bool isValidated = true;
            string[] lines = File.ReadAllLines(beRepairFile.Text);
            if (lines == null || lines.Length < 3)
            {
                MessageDxUtil.ShowWarning("程序修复文件无效,请联系软件供应商.");
                isValidated = false;
                return isValidated;
            }

            SClient client = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                client = clientService.Get();
            }
            else
            {
                client = clientService.Get(machineCode);
            }
            if (client != null)
            {
                if (!string.IsNullOrEmpty(client.ExpireCode))
                {
                    string expiredDate = YF.Utility.Security.Encrypt.DecryptDES(client.ExpireCode, CurrentClient.Instance.EncryptKey);
                    int expDate = YF.Utility.Security.Encrypt.DecryptDES(lines[1], CurrentClient.Instance.EncryptKey).ToInt();
                    if (expDate < expiredDate.ToInt())
                    {
                        MessageDxUtil.ShowWarning("程序修复文件无效,请联系软件供应商.");
                        isValidated = false;
                        return isValidated;
                    }
                }
            }
            return isValidated;
        }

        private bool Register()
        {
            bool isRegistered = false;
            try
            {
                string[] lines = File.ReadAllLines(beRepairFile.Text);
                if (lines == null || lines.Length < 3)
                {
                    lblNote.Text = "程序修复文件无效,请联系软件供应商.";
                }
                else
                {
                    string sourceRegisterCode = SoftRegister.GenerateRegisterCode(machineCode).ToMd5();
                    string inputRegisterCode = lines[0].ToMd5();
                    string verifyCode = YF.MWS.Util.Utility.GetGuid();
                    SClient client = clientService.Get(machineCode);
                    if (client!=null && sourceRegisterCode.ToLower() == inputRegisterCode.ToLower())
                    {
                        AuthCfg cfg = Encrypt.DecryptDES(lines[3], CurrentClient.Instance.EncryptKey).JsonDeserialize<AuthCfg>();
                        string authCode = CfgUtil.GetAuthCode(cfg);
                        isRegistered = clientService.Register(client.ClientName, machineCode, lines[0], lines[1], lines[2], verifyCode, authCode);
                        if (isRegistered)
                        {
                            WriteAuthCfg(lines[3], verifyCode);
                            webClientService.Save(client);
                            isExpired = false;
                            isUpgrade = false;
                        }
                        MessageDxUtil.ShowTips("恭喜您:软件修复成功.");
                    }
                    else
                    {
                        lblNote.Text = "软件修复失败,请联系软件销售商.";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                lblNote.Text = "软件修复时发生未知错误,请重试.";
            }
            return isRegistered;
        }

        private void WriteAuthCfg(string authText, string verifyCode)
        {
            string path = Path.Combine(Application.StartupPath, "auth.cfg");
            List<string> lstIine = new List<string>();
            lstIine.Add(authText);
            lstIine.Add(verifyCode);
            YF.MWS.Util.Utility.Serialize(path, lstIine);
        }

        private void beRepairFile_Click(object sender, EventArgs e)
        {
            if (ofdRegisterFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                beRepairFile.Text = ofdRegisterFile.FileName;
            }
        }

        private void FrmRepair_Load(object sender, EventArgs e)
        {
            txtMachineCode.Text = machineCode;
        }

        private void btnAddConsult_Click(object sender, EventArgs e)
        {
            FrmConsult frmConsult = new FrmConsult();
            if (frmConsult.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
    }
}