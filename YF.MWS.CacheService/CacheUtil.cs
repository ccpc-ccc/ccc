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
            WarehCacher.GetWarehList();
            MaterialCacher.InitCacher();
        }

        /// <summary>
        /// 刷新系统缓存
        /// </summary>
        public static void Refresh() 
        {
            CarCacher.Remove();
            CardCacher.Refresh();
            CustomerCacher.Remove();
            MasterCacher.Refresh();
            WarehCacher.Refresh();
            MaterialCacher.Refresh();
        }
    }
}
