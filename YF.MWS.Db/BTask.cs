using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class BTask :BaseEntity
    {
        public virtual string TaskType { get; set; }
        public virtual string TaskName { get; set; }
        public virtual string TaskContent { get; set; }
        public virtual string RefId { get; set; }
        public virtual int TaskState { get; set; }
    }
}
