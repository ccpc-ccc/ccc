using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    public class WeightPageQueryCondition : PageQueryCondition
    {
        [JsonProperty("viewId")]
        public string ViewId;
    }
}
