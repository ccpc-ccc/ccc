using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// PLC配置信息
    /// </summary>
    public class PlcCfg
    {
        /// <summary>
        /// 过期日期
        /// </summary>
        public int ExpireDate { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Start { get; set; }
    }
}
