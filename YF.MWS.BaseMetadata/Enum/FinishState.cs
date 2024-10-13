using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 磅单完成状态
    /// </summary>
    public enum FinishState
    {
        /// <summary>
        /// 未完成
        /// </summary>
        /// 
        [Description("未完成")]
        Unfinished = 0,
        /// <summary>
        /// 已完成
        /// </summary>
        /// 
        [Description("已完成")]
        Finished = 1,
    }
}
