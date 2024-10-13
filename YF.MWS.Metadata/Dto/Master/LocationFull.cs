using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility;

namespace YF.MWS.Metadata.Dto
{
    public class LocationFull : SLocation
    {
        public string LocationTypeName
        {
            get
            {
                return LocationType.ToDescription();
            }
        }
    }
}
