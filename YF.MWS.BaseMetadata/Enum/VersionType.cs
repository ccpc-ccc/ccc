using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 版本类型
    /// </summary>
    public enum VersionType
    {
        /// <summary>
        /// 正式版
        /// </summary>
        /// 
        [Description("正式版")]
        Official,
        /// <summary>
        /// 试用版
        /// </summary>
        /// 
        [Description("试用版")]
        Probation
    }
}
