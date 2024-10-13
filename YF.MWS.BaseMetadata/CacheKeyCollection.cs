using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    public class CacheKeyCollection
    {
        private static string codeKey = "Code";
        private static string customerKey = "Customer";
        private const string materialPrefix = "Material";

        public static string MaterialCompanyList(string companyId)
        {
            return string.Format("{0}:List:Company:{1}", materialPrefix, companyId);
        }

        public static string CodeListKey()
        {
            return string.Format("{0}:List", codeKey);
        }

        public static string CustomerIdKey(string customerId)
        {
            return string.Format("{0}:Id:{1}", customerKey, customerId);
        }

        public static string CustomerListKey(string companyId)
        {
            return string.Format("{0}:Company:{1}", customerKey, companyId);
        }

        public static string CustomerListKey(CustomerType type, string companyId)
        {
            return string.Format("{0}:Type:{1}:Company:{2}", customerKey, type.ToString(), companyId);
        }
    }
}
