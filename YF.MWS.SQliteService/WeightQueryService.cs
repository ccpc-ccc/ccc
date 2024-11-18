using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Enum;
using YF.MWS.Util;
using YF.MWS.Metadata;
using System.Data;
using YF.Utility.Data;
using YF.MWS.Db;
using YF.Utility;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using YF.Utility.Log;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.SQliteService
{
    public class WeightQueryService :BaseService, IWeightQueryService
    {
        private IMasterService masterService = new MasterService();
        private IWeightViewService viewService = new WeightViewService();
        #region
        private string GetFinanceConditon(DateTime dtStart, DateTime dtEnd, FinaSettlement settleState,DateType type) 
        {
            StringBuilder sbCondition = new StringBuilder();
            StringBuilder sbFinanceCondition = new StringBuilder();
            sbCondition.AppendFormat(" a.RowState != '{0}' ", (int)RowState.Delete);
            sbCondition.AppendFormat("and a.FinishState='{0}'", (int)FinishState.Finished);
            if (dtStart != DateTime.MinValue)
            {
                switch (type)
                {
                    case DateType.Weight:
                        if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                        {
                            sbCondition.AppendFormat("and a.FinishTime>=datetime('{0}') ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                        }
                        else
                        {
                            sbCondition.AppendFormat("and a.FinishTime>= '{0}'", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                        }
                        break;
                    case DateType.FinanceSettle:
                        if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                        {
                            sbCondition.AppendFormat("and i.CreateTime>=datetime('{0}') ", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                        }
                        else
                        {
                            sbCondition.AppendFormat("and i.CreateTime>= '{0}'", dtStart.ToString("yyyy-MM-dd 00:00:00"));
                        }
                        break;
                }

            }
            if (dtEnd != DateTime.MinValue)
            {
                switch (type)
                {
                    case DateType.Weight:
                        if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                        {
                            sbCondition.AppendFormat("and a.FinishTime<=datetime('{0}') ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                        }
                        else
                        {
                            sbCondition.AppendFormat("and a.FinishTime<='{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                        }
                        break;
                    case DateType.FinanceSettle:
                        if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                        {
                            sbCondition.AppendFormat("and i.CreateTime<=datetime('{0}') ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                        }
                        else
                        {
                            sbCondition.AppendFormat("and i.CreateTime<='{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                        }
                        break;
                }
 
            }
            switch (settleState)
            {
                case FinaSettlement.AllSettled:
                    sbFinanceCondition.Append(" and i.FreightSettleState=1 and i.PaymentSettleState=1");
                    break;
                case FinaSettlement.AllUnSettled:
                    sbFinanceCondition.Append(" and ((i.FreightSettleState=0 and i.PaymentSettleState=0) or i.FreightSettleState is null)");
                    break;
                case FinaSettlement.FreightSettled:
                    sbFinanceCondition.Append(" and i.FreightSettleState=1");
                    break;
                case FinaSettlement.FreightUnSettled:
                    sbFinanceCondition.Append(" and (i.FreightSettleState=0 or i.FreightSettleState is null)");
                    break;
                case FinaSettlement.PaymentSettled:
                    sbFinanceCondition.Append(" and i.PaymentSettleState=1");
                    break;
                case FinaSettlement.PaymentUnSettled:
                    sbFinanceCondition.Append(" and (i.PaymentSettleState=0 or i.PaymentSettleState is null)");
                    break;
                case FinaSettlement.FinanceAuthed:
                    sbFinanceCondition.Append(" and i.SettleState=1");
                    break;
                case FinaSettlement.FinanceUnAuthed:
                    sbFinanceCondition.Append(" and (i.SettleState=0 or i.SettleState is null)");
                    break;
            }
            string condition = string.Format("{0} {1}", sbCondition, sbFinanceCondition);
            return condition;
        }
        #endregion
        private string WeightFiles = @"a.ViewId, a.Id, a.WeightNo, a.MeasureType, a.RowState, a.CardNo, a.FinishState,a.QcState, a.CreateTime, a.FinishTime,a.WaybillNo,a.TareTime,a.GrossTime,
            a.CarNo as CarId, a.DriverName, a.QcNo,a.MaterialAmount,a.AdditionalTime,a.GrossWeight, a.MeasureUnit, a.CustomCharge,a.OrderSource,a.TareWeight, a.SuttleWeight,a.SyncState,
            a.WeighterName WeighterId,a.d1,a.d2,a.d3,a.d4,a.d5,a.t1,a.t2,a.t3,a.t4,a.t5,a.t6,a.t7,a.t8,a.t9,a.PayType,a.UnitMoney,a.ImpurityWeight,a.MaxWeight,a.NetWeight,a.UnitPrice,a.RegularCharge,a.Remark,a.MaterialModel,a.WarehBizType as WarehBizType,a.AxleCount,
            a.CustomerBalance,a.PrintCount";

        public DataTable GetFinanceList(List<string> lstWeightId, string viewId) 
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMeasureType = masterService.GetSubList(SysCode.MeasureType.ToString());
            List<SCode> lstOrderSource = masterService.GetSubList(SysCode.OrderSource.ToString());
            SCode code = null;
            string inWeightId;
            if (lstWeightId != null && lstWeightId.Count > 0)
            {
                inWeightId = YF.MWS.Util.Utility.GetSqlIn(lstWeightId);
            }
            else 
            {
                inWeightId="'0'";
            }
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
            dtWeight.Columns.Add("Id");
            dtWeight.Columns.Add("磅单号");
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("完成时间", typeof(DateTime));
            //dtWeight.Columns.Add("司磅员");
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
            if (!dtWeight.Columns.Contains("财务审核"))
            {
                dtWeight.Columns.Add("财务审核");
            }
            if (!dtWeight.Columns.Contains("运费结算"))
            {
                dtWeight.Columns.Add("运费结算");
            }
            if (!dtWeight.Columns.Contains("货款结算"))
            {
                dtWeight.Columns.Add("货款结算");
            }
            if (!dtWeight.Columns.Contains("结算单号"))
            {
                dtWeight.Columns.Add("结算单号");
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.ViewId,a.Id,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,a.RegularCharge,
                                               a.RealCharge,a.MeasureUnit,a.OrderSource as '磅单来源',a.DriverName,a.WaybillNo,
                                                a.Remark,a.WeighterName,a.FinishTime as '完成时间',a.WeightNo as '磅单号',a.CarNo as 'CarId',d.CustomerName as 'CustomerId',
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',
                                                h.CustomerName as 'ReceiverId',j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId',m.CustomerName as 'DeliveryId',
                                                 case i.SettleState when 1 then '已审核' else '未审核' end as '财务审核',
                                                case i.FreightSettleState when 1 then '已结算' else '未结算' end as '运费结算',
                                                 case i.PaymentSettleState when 1 then '已结算' else '未结算' end as '货款结算',i.SettleNo as '结算单号'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                left join S_Customer j on a.DeliveryId=j.Id 
                                                left join B_WeightExt i on a.Id=i.Id 
                                                left join S_Customer k on a.ManufacturerId=k.Id 
                                                left join S_Customer m on a.DeliveryId=m.Id 
                                                 where a.Id in({0});", inWeightId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtMain = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                dtMain = service.GetDataTable(sbSql.ToString());
            } 
            sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0});",
                                                inWeightId);
            dtExtend = GetTable(sbAttrSql.ToString());
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

        public WeightQueryResult GetTopList(TopWeightQuery query) 
        {
            WeightQueryResult result = new WeightQueryResult();
            result.Weight = GetTopListTable(query);
            return result;
        }
        public DataTable GetTopListTable(TopWeightQuery query) {
            DataTable dtTarget = new DataTable();
            DataTable dtWeight = null;
            List<SWeightViewDtl> columns = viewService.GetShow2DetailList(ViewType.Weight);
            string condtion = query.Condition;
            int topN = query.TopN;
            if (topN <= 0)
                topN = 5000;
            InitTargetTable(dtTarget, columns);
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                sql = string.Format(@"select {4},c.WarehName as WarehId,b.MaterialName as MaterialId,
                                                  d.CustomerName as CustomerId,e.CustomerName as DeliveryId,f.CustomerName as ReceiverId,g.CustomerName as TransferId,
                                                  j.CustomerName as ManufacturerId,k.CustomerName as SupplierId,m.WeighterName as TareWeighterName,n.WeighterName as GrossWeighterName
                                                 from B_Weight a  left join S_Material b on a.MaterialId=b.Id 
                                                 left join S_Wareh c on a.WarehId=c.Id
                                                 left join S_Customer d on a.CustomerId=d.Id 
                                                 left join S_Customer e on a.DeliveryId=e.Id  
                                                 left join S_Customer f on a.ReceiverId=f.Id 
                                                 left join S_Customer g on a.TransferId=g.Id 
                                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                                 left join S_Customer k on a.SupplierId=k.Id 
                                                 left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={2} 
                                                left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={3} 
                                                 where 1=1 {0} order by a.FinishTime desc limit 0,{1}",
                                                 condtion, topN, (int)WeightType.Tare, (int)WeightType.Gross, WeightFiles);
                dtWeight = sqliteDb.ExecuteDataTable(sql);
            } else {
                sql = string.Format(@"select top {0} {4},c.WarehName as WarehId,b.MaterialName as MaterialId,
                                                  d.CustomerName as CustomerId,e.CustomerName as DeliveryId,f.CustomerName as ReceiverId,g.CustomerName as TransferId,
                                                  j.CustomerName as ManufacturerId,k.CustomerName as SupplierId,m.WeighterName as TareWeighterName,n.WeighterName as GrossWeighterName 
                                                 from B_Weight a  left join S_Material b on a.MaterialId=b.Id 
                                                 left join S_Wareh c on a.WarehId=c.Id
                                                 left join S_Customer d on a.CustomerId=d.Id 
                                                 left join S_Customer e on a.DeliveryId=e.Id  
                                                 left join S_Customer f on a.ReceiverId=f.Id 
                                                 left join S_Customer g on a.TransferId=g.Id 
                                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                                 left join S_Customer k on a.SupplierId=k.Id 
                                                 left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={2} 
                                                 left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={3} 
                                                 left join S_Client o on a.MachineCode=o.MachineCode 
                                                 left join S_Client p on a.TareMachineCode=p.MachineCode 
                                                 where 1=1 {1} order by a.FinishTime desc",
                                                 topN, condtion, (int)WeightType.Tare, (int)WeightType.Gross, WeightFiles);
                dtWeight = service.GetDataTable(sql);
            }
            SetTargetTable(dtTarget, dtWeight);
            return dtTarget;
        }
        private void InitTargetTable(DataTable dtTarget, List<SWeightViewDtl> columns)
        {
            dtTarget.Columns.Add("ViewId");
            dtTarget.Columns.Add("Id");
            DataColumn dc = new DataColumn("WeightNo", typeof(string));
            dc.Caption = "磅单号";
            dtTarget.Columns.Add(dc);
            if (columns != null && columns.Count > 0)
            {
                foreach (var column in columns)
                {
                    if (!dtTarget.Columns.Contains(column.FieldName)) 
                    {
                        dc = new DataColumn(column.FieldName);
                        dc.Caption = column.ControlName;
                        dtTarget.Columns.Add(dc);
                    }
                }
            }
        }

        private void SetTargetTable(DataTable dtTarget, DataTable dtWeight) 
        {
            if (dtWeight == null||dtWeight.Rows.Count<=0)
                return;
            List<QWeight> weights = TableHelper.TableToList<QWeight>(dtWeight);
            if (weights == null)
                return;
            List<SCode> lstWarehBizType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.WarehBizType);
            List<SCode> lstMeasureType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.MeasureType);
            SCode code;
            foreach (DataColumn column in dtTarget.Columns) {
                if (dtWeight.Columns.Contains(column.ColumnName)) {
                    column.DataType = dtWeight.Columns[column.ColumnName].DataType;
                }
            }
            foreach (DataRow drWeight in dtWeight.Rows)
            {
                DataRow drTarget = dtTarget.NewRow();
                foreach (DataColumn dcTarget in dtTarget.Columns) 
                {
                    if (dcTarget.ColumnName == Consts.COLUMN_MEASURE_TYPE_NAME && dtWeight.Columns.Contains(Consts.COLUMN_MEASURE_TYPE_NAME))
                    {
                        if (lstMeasureType != null && lstMeasureType.Count > 0)
                        {
                            code = lstMeasureType.Find(c => c.ItemCode == drWeight[Consts.COLUMN_MEASURE_TYPE_NAME].ToObjectString());
                            if (code != null)
                                drWeight[Consts.COLUMN_MEASURE_TYPE_NAME] = code.ItemCaption;
                            else
                                drWeight[Consts.COLUMN_MEASURE_TYPE_NAME] = "";
                        }
                    }
                    
                    if (dcTarget.ColumnName == "WarehBizType" && dtWeight.Columns.Contains("WarehBizType") && drWeight["WarehBizType"] != null)  //结算状态
                    {
                        drTarget["WarehBizType"] = drWeight["WarehBizType"].ToEnum<WarehBizType>().ToDescription();
                    } else if (dcTarget.ColumnName == "PayType" && dtWeight.Columns.Contains("PayType") && drWeight["PayType"] != null)  //结算状态
                    {
                        drTarget["PayType"] = drWeight["PayType"].ToEnum<PayType>().ToDescription();
                    } else if (dcTarget.ColumnName == "MeasureUnit" && dtWeight.Columns.Contains("MeasureUnit") && drWeight["MeasureUnit"] != null)  //计量单位
                    {
                        drTarget["MeasureUnit"] = RetCode.UnitFile(drWeight["MeasureUnit"].ToString());
                    } else if (dcTarget.ColumnName == "OrderSource" && dtWeight.Columns.Contains("OrderSource"))  //榜单来源
                    {
                        drTarget["OrderSource"] = drWeight["OrderSource"].ToEnum<OrderSource>().ToDescription();
                    } else if (dtWeight.Columns.Contains(dcTarget.ColumnName) && dtWeight.Columns[dcTarget.ColumnName].DataType.Name == "DateTime" && drWeight["CreateTime"] != null) { //日期格式转换
                        drTarget[dcTarget.ColumnName] = drWeight[dcTarget.ColumnName].ToDateTime("yyyy-MM-dd HH:mm:ss");
                    } else if (dcTarget.ColumnName == "FinishStateName" && dtWeight.Columns.Contains("FinishState")) { //完成状态
                        drTarget["FinishStateName"] = drWeight["FinishState"].ToEnum<FinishState>().ToDescription();
                    } else if (dtWeight.Columns.Contains(dcTarget.ColumnName)) 
                    {
                        drTarget[dcTarget.ColumnName] = drWeight[dcTarget.ColumnName];
                    }
                }
                dtTarget.Rows.Add(drTarget);
            }
        }

        public WeightQueryResult Query(WeightQueryCondition qc, bool startPage) 
        {
            WeightQueryResult result = new WeightQueryResult();
            DataTable dtTarget = new DataTable();
            DataTable dtWeight = null;
            InitTargetTable(dtTarget,qc.Columns);
            int pageIndex = qc.PageNo;
            int pageSize = qc.PageSize;
            int startIndex = pageSize * pageIndex;
            int endIndex = pageSize * (pageIndex + 1);
            string condition = QueryUtil.GetWeightCondition(qc);
            string sql = string.Format(@"select count(1) from B_Weight a  where 1=1 {0}", condition);
            string payCondition = string.Empty;
            DataTable dt = GetTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.Total = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
            if (startPage)
            {
                #region 单机版
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sql = string.Format(@"select {5},
                                 k.ClientName,l.ClientName as TareClientName,
                                 f.CustomerName as ReceiverId,g.CustomerName as SupplierId,h.CustomerName as TransferId,
                                b.MaterialName as MaterialId,c.WarehName as WarehId, d.CustomerName as CustomerId,e.CustomerName as DeliveryId,j.CustomerName as ManufacturerId,
                                m.WeightTime  as TareTime,m.WeighterName as TareWeighterName,
                                n.WeightTime  as GrossTime,n.WeighterName as GrossWeighterName
                                from(select a.* from B_Weight a  where 1=1 {0} order by a.FinishTime desc limit {1},{2})a  
                                left join S_Material b on a.MaterialId=b.Id 
                                 left join S_Wareh c on a.WarehId=c.Id
                                 left join S_Customer d on a.CustomerId=d.Id 
                                 left join S_Customer e on a.DeliveryId=e.Id  
                                 left join S_Customer f on a.ReceiverId=f.Id 
                                 left join S_Customer g on a.SupplierId=g.Id 
                                 left join S_Customer h on a.TransferId=h.Id 
                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                 left join S_Client k on a.MachineCode=k.MachineCode 
                                 left join S_Client l on a.TareMachineCode=l.MachineCode 
                                 left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={3} 
                                 left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={4} 
                                 order by a.FinishTime desc", condition, startIndex * qc.PageSize, qc.PageSize, (int)WeightType.Tare, (int)WeightType.Gross, WeightFiles);
                    dtWeight = sqliteDb.ExecuteDataTable(sql);
                }
                #endregion
                #region 网络版
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    sql = string.Format(@"select {5},
                                 k.ClientName,l.ClientName as TareClientName,
                                 f.CustomerName as ReceiverId,g.CustomerName as SupplierId,h.CustomerName as TransferId,
                                b.MaterialName as MaterialId,c.WarehName as WarehId, d.CustomerName as CustomerId,e.CustomerName as DeliveryId,j.CustomerName as ManufacturerId,
                                m.WeighterName as TareWeighterName,n.WeighterName as GrossWeighterName 
                                from(select * from(select row_number() over(order by a.FinishTime desc) RN,a.*
                                 from B_Weight a  where 1=1  {0} order by a.FinishTime desc)a where RN>{1} and RN<={2})a 
                                left join S_Material b on a.MaterialId=b.Id 
                                 left join S_Wareh c on a.WarehId=c.Id
                                 left join S_Customer d on a.CustomerId=d.Id 
                                 left join S_Customer e on a.DeliveryId=e.Id  
                                 left join S_Customer f on a.ReceiverId=f.Id 
                                 left join S_Customer g on a.SupplierId=g.Id 
                                 left join S_Customer h on a.TransferId=h.Id 
                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                 left join S_Client k on a.MachineCode=k.MachineCode 
                                 left join S_Client l on a.TareMachineCode=l.MachineCode 
                                 left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={3} 
                                 left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={4} 
                                 order by a.FinishTime desc ", condition, startIndex, endIndex, (int)WeightType.Tare, (int)WeightType.Gross,WeightFiles);
                    dtWeight = service.GetDataTable(sql);
                }
                #endregion
            }
            else
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sql = string.Format(@"select {4},
                                 k.ClientName,l.ClientName as TareClientName,
                                 f.CustomerName as ReceiverId,g.CustomerName as SupplierId,h.CustomerName as TransferId,
                                b.MaterialName as MaterialId,c.WarehName as WarehId, d.CustomerName as CustomerId,e.CustomerName as DeliveryId,j.CustomerName as ManufacturerId,m.WeighterName as TareWeighterName,
                                n.WeighterName as GrossWeighterName
                                from(select a.* from B_Weight a where 1=1 {0} order by a.FinishTime desc) a  
                                left join S_Material b on a.MaterialId=b.Id 
                                 left join S_Wareh c on a.WarehId=c.Id
                                 left join S_Customer d on a.CustomerId=d.Id 
                                 left join S_Customer e on a.DeliveryId=e.Id  
                                 left join S_Customer f on a.ReceiverId=f.Id 
                                 left join S_Customer g on a.SupplierId=g.Id 
                                 left join S_Customer h on a.TransferId=h.Id 
                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                 left join S_Client k on a.MachineCode=k.MachineCode 
                                 left join S_Client l on a.TareMachineCode=l.MachineCode 
                                 left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={1} 
                                 left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={2} 
                                 where 1=1 {3} order by a.FinishTime desc", condition, (int)WeightType.Tare, (int)WeightType.Gross, payCondition,WeightFiles);
                }
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    sql = string.Format(@"select {4},
                                 k.ClientName,l.ClientName as TareClientName,
                                 f.CustomerName as ReceiverId,g.CustomerName as SupplierId,h.CustomerName as TransferId,
                                b.MaterialName as MaterialId,c.WarehName as WarehId, d.CustomerName as CustomerId,e.CustomerName as DeliveryId,j.CustomerName as ManufacturerId,
                                m.WeighterName as TareWeighterName,n.WeighterName as GrossWeighterName
                                from(select a.* from B_Weight a  where 1=1 {0})a 
                                left join S_Material b on a.MaterialId=b.Id 
                                 left join S_Wareh c on a.WarehId=c.Id
                                 left join S_Customer d on a.CustomerId=d.Id 
                                 left join S_Customer e on a.DeliveryId=e.Id  
                                 left join S_Customer f on a.ReceiverId=f.Id 
                                 left join S_Customer g on a.SupplierId=g.Id 
                                 left join S_Customer h on a.TransferId=h.Id 
                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                 left join S_Client k on a.MachineCode=k.MachineCode 
                                 left join S_Client l on a.TareMachineCode=l.MachineCode 
                                 left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={1} 
                                 left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={2} 
                                 where 1=1 {3} order by a.FinishTime desc", condition, (int)WeightType.Tare, (int)WeightType.Gross, payCondition,WeightFiles);
                }
                dtWeight = GetTable(sql);
            }
            //Logger.Write("Query:" + sql);
            SetTargetTable(dtTarget, dtWeight);
            result.Weight = dtTarget;
            return result;
        }
    }
}
