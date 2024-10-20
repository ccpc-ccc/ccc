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
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    public class WarehService :BaseService, IWarehService
    {
        

        public WarehService()
        { }

        public bool Delete(string warehId)
        {
            string sql = $"delete from S_Wareh  where Id = '{warehId}'";
            return base.ExecuteSql(sql);
        }

        public SWareh Get(string warehId)
        {
            SWareh wareh = null;
            string sql;
            sql = string.Format(@"select Id, WarehCode, WarehName, Location, CreaterId, UpdaterId, CreateTime, 
                          UpdateTime, RowState from S_Wareh where Id='{0}' ", warehId);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                wareh = TableHelper.RowToEntity<SWareh>(dt.Rows[0]);
            }
            return wareh;
        }

        public SWareh GetByName(string warehName)
        {
            SWareh wareh = null;
            string sql;
            sql = string.Format(@"select * from S_Wareh where WarehName='{0}' ", warehName);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                wareh = TableHelper.RowToEntity<SWareh>(dt.Rows[0]);
            }
            return wareh;
        }

        public List<SWareh> GetList()
        {
            string sql;
            sql = string.Format(@"select * from S_Wareh where RowState!={0}", (int)RowState.Delete);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SWareh>(dt);
        }

        public bool Save(SWareh wareh)
        {
            bool isSaved = false;
            string sql = string.Empty;
            if (string.IsNullOrEmpty(wareh.Id))
            {
                wareh.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SWareh>(wareh, "S_Wareh");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else
            {
                isSaved = service.Save<SWareh>(wareh, wareh.Id);
            }
            return isSaved;
        }
    }
}
