using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    public class S_Attribute:BaseEntity
    {
        public string? SubjectId { get; set; }
        public string? DataType { get; set; }
        public string? AttributeName { get; set; }
        public string? FullName { get; set; }
        public string? FieldName { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string? Expression { get; set; }
        /// <summary>
        /// 自动计算排序号
        /// </summary>
        public int? AutoCalcNo { get; set; }
    }
}
