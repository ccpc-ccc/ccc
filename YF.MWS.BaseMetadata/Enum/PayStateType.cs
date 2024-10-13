using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 支付开启状态
    /// </summary>
    public enum PayStateType
    {
        /// <summary>
        /// 未开启
        /// </summary>
        /// 
        [Description("未开启")]
        UnOpen = 0,
        /// <summary>
        /// 开启
        /// </summary>
        /// 
        [Description("未开启")]
        Open = 1
    }
}
