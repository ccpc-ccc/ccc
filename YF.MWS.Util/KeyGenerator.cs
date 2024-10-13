using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.Utility;

namespace YF.MWS.Util
{
    public class KeyGenerator
    {
        public static string GetWeightQueryKey(string prefix, string bizType, WeightQueryCondition condition) 
        {
            StringBuilder sbKey = new StringBuilder();
            sbKey.AppendFormat("{0}:{1}:{2}", prefix, bizType,condition.JsonSerialize().ToMd5());
            return sbKey.ToString();
        }
    }
}
