using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public class ViewItemClickEventArgs : EventArgs
    {
        private WeightDirection direction;

        public WeightDirection Direction
        {
            get { return direction; }
        }

        private string viewId;

        public string ViewId
        {
            get { return viewId; }
            set { viewId = value; }
        }

        public ViewItemClickEventArgs(WeightDirection direction, string viewId) 
        {
            this.direction = direction;
            this.viewId = viewId;
        }
    }
}
