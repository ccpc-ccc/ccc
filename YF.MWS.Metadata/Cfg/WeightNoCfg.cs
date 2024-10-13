using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 磅单号生成规则配置类
    /// Author:闫孝感
    /// Date:2024-12-20
    /// </summary>
    public class WeightNoCfg
    {
        /// <summary>
        /// 前缀格式
        /// </summary>
        public WeightNoPrefixFormat PrefixFormat { get; set; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 基数
        /// </summary>
        public int CardinalNo { get; set; }
        /// <summary>
        /// 序列号位数
        /// </summary>
        public int SerialNoDigit { get; set; }
        /// <summary>
        /// 当前日期(yyyyMMdd)
        /// </summary>
        public int CurrentDate { get; set; }

        /// <summary>
        /// 小数位数
        /// </summary>
        public int DecimalDigits { get; set; }


    }
}
