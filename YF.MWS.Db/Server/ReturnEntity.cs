using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db.Server {
    public class ReturnEntity {
        public bool Result { get; set; }
        public string Token { get; set; }
        public bool success { get; set; }
        public string msg { get; set; }
        public string Message { get; set; }
        public Newtonsoft.Json.Linq.JObject model { get; set; }
    }
    public class ServerReturnEntity {
        public bool success { get; set; }
        public string Token { get; set; }
        public string msg { get; set; }
        public Newtonsoft.Json.Linq.JObject obj { get; set; }
    }
}
