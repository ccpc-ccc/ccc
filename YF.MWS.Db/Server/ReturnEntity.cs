using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db.Server {
    public class ReturnEntity {
        public Result result { get; set; }
        public int status { get; set; }
        public string message { get; set; }
    }
    public class Result {
        public string status { get; set; }
        public string message { get; set; }

    }
}
