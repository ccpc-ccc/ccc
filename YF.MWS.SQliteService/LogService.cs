using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    /// <summary>
    /// 日志服务类
    /// Author:仇军
    /// Date:2015-02-08
    /// </summary>
    public class LogService :BaseService, ILogService
    {
        #region ILogService 成员

        public bool Add(BLog log)
        {
            if(string.IsNullOrEmpty(log.Id))
                log.Id = YF.MWS.Util.Utility.GetGuid();
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = SqliteSqlUtil.GetSaveSql<BLog>(log, "B_Log");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.Insert(log);
            }
        }

        public bool Add(LogActionType type, string recId, string recNo, string logDesc) 
        {
            BLog log = new BLog();
            log.LogDesc = logDesc;
            log.LogTime = DateTime.Now;
            log.ActionType = type.ToString();
            log.RecId = recId;
            log.RecNo = recNo;
            log.Id = YF.MWS.Util.Utility.GetGuid();
            log.UserId = CurrentUser.Instance.Id;
            return Add(log);
        }

        public bool Delete(List<string> lstLogId)
        {
            string sql = string.Empty;
            List<string> lstSql = new List<string>();
            foreach(string logId in lstLogId){
                sql = string.Format(@"DELETE FROM B_Log  WHERE Id = '{0}'", logId);
                lstSql.Add(sql);
            }
            return ExecuteSql(lstSql);
        }

        public PageList<QLog> GetList(LogQuery query)
        {
            PageList<QLog> result = new PageList<QLog>();
            int pageNo = query.PageIndex;
            int pageSize = query.PageSize;
            int startPageIndex = pageNo * pageSize;
            int endPageIndex = (pageNo + 1) * pageSize;
            string condition = QueryUtil.GetLogCondition(query);
            string sql = string.Format(@"select count(*) from B_Log a {0}", condition);
            object scalar = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                scalar = sqliteDb.ExecuteScalar(sql);
                if (scalar != null)
                    result.Total = Convert.ToInt32(scalar);
                sql = string.Format(@"select a.*,b.FullName from(select a.ActionType,a.RecNo,a.Id,a.LogDesc,a.UserId,a.LogTime 
                                                   from B_Log a {0} order by a.LogTime desc limit {1},{2}) a 
                                                  left join S_User b on a.UserId=b.Id", condition, startPageIndex, pageSize);
                result.Models = sqliteDb.GetObjectList<QLog>(sql);
            }
            else
            {
                scalar = service.GetScalar(sql);
                if (scalar != null)
                    result.Total = Convert.ToInt32(scalar);
                sql = string.Format(@"select a.*,b.FullName from(select a.* from(select row_number() over(order by a.LogTime desc) RN,
                                                  a.ActionType,a.RecNo,a.Id,a.LogDesc,a.UserId,a.LogTime 
                                                   from B_Log a {0})a where RN>{1} and RN<={2}) a 
                                                  left join S_User b on a.UserId=b.Id", condition, startPageIndex, endPageIndex);
                result.Models = service.GetObjectList<QLog>(sql);
            }
            return result;
        }

        public List<QLog> GetList(string recId)
        {
            string sql;
            sql = string.Format(@"select a.Id,a.LogDesc,a.LogTime,b.FullName from B_Log a 
                                             left join S_User b on a.UserId=b.Id where a.RecId='{0}' order by LogTime desc", recId);
            return base.getList<QLog>(sql);
        }

        #endregion
    }
}
