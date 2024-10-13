using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;
using YF.Utility.Metadata;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Metadata.Message
{
    public class SendMessage {
        public static bool SendEmail(EmailCfg emailCfg,string filePath="") {
            MailMessage message = new MailMessage();
            //添加邮件接收地址,可以添加多个接收邮箱地址
            message.To.Add(emailCfg.Recipient);
            string fromAddress = emailCfg.Emailservice.Replace("smtp.", emailCfg.UserName + "@");
            //设置发件人地址，发件人姓名，以及编码
            message.From = new MailAddress(fromAddress, emailCfg.UserName, System.Text.Encoding.UTF8);
            //添加附件
            if (filePath != "") {
                Attachment mailAttACH = new Attachment(filePath);
                message.Attachments.Add(mailAttACH);
            }
            message.Subject = emailCfg.Title;
            message.SubjectEncoding = System.Text.Encoding.UTF8;  //邮件标题编码
            message.Body = emailCfg.Content;
            message.BodyEncoding = System.Text.Encoding.UTF8;   //邮件内内容的编码
            message.IsBodyHtml = false;//设置邮件是否为HTML邮件
            message.Priority = MailPriority.Normal; //设置邮件优先级
            SmtpClient client = new SmtpClient();
            //设置发件人的邮箱和授权码。相当于登录邮箱
            client.Credentials = new NetworkCredential(emailCfg.UserName, emailCfg.Password);

            //设置邮箱使用的端口，这里以163邮箱为例
            client.Port = 25;
            //设置smtp的服务地址
            client.Host = emailCfg.Emailservice;
            try {
                //发送邮件
                client.Send(message);
                //MessageDxUtil.ShowTips("发送成功");
                Logger.Info("发送邮件成功，邮件地址："+ fromAddress);
                return true;
            } catch (SmtpException ex) {
                Logger.WriteException(ex);
                return false;
                //MessageDxUtil.ShowError("发送失败,请检查是否开通IMAP/SMTP服务。");
            }
        }
    }
}
