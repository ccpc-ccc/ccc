using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System.IO;
using YF.Utility.Configuration;
using System.Threading;
using YF.Utility.Log;
using YF.Utility.Data;

namespace YF.MWS.Util
{
    public class SqliteDb
    {
        private string dbPath;
        private bool isExistDbFile = false;
        /// <summary>
        /// sqlite 
        /// </summary>
        public string DbPath
        {
            get
            {
                return dbPath;
            }
            set
            {
                dbPath = value;
            }
        }

        public SqliteDb()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSetting.GetValue("dsnSqlite"));
            isExistDbFile = File.Exists(dbPath);
        }

        public SqliteDb(string dbFilePath)
        {
            dbPath = dbFilePath;
            isExistDbFile = File.Exists(dbPath);
        }

        /// <summary>
        /// 清除所有的连接池
        /// </summary>
        public void ClearConnection() 
        {
            SQLiteConnection.ClearAllPools();
            GC.Collect();
            Thread.Sleep(50);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetSQLiteConnection()
        {
            SQLiteConnection sqlCon = null;
            string conStr = @"Data Source=" + DbPath;
            try
            {
                if (isExistDbFile)
                {
                    sqlCon = new SQLiteConnection(conStr);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            } 
            return sqlCon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
        {
            if (conn == null)
                return;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (p != null)
            {
                foreach (object parm in p)
                    cmd.Parameters.AddWithValue(string.Empty, parm);
                //for (int i = 0; i < p.Length; i++)
                // cmd.Parameters[i].Value = p[i];
            }
        }

        public T GetObject<T>(string cmdText, params object[] p) where T : new()
        {
            DataTable dt = ExecuteDataTable(cmdText, p);
            if (dt != null && dt.Rows!=null && dt.Rows.Count>0)
                return TableHelper.RowToEntity<T>(dt.Rows[0]);
            else
                return default(T);
        }

        public List<T> GetObjectList<T>(string cmdText, params object[] p) where T : new()
        {
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
        public DataTable ExecuteDataTable(string cmdText, params object[] p)
        {
            DataTable dt = new DataTable();
            try
            {
                //SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection connection = GetSQLiteConnection())
                {
                    if (connection == null)
                        return dt;
                    using (SQLiteCommand command = new SQLiteCommand())
                    {
                        PrepareCommand(command, connection, cmdText, p);
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                        {
                            da.Fill(dt);
                        }
                        //SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                        //da.Fill(dt);
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.Write("Error SQL:" + cmdText); 
                Logger.WriteException(ex);
            }
            return dt;
        }

        /// <summary>
        /// get dataset
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, params object[] p)
        {
            DataSet ds = new DataSet();
            //SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                if (connection == null)
                    return ds;
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, connection, cmdText, p);
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                    {
                        da.Fill(ds);
                    }
                    //SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    //da.Fill(dt);
                }

            }
            return ds;
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdText">a</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, params object[] p)
        {
            int res = 0;
            try
            {
                SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection connection = GetSQLiteConnection())
                {
                    if (connection == null)
                        return res;
                    PrepareCommand(command, connection, cmdText, p);
                    res = command.ExecuteNonQuery();
                }
                if (res == 0)
                {
                    res = 1;
                }
            }
            catch (Exception ex) 
            {
                res = 0;
                Logger.Write("SQL:" + cmdText);
                Logger.WriteException(ex);
            }
            return res;
        }

        /// <summary>
        /// 批量执行SQL语句(带事务模式下)
        /// </summary>
        /// <param name="lstSql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(List<string> lstSql)
        {
            int result = 0;
            string tempSql = string.Empty;
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                if (connection == null)
                    return result;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (SQLiteTransaction trans = connection.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmd = connection.CreateCommand())
                        {
                            foreach (string sql in lstSql)
                            {
                                tempSql = sql;
                                cmd.CommandText = sql;
                                result += cmd.ExecuteNonQuery();
                            }
                            trans.Commit();
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.Write("SQL:"+tempSql);
                        Logger.WriteException(ex);
                        trans.Rollback();
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 返回SqlDataReader对象
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteReader(string cmdText, params object[] p)
        {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection connection = GetSQLiteConnection();
            if (connection == null)
                return null;
            try
            {
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText, params object[] p)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                if (connection == null)
                    return null;
                PrepareCommand(cmd, connection, cmdText, p);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="cmdText"></param>
        /// <param name="countText"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public DataSet ExecutePager(ref int recordCount, int pageIndex, int pageSize, string cmdText, string countText, params object[] p)
        {
            if (recordCount < 0)
                recordCount = int.Parse(ExecuteScalar(countText, p).ToString());
            DataSet ds = new DataSet();
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection connection = GetSQLiteConnection())
            {
                if (connection == null)
                    return ds;
                PrepareCommand(command, connection, cmdText, p);
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(ds, (pageIndex - 1) * pageSize, pageSize, "result");
            }
            return ds;
        }

    }
}
