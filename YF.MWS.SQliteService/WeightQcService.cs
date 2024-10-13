using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;

namespace YF.MWS.SQliteService
{
    public class WeightQcService : IWeightQcService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IMasterService masterService = new MasterService();
        private IService service = null;
        
        public WeightQcService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
                
            }
        } 

        #region IWeightQcService 成员

        public BWeightQc Get(string qcId)
        {
            BWeightQc detail = null;
            string sql;
            sql = string.Format(@"select * from B_WeightQc where Id='{0}' ", qcId);
            DataTable dt;
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
                detail = TableHelper.RowToEntity<BWeightQc>(dt.Rows[0]);
            }
            return detail;
        }

        public BWeightQc GetByNo(string qcNo)
        {
            BWeightQc detail = null;
            string sql;
            sql = string.Format(@"select * from B_WeightQc where QcNo='{0}' ", qcNo);
            DataTable dt;
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
                detail = TableHelper.RowToEntity<BWeightQc>(dt.Rows[0]);
            }
            return detail;
        }

        public List<BWeightQc> GetList() 
        {
            List<BWeightQc> lstQc = new List<BWeightQc>();
            string sql;
            sql = "select QcId,QcNo,WeightNo from B_WeightQc";
            DataTable dt;
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
                lstQc = TableHelper.TableToList<BWeightQc>(dt);
            }
            return lstQc;
        }

        public BWeightQc GetByWeightId(string weightId)
        {
            BWeightQc detail = null;
            string sql;
            sql = string.Format(@"select * from B_WeightQc where WeightId='{0}' ", weightId);
            DataTable dt;
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
                detail = TableHelper.RowToEntity<BWeightQc>(dt.Rows[0]);
            }
            return detail;
        }



        public DataSet GetReport(string weightId,string qcId)
        {
            DataSet ds = new DataSet();
            List<SCode> lstCode = masterService.GetSubList(SysCode.MeasureType.ToString());
            SCode code = null;
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(@"select  b.FinishTime as '过磅日期',a.Inspector as '质检员',a.Remark  as '备注',b.WeightNo as '磅单号',a.CarNo as '车牌号',d.CustomerName as '发货单位',
                                                a.[QcNo] as '质检单号',a.[Water] as '水分',a.[Impurity] as '杂质',a.[YellowRate] as '黄变率',a.[BrownRate] as '出糙率',        
                                                a.[MilledRice] as '整精米率',a.[HeavyMetal] as '重金属',a.[MutualRate] as '互混率',a.PackageType as '包装方式',
                                                a.[BrokenRate] as '碎米率',a.[SmallBrokenRate] as '其中小碎',a.[PowderRate] as '糠粉率',a.[FattyAcid] as '脂肪酸值',
                                                a.[ImperfectGrain] as '不完善粒', e.MaterialName as '品名',a.[ColorOdor] as '色泽气味',a.MeasureType as '业务类型',
                                                a.[Judgement] as '综合判定',a.[ProductFlow] as '产品流向',a.[QcDate] as '日期',f.CustomerName as '收货单位'
                                                 from B_WeightQc a left join S_Customer d on a.DeliveryId=d.Id
                                                 left join B_Weight b on a.WeightId=b.Id 
                                                left join S_Material e on a.MaterialId=e.Id 
                                                left join S_Customer f on a.ReceiverId=f.Id
                                                where a.Id='{0}';", qcId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                ds = sqliteDb.ExecuteDataSet(sbSql.ToString());
            }
            else 
            {
                ds = service.GetDataSet(sbSql.ToString());
            }
            if (ds.Tables.Count > 0) 
            {
                if (!ds.Tables[0].Columns.Contains("原发数量")) 
                {
                    ds.Tables[0].Columns.Add("原发数量");
                }
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0) 
            {
                ds.Tables[0].TableName = "质检单";
                code = lstCode.Find(c => c.ItemCode == ds.Tables[0].Rows[0]["业务类型"].ToObjectString());
                if (code != null)
                {
                    ds.Tables[0].Rows[0]["业务类型"] = code.ItemCaption;
                }
                lstCode = masterService.GetSubList("Judgement");
                code = lstCode.Find(c => c.ItemCode == ds.Tables[0].Rows[0]["综合判定"].ToObjectString());
                if (code != null)
                {
                    ds.Tables[0].Rows[0]["综合判定"] = code.ItemCaption;
                }
                lstCode = masterService.GetSubList("ProductFlow");
                code = lstCode.Find(c => c.ItemCode == ds.Tables[0].Rows[0]["产品流向"].ToObjectString());
                if (code != null)
                {
                    ds.Tables[0].Rows[0]["产品流向"] = code.ItemCaption;
                }
                lstCode = masterService.GetSubList("PackageType");
                code = lstCode.Find(c => c.ItemCode == ds.Tables[0].Rows[0]["包装方式"].ToObjectString());
                if (code != null)
                {
                    ds.Tables[0].Rows[0]["包装方式"] = code.ItemCaption;
                }
                sbSql.Clear();
                sbSql.AppendFormat(@" select a.AttributeValue,b.[FieldName] from B_WeightAttribute a inner join S_Attribute b 
                                             on a.[AttributeId]=b.[Id] where b.fieldName='PrimaryAmount' and a.[WeightId]='{0}'",weightId);
                DataTable dtTemp = null;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    dtTemp = sqliteDb.ExecuteDataTable(sbSql.ToString());
                }
                else
                {
                    dtTemp = service.GetDataTable(sbSql.ToString());
                }
                if (dtTemp != null && dtTemp.Rows.Count > 0) 
                {
                    ds.Tables[0].Rows[0]["原发数量"] = dtTemp.Rows[0][0];
                }
            }
            return ds;
        }

        public bool SaveQc(BWeightQc weightQc)
        {
            bool isSaved = false;
            string sql;
            sql = SqliteSqlUtil.GetSaveSql<BWeightQc>(weightQc, "B_WeightQc");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                isSaved = service.Save<BWeightQc>(weightQc, weightQc.Id);
            }
            if (isSaved) 
            {
                sql = string.Format("update B_Weight set QcState=1,QcNo='{1}' where Id='{0}'",
                                            weightQc.WeightId,weightQc.QcNo);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sqliteDb.ExecuteNonQuery(sql);
                }
                else 
                {
                    service.ExecuteNonQuery(sql);
                }
            }
            return isSaved;
        }

        #endregion
    }
}
