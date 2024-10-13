using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 显示格式类型
    /// </summary>
    public enum DisplayFormatStringType
    {
        /// <summary>
        /// 整数
        /// </summary>
        /// 
        [Description("整数")]
        [FormatValue("{0:F0}")]
        Int,
        /// <summary>
        /// 一位小数
        /// </summary>
        /// 
        [Description("一位小数")]
        [FormatValue("{0:F1}")]
        OneDecimal,
        /// <summary>
        ///两位小数
        /// </summary>
        /// 
        [Description("两位小数")]
        [FormatValue("{0:F2}")]
        TwoDecimal,
        /// <summary>
        ///三位小数
        /// </summary>
        /// 
        [Description("三位小数")]
        [FormatValue("{0:F3}")]
        ThreeDecimal,
        /// <summary>
        ///年份
        /// </summary>
        /// 
        [Description("年份")]
        [FormatValue("yyyy")]
        Year,
        /// <summary>
        ///简单日期
        /// </summary>
        /// 
        [Description("简单日期")]
        [FormatValue("yyyy-MM-dd")]
        SimpleDate,
        /// <summary>
        ///完整日期
        /// </summary>
        /// 
        [Description("完整日期")]
        [FormatValue("yyyy-MM-dd HH:mm:ss")]
        FullDate
    }

    /// <summary>
    /// 格式类型
    /// </summary>
    public enum FormatType 
    {
        /// <summary>
        /// 无格式
        /// </summary>
        /// 
        [Description("无格式")]
        None = 0,
        /// <summary>
        /// 数字
        /// </summary>
        /// 
        [Description("数字")]
        Numeric = 1,
        /// <summary>
        /// 日期
        /// </summary>
        /// 
        [Description("日期")]
        DateTime = 2,
        /// <summary>
        /// 自定义
        /// </summary>
        /// 
        [Description("自定义")]
        Custom = 3
    }
}
