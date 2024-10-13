using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class TMessage
    {
        public string MessageId { get; set; }
        public string MessageType { get; set; }
        public string MessageTitle { get; set; }
        public string MessageTime { get; set; }
        public string MessageContent { get; set; }
    }
}
