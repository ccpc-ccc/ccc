using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 计量单位
    /// </summary>
    public enum MeasureUnitType
    {
        /// <summary>
        /// 克
        /// </summary>
        /// 
        [Description("克")]
        G = 0,
        /// <summary>
        /// 公斤
        /// </summary>
        /// 
        [Description("公斤")]
        Kg = 1,
        /// <summary>
        /// 吨
        /// </summary>
        /// 
        [Description("吨")]
        Ton = 2
    }
}
