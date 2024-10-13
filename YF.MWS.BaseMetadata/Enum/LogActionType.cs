using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogActionType
    {
        /// <summary>
        /// 磅单
        /// </summary>
        /// 
        [Description("磅单")]
        Weight = 0,
        /// <summary>
        /// 车辆
        /// </summary>
        /// 
        [Description("车辆")]
        Car = 1,
        /// <summary>
        /// 物资
        /// </summary>
        /// 
        [Description("物资")]
        Material = 2,
        /// <summary>
        /// 客户
        /// </summary>
        /// 
        [Description("客户")]
        Customer = 3,
        /// <summary>
        /// 客户
        /// </summary>
        /// 
        [Description("邮件")]
        Email = 4
    }
}
