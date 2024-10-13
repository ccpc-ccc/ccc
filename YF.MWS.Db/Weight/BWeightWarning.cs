using System;

namespace YF.MWS.Db
{
    /// <summary>
    /// 榜单预警
    /// </summary>
    public class BWeightWarning : BaseEntity
    {
        /// <summary>
        /// 预警磅单Id（不可空）
        /// </summary>
        public virtual string WeightId { get; set; }
        ///// <summary>
        ///// 磅单编号（不可空）
        ///// </summary>
        //public virtual string WeightNo { get; set; }
        /// <summary>
        /// 预警类型，与S_Code关联（不可空）
        /// </summary>
        public virtual string WarningType { get; set; }
        /// <summary>
        /// 预警内容（不可空）
        /// </summary>
        public virtual string WarnContent { get; set; }
        /// <summary>
        /// 发生时间（不可空）
        /// </summary>
        public virtual DateTime WarnTime { get; set; }
        /// <summary>
        /// 责任人（可空）
        /// </summary>
        public virtual string ChargerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string UserId { get; set; }
        /// <summary>
        /// 是否解决（0：未解决 1：已解决）（不可空）
        /// </summary>
        public virtual int ResolveState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime ResolveTime { get; set; }
        /// <summary>
        /// 解决备注（可空）
        /// </summary>
        public virtual string Solution { get; set; }
    }
}
