using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 传输服务设置类
    /// Author:仇军
    /// Date:2014-12-20
    /// </summary>
    public class TransferCfg
    {
        /// <summary>
        /// 服务端地址
        /// </summary>
        public string ServerUrl { get; set; }
        /// <summary>
        /// 连接码
        /// </summary>
        public string RegisterCode { get; set; }
        /// <summary>
        /// 终端编号
        /// </summary>
        public string MachineCode { get; set; }
        /// <summary>
        /// 商户编码
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// 是否开启
        /// </summary>
        public bool isOpen { get; set; }
        public bool AutoSend { get; set; }
    }
}
