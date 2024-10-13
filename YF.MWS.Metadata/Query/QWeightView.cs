using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Query
{
    public class QWeightView : SWeightView
    {
        private string viewTypeCaption;

        public string ViewTypeCaption
        {
            get { return viewTypeCaption; }
            set { viewTypeCaption = value; }
        }

        public string ExtViewName 
        {
            get 
            {
                if (IsDefault == 1)
                {
                    return string.Format("{0}(默认界面)", ViewName);
                }
                else 
                {
                    return ViewName;
                }
            }
        }

        
    }
}
