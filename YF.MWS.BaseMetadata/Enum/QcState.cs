using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 磅单质检状态
    /// </summary>
    public enum QcState
    {
        /// <summary>
        /// 未检验
        /// </summary>
        /// 
        [Description("未检验")]
        UnChecked = 0,
        /// <summary>
        /// 合格
        /// </summary>
        /// 
        [Description("合格")]
        Qualified = 1,
        /// <summary>
        /// 不合格
        /// </summary>
        /// 
        [Description("不合格")]
        UnQualified = 2
    }
}
