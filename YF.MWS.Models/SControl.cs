using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// 用户控件定义信息
    /// Author:yafyr
    /// Date:2014-11-11
    /// </summary>
    public class S_Control:BaseEntity
    {
        public string? ControlName { get; set; }
        public string? FieldName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>
        /// 操作名称,权限控制需要用到
        /// </summary>
        public string? ActionName { get; set; }
        public string? Caption { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string? Expression { get; set; }
        /// <summary>
        /// 自动计算排序号
        /// </summary>
        public int? AutoCalcNo { get; set; }
        public string? ErrorText { get; set; }
        public int? IsRequired { get; set; }
    }
}
