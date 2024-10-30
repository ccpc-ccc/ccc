using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 车牌设置
    /// </summary>
    public class CarNoCfg
    {
        /// <summary>
        /// 车牌号前两位区域代码
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 车牌输出长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 开启首次过磅存皮重
        /// </summary>
        public bool AutoSaveTareWeight { get; set; }
        /// <summary>
        /// 开启自动加载皮重
        /// </summary>
        public bool AutoLoadTareWeight { get; set; }
    }
}
