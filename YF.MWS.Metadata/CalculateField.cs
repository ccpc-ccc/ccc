using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    public class CalculateField
    {
        private List<string> lstRelatedControl = new List<string>();

        public List<string> LstRelatedControl
        {
            get { return lstRelatedControl; }
            set { lstRelatedControl = value; }
        }

        public string ControlName { get; set; }

        public string Expression { get; set; }

        public int AutoCalNo { get; set; }
         
    }
}
