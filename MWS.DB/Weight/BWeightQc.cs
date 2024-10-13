using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    public class BWeightQc:BaseEntity
    {
        /// <summary>
        /// 质检单号
        /// </summary>
        public virtual string QcNo { get; set; }

        /// <summary>
        /// 质检日期
        /// </summary>
        public virtual DateTime? QcDate { get; set; }

        /// <summary>
        /// 车牌Id
        /// </summary>
        public virtual string CarId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }

        /// <summary>
        /// 原发数量
        /// </summary>
        public virtual decimal PrimaryAmount { get; set; }
        /// <summary>
        /// 磅单ID
        /// </summary>
        public virtual string WeightId { get; set; }
        /// <summary>
        /// 磅单序列号
        /// </summary>
        public virtual string WeightNo { get; set; }

        public virtual string MaterialId { get; set; }
        /// <summary>
        /// 发货商ID
        /// </summary>
        public virtual string DeliveryId { get; set; }
        /// <summary>
        /// 收货商ID
        /// </summary>
        public virtual string ReceiverId { get; set; }

        public virtual string MeasureType { get; set; }
        /// <summary>
        /// 水分
        /// </summary>
        public virtual decimal Water { get; set; }
        /// <summary>
        /// 杂质
        /// </summary>
        public virtual decimal Impurity { get; set; }
        /// <summary>
        /// 黄变率
        /// </summary>
        public virtual decimal YellowRate { get; set; }
        /// <summary>
        /// 出糙率
        /// </summary>
        public virtual decimal BrownRate { get; set; }
        /// <summary>
        /// 色泽气味
        /// </summary>
        public virtual string ColorOdor { get; set; }
        /// <summary>
        /// 整精米率
        /// </summary>
        public virtual decimal MilledRice { get; set; }
        /// <summary>
        /// 综合判定
        /// </summary>
        public virtual string Judgement { get; set; }
        /// <summary>
        /// 重金属
        /// </summary>
        public virtual decimal HeavyMetal { get; set; }
        /// <summary>
        /// 产品流向
        /// </summary>
        public virtual string ProductFlow { get; set; }
        /// <summary>
        /// 互混率
        /// </summary>
        public virtual decimal MutualRate { get; set; }
        /// <summary>
        /// 碎米率
        /// </summary>
        public virtual decimal BrokenRate { get; set; }
        /// <summary>
        /// 其中：小碎
        /// </summary>
        public virtual decimal SmallBrokenRate { get; set; }
        /// <summary>
        /// 糠粉率
        /// </summary>
        public virtual decimal PowderRate { get; set; }
        /// <summary>
        /// 脂肪酸值
        /// </summary>
        public virtual decimal FattyAcid { get; set; }
        /// <summary>
        /// 不完善粒
        /// </summary>
        public virtual decimal ImperfectGrain { get; set; }
        /// <summary>
        /// 质检员
        /// </summary>
        public virtual string Inspector { get; set; }
        /// <summary>
        /// 质检状态
        /// </summary>
        public virtual int QcState { get; set; }
        /// <summary>
        /// 包装方式
        /// </summary>
        public virtual string PackageType { get; set; }
        public virtual string Remark { get; set; }
    }
}
