using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.Utility.Cache;

namespace YF.MWS.CacheService
{
    /// <summary>
    /// 称重查询
    /// </summary>
    public class WeightCacher {
        IWeightQueryService weightService =new WeightQueryService();
        /// <summary>
        /// 日明细报表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDayListTable() {
            TopWeightQuery query = new TopWeightQuery() {
                TopN = 0,
                Condition = string.Format("CreateTime >={0} and CreateTime<={1}", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd 00:00:00"))
            };
            return weightService.GetTopListTable(query);
        }
        /// <summary>
        /// 周明细报表
        /// </summary>
        /// <returns></returns>
        public DataTable GetWeekListTable() {
            DateTime dt = DateTime.Now.AddDays(-7);
            string startDay = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).ToString("yyyy-MM-dd 00:00:00");
            string endDay = dt.AddDays(8 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).ToString("yyyy-MM-dd 00:00:00");
            TopWeightQuery query = new TopWeightQuery() {
                TopN = 0,
                Condition = string.Format("CreateTime >={0} and CreateTime<={1}", startDay, endDay)
            };
            return weightService.GetTopListTable(query);
        }
        /// <summary>
        /// 月明细报表
        /// </summary>
        /// <returns></returns>
        public DataTable GetMonthListTable() {
            DateTime dt = DateTime.Now.AddMonths(-1);
            string startDay = dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd 00:00:00");
            string endDay = dt.AddDays(1 - dt.Day).AddMinutes(1).ToString("yyyy-MM-dd 00:00:00");
            TopWeightQuery query = new TopWeightQuery() {
                TopN = 0,
                Condition = string.Format("CreateTime >={0} and CreateTime<={1}", startDay, endDay)
            };
            return weightService.GetTopListTable(query);
        }
        /// <summary>
        /// 年明细报表
        /// </summary>
        /// <returns></returns>
        public DataTable GetYearListTable() {
            DateTime dt = DateTime.Now.AddYears(-1);
            string startDay = new DateTime(dt.Year, 1, 1).ToString("yyyy-MM-dd 00:00:00");
            string endDay = new DateTime(dt.Year + 1, 1, 1).ToString("yyyy-MM-dd 00:00:00");
            TopWeightQuery query = new TopWeightQuery() {
                TopN = 0,
                Condition = string.Format("CreateTime >={0} and CreateTime<={1}", startDay, endDay)
            };
            return weightService.GetTopListTable(query);
        }
        public DataTable GetListTable(DateTypeNew type) {
            if (type == DateTypeNew.day) {
                return GetDayListTable();
            } else if (type == DateTypeNew.week) {
                return GetWeekListTable();
            } else if (type == DateTypeNew.year) {
                return GetYearListTable();
            } else if (type == DateTypeNew.month) { return GetMonthListTable(); } else return null;
        }
    }
}
