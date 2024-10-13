using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata
{
    public class WeightCapture
    {
        public FinishState State { get; set; }
        public string WeightId { get; set; }
        public string WaterMarkText { get; set; }
    }
}
