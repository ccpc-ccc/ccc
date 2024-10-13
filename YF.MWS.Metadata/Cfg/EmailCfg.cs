using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    public class EmailCfg
    {
        public string Emailservice { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// 是否自动发送
        /// </summary>
        public bool AutoSend { get; set; }
        /// <summary>
        /// day、每天定时发送 hour 每小时自动发送
        /// </summary>
        public string SendType { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        public string Content { get;set; }
        /// <summary>
        /// 报表类型
        /// </summary>
        public string RereportType { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
        /// <summary>
        /// 上次发送时间
        /// </summary>
        public DateTime LastSendTime { get; set; } = DateTime.MinValue;
    }
    public class ListEmailServer {
        public List<ListItem> listItems = new List<ListItem>();
        public ListEmailServer() {
            listItems.Add(new ListItem() { Text = "smtp.qq.com", Value = "smtp.qq.com" });
            listItems.Add(new ListItem() { Text = "smtp.163.com", Value = "smtp.163.com" });
            listItems.Add(new ListItem() { Text = "smtp.126.com", Value = "smtp.126.com" });
            listItems.Add(new ListItem() { Text = "smtp.sina.com.cn", Value = "smtp.sina.com.cn" });
            listItems.Add(new ListItem() { Text = "smtp.mail.yahoo.com", Value = "smtp.mail.yahoo.com" });
            listItems.Add(new ListItem() { Text = "smtp.sohu.com", Value = "smtp.sohu.com" });
        }
    }
    public class ListRerportType {
        public List<ListItem> listItems = new List<ListItem>();
        public ListRerportType() {
            listItems.Add(new ListItem() { Text = "日明细报表", Value = "day" });
            listItems.Add(new ListItem() { Text = "周明细报表", Value = "week" });
            listItems.Add(new ListItem() { Text = "月明细报表", Value = "month" });
            listItems.Add(new ListItem() { Text = "年明细报表", Value = "year" });
        }
    }
}
