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
using YF.Utility;
using YF.MWS.Metadata.Query;

namespace YF.MWS.SQliteService
{
    public class WeightExtService : IWeightExtService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;
        private IMasterService masterService = new MasterService();
        public WeightExtService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        #region Private Methods
        private string GetFilterExpression(DataTable dtWeight, List<QueryCondition> lstExtendCondition)
        {
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.Append("1=1");
            foreach (QueryCondition qc in lstExtendCondition)
            {
                if (dtWeight.Columns.Contains(qc.ColumnName))
                {
                    sbCondition.AppendFormat(" and [{0}] like '%{1}%' ", qc.ColumnName, qc.Input);
                }
            }
            return sbCondition.ToString();
        }
        private DataTable GetFilterTable(DataTable dtWeight, List<QueryCondition> lstExtendCondition)
        {
            DataTable dtTarget = dtWeight.Clone();
            DataRow[] drs;
            drs = dtWeight.Select(GetFilterExpression(dtWeight, lstExtendCondition));
            if (drs != null && drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    dtTarget.ImportRow(dr);
                }
            }
            return dtTarget;
        }
        #endregion

        #region IWeightExtService 成员


        /// <summary>
        /// 获取补录磅单
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public DataTable GetAddList(DateTime dtStart, DateTime dtEnd,OrderSource source,string viewId)
        { 
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.AppendFormat(" a.RowState != '{0}' ", (int)RowState.Delete);
            if (dtStart != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime>=datetime('{0}') ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
                else
                {
                    sbCondition.AppendFormat("and a.FinishTime>='{0}' ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (dtEnd != DateTime.MinValue)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sbCondition.AppendFormat("and a.FinishTime<datetime('{0}') ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
                else
                {
                    sbCondition.AppendFormat("and a.FinishTime<'{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            sbCondition.AppendFormat("and a.OrderSource='{0}'", source);


            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string condition = sbCondition.ToString();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMeasureType = masterService.GetSubList(SysCode.MeasureType.ToString());
            List<SCode> lstOrderSource = masterService.GetSubList(SysCode.OrderSource.ToString());
            SCode code = null;
            sbSql.AppendFormat("select a.[ControlName],a.[ControlType],a.[FullName],a.[FieldName] from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", viewId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtViewDtl = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                dtViewDtl = service.GetDataTable(sbSql.ToString());
            }
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dtViewDtl);
            dtWeight.Columns.Add("ViewId");
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("磅单号");
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("日期", typeof(DateTime));
            dtWeight.Columns.Add("司磅员");
            //dtWeight.Columns.Add("客户");
            //dtWeight.Columns.Add("皮重时间", typeof(DateTime));
            //dtWeight.Columns.Add("毛重时间", typeof(DateTime));
            foreach (DataRow dr in dtViewDtl.Rows)
            {
                if (dr["ControlType"].ToEnum<ControlType>() == ControlType.Extend)
                {
                    if (!dtWeight.Columns.Contains(dr["ControlName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["ControlName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["ControlName"].ToObjectString());
                        }
                    }
                }
                else
                {
                    //对于标准控件的列名用FieldName
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                        }
                    }
                }
            }
            if (!dtWeight.Columns.Contains("打印次数"))
            {
                //dtWeight.Columns.Add("打印次数");
            } 
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.ViewId,a.Id as WeightId,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,
                                               a.RealCharge,a.MeasureUnit,a.DriverName,a.OrderSource as '磅单来源',
                                                a.Remark,a.WeighterName,a.FinishTime as '日期',a.WeightNo as '磅单号',a.CarNo as 'CarId',d.CustomerName as 'CustomerId',
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',
                                                h.CustomerName as 'ReceiverId',j.CustomerName as 'DeliveryId'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer j on a.DeliveryId=j.Id  
                                                 where {0};", condition);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtMain = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                dtMain = service.GetDataTable(sbSql.ToString());
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.Id   from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join B_WeightExt i on a.Id=i.Id 
                                                 where {0}", condition);
            sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0});", sbSql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtExtend = sqliteDb.ExecuteDataTable(sbAttrSql.ToString());
            }
            else
            {
                dtExtend = service.GetDataTable(sbAttrSql.ToString());
            }
            DataRow[] drExtends;
            DataRow drMain;
            DataRow drWeight;
            string columnName;
            if (dtMain != null)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    drMain = dtMain.Rows[i];
                    drWeight = dtWeight.NewRow();
                    code = lstMeasureType.Find(c => c.ItemCode == drMain["MeasureType"].ToObjectString());
                    if (code != null)
                    {
                        drMain["MeasureType"] = code.ItemCaption;
                    }
                    code = lstOrderSource.Find(c => c.ItemCode == drMain["磅单来源"].ToObjectString());
                    if (code != null)
                    {
                        drMain["磅单来源"] = code.ItemCaption;
                    }
                    for (int j = 0; j < dtMain.Columns.Count; j++)
                    {
                        columnName = dtMain.Columns[j].ColumnName;
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            drWeight[columnName] = drMain[columnName];
                        }
                    }
                    if (dtExtend != null && dtExtend.Rows.Count > 0)
                    {
                        drExtends = dtExtend.Select(string.Format("[WeightId]='{0}'", drMain["WeightId"]));
                        foreach (DataRow dr in drExtends)
                        {
                            columnName = string.Format("{0}", dr["AttributeName"]);
                            if (dtWeight.Columns.Contains(columnName))
                            {
                                drWeight[columnName] = dr["AttributeValue"];
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            }
            if (lstDetail != null && lstDetail.Count > 0)
            {
                lstDetail = lstDetail.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
                foreach (DataColumn dc in dtWeight.Columns)
                {
                    SWeightViewDtl dtl = lstDetail.Find(c => c.FieldName == dc.ColumnName);
                    if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dtWeight.Columns.Contains(dtl.ControlName))
                    {
                        dc.ColumnName = dtl.ControlName;
                    }
                }
            }
            return dtWeight;   
        }

        public DataSet GetMeasureSearch(string viewId, string condition, string conditionTareTime, string conditionGrossTime, List<QueryCondition> lstExtendCondition)
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            DataSet ds = new DataSet();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMeasureType = masterService.GetSubList(SysCode.MeasureType.ToString());
            List<SCode> lstOrderSource = masterService.GetSubList(SysCode.OrderSource.ToString());
            SCode code = null;
            sbSql.AppendFormat("select a.[ControlName],a.[ControlType],a.[FullName],a.[FieldName],a.[ControlType] from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", viewId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtViewDtl = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else 
            {
                dtViewDtl = service.GetDataTable(sbSql.ToString());
            }
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dtViewDtl);
            dtWeight.Columns.Add("ViewId");
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("单号");
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("开始日期", typeof(DateTime));
            dtWeight.Columns.Add("完成日期", typeof(DateTime));
            foreach (DataRow dr in dtViewDtl.Rows) 
            {
                if (dr["ControlType"].ToEnum<ControlType>() == ControlType.Extend)
                {
                    if (!dtWeight.Columns.Contains(dr["ControlName"].ToObjectString()))
                    {
                        dtWeight.Columns.Add(dr["ControlName"].ToObjectString());
                    }
                }
                else
                {
                    //对于标准控件的列名用FieldName
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    {
                        dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                    }
                }
            }
            if (!dtWeight.Columns.Contains("打印次数")) 
            {
                //dtWeight.Columns.Add("打印次数");
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select a.Id as WeightId,a.ViewId,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,
                                               a.RegularCharge,a.MeasureUnit,a.OrderSource as '磅单来源',a.DriverName,
                                                a.Remark,a.WeighterName,a.CreateTime as '开始日期',a.FinishTime as '完成日期',a.WeightNo as '单号',a.CarNo as 'CarId',d.CustomerName as 'CustomerId',
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',a.WaybillNo as '运单号',a.MaterialModel,
                                                f.WeightTime  as '皮重时间',g.WeightTime  as '毛重时间',h.CustomerName as 'ReceiverId',i.CustomerName as 'DeliveryId',
                                                j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id 
                                                left join B_WeightExt c on a.Id=c.Id   
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0}  
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1}  
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                left join S_Customer j on a.SupplierId=j.Id
                                                left join S_Customer k on a.ManufacturerId=k.Id
                                                 where {2}{3} {4} order by a.FinishTime desc;",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition,conditionTareTime,conditionGrossTime);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtMain = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else 
            {
                dtMain = service.GetDataTable(sbSql.ToString());
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.Id   from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                             left join B_WeightExt c on a.Id=c.Id    
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0} 
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1} 
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                 where {2}",
                                    (int)WeightType.Tare, (int)WeightType.Gross, condition);
            sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0});", sbSql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtExtend = sqliteDb.ExecuteDataTable(sbAttrSql.ToString());
            }
            else 
            {
                dtExtend = service.GetDataTable(sbAttrSql.ToString());
            }
            DataRow[] drExtends;
            DataRow drMain;
            DataRow drWeight;
            string columnName;
            if (dtMain != null)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    drMain = dtMain.Rows[i];
                    drWeight = dtWeight.NewRow();
                    code = lstMeasureType.Find(c => c.ItemCode == drMain["MeasureType"].ToObjectString());
                    if (code != null)
                    {
                        drMain["MeasureType"] = code.ItemCaption;
                    }
                    code = lstOrderSource.Find(c => c.ItemCode == drMain["磅单来源"].ToObjectString());
                    if (code != null)
                    {
                        drMain["磅单来源"] = code.ItemCaption;
                    }
                    for (int j = 0; j < dtMain.Columns.Count; j++)
                    {
                        columnName = dtMain.Columns[j].ColumnName;
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            drWeight[columnName] = drMain[columnName];
                        }
                    }
                    if (dtExtend != null && dtExtend.Rows.Count > 0)
                    {
                        drExtends = dtExtend.Select(string.Format("[WeightId]='{0}'", drMain["WeightId"]));
                        foreach (DataRow dr in drExtends)
                        {
                            columnName = string.Format("{0}", dr["AttributeName"]);
                            if (dtWeight.Columns.Contains(columnName))
                            {
                                drWeight[columnName] = dr["AttributeValue"];
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            } 
            if (lstDetail != null && lstDetail.Count > 0)
            {
                lstDetail = lstDetail.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
                foreach (DataColumn dc in dtWeight.Columns)
                {
                    SWeightViewDtl dtl = lstDetail.Find(c => c.FieldName == dc.ColumnName);
                    if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dtWeight.Columns.Contains(dtl.ControlName))
                    {
                        dc.ColumnName = dtl.ControlName;
                    }
                }
            }
            YF.MWS.Util.Utility.InitRow(dtWeight);
            if (lstExtendCondition == null || lstExtendCondition.Count == 0)
            {
                ds.Tables.Add(dtWeight);
            }
            else 
            {
                DataTable dtTarget = GetFilterTable(dtWeight, lstExtendCondition);
                ds.Tables.Add(dtTarget);
            }
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "磅单"; 
            }
            return ds;
        }

        public BWeightExt Get(string weightId) 
        {
            BWeightExt detail = null;
            string sql;
            sql = string.Format(@"select * from B_WeightExt where WeightId='{0}' ", weightId);
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
                detail = TableHelper.RowToEntity<BWeightExt>(dt.Rows[0]);
            }
            return detail;
        }

        public bool Save(BWeightExt weightExt)
        {
            if (string.IsNullOrEmpty(weightExt.SettleNo)) 
            {
                ISeqNoService seqNoService = new SeqNoService();
                weightExt.SettleNo = seqNoService.GetSeqNo(SeqCode.Settle.ToString());
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql;
                sql = SqliteSqlUtil.GetSaveSql<BWeightExt>(weightExt, "B_WeightExt");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.Save<BWeightExt>(weightExt, weightExt.Id);
            }
        }

        #endregion
    }
}
