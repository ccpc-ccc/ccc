using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 计划单
    /// </summary>
    public class BPlan : BaseEntity
    {
        public virtual string DeptId { get; set; }
        public virtual string PlanNo { get; set; }
        /// <summary>
        /// 计划单类型
        /// </summary>
        public virtual PlanType PlanType { get; set; }
        public virtual string CarNo { get; set; }
        /// <summary>
        /// 物资Id
        /// </summary>
        public virtual string MaterialId { get; set; }
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 客户单位Id
        /// </summary>
        public virtual string CustomerId { get; set; }
        public virtual string DeliveryId { get; set; }
        public virtual string ReceiverId { get; set; }
        /// <summary>
        /// 限制类型
        /// </summary>
        public virtual PlanLimitType LimitType { get; set; }
        /// <summary>
        /// 仓库业务类型
        /// </summary>
        public virtual WarehBizType WarehBiz { get; set; }
        /// <summary>
        /// 计划车次
        /// </summary>
        public virtual int PlanCarCount { get; set; }
        /// <summary>
        /// 完成次数
        /// </summary>
        public virtual int FinishedCarCount { get; set; }
        /// <summary>
        /// 计划吨位
        /// </summary>
        public virtual decimal PlanWeight { get; set; }
        /// <summary>
        /// 完成吨位
        /// </summary>
        public virtual decimal FinishedWeight { get; set; }
        /// <summary>
        /// 剩余吨位
        /// </summary>
        /// 
        [Field(IsSqliteIgnore = true)]
        public virtual decimal SurplusWeight
        {
            get
            {
                return PlanWeight - FinishedWeight;
            }
        }
        /// <summary>
        /// 剩余车次
        /// </summary>
        /// 
        [Field(IsSqliteIgnore =true)]
        public virtual int SurplusCarCount
        {
            get
            {
                if (PlanCarCount == 0)
                    return 0;
                else
                    return PlanCarCount - FinishedCarCount;
            }
        }
        public virtual PlanStateType PlanState { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
        public virtual string Remark { get; set; }
        public virtual SyncState SyncState { get; set; }
    }
}
