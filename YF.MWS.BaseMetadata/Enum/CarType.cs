using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 车辆类型
    /// </summary>
    public enum CarType
    {
        /// <summary>
        /// 内部车辆
        /// </summary>
        /// 
        [Description("内部车辆")]
        Inner = 0,
        /// <summary>
        /// 外部车辆
        /// </summary>
        /// 
        [Description("外部车辆")]
        Out = 1
    }
}
