using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility;

namespace YF.MWS.Metadata.Dto
{
    public class PlanFull : BPlan
    {
        public string DeptName { get; set; }
        public string MaterialName { get; set; }
        public string CustomerName { get; set; }
        public string DeliverName { get; set; }
        public string ReceiverName { get; set; }
        public string LimitTypeName
        {
            get
            {
                return LimitType.ToDescription();
            }
        }
        public string PlanStateName
        {
            get
            {
                return PlanState.ToDescription();
            }
        }
        public string WarehBizName
        {
            get
            {
                return WarehBiz.ToDescription();
            }
        }
    }
}
