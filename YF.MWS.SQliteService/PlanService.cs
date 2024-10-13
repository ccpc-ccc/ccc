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
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility;

namespace YF.MWS.SQliteService
{
    public class PlanService : IPlanService
    {
        private IService service = null;
        private SqliteDb sqliteDb = new SqliteDb();

        public PlanService()
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        #region private methods
        private string GetPlanCondition(PlanQuery query)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" and a.RowState!={0}", (int)RowState.Delete);
            if (!string.IsNullOrEmpty(query.CustomerId))
            {
                sb.AppendFormat(" and a.CustomerId='{0}'", query.CustomerId);
            }
            if (query.WarehBiz.HasValue)
            {
                sb.AppendFormat(" and a.WarehBiz='{0}'", (int)query.WarehBiz.Value);
            }
            if (!string.IsNullOrEmpty(query.DeliveryId))
            {
                sb.AppendFormat(" and a.DeliveryId='{0}'", query.DeliveryId);
            }
            if (!string.IsNullOrEmpty(query.ReceiverId))
            {
                sb.AppendFormat(" and a.ReceiverId='{0}'", query.ReceiverId);
            }
            if (!string.IsNullOrEmpty(query.MaterialId))
            {
                sb.AppendFormat(" and a.MaterialId='{0}'", query.MaterialId);
            }
            if (query.StartTime.HasValue)
            {
                sb.AppendFormat(" and a.PlanTime>='{0}'", query.StartTime.Value.ToString("yyyy-MM-dd 00:00:00"));
            }
            if (query.EndTime.HasValue)
            {
                sb.AppendFormat(" and a.PlanTime<'{0}'", query.EndTime.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
            }
            return sb.ToString();
        }
        private void RefreshWeights(List<BWeight> weights, string planId)
        {
            if (weights == null || weights.Count == 0)
                return;
            BWeight firstWeight = weights[0];
            BPlan plan = Get(planId);
            if (plan == null)
                return;
            string sql;
            List<string> sqls = new List<string>();
            int carCount = 0;
            decimal finishedWeight = 0;
            sql = string.Format("delete from B_WeightPlan where PlanId='{0}';", planId);
            sqls.Add(sql);
            foreach (BWeight weight in weights)
            {
                if (weight.FinishState == (int)FinishState.Finished)
                {
                    carCount++;
                    finishedWeight += UnitUtil.GetValue(weight.MeasureUnit, "Ton", weight.SuttleWeight);
                }
                sql = string.Format(@"INSERT INTO B_WeightPlan (Id,PlanId,PlanWeight,FinishedWeight,FinishedCarCount,FinishTime)
                                                      VALUES('{0}','{1}','{2}','{3}','{4}','{5}');",
                                                      weight.Id, planId, plan.PlanWeight, finishedWeight, carCount, weight.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"));
                sqls.Add(sql);
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                service.ExecuteNonQuery(sqls);
            else
                sqliteDb.ExecuteNonQuery(sqls);
        }

        private bool RefreshPlan(string planId)
        {
            bool isUpdated = false;
            List<string> sqls = new List<string>();
            string sql = string.Format(@"update a set a.FinishedCarCount=b.CarCount,a.FinishedWeight=b.SuttleWeight  from B_Plan a inner join
                                                                          (select isnull(SUM(dbo.GetWeight(SuttleWeight,MeasureUnit,'Ton')),0) SuttleWeight,COUNT(1) CarCount,'{0}' PlanId
                                                                         from B_Weight where RowState!={1} and FinishState={2} and RefId='{0}')b on a.Id=b.PlanId
                                                                         where a.Id='{0}';", planId, (int)RowState.Delete, (int)FinishState.Finished);
            sqls.Add(sql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                isUpdated = service.ExecuteNonQuery(sqls);
            else
            {
                List<BWeight> weights = null;
                sql = string.Format(@"select SuttleWeight,MeasureUnit from B_Weight where RowState!={0} and FinishState={1} and RefId='{2}'", (int)RowState.Delete, (int)FinishState.Finished,planId);
                weights = sqliteDb.GetObjectList<BWeight>(sql);
                if (weights != null && weights.Count > 0)
                {
                    int count = weights.Count;
                    decimal finishedWeight = 0;
                    MeasureUnitType unitType = MeasureUnitType.Ton;
                    foreach (BWeight weight in weights)
                    {
                        unitType = weight.MeasureUnit.ToEnum<MeasureUnitType>();
                        if (unitType == MeasureUnitType.Kg)
                            finishedWeight += Math.Round(weight.SuttleWeight / 1000, 2);
                        else
                            finishedWeight += weight.SuttleWeight;
                    }
                    sql = string.Format("update B_Plan set FinishedCarCount={0},FinishedWeight={1} where Id='{2}'",count,finishedWeight,planId);
                    isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            return isUpdated;
        }
        #endregion

        public bool BatchRefresh(string planId)
        {
            string sql = string.Format(@"select a.MeasureUnit,a.SuttleWeight,a.WeightId,a.RefId,a.FinishTime,a.CreateTime,a.FinishState from B_Weight a 
                                                        where RefId='{0}' and RowState!={1} order by FinishTime asc",
                                                        planId, (int)RowState.Delete);
            List<BWeight> weights = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                weights = service.GetObjectList<BWeight>(sql);
            else
                weights = sqliteDb.GetObjectList<BWeight>(sql);
            if (weights != null)
            {
                RefreshWeights(weights, planId);
            }
            return RefreshPlan(planId);
        }

        public bool Delete(string planId)
        {
            bool isDeleted = false;
            string sql = sql = string.Format("update B_Plan set RowState={0} where Id='{1}'", (int)RowState.Delete, planId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                isDeleted = service.ExecuteNonQuery(sql);
            else
                isDeleted = sqliteDb.ExecuteNonQuery(sql) > 0;
            return isDeleted;
        }

        public BPlan Get(string planId)
        {
            string sql = string.Format("select * from B_Plan where Id='{0}'", planId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObject<BPlan>(sql);
            else
                return sqliteDb.GetObject<BPlan>(sql);
        }

        public BPlan Get(string customerId, PlanStateType stateType)
        {
            string sql = string.Format(@"select  a.* from B_Plan a  where a.PlanState={0} and a.CustomerId='{1}' and a.RowState!={2} order by a.StartTime asc",
                                                         (int)stateType, customerId, (int)RowState.Delete);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObject<BPlan>(sql);
            else
                return sqliteDb.GetObject<BPlan>(sql);
        }

        public BPlan GetByCar(string carNo, PlanStateType stateType)
        {
            string sql = string.Format(@"select  a.* from B_Plan a  where a.PlanState={0} and a.CarNo='{1}' and a.RowState!={2} order by a.StartTime asc",
                                                         (int)stateType, carNo, (int)RowState.Delete);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObject<BPlan>(sql);
            else
                return sqliteDb.GetObject<BPlan>(sql);
        }

        public List<BPlan> GetList()
        {
            string sql = string.Format(@"select * from B_Plan a where a.RowState!={0}", (int)RowState.Delete);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObjectList<BPlan>(sql);
            else
                return sqliteDb.GetObjectList<BPlan>(sql);
        }

        public List<BPlan> GetList(List<string> planNos)
        {
            string sql = string.Format(@"select * from B_Plan where PlanNo in({0})", SqlConditionUtil.GetArrayIn(planNos));
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.GetObjectList<BPlan>(sql);
            else
                return sqliteDb.GetObjectList<BPlan>(sql);
        }

        public bool IsExistsPlanByCarNo(string strCarNo)
        {
            bool result = false;
            string sql = string.Format("select count(PlanId) from B_Plan where RowState<>3 and PlanState=0 and getdate()<EndTime and CarNo='{0}'", strCarNo);
            int rows = 0;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                rows = sqliteDb.ExecuteScalar(sql).ToInt();
            }
            else
            {
                rows = service.GetDataTable(sql).Rows[0][0].ToInt();
            }
            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

        public PageList<PlanFull> GetList(PlanQuery query)
        {
            PageList<PlanFull> results = new PageList<PlanFull>();
            string condition = GetPlanCondition(query);
            string sql = string.Format("select count(1) from B_Plan a where 1=1 {0}", condition);
            object scarlar = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                scarlar = service.GetScalar(sql);
            else
                scarlar = sqliteDb.ExecuteScalar(sql);
            int pageNo = query.PageIndex;
            int pageSize = query.PageSize;
            int startPageIndex = pageNo * pageSize;
            int endPageIndex = (pageNo + 1) * pageSize;
            if (scarlar!=null)
            {
                results.Total = Convert.ToInt32(scarlar);
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                sql = string.Format(@"select a.*,b.CustomerName,c.CustomerName as DeliverName,d.MaterialName,e.DeptName from( select a.* from( 
                                              select row_number() over(order by StartTime desc) as RN,a.* from B_Plan a where 1=1 {0})a  where RN>{1} and RN<={2})a 
                                              left join S_Customer b on a.CustomerId=b.Id 
                                              left join S_Customer c on a.DeliveryId=c.Id
                                              left join S_Material d on a.MaterialId=d.Id 
                                              left join S_Dept e on a.DeptId=e.Id",
                                               condition, startPageIndex, endPageIndex);
                results.Models = service.GetObjectList<PlanFull>(sql);
            }
            else
            {
                sql = string.Format(@"select a.*,b.CustomerName,c.CustomerName as DeliverName,d.MaterialName,e.DeptName from(
                                              select a.* from B_Plan a where 1=1 {0} order by a.StartTime desc limit {1},{2})a 
                                              left join S_Customer b on a.CustomerId=b.Id 
                                              left join S_Customer c on a.DeliveryId=c.Id
                                              left join S_Material d on a.MaterialId=d.Id 
                                              left join S_Dept e on a.DeptId=e.Id",
                                               condition, startPageIndex, endPageIndex);
                results.Models = sqliteDb.GetObjectList<PlanFull>(sql);
            }
            return results;
        }

        public bool Update(BWeight weight)
        {
            bool isUpdated = false;
            if (string.IsNullOrEmpty(weight.RefId))
                return isUpdated;
            string planId = weight.RefId;
            BatchRefresh(planId);
            return isUpdated;
        }

        public bool UpdateState(string planId, PlanStateType type)
        {
            string sql = string.Format(@"update B_Plan set PlanState={0} where Id='{1}'", (int)type, planId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.ExecuteNonQuery(sql);
            else
                return sqliteDb.ExecuteNonQuery(sql) > 0;
        }

        public bool Save(BPlan plan)
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                return service.Save(plan, plan.Id);
            else
            {
                string sql = SqliteSqlUtil.GetSaveSql(plan, "B_Plan");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
        }
    }
}
