using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class BWeightAttribute:BaseEntity
    {
        public virtual string WeightId { get; set; }
        public virtual string AttributeId { get; set; }
        public virtual string AttributeName { get; set; }
        public virtual string AttributeValue { get; set; }
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
