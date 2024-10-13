using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    /// <summary>
    /// 查询条件
    /// </summary>
    /// 
    [Serializable]
    public class QueryCondition
    {
        public string Id { get; set; }
        /// <summary>
        /// 搜索输入控件类别
        /// </summary>
        public SearchControlType ControlType { get; set; }
        /// <summary>
        /// 字段类别
        /// </summary>
        public SearchFieldType FieldType { get; set; }
        public string SearchKey { get; set; }
        public string ColumnName { get; set; }
        public string Caption { get; set; }
        public int Visible { get; set; }
        public string Input { get; set; }
        public string SettingCaption { get; set; }
        public override string ToString()
        {
            return Caption;
        }
    }
}
