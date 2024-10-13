using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IWarehService
    {
        bool Delete(string warehId);
        SWareh Get(string warehId);
        SWareh GetByName(string warehName);
        List<SWareh> GetList();
        bool Save(SWareh wareh);
    }
}
