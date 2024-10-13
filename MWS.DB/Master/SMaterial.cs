using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;
using YF.Utility;
using YF.MWS.BaseMetadata;

namespace YF.ECS.Db
{
    /// <summary>
    /// 物资定义信息
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class SMaterial : BaseEntity
    {
        public virtual string MaterialName { get; set; }
        public virtual string PYMaterialName { get; set; }
        public virtual string MaterialCode { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string MachineCode { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public virtual string SpecName { get; set; }
        public virtual string Unit { get; set; }
        public virtual int State { get; set; }
        [Field(IsSqliteIgnore = true)]
        public virtual string StateName { get { return State.ToEnum<MaterialStateType>().ToDescription(); } }
        public virtual string Remark { get; set; }
        public virtual decimal UnitPrice { get; set; }
        [Field(IsSqliteIgnore=true)]
        public virtual decimal MaxUnitPrice { get; set; }
        [Field(IsSqliteIgnore = true)]
        public virtual decimal MinUnitPrice { get; set; }
        public virtual string MaterialType { get; set; }

        public virtual int SyncState { get; set; }
        /// <summary>
        /// 物资数量
        /// </summary>
        public virtual decimal Quantity { get; set; }
    }
}
