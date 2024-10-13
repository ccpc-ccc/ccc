using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Metadata;
using YF.Utility.IO;
using YF.Utility.Net;
using YF.MWS.BaseMetadata;

namespace YF.MWS.SQliteService
{
    public class SyncService : ISyncService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        #region private method 

        private List<string> GetColumns(string tableName)
        {
            List<string> lstColumnName = new List<string>();
            DataTable dtColumn = new DataTable();
            string sql = string.Format(@"pragma table_info('{0}')", tableName);
            dtColumn = sqliteDb.ExecuteDataTable(sql);
            foreach (DataRow dr in dtColumn.Rows)
            {
                lstColumnName.Add(dr["name"].ToString());
            }
            return lstColumnName;
        }

        private string GetInsertSql(string tableName,DataRow drSource) 
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            List<string> lstColumns = GetColumns(tableName);
            foreach (string columnName in lstColumns) 
            {
                if (drSource.Table.Columns.Contains(columnName)) 
                {
                    sbColumns.AppendFormat("{0},", columnName);
                    sbValues.AppendFormat("'{0}',", drSource[columnName]);
                }
            }
            if (sbColumns.Length > 0) 
            {
                sbColumns.Remove(sbColumns.Length - 1, 1);
                sbValues.Remove(sbValues.Length - 1, 1);
            }
            sb.AppendFormat("insert into {0}({1}) values({2})", tableName, sbColumns, sbValues);
            return sb.ToString();
        }

        private void Import(string tableName,DateTime dtUpdateTime, SqliteDb dbTarget) 
        {
            List<string> lstSql=new List<string>(); 
            string sql;
            sql = string.Format(@"select * from (select * from {0} where updatetime>=datetime('{1}')  order by updatetime desc) 
                                               order by updatetime desc", tableName, dtUpdateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            DataTable dtTarget = sqliteDb.ExecuteDataTable(sql);
            if (dtTarget == null || dtTarget.Rows.Count == 0) 
            {
                return;
            }
            foreach (DataRow drTarget in dtTarget.Rows) 
            {
                lstSql.Add(GetInsertSql(tableName, drTarget));
            }
            dbTarget.ExecuteNonQuery(lstSql);
            sql = string.Format("update S_SyncTable set MaxTime='{0}' where TableName='{1}'", 
                                        dtTarget.Rows[dtTarget.Rows.Count - 1]["UpdateTime"].ToDateTime().ToString("yyyy-MM-dd HH:mm:ss"),tableName);
            sqliteDb.ExecuteNonQuery(sql);
        }

        private void Delete(string tableName, SqliteDb db) 
        {
            string sql;
            sql = string.Format("delete from {0}",tableName);
            db.ExecuteNonQuery(sql);
        }

        #endregion

        #region ISyncService 成员

        public byte[] GetUpload(string tempDbFile)
        {
            byte[] bytes = null;
            SqliteDb sqliteDbTarget = new SqliteDb(tempDbFile);
            //获取需要同步的表
            string sql;
            DataTable dtSync;
            sql = "select * from S_SyncTable";
            dtSync = sqliteDb.ExecuteDataTable(sql);
            string tableName;
            string fkField;
            DateTime dtMaxTime;
            foreach (DataRow drSync in dtSync.Rows) 
            {
                tableName = drSync["TableName"].ToObjectString();
                fkField = drSync["FkField"].ToObjectString();
                dtMaxTime = drSync["MaxTime"].ToDateTime();
                Delete(tableName, sqliteDbTarget);
                Import(tableName, dtMaxTime, sqliteDbTarget);
            }
            sqliteDbTarget.ClearConnection();
            string copyedFile = Path.Combine(Path.GetDirectoryName(tempDbFile), Util.Utility.GetGuid() + ".db");
            File.Copy(tempDbFile, copyedFile);
            string zippedFile = Path.Combine(Path.GetDirectoryName(tempDbFile), Util.Utility.GetGuid() + ".zip");
            ZipHelper.ZipFile(copyedFile, zippedFile, 9);
            bytes = File.ReadAllBytes(zippedFile);
            FileHelper.DeleteDir(Path.GetDirectoryName(tempDbFile));
            return bytes;
        }

        public bool SaveCustomer(string url, SCustomer customer, string machineCode) 
        {
            bool isSaved = false;
            ResultMessage result = new ResultMessage();
            url = string.Format("{0}/api/sync/savecustomer?machineCode={1}", url, machineCode);
            string res = HttpClient.DoPostJson(url,customer.JsonSerialize());
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<ResultMessage>();
                if (result != null && result.Code == ResultCode.Success) 
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }

        public bool SaveMaterial(string url, SMaterial material, string machineCode)
        {
            bool isSaved = false;
            ResultMessage result = new ResultMessage();
            url = string.Format("{0}/api/sync/savematerial?machineCode={1}", url, machineCode);
            string res = HttpClient.DoPostJson(url, material.JsonSerialize());
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<ResultMessage>();
                if (result != null && result.Code == ResultCode.Success)
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }

        public bool SaveWareh(string url, SWareh wareh, string machineCode)
        {
            bool isSaved = false;
            ResultMessage result = new ResultMessage();
            url = string.Format("{0}/api/sync/savewareh?machineCode={1}", url, machineCode);
            string res = HttpClient.DoPostJson(url, wareh.JsonSerialize());
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<ResultMessage>();
                if (result != null && result.Code == ResultCode.Success)
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }

        public bool SaveView(string url, DSyncWeightView view, string machineCode)
        {
            bool isSaved = false;
            ResultMessage result = new ResultMessage();
            url = string.Format("{0}/api/sync/saveview?machineCode={1}", url, machineCode);
            string res = HttpClient.DoPostJson(url, view.JsonSerialize());
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<ResultMessage>();
                if (result != null && result.Code == ResultCode.Success)
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }

        public bool SavePay(string url, BPay pay,string machineCode)
        {
            bool isSaved = false;
            ResultMessage result = new ResultMessage();
            url = string.Format("{0}/api/sync/savepay?machineCode={1}", url, machineCode);
            string res = HttpClient.DoPostJson(url, pay.JsonSerialize());
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<ResultMessage>();
                if (result != null && result.Code == ResultCode.Success)
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }
        #endregion
    }
}
