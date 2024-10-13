using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 系统日志
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class BLog:BaseEntity
    {
        /// <summary>
        /// 关联外部对象Id
        /// </summary>
        public virtual string RecId { get; set; }
        public virtual string RecNo { get; set; }
        public virtual string TableName { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string ActionType { get; set; }
        public virtual string LogDesc { get; set; }
        public virtual string OldValue { get; set; }
        public virtual string NewValue { get; set; }
        public virtual string UserId { get; set; }
        public virtual DateTime LogTime { get; set; } 
    }
}
