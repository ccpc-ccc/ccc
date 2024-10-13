using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 磅单来源
    /// </summary>
    public enum OrderSource
    {
        /// <summary>
        /// 移动端
        /// </summary>
        /// 
        [Description("移动端")]
        Mobile = 0,
        /// <summary>
        /// 过磅
        /// </summary>
        /// 
        [Description("过磅")]
        Weight = 1,
        /// <summary>
        /// 补录
        /// </summary>
        /// 
        [Description("补录")]
        Additional = 2,
        /// <summary>
        /// 计量方
        /// </summary>
        /// 
        [Description("计量方")]
        Measure = 3,
        /// <summary>
        /// 导入
        /// </summary>
        /// 
        [Description("导入")]
        Import = 4,
        /// <summary>
        /// 自动过磅
        /// </summary>
        /// 
        [Description("自动过磅")]
        AutoWeight = 5,
        /// <summary>
        /// 模拟称重
        /// </summary>
        /// 
        [Description("模拟称重")]
        SimulateWeight = 6,
        /// <summary>
        /// 触摸屏
        /// </summary>
        /// 
        [Description("触摸屏")]
        Pad = 7
    }
}