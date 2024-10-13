using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 车辆信息表
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class S_Car:BaseEntity
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string? CarNo { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string? CarType { get; set; }
        /// <summary>
        /// 司机
        /// </summary>
        public string? DriverName { get; set; }
        /// <summary>
        /// 限载重量
        /// </summary>
        public decimal? LimitWeight { get; set; }
        /// <summary>
        /// 限制状态
        /// 0:不限制 1:限制
        /// </summary>
        public int? LimitState { get; set; }
        /// <summary>
        /// 车辆皮重
        /// </summary>
        public decimal? Tare { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string? Unit { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public string? CompanyId { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(CompanyId))]
        public S_Company? Company { get; set; }


    }
}
