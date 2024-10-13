using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Util;
using YF.MWS.Metadata;
using YF.Utility.Data;
using YF.Utility.IO;
using System.IO;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using System.Data.SqlClient;
using YF.Utility;
using YF.MWS.Metadata.Transfer;
using YF.Utility.Net;

namespace YF.MWS.SQliteService
{
    public class FileService : IFileService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;

        public FileService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        #region IFileService 成员
        public bool DeleteBatch(string weightId) 
        {
            bool isDeleted = false;
            string sql;
            List<BFile> lstFile = new List<BFile>();
            sql = string.Format(@"select FileUrl from B_File where RecId = '{0}'", weightId);
            DataTable dt = sqliteDb.ExecuteDataTable(sql);
            lstFile = TableHelper.TableToList<BFile>(dt);
            foreach (BFile file in lstFile)
            {
                FileHelper.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileUrl));
            }
            sql = string.Format(@"delete from B_File where RecId = '{0}'", weightId);
            isDeleted = sqliteDb.ExecuteNonQuery(sql) > 0;
            return isDeleted;
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="file">文件实体类</param>
        /// <returns></returns>
        public bool Add(BFile file)
        {
            string sql;
            sql = SqliteSqlUtil.GetSaveSql<BFile>(file, "B_File");
            return sqliteDb.ExecuteNonQuery(sql) > 0;
        }

        public TPageResult GetListFromRemote(string url, string recId) 
        {
            TPageResult result = new TPageResult();
            url = string.Format("{0}/api/file/listwithrecid?recId={1}", url, recId);
            string res = HttpClient.DoGetJson(url);
            if (!string.IsNullOrWhiteSpace(res) && res.Length > 0)
            {
                result = res.JsonDeserialize<TPageResult>();
            }
            return result;
        }

        public void DeleteRemote(string url,string recId) 
        {
            url = string.Format("{0}/api/WebFile/delete?recId={1}", url, recId);
            HttpClient.DoGetJson(url);
        }

        public List<BFile> Get(string recId, FileBusinessType type)
        {
            string sql;
            DataTable dt = null;
            sql = string.Format(@"select * from B_File where RecId = '{0}' and BusinessType = '{1}'", recId, type);
            dt = sqliteDb.ExecuteDataTable(sql);
            return TableHelper.TableToList<BFile>(dt);
        }
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="recId">关联主表Id</param>
        /// <param name="tableName">表名</param>
        /// <param name="type">文件类型</param>
        /// <returns></returns>
        public List<BFile> Get(string recId, string tableName, FileBusinessType type)
        {
            string sql; 
            DataTable dt = null;
            sql = string.Format(@"select * from B_File where RecId = '{0}' and TableName = '{1}' and BusinessType = '{2}'", recId, tableName, type);
            dt = sqliteDb.ExecuteDataTable(sql);
            return TableHelper.TableToList<BFile>(dt);
        }

        public int GetCount(string recId, string tableName, FileBusinessType type)
        {
            string sql;
            DataTable dt = null;
            sql = string.Format(@"select count(1) from B_File where RecId = '{0}' and TableName = '{1}' and BusinessType = '{2}'", recId, tableName, type);
            dt = sqliteDb.ExecuteDataTable(sql);
            return dt.Rows[0][0].ToInt();
        }

        public List<BFile> GetUploadList() 
        {
            string sql;
            sql = string.Format(@"select * from B_File where SyncState=0 order by CreateTime desc limit 0,20");
            DataTable dt = null;
            dt = sqliteDb.ExecuteDataTable(sql);
            return TableHelper.TableToList<BFile>(dt);
        }

        public List<BFile> GetUploadList(string recId)
        {
            string sql = string.Format(@"select * from B_File where RecId = '{0}' and SyncState={1}", recId, (int)SyncState.UnSynced);
            DataTable dt = null;
            dt = sqliteDb.ExecuteDataTable(sql);
            return TableHelper.TableToList<BFile>(dt);
        }

        public void UpdateSyncState(string fileId) 
        {
            string sql;
            sql = string.Format(@"update B_File set SyncState={0} where Id = '{1}' ", (int)SyncState.Synced,fileId);
            sqliteDb.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
