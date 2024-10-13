using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    public enum LocationType
    {
        /// <summary>
        /// 入口
        /// </summary>
        /// 
        [Description("入口")]
        Entrance = 0,
        /// <summary>
        /// 出口
        /// </summary>
        /// 
        [Description("出口")]
        Exit = 1,
    }
}
