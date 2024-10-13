using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Query
{
    public class LogQuery : BaseQuery
    {
        public LogActionType? ActionType { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Key { get; set; }
    }
}
