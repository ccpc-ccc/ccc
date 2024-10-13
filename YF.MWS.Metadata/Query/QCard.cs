using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Query
{
    /// <summary>
    /// IC计划卡信息查询
    /// Author:闫孝感
    /// Date:2023-11-14
    /// </summary>
    public class QPlanCard : BPlanCard
    {
        public override string CustomerName { get; set; }
        public override string  DeliveryName { get; set; }
        public override string ReceiverName { get; set; }
        public override string MaterialName { get; set; }
    }
}
