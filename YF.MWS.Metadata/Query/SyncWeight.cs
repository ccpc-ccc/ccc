using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Query
{
    public class SyncWeight
    {
        public BWeight Weight { get; set; }
        public BWeightDetail TareWeight { get; set; }
        public BWeightDetail GrossWeight { get; set; }
    }
}
