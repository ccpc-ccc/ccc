using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;


namespace YF.MWS.Metadata
{
    public class ModuleTree:SModule
    {
        //public virtual Guid Id { get; set; }
        //public virtual Guid ParentId { get; set; }
        //public virtual string Name { get; set; }
        //public virtual string Url { get; set; }
        //public virtual string Icon { get; set; }
        //public virtual int OrderNo { get; set; }

        //public virtual Guid ModuleId { get; set; }
        //public virtual Guid ParentId { get; set; }
        //public virtual string ModuleName { get; set; }
        //public virtual string FullName { get; set; }

        public virtual List<SModule> children { get; set; }
        
        public virtual bool status { get; set; }
    }
}
