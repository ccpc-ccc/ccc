using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Event
{
    public class WeightVauleChangedEventArgs : EventArgs
    {
        private string controlName;
        private string fieldName;
        private string actionName;

        public string ActionName
        {
            get { return actionName; }
            set { actionName = value; }
        }

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        public string ControlName
        {
            get { return controlName; }
            set { controlName = value; }
        }

        public WeightVauleChangedEventArgs(string controlName) 
        {
            this.controlName = controlName;
        }
    }
}
