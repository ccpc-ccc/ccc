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
    /// <summary>
    /// 客户缓存类
    /// </summary>
    public class CustomerCacher
    {
        private static string customerKey = "customer:";

        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <returns></returns>
        public static List<SCustomer> GetList()
        {
            string key = customerKey + "list";
            List<SCustomer> lstCustomer = new List<SCustomer>();
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstCustomer = (List<SCustomer>)CacheFactory.CacheInstance.Get(key);
            }
            if (lstCustomer == null || lstCustomer.Count==0)
            {
                ICustomerService customerService = new CustomerService();
                lstCustomer = customerService.GetCustomerList();
                CacheFactory.CacheInstance.Add(key, lstCustomer, -1);
            }
            return lstCustomer;
        }

        /// <summary>
        /// 根据类别获取客户列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<SCustomer> GetCustomerList(CustomerType type) 
        {
            List<SCustomer> lstFind = new List<SCustomer>();
            List<SCustomer> lstCustomer= GetList();
            if (lstCustomer != null && lstCustomer.Count > 0) 
            {
                lstFind = lstCustomer.FindAll(c => c.CustomerType == type.ToString());
            }
            return lstFind;
        }

        public static SCustomer Get(string customerId) 
        {
            SCustomer customer = null;
            string key = customerKey + customerId;
            if (CacheFactory.CacheInstance.Contains(key))
            {
                customer = (SCustomer)CacheFactory.CacheInstance.Get(key);
            }
            if (customer == null)
            {
                IMasterService customerService = new MasterService();
                customer = customerService.GetCustomer(customerId);
                CacheFactory.CacheInstance.Add(key, customer);
            }
            return customer;
        }

        public static string GetCustomerName(string customerId)
        {
            string name = string.Empty;
            SCustomer customer = Get(customerId);
            if (customer != null)
            {
                name = customer.CustomerName;
            }
            return name;
        }

        public static void Remove()
        {
            string key = customerKey + "list";
            CacheFactory.CacheInstance.Delete(key);
            GetList();
        }

        /// <summary>
        /// 更新单个客户缓存信息
        /// </summary>
        /// <param name="customerId"></param>
        public static void UpdateCustomer(string customerId) 
        {
            string key = customerKey + customerId;
            CacheFactory.CacheInstance.Delete(key);
            Get(customerId);
        }

        public static void InitCacher() 
        {
            GetList();
        }
    }
}
