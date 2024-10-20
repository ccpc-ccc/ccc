using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.Utility.Security;
using YF.Utility;
using YF.MWS.Win.Util;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.Utility.Configuration;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using System.IO;
using YF.Utility.Log;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Util;
using YF.MWS.Win.View.User;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Win.View.Home;

namespace YF.MWS.Win {
    public partial class FrmRegister : DevExpress.XtraEditors.XtraForm {
        private IClientService clientService = new ClientService();
        private IWebClientService webClientService = new WebClientService();
        private bool isExpired = false;
        private string machineCode = string.Empty;
        public bool IsExpired {
            get { return isExpired; }
            set { isExpired = value; }
        }
        public FrmRegister() {
            InitializeComponent();
            machineCode = SoftValidator.GetMachineCode();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            if (ValidateForm() && ValidateRegisterFile()) {
                if (Register()) {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void FrmRegister_Load(object sender, EventArgs e) {
            string note = AppSetting.GetValue("note");
            lblNote.Text = note;
            txtMachineCode.Text = machineCode;
            BindData();
        }

        private void BindData() {
            SClient client = clientService.Get(machineCode);
            if (client != null) {
                DateTime regDate = client.RegisterDate;
                if (DateUtil.YearsDiff(regDate, DateTime.Now) > 1) {
                    lblRegisterFile.Text = "升级文件";
                    lblNote.Text = "因文件缺失导致程序无法运行";
                    btnRegister.Text = "文件缺失升级";
                    //isUpgrade = true;
                    this.Text = "程序升级";
                }
                teClientName.Text = client.ClientName;
            } else {
                teClientName.Text = Consts.DEFAULT_CLIENT_NAME;
            }
        }

        private bool ValidateForm() {
            bool isValidated = true;
            if (teClientName.Text.Length == 0) {
                teClientName.ErrorText = "请输入客户端名称.";
                isValidated = false;
            }
            if (txtMachineCode.Text.Length == 0) {
                txtMachineCode.ErrorText = "请输入机器码.";
                isValidated = false;
            }
            if (beRegisterFile.Text.Length == 0) {
                    beRegisterFile.ErrorText = "请选择注册文件.";
                isValidated = false;
            }
            return isValidated;
        }

        private bool ValidateRegisterFile() {
            bool isValidated = true;
            string[] lines = File.ReadAllLines(beRegisterFile.Text);
            if (lines == null || lines.Length < 3) {
                    MessageDxUtil.ShowWarning("注册文件无效,请联系软件供应商.");
                isValidated = false;
                return isValidated;
            }

            SClient client = clientService.Get(machineCode);
            if (client != null) {
                if (!string.IsNullOrEmpty(client.ExpireCode)) {
                    string expiredDate = DateTime.Now.ToString("yyyyMMdd");
                    int expDate = YF.Utility.Security.Encrypt.DecryptDES(lines[1], CurrentClient.Instance.EncryptKey).ToInt();
                    if (expDate < expiredDate.ToInt()) {
                            MessageDxUtil.ShowWarning("注册文件无效,请联系软件供应商.");
                        isValidated = false;
                        return isValidated;
                    }
                }
            }
            return isValidated;
        }

        private bool Register() {
            bool isRegistered = false;
            try {
                string[] lines = File.ReadAllLines(beRegisterFile.Text);
                if (lines == null || lines.Length < 3) {
                        lblNote.Text = "注册文件无效,请联系软件供应商.";
                    lblNote.Text += "\r\n" + AppSetting.GetValue("note");
                } else {
                    string sourceRegisterCode = SoftRegister.GenerateRegisterCode(txtMachineCode.Text).ToMd5();
                    string inputRegisterCode = lines[0].ToMd5();
                    string verifyCode = YF.MWS.Util.Utility.GetGuid();
                    if (sourceRegisterCode.ToLower() == inputRegisterCode.ToLower()) {
                        AuthCfg cfg = Encrypt.DecryptDES(lines[3], CurrentClient.Instance.EncryptKey).JsonDeserialize<AuthCfg>();
                        string authCode = CfgUtil.GetAuthCode(cfg);
                        isRegistered = clientService.Register(teClientName.Text, txtMachineCode.Text, lines[0], lines[1], lines[2], verifyCode, authCode);
                         MessageDxUtil.ShowTips("恭喜您:软件注册成功.");
                    } else {
                            lblNote.Text = "软件注册失败,请联系软件销售商.";
                        lblNote.Text += "\r\n"+AppSetting.GetValue("note");
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                    lblNote.Text = "软件注册时发生未知错误,请重试.";
            }
            return isRegistered;
        }

        private void WriteAuthCfg(string authText, string verifyCode) {
            string path = Path.Combine(Application.StartupPath, "auth.cfg");
            List<string> lstIine = new List<string>();
            lstIine.Add(authText);
            lstIine.Add(verifyCode);
            YF.MWS.Util.Utility.Serialize(path, lstIine);
        }

        private void beRegisterFile_Click(object sender, EventArgs e) {
            if (ofdRegisterFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                beRegisterFile.Text = ofdRegisterFile.FileName;
            }
        }

        private void btnTrial_Click(object sender, EventArgs e) {
            //AppConfigUtil.SetConfigValue("version", VersionType.Probation.ToString());
            //MessageDxUtil.ShowTips("已经设为试用版,请关闭此窗口,重启程序.");
            using (FrmExpiredHandle frm = new FrmExpiredHandle()) {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void btnAddConsult_Click(object sender, EventArgs e) {
            FrmConsult frmConsult = new FrmConsult();
            if (frmConsult.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

            }
        }


    }
}