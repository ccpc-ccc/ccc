using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 磅单财务扩展信息
    /// </summary>
    public class BWeightExt:BaseEntity
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public virtual string CardNo { get; set; }
        /// <summary>
        /// 结算单号
        /// </summary>
        public virtual string SettleNo { get; set; }
        /// <summary>
        /// 财务结算
        /// </summary>
        public virtual int SettleState { get; set; }
        /// <summary>
        /// 运费结算
        /// </summary>
        public virtual int FreightSettleState { get; set; }
        /// <summary>
        /// 货款结算
        /// </summary>
        public virtual int PaymentSettleState { get; set; }
        /// <summary>
        /// 物资系列Id
        /// </summary>
        public virtual string MaterialSeriesId { get; set; }
    }
}
