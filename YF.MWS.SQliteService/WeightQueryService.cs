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
            a.CarNo as CarId, a.DriverName, a.QcNo,a.MaterialAmount,a.AdditionalTime,a.GrossWeight, a.MeasureUnit, a.CustomCharge,a.OrderSource,a.TareWeight, a.SuttleWeight, 
            a.WeighterName,a.d1,a.d2,a.d3,a.PayType,a.UnitMoney,a.ImpurityWeight,a.MaxWeight,a.NetWeight,a.UnitPrice,a.RegularCharge,a.Remark,a.MaterialModel,a.WarehBizType as WarehBizType,a.AxleCount,
            a.CustomerBalance,a.PrintCount";
        public DataTable Export(WeightQueryCondition query)
        {
            string condition = QueryUtil.GetWeightCondition(query);
            string sql = string.Format(@"select a.WeightNo '磅单号',a.CarNo as '车牌号',b.CustomerName as '客户单位',g.CustomerName as '收货单位',
                                                         c.CustomerName as '发货单位',d.MaterialName as '物料', 
                                                            e.SpecName as '规格',f.WarehName as '仓库',a.GrossWeight as '毛重',a.TareWeight as '皮重',a.SuttleWeight as '净重',a.CardNo as '卡号',
                                                             a.CreateTime as '开始时间',a.FinishTime as '完成时间',m.WeightTime as '皮重时间',n.WeightTime as '毛重时间',a.Remark as '备注'
                                                            from (select a.* from B_Weight a where 1=1 {0})a 
                                                            left join S_Customer b on a.CustomerId=b.Id 
                                                            left join S_Customer c on a.DeliveryId=b.Id
                                                            left join S_Material d on a.MaterialId=d.Id 
                                                            left join S_MaterialSpec e on a.SpecId=e.Id 
                                                            left join S_Wareh f on a.WarehId=f.Id 
                                                            left join S_Customer g on a.ReceiverId=g.Id 
                                                            left join B_WeightDetail m on a.Id=m.WeightId and m.WeightType={1} 
                                                            left join B_WeightDetail n on a.Id=n.WeightId and n.WeightType={2} ",
                                                            condition, (int)WeightType.Tare, (int)WeightType.Gross);
            DataTable dt = GetTable(sql);
            return dt;
        }
        public List<VWeight> GetViewsByWaybillNo(string waybillNo) {
            string sql = "";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                sql = string.Format(@"select {1},c.WarehName,b.MaterialName,d.CustomerName,e.CustomerName as DeliveryName,f.CustomerName as ReceiverName,g.CustomerName as TransferName,
                                                  j.CustomerName as ManufacturerName,k.CustomerName as SupplierName from B_Weight a  left join S_Material b on a.MaterialId=b.Id 
                                                 left join S_Wareh c on a.WarehId=c.Id
                                                 left join S_Customer d on a.CustomerId=d.Id 
                                                 left join S_Customer e on a.DeliveryId=e.Id  
                                                 left join S_Customer f on a.ReceiverId=f.Id 
                                                 left join S_Customer g on a.TransferId=g.Id 
                                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                                 left join S_Customer k on a.SupplierId=k.Id 
                                                 where a.WaybillNo='{0}' order by a.FinishTime",
                                                 waybillNo,WeightFiles);
            } else {
                sql = string.Format(@"select {4},c.WarehName,b.MaterialName,d.CustomerName,e.CustomerName as DeliveryName,f.CustomerName as ReceiverName,g.CustomerName as TransferName,
                                                  j.CustomerName as ManufacturerName,k.CustomerName as SupplierName from B_Weight a  left join S_Material b on a.MaterialId=b.Id 
                                                 left join S_Wareh c on a.WarehId=c.Id
                                                 left join S_Customer d on a.CustomerId=d.Id 
                                                 left join S_Customer e on a.DeliveryId=e.Id  
                                                 left join S_Customer f on a.ReceiverId=f.Id 
                                                 left join S_Customer g on a.TransferId=g.Id 
                                                 left join S_Customer j on a.ManufacturerId=j.Id 
                                                 left join S_Customer k on a.SupplierId=k.Id 
                                                 left join S_Client o on a.MachineCode=o.MachineCode 
                                                 left join S_Client p on a.TareMachineCode=p.MachineCode 
                                                 where a.WaybillNo='{0}' order by a.FinishTime desc",
                                                  waybillNo, (int)WeightType.Tare, (int)WeightType.Gross, WeightFiles);
            }
            return base.getList<VWeight>(sql);
        }
        public List<BWeight> GetList(int year) 
        {
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select Id,WeightNo,CarNo from B_Weight a 
                                           where  (abs(strftime('%Y',a.FinishTime))={0} or abs(strftime('%Y',a.FinishTime))={1})  and a.RowState!={1}",
                                           year, year - 1, (int)RowState.Delete);
            }
            else 
            {
                sql = string.Format(@"select Id,WeightNo,CarNo from B_Weight a 
                                           where  (datepart(year,a.FinishTime)={0} or datepart(year,a.FinishTime)={1})  and a.RowState!={1}",
                           year, year - 1, (int)RowState.Delete);
            }
            return base.getList<BWeight>(sql);
        }

        public List<BWeight> GetNotQcList(int year)
        {
            List<BWeight> lst = new List<BWeight>();
            string sql;
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select Id,WeightNo,CarNo from B_Weight a 
                                        where (abs(strftime('%Y',a.FinishTime))={0} or abs(strftime('%Y',a.FinishTime))={1}) 
                                         and a.RowState!={2} and Id not in (select WeightId from B_WeightQc)",
                                           year, year - 1, (int)RowState.Delete);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format(@"select Id,WeightNo,CarNo from B_Weight a 
                                        where (datepart(year,a.FinishTime)={0} or datepart(year,a.FinishTime)={1}) 
                                         and a.RowState!={2} and Id not in (select WeightId from B_WeightQc)",
                           year, year - 1, (int)RowState.Delete);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                lst = TableHelper.TableToList<BWeight>(dt);
            }
            return lst;
        }

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

        public DataTable GetFinanceList(DateTime dtStart, DateTime dtEnd, FinaSettlement settleState,DateType type) 
        {
            string condition = GetFinanceConditon(dtStart, dtEnd, settleState,type);
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
            sbSql.AppendFormat("select a.[ControlName],a.[ControlType],a.[FullName],a.[FieldName] from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", CurrentClient.Instance.ViewId);
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
            dtWeight.Columns.Add("完成日期", typeof(DateTime));
            dtWeight.Columns.Add("结算日期", typeof(DateTime));
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
                                                a.Remark,a.WeighterName,a.FinishTime as '完成日期',a.WeightNo as '磅单号',a.CarNo as 'CarId',d.CustomerName as 'CustomerId',
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',
                                                h.CustomerName as 'ReceiverId',j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId',m.CustomerName as 'DeliveryId',
                                                 case i.SettleState when 1 then '已审核' else '未审核' end as '财务审核',
                                                case i.FreightSettleState when 1 then '已结算' else '未结算' end as '运费结算',
                                                 case i.PaymentSettleState when 1 then '已结算' else '未结算' end as '货款结算',i.SettleNo as '结算单号',i.CreateTime as '结算日期'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                left join S_Customer j on a.DeliveryId=j.Id 
                                                left join B_WeightExt i on a.Id=i.Id 
                                                left join S_Customer k on a.ManufacturerId=k.Id 
                                                left join S_Customer m on a.DeliveryId=m.Id 
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

        private string GetQcCondition(DateTime dtStart, DateTime dtEnd, int qcState) 
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
                    sbCondition.AppendFormat("and a.FinishTime< '{0}' ", dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                }
            }
            if (qcState != 2)
            {
                sbCondition.AppendFormat(" and a.QcState={0}", qcState);
            }
            return sbCondition.ToString();
        }
        public DataTable GetQcList(DateTime dtStart, DateTime dtEnd, int qcState) 
        {
            string condition = GetQcCondition(dtStart, dtEnd, qcState);
            DataTable dtWeight = new DataTable(); 
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMeasureType = masterService.GetSubList(SysCode.MeasureType.ToString());
            List<SCode> lstJudgementType = masterService.GetSubList(SysCode.Judgement.ToString());
            List<SCode> lstProductFlowType = masterService.GetSubList(SysCode.ProductFlow.ToString());
            List<SCode> lstPackageType = masterService.GetSubList(SysCode.PackageType.ToString());
            SCode code = null; 
            DataTable dtColumnCfg = YF.MWS.Util.Utility.GetColumnsCfg(PrintCfgType.Qc);
            DataType type = DataType.Unkown;
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("QcId");
            if (dtColumnCfg != null && dtColumnCfg.Rows.Count > 0) 
            {
                foreach (DataRow dr in dtColumnCfg.Rows) 
                {
                    type = dr["type"].ToEnum<DataType>();
                    if (type == DataType.DateTime) 
                    {
                        if (!dtWeight.Columns.Contains(dr["name"].ToObjectString()))
                        {
                            dtWeight.Columns.Add(dr["name"].ToObjectString(), typeof(DateTime));
                        }
                    }
                    else if (type == DataType.Int)
                    {
                        if (!dtWeight.Columns.Contains(dr["name"].ToObjectString()))
                        {
                            dtWeight.Columns.Add(dr["name"].ToObjectString(), typeof(int));
                        }
                    }
                    else
                    {
                        if (!dtWeight.Columns.Contains(dr["name"].ToObjectString()))
                        {
                            dtWeight.Columns.Add(dr["name"].ToObjectString());
                        }
                    }
                }
            } 
            sbSql.Clear();
            sbSql.AppendFormat(@"select  i.Id as QcId,a.Id as Weight,a.GrossWeight as '毛重',a.SuttleWeight as '净重',a.TareWeight as '皮重',a.NetWeight as '实重',a.UnitPrice as '单价',a.UnitCharge as '收费单价',
                                               a.RealCharge as '过磅费',a.MeasureUnit as '计量单位',case a.OrderSource when 'Additional' then '补单' else '称重' end as '磅单来源',a.DriverName as '驾驶员',
                                                a.Remark  as '备注',a.WeighterName  as '司磅员',a.FinishTime as '过磅日期',a.WeightNo as '磅单号',a.CarNo as '车号',d.CustomerName as '客户',
                                                e.MaterialName as '品名',a.MeasureType as '业务类型',a.PrintCount as '打印次数',
                                                h.CustomerName as '接收单位',j.CustomerName as '发货单位', i.QcNo as '质检单号',i.Water as '水份%',i.PrimaryAmount as '原发数量',i.Impurity as '杂质%',
                                                i.YellowRate as '黄变率%',i.BrownRate as '出糙率%',i.MilledRice as '整精米率%',i.HeavyMetal as '重金属',i.BrokenRate as '碎米率',
                                                i.SmallBrokenRate as '其中小碎',i.PowderRate as '糠粉率',i.FattyAcid as '脂肪酸值',i.ImperfectGrain as '不完善率',i.MutualRate as '互混率',
                                                i.Judgement as '综合判定',i.ProductFlow as '产品流向',i.Inspector as '检验员'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer j on a.DeliveryId=j.Id 
                                                left join B_WeightQc i on a.Id=i.WeightId 
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
            sbSql.AppendFormat(@"select  a.Id as WeightId  from B_Weight a left join S_User b on a.WeighterId=b.Id  
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
                    code = lstMeasureType.Find(c => c.ItemCode == drMain["业务类型"].ToObjectString());
                    if (code != null)
                    {
                        drMain["业务类型"] = code.ItemCaption;
                    } 
                    code = lstJudgementType.Find(c => c.ItemCode == drMain["综合判定"].ToObjectString());
                    if (code != null)
                    {
                        drMain["综合判定"] = code.ItemCaption;
                    }
                    code = lstProductFlowType.Find(c => c.ItemCode == drMain["产品流向"].ToObjectString());
                    if (code != null)
                    {
                        drMain["产品流向"] = code.ItemCaption;
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
                                /*if (columnName == "包装方式")
                                {
                                    code = lstPackageType.Find(c => c.ItemCode == dr["AttributeValue"].ToObjectString());
                                    if (code != null)
                                    {
                                        drWeight["包装方式"] = code.ItemCaption;
                                    }
                                }
                                else
                                {
                                    drWeight[columnName] = dr["AttributeValue"];
                                }*/
                                drWeight[columnName] = dr["AttributeValue"];
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            }
            return dtWeight;   
        }
    }
}
