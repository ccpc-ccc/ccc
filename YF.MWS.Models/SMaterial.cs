using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Models
{
    /// <summary>
    /// 物资定义信息
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_Material : BaseEntity
    {
        public string? MaterialName { get; set; }
        public string? PYMaterialName { get; set; }
        public string? MaterialCode { get; set; }
        public string? CompanyId { get; set; }
        public string? MachineCode { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string? SpecName { get; set; }
        public string? Unit { get; set; }
        public int? State { get; set; }
        public string? Remark { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? MaxUnitPrice { get; set; }
        public decimal? MinUnitPrice { get; set; }
        public string? MaterialType { get; set; }

        public int? SyncState { get; set; }
        /// <summary>
        /// 物资数量
        /// </summary>
        public decimal? Quantity { get; set; }
    }
}
