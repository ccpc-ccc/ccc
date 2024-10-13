using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Util;
using YF.MWS.Util.Dynamic;
using YF.Utility;
using YF.Utility.Configuration;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    public abstract class BaseService {
        protected SqliteDb sqliteDb = new SqliteDb();
        protected IService service = null;
        public BaseService() {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) {
                service = ServiceInitialization.DbService;
            }
        }
        protected virtual DataTable GetTable(string sql) {
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                dt = sqliteDb.ExecuteDataTable(sql);
            } else {
                dt = service.GetDataTable(sql);
            }
            return dt;
        }
        protected virtual bool ExecuteSql(string sql) {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            } else {
                return service.ExecuteNonQuery(sql);
            }
        }
        protected virtual bool save<T>(T mode,string tableName) where T:BaseEntity,new() {
            string sql = SqliteSqlUtil.GetSaveSql<T>(mode, tableName);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            } else {
                return service.Save<T>(mode, mode.Id);
            }
        }
        protected virtual bool ExecuteSql(List<string> sqls) {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                return sqliteDb.ExecuteNonQuery(sqls) > 0;
            } else {
                return service.ExecuteNonQuery(sqls);
            }
        }
        protected virtual T getModel<T>(string sql) where T : new() {
            DataTable dt = GetTable(sql);
            if (dt == null || dt.Rows.Count <= 0) return default(T);
            return TableHelper.RowToEntity<T>(dt.Rows[0]);
        }
        public virtual T getModel<T>(DataRow row) where T : new() {
            return TableHelper.RowToEntity<T>(row);
        }
        protected virtual List<T> getList<T>(string sql) where T : new() {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                return sqliteDb.GetObjectList<T>(sql);
            } else {
                return service.GetObjectList<T>(sql);
            }
        }
        protected virtual List<T> getPageData<T>(string sql,int pageIndex,int pageSize)  where T : new(){
            if (sql != ""&&pageSize>0) {
                sql += string.Format(" offset {0} rows fetah next {1} rows only",((pageIndex-1)*pageSize),pageSize);
            }
            return service.GetObjectList<T>(sql);
        }
    }
}
