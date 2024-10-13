using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Configuration;
using YF.Utility;

namespace YF.MWS.Metadata.Query
{
    public class PageQueryCondition
    {
        [JsonProperty("extendCondition")]
        public string ExtendCondition;
        [JsonProperty("lstColumn")]
        public List<QColumn> LstColumn;
        [JsonProperty("pageIndex")]
        public int PageIndex;
        [JsonProperty("pageSize")]
        public int PageSize;

        public PageQueryCondition()
        {
            PageSize = AppSetting.GetValue("pageSize").ToInt();
            if (PageSize == 0)
            {
                PageSize = 50;
            }
        }
    }
}
