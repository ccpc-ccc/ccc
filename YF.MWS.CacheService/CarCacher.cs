using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.Utility.Cache;

namespace YF.MWS.CacheService
{
    /// <summary>
    /// 车辆缓存
    /// </summary>
    public class CarCacher
    {
        private static string carKey = "car:";

        /// <summary>
        /// 获取车辆信息
        /// </summary>
        /// <returns></returns>
        public static List<SCar> GetList()
        {
            string key = carKey + "list";
            List<SCar> lstCar =null;
            if (CacheFactory.CacheInstance.Contains(key))
            {
                lstCar = (List<SCar>)CacheFactory.CacheInstance.Get(key);
            }
            if (lstCar == null || lstCar.Count==0)
            {
                ICarService cardService = new CarService();
                lstCar = cardService.GetList();
                CacheFactory.CacheInstance.Add(key, lstCar, -1);
            }
            return lstCar;
        }

        public static SCar Get(string carId)
        {
            SCar car = null;
            if (!string.IsNullOrEmpty(carId))
            {
                List<SCar> lstCar = GetList();
                if (lstCar != null && lstCar.Count > 0)
                {
                    car = lstCar.Find(c => c.Id == carId);
                }
            }
            return car;
        }

        public static SCar GetWithCarNo(string carNo) 
        {
            SCar car = null;
            string key = string.Format("{0}{1}",carKey,carNo);
            if (CacheFactory.CacheInstance.Contains(key)) 
            {
                car = (SCar)CacheFactory.CacheInstance.Get(key);
            }
            if (car==null)
            {
                ICarService cardService = new CarService();
                car = cardService.GetByCarNo(carNo);
                if (car != null)
                {
                    CacheFactory.CacheInstance.Add(key, car);
                }
            }
            return car;
        }

        public static void Remove(string carNo) 
        {
            string key = string.Format("{0}{1}", carKey, carNo);
            CacheFactory.CacheInstance.Delete(key);
        }

        public static void Remove() 
        {
            string key = carKey + "list";
            CacheFactory.CacheInstance.Delete(key);
            InitCacher();
        }

        public static void InitCacher() 
        {
            GetList();
        }
    }
}
