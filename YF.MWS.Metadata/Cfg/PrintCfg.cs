using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 磅单打印设置
    /// </summary>
    public class PrintCfg
    {
        public PrintMode Mode { get; set; }

        /// <summary>
        /// 磅单打印机名称
        /// </summary>
        public string WeightPrinterName { get; set; }

        /// <summary>
        /// 临时磅单打印机名称
        /// </summary>
        public string WeightTempPrinterName { get; set; }

        /// <summary>
        /// 是否附加打印临时磅单
        /// </summary>
        public bool AppendPrintTemp { get; set; }

        /// <summary>
        /// 启用补打磅单模板
        /// </summary>
        public bool StartReWeightTemplate { get; set; }
        /// <summary>
        /// PDF打印
        /// </summary>
        public bool PrintPhoto { get; set; }
        public string rightTitle { get; set; }
        /// <summary>
        /// 启用磅单打印次数限制
        /// </summary>
        public bool StartPrintCountLimit { get; set; }
        /// <summary>
        /// 每个磅单最多打印次数
        /// </summary>
        public int MaxPrintCount { get; set; }
    }
}
