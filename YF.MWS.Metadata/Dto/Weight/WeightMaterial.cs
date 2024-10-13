using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Dto
{
    /// <summary>
    /// 磅单物资统计报表
    /// </summary>
    public class WeightMaterial
    {
        /// <summary>
        /// 磅单号
        /// </summary>
        public string WeightNo { get; set; }
        /// <summary>
        /// 物资名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 物资分类名称
        /// </summary>
        public string MaterialTypeName { get; set; }
        /// <summary>
        /// 物资规格
        /// </summary>
        public string MaterialModel { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public decimal GrossWeight { get; set; }
    }
}
