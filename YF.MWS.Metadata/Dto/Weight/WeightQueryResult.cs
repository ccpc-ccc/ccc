using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Dto
{
    public class WeightQueryResult
    {
        public int Total { get; set; }
        public DataTable Weight { get; set; }
    }
}
