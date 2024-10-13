using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.SQliteService
{
    public class StatementService : IStatementService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;

        #region private methods
        private void InitCustomerMultipleMaterial(DataTable dtTarget, List<SMaterial> materials) 
        {
            dtTarget.Columns.Add("序号", typeof(int));
            dtTarget.Columns.Add("客户");
            if (materials != null && materials.Count > 0)
            {
                string columnName = string.Empty;
                foreach (SMaterial material in materials) 
                {
                    columnName = string.Format("物资_{0}", material.MaterialName);
                    if (!dtTarget.Columns.Contains(columnName)) 
                    {
                        dtTarget.Columns.Add(columnName);
                    }
                }
                columnName = "物资_合计";
                if (!dtTarget.Columns.Contains(columnName))
                {
                    dtTarget.Columns.Add(columnName);
                }
            }
            dtTarget.Columns.Add("客户货款", typeof(decimal));
        }

        private void InitReceiverCarGroup(DataTable dtTarget) 
        {
            dtTarget.Columns.Add("收货单位");
            dtTarget.Columns.Add("车牌号");
            dtTarget.Columns.Add("车数", typeof(int));
            dtTarget.Columns.Add("毛重", typeof(decimal));
            dtTarget.Columns.Add("皮重", typeof(decimal));
            dtTarget.Columns.Add("净重", typeof(decimal));
        }

        private void InitThreeColumn(DataTable dtTarget) 
        {
            dtTarget.Columns.Add("磅单号1");
            dtTarget.Columns.Add("物资1");
            dtTarget.Columns.Add("物资分类1");
            dtTarget.Columns.Add("物资规格1");
            dtTarget.Columns.Add("毛重1", typeof(decimal));
            dtTarget.Columns.Add("计数1", typeof(int));
            dtTarget.Columns.Add("磅单号2");
            dtTarget.Columns.Add("物资2");
            dtTarget.Columns.Add("物资分类2");
            dtTarget.Columns.Add("物资规格2");
            dtTarget.Columns.Add("毛重2", typeof(decimal));
            dtTarget.Columns.Add("计数2", typeof(int));
            dtTarget.Columns.Add("磅单号3");
            dtTarget.Columns.Add("物资3");
            dtTarget.Columns.Add("物资分类3");
            dtTarget.Columns.Add("物资规格3");
            dtTarget.Columns.Add("毛重3", typeof(decimal));
            dtTarget.Columns.Add("计数3", typeof(int));
            dtTarget.Columns.Add("毛重小计", typeof(decimal));
            dtTarget.Columns.Add("计数小计", typeof(int));
        }

        private void AddReceiverCarGroupRow(DataTable dtTarget, string receiverName,List<ReceiverCarGroupStatistics> receiverCarGroups) 
        {
            if (receiverCarGroups != null && receiverCarGroups.Count > 0) 
            {
                DataRow drNew = null;
                foreach (ReceiverCarGroupStatistics stat in receiverCarGroups) 
                {
                    drNew = dtTarget.NewRow();
                    drNew[0] = receiverName;
                    drNew[1] = stat.CarNo;
                    drNew[2] = stat.WeightCount;
                    drNew[3] = stat.GrossWeight;
                    drNew[4] = stat.TareWeight;
                    drNew[5] = stat.SuttleWeight;
                    dtTarget.Rows.Add(drNew);
                }
                drNew = dtTarget.NewRow();
                drNew[1] = "合计";
                drNew[2] = receiverCarGroups.Sum(c => c.WeightCount);
                drNew[3] = receiverCarGroups.Sum(c => c.GrossWeight);
                drNew[4] = receiverCarGroups.Sum(c => c.TareWeight);
                drNew[5] = receiverCarGroups.Sum(c => c.SuttleWeight);
                dtTarget.Rows.Add(drNew);
            }
        }

        private List<SMaterial> GetMaterialList() 
        {
            List<SMaterial> materials = new List<SMaterial>();
            string sql = "select * from S_Material";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                materials = service.GetObjectList<SMaterial>(sql);
            }
            else 
            {
                DataTable dt = sqliteDb.ExecuteDataTable(sql);
                if (dt != null)
                    materials = TableHelper.TableToList<SMaterial>(dt);
            }
            return materials;
        }
        private DataTable GenerateCustomerMultipleMaterial(List<CustomerMaterialStatistics> customerMaterials) 
        {
            DataTable dtTarget = new DataTable();
            dtTarget.TableName="客户多物资";
            List<SMaterial> materials= GetMaterialList();
            InitCustomerMultipleMaterial(dtTarget, materials);
            if (customerMaterials != null && customerMaterials.Count > 0) 
            {
                List<string> customerIds = customerMaterials.Select(c => c.CustomerId).Distinct().ToList();
                int index = 0;
                string columnName = string.Empty;
                decimal totalNetWeight = 0;
                decimal totalCharge = 0;
                foreach (string customerId in customerIds) 
                {
                    index++;
                    DataRow drNew = dtTarget.NewRow();
                    drNew[0] = index;
                    List<CustomerMaterialStatistics> findList = customerMaterials.FindAll(c => c.CustomerId == customerId);
                    if (findList != null && findList.Count > 0) 
                    {
                        drNew[1] = findList[0].CustomerName;
                        totalNetWeight = findList.Sum(c => c.NetWeight);
                        columnName = "物资_合计";
                        drNew[columnName] = totalNetWeight;
                        totalCharge = findList.Sum(c => c.RegularCharge);
                        columnName = "客户货款";
                        drNew[columnName] = totalCharge;
                        foreach (CustomerMaterialStatistics stat in findList) 
                        {
                            columnName = string.Format("物资_{0}", stat.MaterialName);
                            if (drNew.Table.Columns.Contains(columnName))
                                drNew[columnName] = stat.NetWeight;
                        }
                    }
                    dtTarget.Rows.Add(drNew);
                }
            }
            return dtTarget;
        }

        private DataTable GenerateReceiverCarGroup(List<ReceiverCarGroupStatistics> receiverCarGroups) 
        {
            DataTable dtTarget = new DataTable();
            dtTarget.TableName = "收货单位车辆";
            InitReceiverCarGroup(dtTarget);
            if (receiverCarGroups != null && receiverCarGroups.Count > 0)
            {
                List<string> receiverNames = receiverCarGroups.Select(c => c.ReceiverName).Distinct().ToList();
                foreach (string receiver in receiverNames) 
                {
                    AddReceiverCarGroupRow(dtTarget, receiver, receiverCarGroups.FindAll(c => c.ReceiverName == receiver));
                }
                DataRow drNew = dtTarget.NewRow();
                drNew[0] = "合计";
                drNew[2] = receiverCarGroups.Sum(c => c.WeightCount);
                drNew[3] = receiverCarGroups.Sum(c => c.GrossWeight);
                drNew[4] = receiverCarGroups.Sum(c => c.TareWeight);
                drNew[5] = receiverCarGroups.Sum(c => c.SuttleWeight);
                dtTarget.Rows.Add(drNew);
            }
            return dtTarget;
        }

        public DataTable GenerateThreeColumn(List<WeightMaterial> weights) 
        {
            DataTable dtTarget = new DataTable();
            dtTarget.TableName = "多列物资";
            InitThreeColumn(dtTarget);
            if (weights != null && weights.Count > 0) 
            {
                int count = weights.Count;
                int rows = weights.Count / 3;
                if (count > 0 && rows == 0)
                    rows = 1;
                if (count > 0 && count % 3 > 0)
                    rows += 1;
                for (int i = 0; i < rows; i++) 
                {
                    DataRow drNew = dtTarget.NewRow();
                    decimal totalWeight = 0;
                    int weightCount = 1;
                    drNew[0] = weights[3 * i].WeightNo;
                    drNew[1] = weights[3 * i].MaterialName;
                    drNew[2] = weights[3 * i].MaterialTypeName;
                    drNew[3] = weights[3 * i].MaterialModel;
                    drNew[4] = weights[3 * i].GrossWeight;
                    drNew[5] = 1;
                    totalWeight += weights[3 * i].GrossWeight;
                    if (3 * i + 1 < count)
                    {
                        drNew[6] = weights[3 * i+1].WeightNo;
                        drNew[7] = weights[3 * i+1].MaterialName;
                        drNew[8] = weights[3 * i].MaterialTypeName;
                        drNew[9] = weights[3 * i].MaterialModel;
                        drNew[10] = weights[3 * i+1].GrossWeight;
                        drNew[11] = 1;
                        totalWeight += weights[3 * i+1].GrossWeight;
                        weightCount += 1;
                    }
                    if (3 * i + 2 < count)
                    {
                        drNew[12] = weights[3 * i + 2].WeightNo;
                        drNew[13] = weights[3 * i + 2].MaterialName;
                        drNew[14] = weights[3 * i].MaterialTypeName;
                        drNew[15] = weights[3 * i].MaterialModel;
                        drNew[16] = weights[3 * i + 2].GrossWeight;
                        drNew[17] = 1;
                        weightCount += 1;
                        totalWeight += weights[3 * i+2].GrossWeight;
                    }
                    drNew[18] = totalWeight;
                    drNew[19] = weightCount;
                    dtTarget.Rows.Add(drNew);
                }
            }
            return dtTarget;
        }

        #endregion

        public StatementService()
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        public bool InitReportDate() 
        {
            bool isInited = false;
            DateTime startTime = new DateTime(2019, 5, 1);
            DateTime endTime = DateTime.Now;
            int days = (int)(endTime - startTime).TotalDays;
            List<string> sqls = new List<string>();
            sqls.Add("delete from B_ReportDate");
            for (int i = 0; i < days; i++) 
            {
                sqls.Add(string.Format(@"insert into B_ReportDate(ReportDate) values('{0}')",startTime.AddDays(i).ToString("yyyy-MM-dd")));
            }
            isInited = service.ExecuteNonQuery(sqls);
            return isInited;
        }

        public DataSet GetCarStatement(List<SCar> cars,DateTime startTime, DateTime endTime) 
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"select a.ReportDate as '日期',ISNULL(b.GrossWeight,0) as '毛重',ISNULL(b.TareWeight,0) as '皮重',ISNULL(b.SuttleWeight,0) as '净重',isnull(b.CarCount,0) as '车数'
                        from  B_ReportDate a left join (select CONVERT(varchar(10),FinishTime,120) as ReportDate,count(CarNo) as CarCount,
                        SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight from B_Weight a where a.FinishTime>='{0} 00:00:00' and a.FinishTime<='{1} 23:59:59' group by 
                        CONVERT(varchar(10),FinishTime,120),CarNo)b on a.ReportDate=b.ReportDate where a.ReportDate>='{0}' and a.ReportDate<='{1}';",
                         startTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"));
            foreach (SCar car in cars) 
            {
                sb.AppendFormat(@"select a.ReportDate as '日期',ISNULL(b.GrossWeight,0) as '毛重',ISNULL(b.TareWeight,0) as '皮重',ISNULL(b.SuttleWeight,0) as '净重',isnull(b.CarCount,0) as '车数'
                        from  B_ReportDate a left join (select CONVERT(varchar(10),FinishTime,120) as ReportDate,count(CarNo) as CarCount,
                        SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight from B_Weight a 
                         where  a.CarNo='{2}' and a.FinishTime>='{0} 00:00:00' and a.FinishTime<='{1} 23:59:59' group by 
                        CONVERT(varchar(10),FinishTime,120),CarNo)b on a.ReportDate=b.ReportDate where a.ReportDate>='{0}' and a.ReportDate<='{1}';",
                         startTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"),car.CarNo);
            }
            ds = service.GetDataSet(sb.ToString());
            return ds;
        }

        public DataSet GetDocumentData(DocumentType type, string id)
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            string sql;
            switch (type)
            {
                case DocumentType.Charge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', 
                                                  a.PayAmount as '支付金额', a.PayTime as '支付时间',a.DrawerName as '经办人',
                                                 c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.CustomerId where a.Id='{0}'", id);
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', 
                                                      a.PayAmount as '支付金额', a.PayTime as '支付时间',a.DrawerName as '经办人',
                                                     c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额'
                                                     from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                     left join S_Customer c on a.CustomerId=c.CustomerId where a.Id='{0}' ",id);
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "收费单";
                    ds.Tables.Add(dt);
                    break;
                case DocumentType.Recharge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '充值流水号',a.CustomerName as '客户名称', a.PayAmount as '充值金额',
                                                  a.PayTime as '充值时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',
                                                  c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where a.Id='{0}' ",id);
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', a.PayAmount as '充值金额', 
                                                 a.PayTime as '充值时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',
                                                 c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where a.Id='{0}' ",id);
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "充值单";
                    ds.Tables.Add(dt);
                    break;
            }
            return ds;
        }

        public DataSet GetDocumentDesignResource(DocumentType type)
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            string sql;
            switch (type)
            {
                case DocumentType.Charge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称',
                                                  a.PayAmount as '支付金额', a.PayTime as '支付时间',a.DrawerName as '经办人',
                                                 c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc LIMIT 0,1",
                                                 PayBizType.Weight.ToString());
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select top 1 b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', 
                                                     a.PayAmount as '支付金额', a.PayTime as '支付时间',a.DrawerName as '经办人',
                                                     c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额'
                                                     from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                     left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc",
                                                     PayBizType.Weight.ToString());
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "收费单";
                    ds.Tables.Add(dt);
                    break;
                case DocumentType.Recharge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '充值流水号',a.CustomerName as '客户名称', a.PayAmount as '充值金额',
                                                  a.PayTime as '充值时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',
                                                  c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc LIMIT 0,1",
                                                  PayBizType.Recharge.ToString());
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select top 1 b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', a.PayAmount as '充值金额', 
                                                 a.PayTime as '充值时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',
                                                 c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc",
                                                 PayBizType.Recharge.ToString());
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "充值单";
                    ds.Tables.Add(dt);
                    break;
            }
            return ds;
        }

        public DataSet GetCustomSummaryDesignResource(SReportTemplate template) 
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            string sql = string.Format("{0}", template.DataSourceSql).Replace("#P#","");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format("select * from({0})a LIMIT 0,1", sql);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format("select top 1 * from({0})a", sql);
                dt = service.GetDataTable(sql);
            }
            
            dt.TableName = "自定义报表";
            ds.Tables.Add(dt);
            return ds;       
        }

        public DataSet GetSummaryDesignResource(SummaryReportType type)
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            string sql;
            switch (type)
            {
                case SummaryReportType.Charge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', a.PayAmount as '支付金额',
                                                  a.PayTime as '支付时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',
                                                  c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc LIMIT 0,3",
                                                  PayBizType.Weight.ToString());
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select top 3 b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称',
                                                 a.PayAmount as '支付金额', a.PayTime as '支付时间',
                                                 c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc",
                                                 PayBizType.Weight.ToString());
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "磅单收费统计表";
                    ds.Tables.Add(dt);
                    break;
                case SummaryReportType.Recharge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '充值流水号',a.CustomerName as '客户名称', a.PayAmount as '充值金额',
                                                  a.PayTime as '充值时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc LIMIT 0,3",
                                                  PayBizType.Recharge.ToString());
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select top 3 b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', 
                                                 a.PayAmount as '充值金额', a.PayTime as '充值时间',
                                                 c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where PayBizType='{0}' ORDER BY PayTime desc",
                                                 PayBizType.Recharge.ToString());
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "客户充值报表";
                    ds.Tables.Add(dt);
                    break;
            }
            return ds;
        }

        public DataTable GetWeightDesignDataSource(WeightSubReportType subType) 
        {
            DataTable dtTarget = new DataTable();
            string sql = string.Empty;
            if (subType == WeightSubReportType.Customer)
            {
                sql = @"select b.CustomerName as '客户',a.GrossWeight as '毛重',a.SuttleWeight as '净重',a.TareWeight as '皮重',a.WeightCount as '磅单数' 
                             from(select a.CustomerId,COUNT(1) as WeightCount,SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight
                             from B_Weight a group by a.CustomerId)a inner join S_Customer b on a.CustomerId=b.Id";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = service.GetDataTable(sql);
                }
                else 
                {
                    dtTarget = sqliteDb.ExecuteDataTable(sql);
                }
                if (dtTarget != null) 
                {
                    dtTarget.TableName = "客户";
                }
            }
            if (subType == WeightSubReportType.CustomerMultipleMaterial) 
            {
                sql = @"select b.CustomerId,b.CustomerName,a.NetWeight,c.MaterialName,a.GrossWeight,
                        a.SuttleWeight,a.TareWeight,a.WeightCount,a.RegularCharge from(select a.CustomerId,a.MaterialId,COUNT(1) as WeightCount,
                        SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight,
                        SUM(a.NetWeight) as NetWeight,sum(a.RegularCharge) as RegularCharge
                         from B_Weight a group by a.CustomerId,a.MaterialId)a inner join S_Customer b on a.CustomerId=b.Id
                         inner join S_Material c on a.MaterialId=c.Id";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = GenerateCustomerMultipleMaterial(service.GetObjectList<CustomerMaterialStatistics>(sql));
                }
                else 
                {
                    dtTarget = GenerateCustomerMultipleMaterial(sqliteDb.GetObjectList<CustomerMaterialStatistics>(sql));
                }
            }
            if (subType == WeightSubReportType.CustomerSingleMaterial)
            {
                sql = @"select b.CustomerName as '客户',c.MaterialName as '物资',a.GrossWeight as '毛重',
                            a.SuttleWeight as '净重',a.TareWeight as '皮重',a.WeightCount as '磅单数' from(select a.CustomerId,a.MaterialId,COUNT(1) as WeightCount,
                            SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight
                             from B_Weight a group by a.CustomerId,a.MaterialId)a inner join S_Customer b on a.CustomerId=b.Id
                             inner join S_Material c on a.MaterialId=c.Id";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = service.GetDataTable(sql);
                }
                else
                {
                    dtTarget = sqliteDb.ExecuteDataTable(sql);
                }
                if (dtTarget != null)
                {
                    dtTarget.TableName = "客户物资";
                }
            }
            if (subType == WeightSubReportType.ThreeColumn)
            {
                
                List<WeightMaterial> weights = null;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    sql = string.Format(@"select top 10 a.WeightNo,a.GrossWeight,b.MaterialName,c.ItemCaption as MaterialTypeName,a.MaterialModel
                                                     from B_Weight a   left join S_Material b on a.MaterialId=b.Id 
                                                     left join (select * from S_Code where ParentId in(select Id from S_Code where ItemCode='MaterialType'))c on b.MaterialType=c.ItemCode where 1=1");
                    weights = service.GetObjectList<WeightMaterial>(sql);
                }
                else
                {
                    sql = string.Format(@"select  a.WeightNo,a.GrossWeight,b.MaterialName from B_Weight a left join S_Material b on a.MaterialId=b.Id where 1=1 limit 0,10");
                    weights = sqliteDb.GetObjectList<WeightMaterial>(sql);
                }
                dtTarget = GenerateThreeColumn(weights);
            }
            if (subType == WeightSubReportType.ReceiverCarGroup)
            {
                sql = @"select b.CustomerName as ReceiverName,a.CarNo,a.GrossWeight,a.TareWeight,a.SuttleWeight,a.WeightCount
                              from(select COUNT(1) as WeightCount,sum(a.GrossWeight) as GrossWeight,sum(a.TareWeight) as TareWeight,
                              sum(a.SuttleWeight) as SuttleWeight,a.CarNo,a.ReceiverId from B_Weight a group by a.CarNo,a.ReceiverId)a 
                              inner join S_Customer b on a.ReceiverId=b.Id;";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = GenerateReceiverCarGroup(service.GetObjectList<ReceiverCarGroupStatistics>(sql));
                }
                else
                {
                    dtTarget = GenerateReceiverCarGroup(service.GetObjectList<ReceiverCarGroupStatistics>(sql));
                }
            }
            if (subType == WeightSubReportType.Sales)
            {
                dtTarget.TableName = "销售";
                dtTarget.Columns.Add("物资");
                dtTarget.Columns.Add("单位");
                dtTarget.Columns.Add("单价", typeof(decimal));
                dtTarget.Columns.Add("净重", typeof(decimal));
                dtTarget.Columns.Add("扣重", typeof(decimal));
                dtTarget.Columns.Add("实重", typeof(decimal));
                dtTarget.Columns.Add("金额", typeof(decimal));
                dtTarget.Columns.Add("付款方式");
                dtTarget.Columns.Add("付款金额", typeof(decimal));
                DataTable dtWeight = null;
                DataTable dtSale = null;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    sql = @"select a.PayAmount,b.ItemCaption PayTypeName from(select SUM(payamount) as PayAmount,PayType from B_Pay a where PayBizType='Weight' group by PayType)a 
                                        inner join (select ItemValue,ItemCaption from S_Code where ParentId in(select Id from S_Code where ItemCode='PayType'))b 
                                        on convert(varchar,a.PayType)=b.ItemValue";
                    dtSale = service.GetDataTable(sql);
                }
                else
                {
                    sql = @"select a.PayAmount,b.ItemCaption PayTypeName from(select SUM(payamount) as PayAmount,PayType from B_Pay a where PayBizType='Weight' group by PayType)a 
                                        inner join (select ItemValue,ItemCaption from S_Code where ParentId in(select Id from S_Code where ItemCode='PayType'))b 
                                        on a.PayType=b.ItemValue";
                    dtSale = sqliteDb.ExecuteDataTable(sql);
                }
                sql = @"select b.MaterialName,a.SuttleWeight,a.ImpurityWeight,a.NetWeight,a.RegularCharge from(select a.MaterialId,sum(a.SuttleWeight) as SuttleWeight,sum(a.ImpurityWeight) as ImpurityWeight,
                                    sum(a.NetWeight) as NetWeight,sum(a.RegularCharge) as RegularCharge from B_Weight a 
                                    group by a.MaterialId)a inner join S_Material b on a.MaterialId=b.Id";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtWeight = service.GetDataTable(sql);
                }
                else
                {
                    dtWeight = sqliteDb.ExecuteDataTable(sql);
                }
                if (dtWeight != null && dtWeight.Rows.Count > 0)
                {
                    decimal price = 0;
                    decimal amount = 0;
                    decimal netweight = 0;
                    DataRow drNew = null;
                    for (int i = 0; i < dtWeight.Rows.Count; i++)
                    {
                        price = 0;
                        drNew = dtTarget.NewRow();
                        amount = dtWeight.Rows[i][4].ToDecimal();
                        netweight = dtWeight.Rows[i][3].ToDecimal();
                        if (netweight != 0)
                            price = amount / netweight;
                        drNew[0] = dtWeight.Rows[i][0] != null ? dtWeight.Rows[i][0].ToObjectString() : "空名称";
                        drNew[1] = "";
                        drNew[2] = price;
                        drNew[3] = dtWeight.Rows[i][1].ToDecimal();
                        drNew[4] = dtWeight.Rows[i][2].ToDecimal();
                        drNew[5] = netweight;
                        drNew[6] = amount;
                        if (dtSale != null && dtSale.Rows.Count > 0 && i < dtSale.Rows.Count)
                        {
                            drNew[7] = dtSale.Rows[i][1].ToObjectString();
                            drNew[8] = dtSale.Rows[i][0].ToDecimal();
                        }
                        dtTarget.Rows.Add(drNew);
                    }
                    if (dtSale != null && dtSale.Rows.Count > 0 && dtSale.Rows.Count > dtWeight.Rows.Count)
                    {
                        int startIndex = dtWeight.Rows.Count;
                        for (int i = startIndex; i < dtSale.Rows.Count; i++)
                        {
                            drNew = dtTarget.NewRow();
                            drNew[7] = dtSale.Rows[i][1].ToObjectString();
                            drNew[8] = dtSale.Rows[i][0].ToDecimal();
                            dtTarget.Rows.Add(drNew);
                        }
                    }
                }    
            }
            return dtTarget;
        }

        public DataTable GetWeightDataSource(WeightSubReportType subType, WeightQueryCondition qc)
        {
            DataTable dtTarget = new DataTable();
            string sql = string.Empty;
            string condition = QueryUtil.GetWeightCondition(qc);
            if (subType == WeightSubReportType.Customer)
            {
                sql = string.Format(@"select b.CustomerName as '客户',a.GrossWeight as '毛重',a.SuttleWeight as '净重',a.TareWeight as '皮重',a.WeightCount as '磅单数' 
                             from(select a.CustomerId,COUNT(1) as WeightCount,SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,
                             SUM(a.SuttleWeight) as SuttleWeight
                             from (select * from B_Weight a where 1=1 {0}) a group by a.CustomerId)a inner join S_Customer b on a.CustomerId=b.Id", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = service.GetDataTable(sql);
                }
                else
                {
                    dtTarget = sqliteDb.ExecuteDataTable(sql);
                }
                if (dtTarget != null)
                {
                    dtTarget.TableName = "客户";
                }
            }
            if (subType == WeightSubReportType.CustomerMultipleMaterial)
            {
                sql = string.Format(@"select b.CustomerId,b.CustomerName,a.NetWeight,c.MaterialName,a.GrossWeight,
                        a.SuttleWeight,a.TareWeight,a.WeightCount,a.RegularCharge from(select a.CustomerId,a.MaterialId,COUNT(1) as WeightCount,
                        SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight,
                        SUM(a.NetWeight) as NetWeight,sum(a.RegularCharge) as RegularCharge
                         from (select * from B_Weight a where  1=1 {0}) a group by a.CustomerId,a.MaterialId)a inner join S_Customer b on a.CustomerId=b.Id
                         inner join S_Material c on a.MaterialId=c.MaterialId", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = GenerateCustomerMultipleMaterial(service.GetObjectList<CustomerMaterialStatistics>(sql));
                }
                else
                {
                    dtTarget = GenerateCustomerMultipleMaterial(sqliteDb.GetObjectList<CustomerMaterialStatistics>(sql));
                }
            }
            if (subType == WeightSubReportType.CustomerSingleMaterial)
            {
                sql = string.Format(@"select b.CustomerName as '客户',c.MaterialName as '物资',a.GrossWeight as '毛重',
                            a.SuttleWeight as '净重',a.TareWeight as '皮重',a.WeightCount as '磅单数' from(select a.CustomerId,a.MaterialId,COUNT(1) as WeightCount,
                            SUM(a.GrossWeight) as GrossWeight,SUM(a.TareWeight) as TareWeight,SUM(a.SuttleWeight) as SuttleWeight
                             from (select * from B_Weight a where 1=1  {0}) a group by a.CustomerId,a.MaterialId)a inner join S_Customer b on a.CustomerId=b.Id
                             inner join S_Material c on a.MaterialId=c.Id", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = service.GetDataTable(sql);
                }
                else
                {
                    dtTarget = sqliteDb.ExecuteDataTable(sql);
                }
                if (dtTarget != null)
                {
                    dtTarget.TableName = "客户物资";
                }
            }
            if (subType == WeightSubReportType.ReceiverCarGroup)
            {
                sql = string.Format(@"select b.CustomerName as ReceiverName,a.CarNo,a.GrossWeight,a.TareWeight,a.SuttleWeight,a.WeightCount
                              from(select COUNT(1) as WeightCount,sum(a.GrossWeight) as GrossWeight,sum(a.TareWeight) as TareWeight,
                              sum(a.SuttleWeight) as SuttleWeight,a.CarNo,a.ReceiverId from B_Weight a where 1=1  {0} group by a.CarNo,a.ReceiverId)a 
                              inner join S_Customer b on a.ReceiverId=b.Id;", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtTarget = GenerateReceiverCarGroup(service.GetObjectList<ReceiverCarGroupStatistics>(sql));
                }
                else
                {
                    dtTarget = GenerateReceiverCarGroup(service.GetObjectList<ReceiverCarGroupStatistics>(sql));
                }
            }
            if (subType == WeightSubReportType.ThreeColumn) 
            {
                sql = string.Format(@"select a.WeightNo,a.GrossWeight,b.MaterialName,c.ItemCaption as MaterialTypeName,a.MaterialModel from B_Weight a 
                                                      left join S_Material b on a.MaterialId=b.Id 
                                                      left join (select * from S_Code where ParentId in(select Id from S_Code where ItemCode='MaterialType'))c on b.MaterialType=c.ItemCode 
                                                      where 1=1 {0}", condition);
                List<WeightMaterial> weights = null;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    weights = service.GetObjectList<WeightMaterial>(sql);
                }
                else 
                {
                    weights = sqliteDb.GetObjectList<WeightMaterial>(sql);
                }
                dtTarget = GenerateThreeColumn(weights);
            }
            if (subType == WeightSubReportType.Sales)
            {
                dtTarget.TableName = "销售";
                dtTarget.Columns.Add("物资");
                dtTarget.Columns.Add("单位");
                dtTarget.Columns.Add("单价", typeof(decimal));
                dtTarget.Columns.Add("净重", typeof(decimal));
                dtTarget.Columns.Add("扣重", typeof(decimal));
                dtTarget.Columns.Add("实重", typeof(decimal));
                dtTarget.Columns.Add("金额", typeof(decimal));
                dtTarget.Columns.Add("付款方式");
                dtTarget.Columns.Add("付款金额", typeof(decimal));
                DataTable dtWeight = null;
                DataTable dtSale = null;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    sql = string.Format(@"select a.PayAmount,b.ItemCaption PayTypeName from (select ItemValue,ItemCaption from S_Code where ParentId in(select Id from S_Code where ItemCode='PayType'))b left join 
                                       (select SUM(b.RegularCharge) as PayAmount,PayType from B_Pay a 
                                       inner join(select Id,RegularCharge from B_Weight a where 1=1 {0})b on a.RefId=b.Id  where PayBizType='Weight' group by PayType)a 
                                         on b.ItemValue=convert(varchar,a.PayType)", condition);
                    dtSale = service.GetDataTable(sql);
                }
                else
                {
                    sql = string.Format(@"select ifnull(a.PayAmount,0) as PayAmount,b.ItemCaption PayTypeName from (select ItemValue,ItemCaption from S_Code where ParentId in(select Id from S_Code where ItemCode='PayType'))b left join 
                                       (select SUM(b.RegularCharge) as PayAmount,PayType from B_Pay a 
                                       inner join(select Id,RegularCharge from B_Weight a where  1=1  {0})b on a.RefId=b.Id  where PayBizType='Weight' group by PayType)a 
                                         on b.ItemValue=a.PayType", condition);
                    dtSale = sqliteDb.ExecuteDataTable(sql);
                }
                sql = string.Format(@"select b.MaterialName,a.SuttleWeight,a.ImpurityWeight,a.NetWeight,a.RegularCharge from(select a.MaterialId,sum(a.SuttleWeight) as SuttleWeight,sum(a.ImpurityWeight) as ImpurityWeight,
                                    sum(a.NetWeight) as NetWeight,sum(a.RegularCharge) as RegularCharge from B_Weight a where  1=1  {0}
                                    group by a.MaterialId)a inner join S_Material b on a.MaterialId=b.Id", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dtWeight = service.GetDataTable(sql);
                }
                else
                {
                    dtWeight = sqliteDb.ExecuteDataTable(sql);
                }
                if (dtWeight != null && dtWeight.Rows.Count > 0)
                {
                    decimal price = 0;
                    decimal amount = 0;
                    decimal netweight = 0;
                    DataRow drNew = null;
                    for (int i = 0; i < dtWeight.Rows.Count; i++)
                    {
                        price = 0;
                        drNew = dtTarget.NewRow();
                        amount = dtWeight.Rows[i][4].ToDecimal();
                        netweight = dtWeight.Rows[i][3].ToDecimal();
                        if (netweight != 0)
                            price = amount / netweight;
                        drNew[0] = dtWeight.Rows[i][0] != null ? dtWeight.Rows[i][0].ToObjectString() : "空名称";
                        drNew[1] = "";
                        drNew[2] = price;
                        drNew[3] = dtWeight.Rows[i][1].ToDecimal();
                        drNew[4] = dtWeight.Rows[i][2].ToDecimal();
                        drNew[5] = netweight;
                        drNew[6] = amount;
                        if (dtSale != null && dtSale.Rows.Count > 0 && i < dtSale.Rows.Count)
                        {
                            drNew[7] = dtSale.Rows[i][1].ToObjectString();
                            drNew[8] = dtSale.Rows[i][0].ToDecimal();
                        }
                        dtTarget.Rows.Add(drNew);
                    }
                    if (dtSale != null && dtSale.Rows.Count > 0 && dtSale.Rows.Count > dtWeight.Rows.Count)
                    {
                        int startIndex = dtWeight.Rows.Count;
                        for (int i = startIndex; i < dtSale.Rows.Count; i++)
                        {
                            drNew = dtTarget.NewRow();
                            drNew[7] = dtSale.Rows[i][1].ToObjectString();
                            drNew[8] = dtSale.Rows[i][0].ToDecimal();
                            dtTarget.Rows.Add(drNew);
                        }
                    }
                }
            }
            return dtTarget;
        }

        public DataSet GetSummaryData(SummaryReportType type, PageQueryCondition qc)
        {
            string condition = qc.ExtendCondition;
            DataSet ds = new DataSet();
            DataTable dt = null;
            string sql;
            switch (type)
            {
                case SummaryReportType.Charge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', a.PayAmount as '支付金额',
                                                  a.PayTime as '支付时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',
                                                 c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where 1=1 {0} ORDER BY PayTime desc",
                                                 condition);
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', 
                                                  a.PayAmount as '支付金额', a.PayTime as '支付时间',a.DrawerName as '经办人',
                                                 c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where 1=1 {0} ORDER BY PayTime desc",
                                                 condition);
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "磅单收费统计表";
                    ds.Tables.Add(dt);
                    break;
                case SummaryReportType.Recharge:
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        sql = string.Format(@"select  b.WeightNo as '磅单号',PayNo as '充值流水号',a.CustomerName as '客户名称', a.PayAmount as '充值金额',
                                                  a.PayTime as '充值时间',c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=cId where 1=1 {0} ORDER BY PayTime desc",
                                                 condition);
                        dt = sqliteDb.ExecuteDataTable(sql);
                    }
                    else
                    {
                        sql = string.Format(@"select b.WeightNo as '磅单号',PayNo as '支付流水号',a.CustomerName as '客户名称', 
                                                 a.PayAmount as '充值金额', a.PayTime as '充值时间',
                                                 c.RechargeAmount as '充值总额',c.PayAmount as '付款总额',c.BalanceAmount as '余额',a.DrawerName as '经办人'
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where  1=1 {0} ORDER BY PayTime desc",
                                                 condition);
                        dt = service.GetDataTable(sql);
                    }
                    dt.TableName = "客户充值报表";
                    ds.Tables.Add(dt);
                    break;
            }
            return ds;
        }
    }
}
