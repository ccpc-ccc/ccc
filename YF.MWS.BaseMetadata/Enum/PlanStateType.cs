using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 计划状态类型
    /// </summary>
    public enum PlanStateType
    {
        /// <summary>
        /// 进行中
        /// </summary>
        /// 
        [Description("进行中")]
        Going = 0,
        /// <summary>
        /// 已完成
        /// </summary>
        /// 
        [Description("已完成")]
        Finished = 1,
        /// <summary>
        /// 已关闭
        /// </summary>
        /// 
        [Description("已关闭")]
        Closed = 2
    }
}
