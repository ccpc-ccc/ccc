using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class SWareh : BaseEntity
    {
        public virtual string CompanyId { get; set; }
        public virtual string MachineCode { get; set; }
        public virtual string WarehCode { get; set; }
        public virtual string WarehName { get; set; }
        public virtual string Location { get; set; }
    }
}
