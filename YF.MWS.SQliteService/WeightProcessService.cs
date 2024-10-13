using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    public class WeightProcessService : IWeightProcessService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;

        public WeightProcessService()
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        public bool Delete(string weightId)
        {
            string sql = string.Format(@"delete from B_WeightConfirm  where Id='{0}'", weightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                return service.ExecuteNonQuery(sql);
            }
            else
            {
                return sqliteDb.ExecuteNonQuery(sql)>0;
            }
        }

        public BWeightConfirm GetConfirm(string weightId)
        {
            string sql = string.Format(@"select  * from B_WeightConfirm  where Id='{0}' order by CreateTime desc", weightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObject<BWeightConfirm>(sql);
            else
                return sqliteDb.GetObject<BWeightConfirm>(sql);
        }

        public List<BWeightConfirm> GetUnSyncConfirmList()
        {
            string sql = string.Format(@"select top 100 * from B_WeightConfirm  where SyncState={0} order by CreateTime desc",
                                                        (int)SyncState.UnSynced);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObjectList<BWeightConfirm>(sql);
            else
            {
                sql = string.Format(@"select * from B_WeightConfirm  where SyncState={0} order by CreateTime desc limit 0,100",
                                                        (int)SyncState.UnSynced);
                return sqliteDb.GetObjectList<BWeightConfirm>(sql);
            }
        }

        public bool SaveConfirm(BWeightConfirm confirm)
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.Save(confirm, confirm.Id);
            else
            {
                string sql = SqliteSqlUtil.GetSaveSql(confirm, "B_WeightConfirm");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
        }

        public bool UpdateFinishState(string weightId, FinishState state)
        {
            string sql = string.Format(@"update B_WeightConfirm set FinishState={0},SyncState={1} where Id='{2}'",
                                                          (int)state, (int)SyncState.UnSynced, weightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.ExecuteNonQuery(sql);
            else
                return sqliteDb.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateRowState(string weightId, RowState state)
        {
            string sql = string.Format(@"update B_WeightConfirm set RowState={0},SyncState={1} where Id='{2}'",
                                                          (int)state, (int)SyncState.UnSynced, weightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.ExecuteNonQuery(sql);
            else
                return sqliteDb.ExecuteNonQuery(sql) > 0;
        }

        public bool UpdateConfirmSyncState(BatchUpdate batchUpdate)
        {
            bool isUpdated = false;
            if (batchUpdate.Ids != null && batchUpdate.Ids.Count > 0)
            {
                string sql = string.Format(@"update B_WeightConfirm set SyncState={0} where Id in({1})",
                                                            (int)SyncState.Synced, SqlConditionUtil.GetArrayIn(batchUpdate.Ids));
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                    isUpdated = service.ExecuteNonQuery(sql);
                else
                    isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            return isUpdated;
        }
    }
}
