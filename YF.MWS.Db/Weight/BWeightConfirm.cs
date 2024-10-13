using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    public class BWeightConfirm
    {
        public virtual string Id { get; set; }
        public virtual string WeightNo { get; set; }
        public virtual string MaterialId { get; set; }
        public virtual string CarNo { get; set; }
        public virtual string CardNo { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string ClientId { get; set; }
        public virtual string CardId { get; set; }

        public virtual QcState QcState { get; set; }
        public virtual DateTime? ConfirmTime { get; set; }
        public virtual MeasureUnitType UnitType { get; set; }
        public virtual FinishState FinishState { get; set; }
        public virtual string AuditorId { get; set; }
        public virtual string Remark { get; set; }
        public virtual decimal GrossWeight { get; set; }
        public virtual decimal TareWeight { get; set; }
        [Field(IsSqliteIgnore =true)]
        public virtual decimal SuttleWeight { get; set; }
        public virtual decimal DeductWeight { get; set; }
        public virtual SyncState SyncState { get; set; }
        public virtual RowState RowState { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
