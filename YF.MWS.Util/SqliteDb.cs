using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.IO;
using YF.Utility.Configuration;
using System.Threading;
using YF.Utility.Log;
using YF.Utility.Data;
using SqlSugar;

namespace YF.MWS.Util {
    public class SqliteDb {
        private string dbPath;
        SqlSugarClient db;
        private bool isExistDbFile = false;
        /// <summary>
        /// sqlite 
        /// </summary>
        public string DbPath {
            get {
                return dbPath;
            }
            set {
                dbPath = value;
            }
        }

        public SqliteDb() {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSetting.GetValue("dsnSqlite"));
            isExistDbFile = File.Exists(dbPath);
            GetSQLiteConnection();
        }

        public SqliteDb(string dbFilePath) {
            dbPath = dbFilePath;
            isExistDbFile = File.Exists(dbPath);
        }

        /// <summary>
        /// 清除所有的连接池
        /// </summary>
        public void ClearConnection() {
            GC.Collect();
            Thread.Sleep(50);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void GetSQLiteConnection() {
            string conStr = @"Data Source=" + DbPath;
            ConnectionConfig config = new ConnectionConfig() {
                ConnectionString = conStr,
                IsAutoCloseConnection = true,
                DbType = SqlSugar.DbType.Sqlite
            };
            db = new SqlSugarClient(config);
        }
        public T GetObject<T>(string cmdText, params object[] p) where T : new() {
            DataTable dt = ExecuteDataTable(cmdText, p);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                return TableHelper.RowToEntity<T>(dt.Rows[0]);
            else
                return default(T);
        }

        public List<T> GetObjectList<T>(string cmdText, params object[] p) where T : new() {
            DataTable dt = ExecuteDataTable(cmdText, p);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                return TableHelper.TableToList<T>(dt);
            else
                return null;
        }

        /// <summary>
        /// execute dataset
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string cmdText, params object[] p) {
            if (db == null) return null;
            if (p != null && p.Length > 0)
                return db.Ado.GetDataTable(cmdText, p);
            else return db.Ado.GetDataTable(cmdText);
        }

        /// <summary>
        /// get dataset
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, params object[] p) {
            if (db == null) return null;
            if (p != null && p.Length > 0)
                return db.Ado.GetDataSetAll(cmdText, p);
            else return db.Ado.GetDataSetAll(cmdText);
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdText">a</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, params object[] p) {
            if (db == null) return -1;
            if (p != null && p.Length > 0)
                return db.Ado.ExecuteCommand(cmdText, p);
            else return db.Ado.ExecuteCommand(cmdText);
        }

        /// <summary>
        /// 批量执行SQL语句(带事务模式下)
        /// </summary>
        /// <param name="lstSql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(List<string> lstSql) {
            if (db == null) return -1;
            foreach (string sql in lstSql) {
                db.Ado.ExecuteCommand(sql);
            }
            return 1;
        }

        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText, params object[] p) {
            DataTable dt = ExecuteDataTable(cmdText, p);
            if (dt == null || dt.Rows.Count == 0) return null;
            return dt.Rows[0][0];
        }

    }
}
