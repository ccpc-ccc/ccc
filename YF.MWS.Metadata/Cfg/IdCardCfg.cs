using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 身份证识别器设置信息
    /// </summary>
    public class IdCardCfg
    {
        /// <summary>
        /// 通讯方式
        /// </summary>
        public CommunicationType CommunicationType { get; set; }
        /// <summary>
        /// 端口类型
        /// </summary>
        public string PortType { get; set; }
        /// <summary>
        /// 端口参数
        /// </summary>
        public string PortPara { get; set; }
        /// <summary>
        ///  扩展参数
        /// </summary>
        public string ExtendPara { get; set; }
        /// <summary>
        /// 开启身份证识别
        /// </summary>
        public bool Start { get; set; }
        /// <summary>
        /// 开启二次过磅读取身份证
        /// </summary>
        public bool StartSecondRead { get; set; }
        /// <summary>
        /// 启用身份证信息生成客户单位
        /// </summary>
        public bool StartGenerateCustomer { get; set; }
    }
}
