using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.Utility.Cache;

namespace YF.MWS.CacheService
{
    public class PayCacher
    {
        private static readonly string chargeCfgKey = "charge:";

        public static List<SCharge> GetChargeList()
        {
            string key = chargeCfgKey + "list";
            List<SCharge> lstPrice = new List<SCharge>();
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstPrice = (List<SCharge>)CacheFactory.CacheInstance.Get(key);
            }
            else
            {
                IPayService masterService = new PayService();
                lstPrice = masterService.GetChargeList();
                CacheFactory.CacheInstance.Add(chargeCfgKey, lstPrice, -1);
            }
            return lstPrice;
        }

        public static void RemoveChargeList()
        {
            string key = chargeCfgKey + "list";
            CacheFactory.CacheInstance.Delete(key);
        }
    }
}
