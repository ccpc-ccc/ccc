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
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;
using System.Net.Mail;
using System.Net;
using YF.MWS.Metadata.Message;
using System.IO;
using YF.MWS.CacheService;
using YF.Utility.IO;

namespace YF.MWS.Win.View.User {
    public partial class FrmSendEmail : DevExpress.XtraEditors.XtraForm {
        private SysCfg Cfg = null;

        public FrmSendEmail() {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e) {
            try {
                EmailCfg emailCfg = Cfg.emailCfg;
                emailCfg.Emailservice = DxHelper.GetStrValue(cbEmailServer);
                emailCfg.RereportType = DxHelper.GetStrValue(cbReportType);
                emailCfg.Password = txtPassword.Text;
                emailCfg.Content = txtContent.Text;
                emailCfg.Title = txtTitle.Text;
                emailCfg.Recipient = txtToAddress.Text;
                emailCfg.UserName = txtUserName.Text;
                emailCfg.SendTime = dtSendTime.EditValue.ToDateTime();
                CfgUtil.SaveCfg(Cfg);
                MessageDxUtil.ShowTips("保存成功");
            } catch (Exception ex) {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存失败");
            }
        }

        private void FrmAuth_Load(object sender, EventArgs e) {
            Cfg = CfgUtil.GetCfg();
            EmailCfg emailCfg = Cfg.emailCfg;
            ListEmailServer list1 = new ListEmailServer();
            DxHelper.BindComboBoxEdit(cbEmailServer, list1.listItems);
            ListRerportType list2 = new ListRerportType();
            DxHelper.BindComboBoxEdit(cbReportType, list2.listItems);
            if(emailCfg != null ) {
                txtPassword.Text = emailCfg.Password;
                txtContent.Text = emailCfg.Content;
                txtTitle.Text = emailCfg.Title;
                txtToAddress.Text = emailCfg.Recipient;
                txtUserName.Text=emailCfg.UserName;
                dtSendTime.EditValue = emailCfg.SendTime;
                DxHelper.SetSelectItemValue(cbEmailServer, emailCfg.Emailservice);
                DxHelper.SetSelectItemValue(cbReportType, emailCfg.RereportType);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            List<VerifyEntity> list = new List<VerifyEntity>();
            list.Add(new VerifyEntity(cbEmailServer, "服务器不能为空"));
            list.Add(new VerifyEntity(txtUserName, "用户名不能为空"));
            list.Add(new VerifyEntity(txtPassword, "密码不能为空"));
            list.Add(new VerifyEntity(txtContent, "发送内容不能为空"));
            list.Add(new VerifyEntity(txtTitle, "标题不能为空"));
            list.Add(new VerifyEntity(txtToAddress, "收件人不能为空"));
            if (!VerifyOperater.isEmptyString(list)) {
                return;
            }
            EmailCfg email = new EmailCfg() {
                Emailservice=cbEmailServer.Text,
                Content=txtContent.Text,
                Password=txtPassword.Text,
                UserName=txtUserName.Text,
                Recipient=txtToAddress.Text,
                Title=txtTitle.Text,
                RereportType=DxHelper.GetStrValue(cbReportType)
            };
            /*string path = "File/Data/" + DateTime.Now.ToString("yyyy年MM月dd日") + "明细报表.xls";
            WeightCacher weightCacher=new WeightCacher();
            DataTable dt = weightCacher.GetListTable(email.RereportType.ToEnum<DateTypeNew>());
            NPOIHelper.DataTableToExcel(dt, path, null);*/
            bool isOk= SendMessage.SendEmail(email);
            if(isOk) {
               MessageDxUtil.ShowTips("发送成功");
            } else {
                MessageDxUtil.ShowError("发送失败,请检查是否开通IMAP/SMTP服务。");
            }
        }
    }
}