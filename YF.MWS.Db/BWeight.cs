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
    public class BWeight
    {
        /// <summary>
        /// 磅单序列号
        /// </summary>
        public virtual string WeightNo { get; set; }

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

        public virtual int SyncState { get; set; }
        public virtual string WeightId { get; set; }
    }
    public class B_Weight2 {
        public string WeightId { get; set; }
        public int IsOpen { get; set; }
        public int IsClose { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
    public class VWeight : BWeight {
        public int IsClose { get; set; } = 0;
        public int IsOpen { get; set; } = 0;
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string WeightId2 { get; set; }
        /// <summary>
        /// 开仓门地址
        /// </summary>
        public string OpenAddress { get; set; }
        /// <summary>
        /// 关仓门地址
        /// </summary>
        public string CloseAddress { get; set; }
    }
}
