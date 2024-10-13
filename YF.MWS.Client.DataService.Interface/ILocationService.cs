using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ILocationService
    {
        SLocation GetLocation(string locationId);
        List<LocationFull> GetLocationList();
        bool SaveLocation(SLocation location);
    }
}
