using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public class WeightItemClickEventArgs : EventArgs
    {
        private WeightCommand command;

        public WeightCommand Command
        {
            get { return command; }
        }
        private WeightDirection direction;

        public WeightDirection Direction
        {
            get { return direction; }
        }

        public WeightItemClickEventArgs(WeightCommand command, WeightDirection direction) 
        {
            this.command = command;
            this.direction = direction;
        }
    }
}
