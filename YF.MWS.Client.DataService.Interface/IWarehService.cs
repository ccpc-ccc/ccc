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
        VWareh Get(string warehId);
        SWareh GetByName(string warehName);
        List<VWareh> GetList();
        void Save2(VWareh model);
        void OptionWareh(string weightId, string type);
        List<VWeight> GetBWeights();
    }
}
