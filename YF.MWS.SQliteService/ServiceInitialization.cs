using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;
using YF.Data.NHProvider.Metadata;
using YF.MWS.BaseMetadata;
using YF.Utility.Configuration;
using YF.Utility.Log;

namespace YF.MWS.SQliteService
{
    public class ServiceInitialization
    {
        private static IService service = null;
        public static IService DbService
        {
            get
            {
                return service;
            }
            set
            {
                service = value;
            }
        }

        private static object lockObj = new object();

        /// <summary>
        /// 初始化DB服务
        /// </summary>
        public static void Init()
        {
            try
            {
                string assmblyName = AppSetting.GetValue("MapAssembly");
                string connectionString = AppSetting.GetValue("dsn");
                lock (lockObj)
                {
                    if (null == service)
                    {
                        service = DataServiceFactory.GetInstance(assmblyName, connectionString, DataSourceType.SqlServer.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
    }
}
