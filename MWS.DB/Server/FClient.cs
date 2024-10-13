using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.ECS.Db.Server
{
    /// <summary>
    /// 附件实体类
    /// </summary>
    public class FClient
    {
        public int id { get; set; }
        public string clientCode { get; set; }
        public string clientKey { get; set; }
        public string clientId { get; set; }
        
    }
}
