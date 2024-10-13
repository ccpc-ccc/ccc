using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 超限磅单限制
    /// </summary>
    public class OverWeightCfg
    {
        /// <summary>
        /// 车辆限重
        /// </summary>
        public decimal MaxWeight { get; set; }

        /// <summary>
        /// 启动超载
        /// </summary>
        public bool Start { get; set; }
    }
}
