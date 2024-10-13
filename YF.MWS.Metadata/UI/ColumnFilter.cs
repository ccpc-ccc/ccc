using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.UI
{
    /// 针对浮点数据类型 的GridControl 列的长度限制,对应数据库的  numeric(8,2) =numeric(Length,DecimalLength)
    /// </summary>
    public class ColumnFilter
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 小数个数
        /// </summary>
        public int DecimalLength { get; set; }
    }
}
