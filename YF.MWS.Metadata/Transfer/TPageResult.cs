using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class TPageResult
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("pageNo")]
        public int PageNo { get; set; }
        [JsonProperty("totalPage")]
        public int TotalPage
        {
            get
            {
                if (PageSize > 0)
                {
                    return (Count % PageSize == 0) ? Count / PageSize : Count / PageSize + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("rows")]
        public object Rows { get; set; }
    }
}
