using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Dto
{
    public class WeightUpdate
    {
        public RowState RowState { get; set; }
        public List<string> WeightIds { get; set; }
        public WeightUpdate()
        {
            WeightIds = new List<string>();
        }
    }

    public class WeightBatchUpdate
    {
        public List<string> WeightIds { get; set; }
        public WeightBatchUpdate()
        {
            WeightIds = new List<string>();
        }
    }
}
