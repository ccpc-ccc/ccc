using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public class CheckBoxChangedEventArgs : EventArgs
    {
        private bool check = false;

        public bool Checked
        {
            get { return check; }
            set { check = value; }
        }
        public CheckBoxChangedEventArgs(bool check) 
        {
            this.check = check;
        }
    }
}
