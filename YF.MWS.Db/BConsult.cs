using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Db
{
    public class BConsult
    {
        public virtual int Id { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string FullName { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string ConsultContent { get; set; }
        public virtual DateTime SubmitTime { get; set; }
        public virtual ConsultStateType ConsultState { get; set; }
    }
}
