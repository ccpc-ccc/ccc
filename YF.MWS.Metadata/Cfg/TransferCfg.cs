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
        /// 
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// 是否开启
        /// </summary>
        public bool isOpen { get; set; }
        /// <summary>
        /// 是否自动上传
        /// </summary>
        public bool AutoSend { get; set; }
        /// <summary>
        /// 开单员姓名
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 开单地址
        /// </summary>
        public string Address { get; set; }
    }
}
