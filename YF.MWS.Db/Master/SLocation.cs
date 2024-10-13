using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 位置信息
    /// </summary>
    public class SLocation : BaseEntity
    {
        public virtual LocationType LocationType { get; set; }
        public virtual ValidateInputMode ValidateInput { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string LocationCode { get; set; }
        public virtual string LocationName { get; set; }
    }
}
