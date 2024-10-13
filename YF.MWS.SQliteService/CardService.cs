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

namespace YF.MWS.SQliteService
{
    public class CardService : ICardService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;
        

        public CardService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        #region ICardService 成员

        public bool Delete(string cardId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from B_PlanCard where Id='{0}'", cardId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isDeleted = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                isDeleted = service.ExecuteNonQuery(sql);
            }
            return isDeleted;
        }

        public bool DeleteBatch(List<string> lstCardId)
        {
            bool isDeleted = false;
            List<string> lstSql = new List<string>();
            foreach (string cardId in lstCardId)
            {
                lstSql.Add(string.Format(@"delete from B_PlanCard where Id='{0}'", cardId));
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isDeleted = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else 
            {
                isDeleted = service.ExecuteNonQuery(lstSql);
            }
            return isDeleted;
        }

        public bool DeleteDetail(string detailId) 
        {
            bool isDeleted = false;
            List<string> lstSql = new List<string>();
            lstSql.Add(string.Format(@"delete from B_CardPreset where CvDetailId='{0}'", detailId));
            lstSql.Add(string.Format(@"delete from S_CardViewDtl where Id='{0}'", detailId));
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isDeleted = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else 
            {
                isDeleted = service.ExecuteNonQuery(lstSql);
            }
            return isDeleted;
        }

        public bool ExistCarNo(string cardId, string carNo) 
        {
            bool isExist = false;
            int rows = 0;
            string sql = string.Format(@"select count(1) from B_PlanCard where Id!='{0}' and CarNo='{1}'",cardId,carNo);
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
                rows = dt.Rows[0][0].ToInt();
            }
            isExist = rows > 0 ? true : false;
            return isExist;
        }

        public DataTable GetExport() 
        {
            string sql;
            sql = @"select Id as 'IC卡编号',CardNo as '卡号',CarNo as '车牌号', DriverName as '司机',
                PlanNo as '计划单号',MeasureType as '业务类别',b.CustomerName as '客户',c.CustomerName as '发货单位',
                d.CustomerName as '收货单位',e.MaterialName as '物资名称'
                 from B_PlanCard a left join S_Customer b on a.CustomerId=b.Id 
                left join S_Customer c on a.DeliveryId=c.Id 
                left join S_Customer d on a.ReceiverId=d.Id 
                left join S_Material e on a.MaterialId=e.Id;";
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            return dt;
        }

        public List<ImportResult> ImportCard(List<BPlanCard> lstCard, ImportMode mode, ICarService carService, ICustomerService customerService, IMaterialService materialService) 
        {
            List<ImportResult> lstResult = new List<ImportResult>();
            SCustomer customer = null;
            SMaterial material = null;
            bool isAdded = false;
            if (lstCard == null || lstCard.Count == 0)
                return lstResult;
            if (mode == ImportMode.New) 
            {
                List<string> lstSql = new List<string>();
                lstSql.Add(string.Format(@"delete from B_CardPreset"));
                lstSql.Add(string.Format(@"delete from S_CardViewDtl"));
                lstSql.Add(string.Format(@"delete from B_PlanCard"));
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sqliteDb.ExecuteNonQuery(lstSql);
                }
                else
                {
                    service.ExecuteNonQuery(lstSql);
                }
            }
            foreach (BPlanCard card in lstCard) 
            {
                BPlanCard cardNew = null;
                BPlanCard find = GetByNo(card.CardNo);
                if (find != null)
                {
                    cardNew = find;
                    cardNew.UpdateTime = DateTime.Now;
                }
                else 
                {
                    cardNew = card;
                    cardNew.CreateTime = DateTime.Now;
                    cardNew.UpdateTime = DateTime.Now;
                }
                if (!string.IsNullOrEmpty(card.CarNo)) 
                {
                    SCar car = carService.GetByCarNo(card.CarNo);
                    if (car == null) 
                    {
                        car = carService.Add(card.CarNo);
                    }
                    if (car != null) 
                    {
                        cardNew.CarId = car.Id;
                    }
                }
                if (!string.IsNullOrEmpty(card.CustomerName)) 
                {
                    customer = customerService.GetCustomerByName(CustomerType.Customer, card.CustomerName);
                    if (customer == null) 
                    {
                        customer = customerService.AddCustomer(CustomerType.Customer, card.CustomerName);
                    }
                    if (customer != null) 
                    {
                        cardNew.CustomerId = customer.Id;
                    }
                }
                if (!string.IsNullOrEmpty(card.DeliveryName))
                {
                    customer = customerService.GetCustomerByName(CustomerType.Delivery, card.DeliveryName);
                    if (customer == null)
                    {
                        customer = customerService.AddCustomer(CustomerType.Delivery, card.DeliveryName);
                    }
                    if (customer != null)
                    {
                        cardNew.DeliveryId = customer.Id;
                    }
                }
                if (!string.IsNullOrEmpty(card.ReceiverName))
                {
                    customer = customerService.GetCustomerByName(CustomerType.Receiver, card.ReceiverName);
                    if (customer == null)
                    {
                        customer = customerService.AddCustomer(CustomerType.Receiver, card.ReceiverName);
                    }
                    if (customer != null)
                    {
                        cardNew.ReceiverId = customer.Id;
                    }
                }
                if (!string.IsNullOrEmpty(card.MaterialName)) 
                {
                    material = materialService.GetMaterialByName(card.MaterialName);
                    if (material != null) 
                    {
                        cardNew.MaterialId = material.Id;
                    }
                }
                isAdded = Save(cardNew);
                if (isAdded)
                    lstResult.Add(new ImportResult() { Success = true });
                else
                    lstResult.Add(new ImportResult() { Success = false });
            }
            return lstResult;
        }

        public BPlanCard GetByCarNo(string carNo) 
        {
            string sql;
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format("select * from B_PlanCard where CarNo='{0}' order by CreateTime desc limit 0,1", carNo);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format("select top 1 * from B_PlanCard where CarNo='{0}' order by CreateTime desc", carNo);
                dt = service.GetDataTable(sql);
            }
            BPlanCard card = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                card = TableHelper.RowToEntity<BPlanCard>(dt.Rows[0]);
            }
            return card;
        }

        public BPlanCard GetByCardId(string cardId)
        {
            string sql;
            sql = string.Format("select * from B_PlanCard where Id='{0}'", cardId);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            BPlanCard card = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                card = TableHelper.RowToEntity<BPlanCard>(dt.Rows[0]);
            }
            return card;
        }

        public BPlanCard GetByNo(string cardNo)
        {
            string sql;
            sql = string.Format("select * from B_PlanCard where CardNo='{0}'", cardNo);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            BPlanCard card = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                card = TableHelper.RowToEntity<BPlanCard>(dt.Rows[0]);
            }
            return card;
        }

        public QPlanCard Get(string cardId)
        {
            string sql;
            sql = string.Format(@"select a.*,b.CustomerName,d.MaterialName,e.CustomerName as DeliveryName,f.CustomerName as ReceiverName
                       from B_PlanCard a left join S_Customer b on a.CustomerId=b.Id
                       left join S_Material d on a.MaterialId=d.Id 
                       left join S_Customer e on a.DeliveryId=e.Id 
                       left join S_Customer f on a.ReceiverId=f.Id where a.CardId='{0}'", cardId.Trim());
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            QPlanCard card = null;
            if (dt != null && dt.Rows.Count > 0) 
            {
                card = TableHelper.RowToEntity<QPlanCard>(dt.Rows[0]);
            }
            return card;
        }

        public QPlanCard GetWithCardNo(string cardNo) 
        {
            string sql;
            sql = string.Format(@"select a.*,b.[CustomerName],d.[MaterialName],e.[CustomerName] as DeliveryName,f.[CustomerName] as ReceiverName
                       from B_PlanCard a left join S_Customer b on a.[CustomerId]=b.[Id] 
                       left join S_Material d on a.[MaterialId]=d.[Id] 
                       left join S_Customer e on a.[DeliveryId]=e.[Id] 
                       left join S_Customer f on a.[ReceiverId]=f.[Id] where a.[CardNo]='{0}'", cardNo.Trim());
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            QPlanCard card = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                card = TableHelper.RowToEntity<QPlanCard>(dt.Rows[0]);
            }
            return card;
        }

        public QPlanCard GetByPlan(string planId)
        {
            string sql;
            sql = string.Format(@"select a.*,b.[CustomerName],d.[MaterialName] 
                       from B_PlanCard a left join S_Customer b on a.[CustomerId]=b.[Id]               
                       left join S_Material d on a.[MaterialId]=d.[Id] where a.[PlanId]='{0}'", planId);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            QPlanCard card = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                card = TableHelper.RowToEntity<QPlanCard>(dt.Rows[0]);
            }
            return card;
        }

        public List<SWeightViewDtl> GetInitedWVDetailList(string viewId) 
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string sql;
            sql = string.Format(@"select a.* from S_WeightViewDtl a where a.ViewId='{0}'",viewId);
            //Logger.Info("GetInitedWVDetailList-SQL:"+sql);
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
                lstDetail = TableHelper.TableToList<SWeightViewDtl>(dt);
            }
            return lstDetail;
        }

        public SCardViewDtl GetCardDetail(string viewId, string detailId)
        {
            SCardViewDtl detail = null;
            string sql;
            sql = string.Format(@"select a.* from S_CardViewDtl a where a.ViewId='{0}' and DetailId='{1}'", viewId, detailId);
            //Logger.Info("GetInitedWVDetailList-SQL:"+sql);
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
                detail = TableHelper.RowToEntity<SCardViewDtl>(dt.Rows[0]);
            }
            return detail;
        }

        public List<BCardPreset> GetPresetList() 
        {
            List<BCardPreset> lstCard = new List<BCardPreset>();
            string sql;
            sql = "select a.* from B_CardPreset a";
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
                lstCard = TableHelper.TableToList<BCardPreset>(dt);
            }
            return lstCard;
        }

        public List<BCardPreset> GetPresetList(string cardId) 
        {
            List<BCardPreset> lstCard = new List<BCardPreset>();
            string sql;
            sql = string.Format(@"select a.* from B_CardPreset a where a.CardId='{0}'",cardId);
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
                lstCard = TableHelper.TableToList<BCardPreset>(dt);
            }
            return lstCard;
        }

        public List<QPlanCard> GetList()
        {
            string sql;
            sql = string.Format(@"select a.*,b.CustomerName,d.MaterialName,e.CustomerName as DeliveryName,f.CustomerName as ReceiverName
                       from B_PlanCard a left join S_Customer b on a.CustomerId=b.Id 
                       left join S_Customer e on a.DeliveryId=e.Id 
                       left join S_Customer f on a.ReceiverId=f.Id    
                       left join S_Material d on a.MaterialId=d.Id");
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                dt = service.GetDataTable(sql);
            }
            List<QPlanCard> lstCard = new List<QPlanCard>();
            if (dt != null && dt.Rows.Count > 0)
            {
                lstCard = TableHelper.TableToList<QPlanCard>(dt);
            }
            return lstCard;
        }

        public PageList<QPlanCard> GetList(PlanCardQuery query)
        {
            PageList<QPlanCard> results = new PageList<QPlanCard>();
            string condition = QueryUtil.GetPlanCardCondition(query);
            string sql = string.Format("select count(1) from B_PlanCard a where 1=1 {0}", condition);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            int pageNo = query.PageIndex;
            int pageSize = query.PageSize;
            int startPageIndex = pageNo * pageSize;
            int endPageIndex = (pageNo + 1) * pageSize;
            if (dt != null && dt.Rows.Count > 0)
            {
                results.Total = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select a.*,b.CustomerName,d.MaterialName,e.CustomerName as DeliveryName,f.CustomerName as ReceiverName from(
                                              select a.* from B_PlanCard a where 1=1 {0} order by CreateTime desc limit {1},{2})a 
                                              left join S_Customer b on a.CustomerId=b.Id 
                                               left join S_Customer e on a.DeliveryId=e.Id 
                                               left join S_Customer f on a.ReceiverId=f.Id    
                                               left join S_Material d on a.MaterialId=d.Id", condition, startPageIndex, pageSize);
                results.Models = sqliteDb.GetObjectList<QPlanCard>(sql);
            }
            else
            {
                sql = string.Format(@"select a.*,b.CustomerName,d.MaterialName,e.CustomerName as DeliveryName,f.CustomerName as ReceiverName from( select a.* from( 
                                              select row_number() over(order by CreateTime desc) as RN,a.* from B_PlanCard a where 1=1 {0})a  where RN>{1} and RN<={2})a 
                                              left join S_Customer b on a.CustomerId=b.Id 
                                               left join S_Customer e on a.DeliveryId=e.Id 
                                               left join S_Customer f on a.ReceiverId=f.Id    
                                               left join S_Material d on a.MaterialId=d.Id", condition, startPageIndex, endPageIndex);
                results.Models = service.GetObjectList<QPlanCard>(sql);
            }
            
            return results;
        }

        public DataTable GetCardList() 
        {
            string viewId=CurrentClient.Instance.ViewId;
            string sql;
            sql = string.Format(@"select a.Id as '编号',a.CardNo as '卡号',c.CarNo as '车牌号',a.PlanNo as '计划号',
                     d.MaterialName as '货物名称',b.[CustomerName] as '客户名称',
                       e.[CustomerName] as '发货单位',f.[CustomerName] as '收货单位',a.DriverName as '司机',
                        a.CreateTime as '创建时间',a.Remark as '备注'
                       from B_PlanCard a left join S_Customer b on a.[CustomerId]=b.[Id] 
                       left join S_Customer e on a.[DeliveryId]=e.[Id] 
                       left join S_Customer f on a.[ReceiverId]=f.[Id] 
                       left join S_Car c on a.[CarId]=c.[Id]                       
                       left join S_Material d on a.[MaterialId]=d.[Id]");
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            List<QCardViewDtl> lstCardView=GetDetailList(viewId);
            if (dt != null && dt.Rows.Count > 0 && lstCardView.Count > 0)
            {
                foreach (QCardViewDtl dtl in lstCardView)
                {
                    if (!dt.Columns.Contains(dtl.FieldName))
                    {
                        dt.Columns.Add(dtl.FieldName);
                    }
                }

                DataTable dtCard;
                sql = "SELECT a.CardId,a.ControlId,a.PresetValue,b.FieldName from B_CardPreset a LEFT JOIN S_WeightViewDtl b ON a.ControlId = b.ControlId";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    dtCard = sqliteDb.ExecuteDataTable(sql);
                }
                else
                {
                    dtCard = service.GetDataTable(sql);
                }
                if (dtCard != null && dtCard.Rows.Count > 0)
                {
                    DataRow[] drRows;
                    foreach (DataRow dr in dt.Rows) 
                    {
                        drRows = dtCard.Select(string.Format("[CardId]='{0}'", dr["编号"]));
                        if (drRows != null && drRows.Length > 0) 
                        {
                            foreach (DataRow r in drRows) 
                            {
                                InitCardRow(r, dr);
                            }
                        }
                    }
                }
                SetCardTableColumn(dt, lstCardView);
            }
            return dt;
        }

        private void SetCardTableColumn(DataTable dt, List<QCardViewDtl> lstCardView) 
        {
            foreach (DataColumn dc in dt.Columns)
            {
                QCardViewDtl dtl = lstCardView.Find(c => c.FieldName == dc.ColumnName);
                if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dt.Columns.Contains(dtl.ControlName))
                {
                    dc.ColumnName = dtl.ControlName;
                }
            }
        }

        private void InitCardRow(DataRow drSource, DataRow drTarget) 
        {
            string fieldName = drSource["FieldName"].ToObjectString();
            if (drTarget.Table.Columns.Contains(fieldName)) 
            {
                drTarget[fieldName] = drSource["PresetValue"];
            }
        }

        public List<QCardViewDtl> GetDetailList(string viewId) 
        {
            List<QCardViewDtl> lstDetail = new List<QCardViewDtl>();
            string sql;
            sql = string.Format(@"select a.*,b.ControlName,b.FullName,b.DecimalDigits,b.Caption,b.FieldName
                                         from S_CardViewDtl a inner join S_WeightViewDtl b on a.DetailId=b.Id
                                           where a.ViewId='{0}'",viewId);
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
                lstDetail = TableHelper.TableToList<QCardViewDtl>(dt);
            }
            return lstDetail;
        }

        public bool Save(BPlanCard card)
        {
            string sql;
            sql = SqliteSqlUtil.GetSaveSql<BPlanCard>(card, "B_PlanCard");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.Save<BPlanCard>(card, card.Id);
            }
        }

        public bool SaveDetail(SCardViewDtl detail) 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql;
                sql = SqliteSqlUtil.GetSaveSql<SCardViewDtl>(detail, "S_CardViewDtl");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.Save<SCardViewDtl>(detail, detail.DetailId);
            }
        }

        public void SavePreset(string cardId, List<BCardPreset> lst)
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                List<string> lstSql = new List<string>();
                lstSql.Add(string.Format("delete from B_CardPreset where CardId='{0}'", cardId));
                if (lst != null && lst.Count > 0)
                {
                    foreach (BCardPreset preset in lst)
                    {
                        lstSql.Add(SqliteSqlUtil.GetSaveSql<BCardPreset>(preset, "B_CardPreset"));
                    }
                }
                sqliteDb.ExecuteNonQuery(lstSql);
            }
            else
            {
                string sql;
                sql = string.Format("delete from B_CardPreset where CardId='{0}'", cardId);
                service.ExecuteNonQuery(sql);
                if (lst != null && lst.Count > 0)
                {
                    foreach (BCardPreset preset in lst)
                    {
                        service.Save<BCardPreset>(preset, preset.Id);
                    }
                }
            }
        }

        #endregion
    }
}
