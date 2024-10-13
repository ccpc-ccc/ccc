using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.Utility.Cache;

namespace YF.MWS.CacheService
{
    public class MaterialCacher
    {
        private static string materialKey = "material:";

        /// <summary>
        /// 获取所有物资信息
        /// </summary>
        /// <returns></returns>
        public static List<SMaterial> GetMaterialList()
        {
            string key = materialKey + "list";
            List<SMaterial> lstCustomer = new List<SMaterial>();
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstCustomer = (List<SMaterial>)CacheFactory.CacheInstance.Get(key);
            }
            if (lstCustomer == null || lstCustomer.Count == 0)
            {
                IMaterialService matedrialService = new MaterialService();
                lstCustomer = matedrialService.GetMaterialList(MaterialStateType.Enable);
                CacheFactory.CacheInstance.Add(key, lstCustomer, -1);
            }
            return lstCustomer;
        }

        public static SMaterial Get(string materialId)
        {
            SMaterial customer = null;
            List<SMaterial> lstCustomer = GetMaterialList();
            if (lstCustomer != null && lstCustomer.Count > 0)
            {
                customer = lstCustomer.Find(c => c.Id == materialId);
            }
            return customer;
        }

        public static string GetMaterialName(string materialId)
        {
            string name = string.Empty;
            SMaterial material = Get(materialId);
            if (material != null)
            {
                name = material.MaterialName;
            }
            return name;
        }

        public static void Refresh()
        {
            string key = materialKey + "list";
            CacheFactory.CacheInstance.Delete(key);
            GetMaterialList();
        }

        public static void InitCacher()
        {
            GetMaterialList();
        }
    }
}
