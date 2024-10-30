using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata;
using YF.MWS.Db; 
using YF.Utility.Cache;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;

namespace YF.MWS.CacheService
{
    public class CacheUtil
    {
        /// <summary>
        /// 初始化缓存数据
        /// </summary>
        public static void Init()
        {
            CarCacher.InitCacher();
            CardCacher.InitCacher();
            CustomerCacher.InitCacher();
            MasterCacher.InitCacher();
            MaterialCacher.InitCacher();
        }
    }
}
