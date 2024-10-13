using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class VWeightQc:VWeightFinance
    {
        /// <summary>
        /// 质检单Id
        /// </summary>
        public string QcId { get; set; }

        /// <summary>
        /// 质检单号
        /// </summary>
        public string QcNo { get; set; }

        /// <summary>
        /// 水分
        /// </summary>
        public decimal Water { get; set; }
        /// <summary>
        /// 杂质
        /// </summary>
        public decimal Impurity { get; set; }
        /// <summary>
        /// 黄变率
        /// </summary>
        public decimal YellowRate { get; set; }
        /// <summary>
        /// 出糙率
        /// </summary>
        public decimal BrownRate { get; set; }
        /// <summary>
        /// 色泽气味
        /// </summary>
        public string ColorOdor { get; set; }
        /// <summary>
        /// 整精米率
        /// </summary>
        public decimal MilledRice { get; set; }
        /// <summary>
        /// 综合判定
        /// </summary>
        public string Judgement { get; set; }
        /// <summary>
        /// 重金属
        /// </summary>
        public decimal HeavyMetal { get; set; }
        /// <summary>
        /// 产品流向
        /// </summary>
        public string ProductFlow { get; set; }
        /// <summary>
        /// 互混率
        /// </summary>
        public decimal MutualRate { get; set; }
        /// <summary>
        /// 碎米率
        /// </summary>
        public decimal BrokenRate { get; set; }
        /// <summary>
        /// 其中：小碎
        /// </summary>
        public decimal SmallBrokenRate { get; set; }
        /// <summary>
        /// 糠粉率
        /// </summary>
        public decimal PowderRate { get; set; }
        /// <summary>
        /// 脂肪酸值
        /// </summary>
        public decimal FattyAcid { get; set; }
        /// <summary>
        /// 不完善粒
        /// </summary>
        public decimal ImperfectGrain { get; set; }

        /// <summary>
        /// 质检员
        /// </summary>
        public string Inspector { get; set; }
        /// <summary>
        /// 质检状态
        /// </summary>
        public int QcState { get; set; }
    }
}
