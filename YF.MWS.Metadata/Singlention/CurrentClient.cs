using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Mode;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 当前客户端
    /// Author:闫孝感
    /// Date:2023-10-28
    /// </summary>
    public class CurrentClient : Singleton<CurrentClient> {
        /// <summary>
        /// 可用次数
        /// </summary>
        public int AvailableTimes { get; set; }
        /// <summary>
        /// 加解密密钥
        /// </summary>
        public string EncryptKey {
            get {
                return "aswdxsdw2023";
            }
        }

        /// <summary>
        /// 当前程序运行版本类型
        /// </summary>
        public AppRunVersion RunVersion { get; set; }
        /// <summary>
        /// Banner图片路径
        /// </summary>
        public string BannerUrl { get; set; }
        /// <summary>
        /// 启动图片路径
        /// </summary>
        public string StartLogoUrl { get; set; }
        /// <summary>
        /// 企业简介
        /// </summary>
        //public string Infor { get; set; }

        public string MachineCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterCode { get; set; }
        /// <summary>
        /// 剩余天数
        /// </summary>
        public int ResidualDays { get; set; }
        public string ViewId { get; set; }
        public string SubjectId { get; set; }
        public DataBaseType DataBase { get; set; }
        /// <summary>
        /// 注册方式
        /// </summary>
        public RegisterMode RegType { get; set; }
        public string VersionFunc { get; set; }
        public string ServerUrl { get; set; }
        /// <summary>
        /// 启用基础数据同步
        /// </summary>
        public bool StartSyncMaster { get; set; }
        public SysCfg sysCfg { get; set; }
    }
}
