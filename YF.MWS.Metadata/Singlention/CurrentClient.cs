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
        /// 是否治超模式
        /// </summary>
        public bool IsExceed { get; set; }

        public VersionCodeType VersionCode { get; set; }
        /// <summary>
        /// 版本类型
        /// </summary>
        public VersionType CurrentVersion { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

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
        /// 验证授权文件
        /// </summary>
        public string VerifyCode { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ViewId { get; set; }
        public string SubjectId { get; set; }
        public DataBaseType DataBase { get; set; }
        /// <summary>
        /// 注册类别
        /// </summary>
        public RegisterMode RegType { get; set; }
        public string VersionFunc { get; set; }
        public string ServerUrl { get; set; }
        /// <summary>
        /// 启用基础数据同步
        /// </summary>
        public bool StartSyncMaster { get; set; }
        /// <summary>
        /// 连接服务器状态
        /// </summary>
        public bool IsConnectedServer { get; set; }
        /// <summary>
        /// 是否模拟称重
        /// </summary>
        public bool IsSimulateWeight { get; set; } = false;
        public SysCfg sysCfg { get; set; }
        #region Server Info
        /// <summary>
        /// 远程服务器地址
        /// </summary>
        public string RemoteServerUrl { get; set; }
        #endregion
    }
}
