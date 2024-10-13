using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 统计字段类型
    /// </summary>
    public enum WeightSummaryItemType
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// 
        [Description("求和")]
        Sum = 0,
        /// <summary>
        /// 最小值
        /// </summary>
        /// 
        [Description("最小值")]
        Min = 1,
        /// <summary>
        /// 最大值
        /// </summary>
        /// 
        [Description("最大值")]
        Max = 2,
        /// <summary>
        /// 计数
        /// </summary>
        /// 
        [Description("计数")]
        Count = 3,
        /// <summary>
        /// 平均值
        /// </summary>
        /// 
        [Description("平均值")]
        Average = 4,
        /// <summary>
        /// 自定义
        /// </summary>
        /// 
        [Description("自定义")]
        Custom = 5,
        /// <summary>
        /// 未知
        /// </summary>
        /// 
        [Description("未知")]
        None = 6
    }
}
