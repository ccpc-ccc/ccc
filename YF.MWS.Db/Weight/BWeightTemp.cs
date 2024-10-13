using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class BWeightTemp : BaseEntity
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 注册码(每个客户端注册后会生成的)
        /// </summary>
        public virtual string MachineCode { get; set; }
        public virtual string WeightNo { get; set; }
        public virtual decimal Weight { get; set; }
        public virtual DateTime WeightTime { get; set; }
        public virtual string Unit { get; set; }
        public virtual string WeighterId { get; set; }
        public virtual string WeighterName { get; set; }
        public virtual string CarNo { get; set; }
        public virtual int AxleCount { get; set; }
        public virtual int OverloadState { get; set; }
        public virtual string OverloadStateDesc 
        {
            get 
            {
                var desc = "未超载";
                if (OverloadState == 1)
                {
                    desc = "已超载";
                }
                return desc;
            }
        }
    }
}
