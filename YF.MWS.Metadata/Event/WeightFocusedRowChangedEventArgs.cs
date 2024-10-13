using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public class WeightFocusedRowChangedEventArgs : EventArgs
    {
        private string weightId;

        public string WeightId
        {
            get { return weightId; }
            set { weightId = value; }
        }

        public WeightFocusedRowChangedEventArgs(string weightId) 
        {
            this.weightId = weightId;
        }
    }
}
