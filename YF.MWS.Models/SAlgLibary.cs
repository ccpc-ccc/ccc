using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 物资算法库
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_AlgLibary:BaseEntity
    {
        public string? MaterialId { get; set; }
        /// <summary>
        /// 换算系数
        /// </summary>
        public decimal? Factor { get; set; }
        /// <summary>
        /// 正偏差
        /// </summary>
        public decimal? PDeviation { get; set; }
        /// <summary>
        /// 负偏差
        /// </summary>
        public decimal? NDeviation { get; set; }
        public int? State { get; set; }
    }
}
