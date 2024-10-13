using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    [Serializable]
    public class SAttribute:BaseEntity
    {
        public virtual string SubjectId { get; set; }
        public virtual string DataType { get; set; }
        public virtual string AttributeName { get; set; }
        public virtual string FullName { get; set; }
        public virtual string FieldName { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public virtual string Expression { get; set; }
        /// <summary>
        /// 自动计算排序号
        /// </summary>
        public virtual int AutoCalcNo { get; set; }
    }
}
