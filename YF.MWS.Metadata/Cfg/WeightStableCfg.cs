using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 重量稳定配置
    /// </summary>
    public class WeightStableCfg
    {
        /// <summary>
        /// 最低可信重量
        /// </summary>
        public decimal MinCredibleWeight { get; set; }

        /// <summary>
        /// 重量稳定偏差(Kg)
        /// </summary>
        public decimal WeightDeviation { get; set; }

        /// <summary>
        /// 采样重量个数
        /// </summary>
        public int SamplingCount { get; set; }

        /// <summary>
        /// 采样时间间隔(秒)
        /// </summary>
        public decimal SampingInterval { get; set; }
    }
}
