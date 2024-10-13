using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 显示格式化属性
    /// </summary>
    public class FormatValueAttribute : Attribute
    {
        private string formatValue;

        public string FormatValue
        {
            get { return formatValue; }
            set { formatValue = value; }
        }
        public FormatValueAttribute(string formatValue) 
        {
            this.formatValue = formatValue;
        }
    }
}
