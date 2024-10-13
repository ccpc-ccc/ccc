using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 物资启用状态
    /// </summary>
    public enum MaterialStateType
    {
        /// <summary>
        /// 禁用
        /// </summary>
        /// 
        [Description("禁用")]
        Disabled=0,
        /// <summary>
        /// 启用
        /// </summary>
        /// 
        [Description("启用")]
        Enable=1
    }
}
