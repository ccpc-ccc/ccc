using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Models
{
    /// <summary>
    /// 称重界面视图详细配置信息
    /// Author:yafyr
    /// Date:2014-11-11
    /// </summary>
    public class S_WeightViewDtl : BaseEntity
    {
        public string? ViewId { get; set; }
        public string? AttributeId { get; set; }
        public string? ControlId { get; set; }
        public string? ControlType { get; set; }
        public string? ControlName { get; set; } 
        public string? ActionName { get; set; }
        public string? FieldName { get; set; }
        public string? FullName { get; set; }

        /// <summary>
        /// 表达式
        /// </summary>
        public string? Expression { get; set; }
        /// <summary>
        /// 自动计算排序号
        /// </summary>
        public int? AutoCalcNo { get; set; }
        /// <summary>
        /// 小数位个数
        /// </summary>
        public int? DecimalDigits { get; set; }

        public int? OrderNo { get; set; }
        /// <summary>
        /// 驻留状态
        /// </summary>
        public string? StayState { get; set; }
        /// <summary>
        /// 自动保存状态
        /// </summary>
        public string? AutoSaveState { get; set; }
        public string? Caption { get; set; }
        public string? ErrorText { get; set; }
        public int? Readonly { get; set; }
        public int? IsRequired { get; set; }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int? SyncState { get; set; }
        /// <summary>
        /// 过磅主界面是否显示
        /// </summary>
        public int? Show1 { get; set; } = 1;
        /// <summary>
        /// 主界面查询是否显示
        /// </summary>
        public int? Show2 { get; set; } = 1;
        /// <summary>
        /// 查询界面是否显示
        /// </summary>
        public int? Show3 { get; set; } = 1;
        /// <summary>
        /// 默认值
        /// </summary>
        public string? t1 { get; set; }
        public string? CompanyId { get; set; }
    }
}
