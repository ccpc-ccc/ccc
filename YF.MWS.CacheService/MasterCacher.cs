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
    public class MasterCacher
    {
        private const string codeKey = "code:";

        public static SCompany GetCompany()
        {
            SCompany corp = null;
            string key = "Client-Company";
            if (CacheFactory.CacheInstance.Contains(key))
            {
                corp = (SCompany)CacheFactory.CacheInstance.Get(key);
            }
            if (corp == null)
            {
                ICompanyService companyService = new CompanyService();
                corp = companyService.GetCompany();
                CacheFactory.CacheInstance.Add(key, corp, -1);
            }
            return corp;
        } 

        public static List<SCode> GetCodeList()
        {
            List<SCode> lstCode = new List<SCode>();
            string key = codeKey + "list";
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstCode = (List<SCode>)CacheFactory.CacheInstance.Get(key);
            }
            else
            {
                IMasterService masterService = new MasterService();
                lstCode = masterService.GetList();
                if (lstCode != null && lstCode.Count > 0)
                {
                    lstCode = lstCode.OrderBy(code => code.OrderNo).ToList();
                }
                CacheFactory.CacheInstance.Add(key, lstCode, -1);
            }
            return lstCode;
        }

        public static string GetCodeCapiton(string codeType, string code)
        {
            string caption = code;
            List<SCode> lstCode = GetSubCodeList(codeType);
            if (lstCode != null && lstCode.Count > 0)
            {
                foreach (SCode c in lstCode)
                {
                    if (c.ItemCode.ToLower() == code.ToLower())
                    {
                        caption = c.ItemCaption;
                        break;
                    }
                }
            }
            return caption;
        }

        public static List<SCode> GetSubCodeList(string code)
        {
            List<SCode> lstAll= GetCodeList();
            SCode parent = null;
            List<SCode> lstFind = new List<SCode>();
            if (lstAll != null && lstAll.Count > 0)
            {
                parent = lstAll.Find((c => c.ItemCode == code && (string.IsNullOrEmpty(c.ParentId) || c.ParentId.Length == 0)));
                if (parent != null)
                {
                    lstFind = lstAll.FindAll(c => c.ParentId == parent.Id);
                }
            }
            return lstFind;
        }

        public static void InitCacher() 
        {
            List<SCode> lstCode = GetCodeList();
            GlobalCacher.LstCode = lstCode;
        }

        public static void Refresh() 
        {
            string key = codeKey + "list";
            CacheFactory.CacheInstance.Delete(key);
            List<SCode> lstCode = GetCodeList();
            GlobalCacher.LstCode = lstCode;
        }
    }
}
