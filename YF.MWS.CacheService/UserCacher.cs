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
    public class UserCacher
    {
        private const string userKey = "user:";

        public static List<SModule> GetModuleList()
        {
            List<SModule> lstModule = new List<SModule>();
            string key = userKey + "module";
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstModule = (List<SModule>)CacheFactory.CacheInstance.Get(key);
            }
            else
            {
                IRoleService roleService = new RoleService();
                lstModule = roleService.GetModuleList();
                CacheFactory.CacheInstance.Add(key, lstModule, -1);
            }
            return lstModule;
        }

        public static List<SModule> GetModuleList(string userId)
        {
            List<SModule> lstModule = new List<SModule>();
            string key = userKey+"module-" + userId;
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstModule = (List<SModule>)CacheFactory.CacheInstance.Get(key);
            }
            else
            {
                IRoleService roleService = new RoleService();
                lstModule = roleService.GetModuleList(userId);
                CacheFactory.CacheInstance.Add(key, lstModule, -1);
            }
            return lstModule;
        }
    }
}
