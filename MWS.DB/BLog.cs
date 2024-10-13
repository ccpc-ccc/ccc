using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 系统日志
    /// Author:闫孝感
    /// Date:2024-08-31
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
