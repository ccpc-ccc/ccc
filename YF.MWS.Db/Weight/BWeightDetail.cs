using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 磅单详情表
    /// Author:仇军
    /// Date:2014-09-10
    /// </summary>
    public class BWeightDetail : BaseEntity
    {
        public virtual string WeightId { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public virtual decimal GrossWeight { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public virtual decimal TareWeight { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public virtual decimal SuttleWeight { get; set; }
        public virtual string OrderSource { get; set; }
        public virtual int WeightNo { get; set; }
        public virtual string WeighterId { get; set; }
        public virtual string WeighterName { get; set; }
        public virtual int WeightType { get; set; }
        public virtual int AccessState { get; set; }
        public virtual DateTime WeightTime { get; set; }
    }
}
