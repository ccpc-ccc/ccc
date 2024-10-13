using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 计划类型
    /// </summary>
    public enum PlanType
    {
        /// <summary>
        /// 派车计划
        /// </summary>
        /// 
        [Description("派车计划")]
        Car = 0,
        /// <summary>
        /// 客户计划
        /// </summary>
        /// 
        [Description("客户计划")]
        Customer = 1
    }
}
