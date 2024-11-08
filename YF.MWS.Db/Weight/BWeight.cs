using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 磅单主表
    /// Author:闫孝感
    /// Date:2024-09-10
    /// </summary>
    public class BWeight:BaseEntity
    {
        /// <summary>
        /// 磅单序列号
        /// </summary>
        public virtual string WeightNo { get; set; }

        public virtual string ViewId { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary>
        public virtual string CustomerId { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 过毛重站点
        /// </summary>
        public virtual string MachineCode { get; set; }
        /// <summary>
        /// 过皮重站点
        /// </summary>
        public virtual string TareMachineCode { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public virtual string SupplierId { get; set; }
        /// <summary>
        /// 发货商ID
        /// </summary>
        public virtual string DeliveryId { get; set; }
        /// <summary>
        /// 收货商ID
        /// </summary>
        public virtual string ReceiverId { get; set; }
        /// <summary>
        /// 承运商ID
        /// </summary>
        public virtual string TransferId { get; set; }
        /// <summary>
        /// 车牌ID
        /// </summary>
        public virtual string CarId { get; set; }
        /// <summary>
        /// 车牌号(如:粤B 888888)
        /// </summary>
        public virtual string CarNo { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public virtual string CardNo { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public virtual string DriverName { get; set; }
        /// <summary>
        /// 物资ID
        /// </summary>
        public virtual string MaterialId { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public virtual string MaterialModel { get; set; }
        /// <summary>
        /// 生产商ID
        /// </summary>
        public virtual string ManufacturerId { get; set; }
        /// <summary>
        /// 物资数量
        /// </summary>
        public virtual decimal MaterialAmount { get; set; }
        /// <summary>
        /// 物资单价
        /// </summary>
        public virtual decimal UnitPrice { get; set; }
        /// <summary>
        /// 计量业务类型
        /// </summary>
        public virtual string MeasureType { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public virtual string MeasureUnit { get; set; }
        /// <summary>
        /// 杂质计算类型
        /// </summary>
        public virtual string ImpurityMeaType { get; set; }
        /// <summary>
        /// 杂质量
        /// </summary>
        public virtual decimal ImpurityWeight { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public virtual decimal TareWeight { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public virtual decimal GrossWeight { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public virtual decimal SuttleWeight { get; set; }
        /// <summary>
        /// 实重
        /// </summary>
        public virtual decimal NetWeight { get; set; }
        /// <summary>
        /// 称重流程类型ID
        /// </summary>
        public virtual int WeightProcess { get; set; }
        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual int FinishState { get; set; }

        /// <summary>
        /// 磅单来源
        /// </summary>
        public virtual string OrderSource { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public virtual string WarehId { get; set; }

        /// <summary>
        /// 仓库业务类别
        /// </summary>
        public virtual string WarehBizType { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public virtual int PrintCount { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        public virtual DateTime? AdditionalTime { get; set; }
        /// <summary>
        /// 磅单完成时间
        /// </summary>
        public virtual DateTime FinishTime { get; set; }
        /// <summary>
        /// 毛重时间
        /// </summary>
        public virtual DateTime GrossTime { get; set; }
        /// <summary>
        /// 皮重时间
        /// </summary>
        public virtual DateTime TareTime { get; set; }
        /// <summary>
        /// 收费单价
        /// </summary>
        public virtual decimal UnitCharge { get; set; }
        /// <summary>
        /// 自定义收费
        /// </summary>
        public virtual decimal CustomCharge { get; set; }

        /// <summary>
        /// 收费方式
        /// </summary>
        public virtual string ChargeType { get; set; }

        /// <summary>
        /// 本次收费
        /// </summary>
        public virtual decimal RegularCharge { get; set; }

        /// <summary>
        /// 实际收费
        /// </summary>
        public virtual decimal RealCharge { get; set; }
        /// <summary>
        /// 客户余额
        /// </summary>
        public virtual decimal CustomerBalance { get; set; }
        /// <summary>
        /// 运单号
        /// </summary>
        public virtual string WaybillNo { get; set; }

        /// <summary>
        /// 质检单号
        /// </summary>
        public virtual string QcNo { get; set; }

        /// <summary>
        /// 质检状态
        /// </summary>
        public virtual int QcState { get; set; }

        /// <summary>
        /// 轴数
        /// </summary>
        public virtual int AxleCount { get; set; }

        /// <summary>
        /// 限重重量
        /// </summary>
        public virtual decimal MaxWeight { get; set; }
        /// <summary>
        /// 超载重量
        /// </summary>
        public virtual decimal OverWeight { get; set; }

        /// <summary>
        /// 是否超重
        /// </summary>
        public virtual int OverWeightState { get; set; }
        /// <summary>
        /// 司磅员ID
        /// </summary>
        public virtual string WeighterId { get; set; }
        /// <summary>
        /// 司磅员姓名
        /// </summary>

        public virtual string WeighterName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public virtual string PayType { get; set; }
        /// <summary>
        /// 物资金额
        /// </summary>
        public virtual decimal UnitMoney { get; set; }
        /// <summary>
        /// 单个重量
        /// </summary>
        public virtual decimal d1 { get; set; }
        /// <summary>
        /// 袋总重量
        /// </summary>
        public virtual decimal d2 { get; set; }
        /// <summary>
        /// 结算重量
        /// </summary>
        public virtual decimal d3 { get; set; }
        public virtual decimal d4 { get; set; }
        public virtual decimal d5 { get; set; }
        public virtual decimal d6 { get; set; }
        public virtual decimal d7 { get; set; }
        public virtual decimal d8 { get; set; }
        public virtual decimal d9 { get; set; }
        public virtual string t1 { get; set; }
        public virtual string t2 { get; set; }
        public virtual string t3 { get; set; }
        public virtual string t4 { get; set; }
        public virtual string t5 { get; set; }
        public virtual string t6 { get; set; }
        public virtual string t7 { get; set; }
        public virtual string t8 { get; set; }
        public virtual string t9 { get; set; }
        public virtual string t10 { get; set; }

        public virtual int SyncState { get; set; }
        public virtual string RefId { get; set; }
        [Field(IsSqliteIgnore =true)]
        public virtual int FinishedCarCount { get; set; }
        [Field(IsSqliteIgnore = true)]
        public virtual decimal FinishedWeight { get; set; }
        /// <summary>
        /// 服务端磅单Id
        /// </summary>
        public virtual string ServiceId { get; set; }
    }
}
