using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.Utility;

namespace YF.MWS.Metadata.Query
{
    public class QLog : BLog
    {
        public string FullName { get; set; }
        public string ActionTypeName { get { return ActionType.ToEnum<LogActionType>().ToDescription(); } }
    }
}
