using Microsoft.Extensions.FileSystemGlobbing.Internal;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// 磅单主表
    /// Author闫孝感
    /// Date:2024-09-10
    /// </summary>
    public class B_Weight:BaseEntity
    {
        /// <summary>
        /// 磅单序列号
        /// </summary>
        public string? WeightNo { get; set; }

        public string? ViewId { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        public string? CustomerId { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        public string? CompanyId { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public string? DeptId { get; set; }
        /// <summary>
        /// 过毛重站点
        /// </summary>
        public string? MachineCode { get; set; }
        /// <summary>
        /// 过皮重站点
        /// </summary>
        public string? TareMachineCode { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public string? SupplierId { get; set; }
        /// <summary>
        /// 发货商ID
        /// </summary>
        public string? DeliveryId { get; set; }
        /// <summary>
        /// 收货商ID
        /// </summary>
        public string? ReceiverId { get; set; }
        /// <summary>
        /// 承运商ID
        /// </summary>
        public string? TransferId { get; set; }
        /// <summary>
        /// 车牌ID
        /// </summary>
        public string? CarId { get; set; }
        /// <summary>
        /// 车牌号(如:粤B 888888)
        /// </summary>
        public string? CarNo { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string? CardNo { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public string? DriverName { get; set; }
        /// <summary>
        /// 物资ID
        /// </summary>
        public string? MaterialId { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string? MaterialModel { get; set; }
        /// <summary>
        /// 生产商ID
        /// </summary>
        public string? ManufacturerId { get; set; }
        /// <summary>
        /// 物资数量
        /// </summary>
        public decimal? MaterialAmount { get; set; }
        /// <summary>
        /// 物资单价
        /// </summary>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 计量业务类型
        /// </summary>
        public string? MeasureType { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string? MeasureUnit { get; set; }
        /// <summary>
        /// 杂质计算类型
        /// </summary>
        public string? ImpurityMeaType { get; set; }
        /// <summary>
        /// 杂质量
        /// </summary>
        public decimal? ImpurityWeight { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public decimal? TareWeight { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public decimal? GrossWeight { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal? SuttleWeight { get; set; }
        /// <summary>
        /// 实重
        /// </summary>
        public decimal? NetWeight { get; set; }
        /// <summary>
        /// 称重流程类型ID
        /// </summary>
        public int? WeightProcess { get; set; }
        /// <summary>
        /// 完成状态  0、预约未审核  1、预约已审核
        /// </summary>
        public int? FinishState { get; set; }

        /// <summary>
        /// 磅单来源
        /// </summary>
        public string? OrderSource { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string? WarehId { get; set; }

        /// <summary>
        /// 仓库业务类别
        /// </summary>
        public string? WarehBizType { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public int? PrintCount { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime? AdditionalTime { get; set; }
        /// <summary>
        /// 磅单完成时间
        /// </summary>
        public DateTime? FinishTime { get; set; }
        /// <summary>
        /// 收费单价
        /// </summary>
        public decimal? UnitCharge { get; set; }
        /// <summary>
        /// 自定义收费
        /// </summary>
        public decimal? CustomCharge { get; set; }

        /// <summary>
        /// 收费方式
        /// </summary>
        public string? ChargeType { get; set; }

        /// <summary>
        /// 本次收费
        /// </summary>
        public decimal? RegularCharge { get; set; }

        /// <summary>
        /// 实际收费
        /// </summary>
        public decimal? RealCharge { get; set; }
        /// <summary>
        /// 客户余额
        /// </summary>
        public decimal? CustomerBalance { get; set; }
        /// <summary>
        /// 运单号
        /// </summary>
        public string? WaybillNo { get; set; }

        /// <summary>
        /// 质检单号
        /// </summary>
        public string? QcNo { get; set; }

        /// <summary>
        /// 质检状态
        /// </summary>
        public int? QcState { get; set; }

        /// <summary>
        /// 轴数
        /// </summary>
        public int? AxleCount { get; set; }

        /// <summary>
        /// 限重重量
        /// </summary>
        public decimal? MaxWeight { get; set; }
        /// <summary>
        /// 超载重量
        /// </summary>
        public decimal? OverWeight { get; set; }

        /// <summary>
        /// 是否超重
        /// </summary>
        public int? OverWeightState { get; set; }
        /// <summary>
        /// 司磅员ID
        /// </summary>
        public string? WeighterId { get; set; }

        public string? WeighterName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public string? PayType { get; set; }
        /// <summary>
        /// 物资金额
        /// </summary>
        public decimal? UnitMoney { get; set; }
        public string? Phone { get; set; }
        /// <summary>
        /// 单个重量
        /// </summary>
        public decimal? d1 { get; set; }
        /// <summary>
        /// 袋总重量
        /// </summary>
        public decimal? d2 { get; set; }
        /// <summary>
        /// 结算重量
        /// </summary>
        public decimal? d3 { get; set; }
        public string? t1 { get; set; }
        public string? t2 { get; set; }
        public string? t3 { get; set; }
        public string? t4 { get; set; }
        public string? t5 { get; set; }
        public string? t6 { get; set; }
        public string? t7 { get; set; }
        public string? t8 { get; set; }
        public string? t9 { get; set; }
        public string? t10 { get; set; }
        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string? OpenId { get; set; }
        public int? SyncState { get; set; }
        public string? RefId { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(CompanyId))]
        public S_Company? Company { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(MaterialId))]
        public S_Material? Material { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(CarId))]
        public S_Car? Car { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(CustomerId))]
        public S_Customer? Customer { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(WarehId))]
        public S_Wareh? Wareh { get; set; }
        [Navigate(NavigateType.OneToMany, nameof(B_File.RecId))]
        public List<B_File>? LstFile { get; set; }
    }
}
