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
    public class WarehCacher
    {
        private const string warehKey = "Wareh_";

        public static List<SWareh> GetWarehList()
        {
            List<SWareh> lstWareh = new List<SWareh>();
            string key = warehKey+"List";
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstWareh = (List<SWareh>)CacheFactory.CacheInstance.Get(key);
            }
            else
            {
                IWarehService roleService = new WarehService();
                lstWareh = roleService.GetList();
                CacheFactory.CacheInstance.Add(key, lstWareh, -1);
            }
            return lstWareh;
        }

        public static void Refresh() 
        {
            string key = warehKey + "List";
            CacheFactory.CacheInstance.Delete(key);
            GetWarehList();
        }
    }
}
