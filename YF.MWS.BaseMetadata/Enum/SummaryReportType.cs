using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 统计报表类型
    /// </summary>
    public enum SummaryReportType
    {
        /// <summary>
        /// 过磅收费报表
        /// </summary>
        /// 
        [Description("收费报表")]
        Charge,
        /// <summary>
        /// 充值报表
        /// </summary>
        /// 
        [Description("充值报表")]
        Recharge,
        /// <summary>
        /// 磅单统计报表
        /// </summary>
        ///
        [Description("磅单统计")]
        Weight,
        /// <summary>
        /// 自定义统计报表
        /// </summary>
        /// 
        [Description("自定义统计报表")]
        Custom
    }

    /// <summary>
    /// 二级磅单统计报表
    /// </summary>
    public enum WeightSubReportType 
    {
        /// <summary>
        /// 普通磅单统计
        /// </summary>
        ///
        [Description("普通磅单统计")]
        Weight,
        /// <summary>
        /// 普通磅单日统计
        /// </summary>
        ///
        [Description("普通磅单日统计")]
        WeightDay,
        /// <summary>
        /// 普通磅单月统计
        /// </summary>
        ///
        [Description("普通磅单月统计")]
        WeightMonth,
        /// <summary>
        /// 销售统计报表
        /// </summary>
        /// 
        [Description("销售统计报表")]
        Sales,
        /// <summary>
        /// 客户统计报表
        /// </summary>
        ///
        [Description("客户统计报表")]
        Customer,
        /// <summary>
        /// 客户多物资统计报表
        /// </summary>
        ///
        [Description("客户多物资统计报表")]
        CustomerMultipleMaterial,
        /// <summary>
        /// 客户单物资统计报表
        /// </summary>
        ///
        [Description("客户单物资统计报表")]
        CustomerSingleMaterial,
        /// <summary>
        /// 收货单位车辆分组统计
        /// </summary>
        ///
        [Description("收货单位车辆分组统计")]
        ReceiverCarGroup,
        /// <summary>
        /// 三列物资统计报表
        /// </summary>
        ///
        [Description("三列物资统计报表")]
        ThreeColumn,
    }
}
