using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public class DeviceReconnectedEventArgs : EventArgs
    {
        public int No { get; set; }
        public DeviceReconnectedEventArgs(int no) 
        {
            No = no;
        }
    }
}
