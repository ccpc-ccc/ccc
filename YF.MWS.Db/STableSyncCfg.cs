using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class STableSyncCfg
    {
        public virtual string SyncId { get; set; }
        public virtual string TableCnName { get; set; }
        public virtual string TableName { get; set; }
        public virtual DateTime MaxTime { get; set; } 
    }
}
