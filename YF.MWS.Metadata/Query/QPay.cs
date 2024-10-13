using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility;

namespace YF.MWS.Metadata.Query
{
    public class QPay : BPay
    {
        public string WeightId { get; set; }
        public string WeightNo { get; set; }
        public decimal RechargeAmount { get; set; }
        public decimal PayTotal { get; set; }
        public decimal PayAmountF 
        {
            get 
            {
                BaseMetadata.PayBizType type = PayBizType.ToEnum<BaseMetadata.PayBizType>();
                if (type == BaseMetadata.PayBizType.Recharge || type == BaseMetadata.PayBizType.Refund)
                    return PayAmount;
                else
                    return 0 - PayAmount;
            }
        }
        public string PayBizTypeName 
        {
            get 
            {
                return PayBizType.ToEnum<BaseMetadata.PayBizType>().ToDescription();
            }
        }
    }
}

