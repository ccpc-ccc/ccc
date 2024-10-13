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
    public class WeightTempService : IWeightTempService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IMasterService masterService = new MasterService();
        private IWeightService weightService = new WeightService();
        private IService service = null;

        public WeightTempService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        #region private methods
        private void AutoSaveToWeight(BWeightTemp temp) 
        {
            BWeight weight = new BWeight();
            weight.Id = temp.Id;
            weight.FinishTime = temp.WeightTime;
            weight.GrossWeight = temp.Weight;
            weight.WeighterName = temp.WeighterName;
            weight.WeighterId = temp.WeighterId;
            weight.MeasureUnit = temp.Unit;
            weight.WeightNo = temp.WeightNo;
            weight.OrderSource = OrderSource.AutoWeight.ToString();
            weight.FinishState = (int)FinishState.Finished;
            weight.MachineCode = CurrentClient.Instance.MachineCode;
            BWeightDetail grossDetail = new BWeightDetail();
            grossDetail.Id = YF.MWS.Util.Utility.GetGuid();
            grossDetail.GrossWeight = temp.Weight;
            grossDetail.OrderSource = OrderSource.AutoWeight.ToString();
            grossDetail.WeighterId = temp.WeighterId;
            grossDetail.WeighterName = temp.WeighterName;
            weightService.Save(weight, null, grossDetail, null);
        }
        #endregion

        #region IWeightTempService 成员

        public List<BWeightTemp> GetList(DateTime dtStart, DateTime dtEnd, int topN)
        {
            List<BWeightTemp> lst = new List<BWeightTemp>();
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.AppendFormat(" where a.RowState != '{0}' ", (int)RowState.Delete);
            if (dtStart != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.WeightTime>=datetime('{0}') ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
                else
                {
                    sbCondition.AppendFormat("and a.WeightTime>='{0}' ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (dtEnd != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.WeightTime<datetime('{0}') ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
                else
                {
                    sbCondition.AppendFormat("and a.WeightTime<'{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            string sql;
           
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format("select * from B_WeightTemp a {0} order by a.WeightTime desc limit 0,{1}", sbCondition, topN);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format("select top {1} * from B_WeightTemp a {0} order by a.WeightTime desc", sbCondition,topN);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lst = TableHelper.TableToList<BWeightTemp>(dt);
            }
            return lst;
        }

        public bool Save(BWeightTemp weightTemp)
        {
            bool isSaved = false;
            string sql; 
            sql = SqliteSqlUtil.GetSaveSql<BWeightTemp>(weightTemp, "B_WeightTemp");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved= sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isSaved= service.Save<BWeightTemp>(weightTemp, weightTemp.Id);
            }
            if (isSaved && weightTemp!=null) 
            {
                AutoSaveToWeight(weightTemp);
            }
            return isSaved;
        }

        #endregion
    }
}
