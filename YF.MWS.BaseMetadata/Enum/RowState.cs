using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 行数据状态
    /// </summary>
    public enum RowState
    {
        /// <summary>
        /// 初始状态
        /// </summary>
        /// 
        [Description("初始状态")]
        Default = 0,
        /// <summary>
        /// 已新增
        /// </summary>
        /// 
        [Description("已新增")]
        Add = 1,
        /// <summary>
        /// 已修改
        /// </summary>
        /// 
        [Description("已修改")]
        Edit = 2,
        /// <summary>
        /// 已删除
        /// </summary>
        /// 
        [Description("已删除")]
        Delete = 3
    }
}
