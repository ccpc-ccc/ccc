using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 计划单限制类型
    /// </summary>
    public enum PlanLimitType
    {
        /// <summary>
        /// 按吨位限制
        /// </summary>
        /// 
        [Description("按吨位限制")]
        Weight = 0,
        /// <summary>
        /// 按次数限制
        /// </summary>
        /// 
        [Description("按次数限制")]
        Count = 1
    }
}
