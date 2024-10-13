using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    public class LocationService : BaseService,ILocationService
    {

        public SLocation GetLocation(string locationId)
        {
            string sql = string.Format("select * from S_Location where Id='{0}'", locationId);
            return base.getModel<SLocation>(sql);
        }
        public List<LocationFull> GetLocationList()
        {
            string sql = "select * from S_Location";
            return base.getList<LocationFull>(sql);
        }
        public bool SaveLocation(SLocation location)
        {
            if (string.IsNullOrEmpty(location.Id))
            {
                location.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                return service.Save<SLocation>(location, location.Id);
            }
            else
            {
                string sql = SqliteSqlUtil.GetSaveSql<SLocation>(location, "S_Location");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
        }
    }
}
