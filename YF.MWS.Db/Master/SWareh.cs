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
    public class VWareh : SWareh {
        public virtual string WarehId { get; set; }
        /// <summary>
        /// b表里面的WarehId字段
        /// </summary>
        public virtual string WarehId2 { get; set; }
        public virtual string OpenAddress { get; set; }
        public virtual string CloseAddress { get; set; }
    }
    public class SWareh2 {
        public virtual string Id { get; set; }
        public virtual string WarehId { get; set; }
        public virtual string OpenAddress { get; set; }
        public virtual string CloseAddress { get; set; }
    }
}
