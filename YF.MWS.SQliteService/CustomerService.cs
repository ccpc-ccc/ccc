using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;
using YF.Utility.Data;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.Util;
using YF.Utility.Language;
using YF.Utility.Metadata;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.SQliteService
{
    public class CustomerService :BaseService, ICustomerService
    {
        private IMasterService masterService;


        public SCustomer AddCustomer(CustomerType type, string customerName)
        {
            SCustomer customer = new SCustomer();
            customer.PYCustomerName = PinYinUtil.GetInitial(customerName);
            customer.CustomerName = customerName;
            customer.CustomerCode = customer.PYCustomerName;
            customer.CustomerType = type.ToString();
            SaveCustomer(customer);
            return customer;
        }

        public bool Delete(string priceId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_CustomerPrice where Id='{0}'",priceId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                isDeleted = service.ExecuteNonQuery(sql);
            }
            else
            {
                isDeleted = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            return isDeleted;
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="codeId">编号</param>
        /// <returns></returns>
        public bool DeleteCustomer(string customerId)
        {
            string sql = string.Format(@"update S_Customer set RowState={0} where Id='{1}'", (int)RowState.Delete, customerId);
            return base.ExecuteSql(sql);
        }

        public bool DeleteCustomerPhysics(string customerId)
        {
            bool isDeleted = false;
            List<string> sqls = new List<string>();
            string sql = string.Format(@"delete from S_Customer where Id='{0}'", customerId);
            sqls.Add(sql);
            sql = string.Format(@"delete from B_Pay where CustomerId='{0}'", customerId);
            sqls.Add(sql);
            return base.ExecuteSql(sqls);
        }

        public SCustomerPrice Get(string priceId)
        {
            SCustomerPrice price = null;
            string sql = string.Format(@"select * from S_CustomerPrice where Id='{0}'", priceId);
            return getModel<SCustomerPrice>(sql);
        }
        public SCustomer GetCustomer(string Id)
        {
            string sql = string.Format(@"select * from S_Customer where Id='{0}'", Id);
            return getModel<SCustomer>(sql);
        }

        public List<SCustomer> GetAllCustomerList()
        {
            string sql = string.Format("select * from S_Customer");
            return base.getList<SCustomer>(sql);
        }

        public List<SCustomer> GetCustomerList()
        {
            string sql = string.Format("select * from S_Customer where RowState!={0}", (int)RowState.Delete);
            return base.getList<SCustomer>(sql);
        }

        public SCustomer GetCustomerByName(CustomerType customerType, string customerName)
        {
            SCustomer customer = null;
            string sql= string.Format("select * from S_Customer where CustomerType='{0}' and CustomerName='{1}'", 
                                              customerType, customerName);
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format("select * from S_Customer where CustomerType='{0}' and CustomerName=N'{1}'",
                                              customerType, customerName);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                customer = TableHelper.RowToEntity<SCustomer>(dt.Rows[0]);
            }
            return customer;
        }

        public SCustomerPrice Get(string customerId, string materialId)
        {
            string sql = string.Format(@"select * from S_CustomerPrice where CustomerId='{0}' and MaterialId='{1}' ", customerId, materialId);
            return base.getModel<SCustomerPrice>(sql);
        }

        public int GetWeightCount(CustomerType type, string customerId) 
        {
            int count = 0;
            object scalar = null;
            string sql = string.Format("select count(1) from B_Weight where CustomerId='{0}'",customerId);
            if (type == CustomerType.Delivery) 
            {
                sql = string.Format("select count(1) from B_Weight where DeliveryId='{0}'", customerId);
            }
            if (type == CustomerType.Receiver)
            {
                sql = string.Format("select count(1) from B_Weight where ReceiverId='{0}'", customerId);
            }
            if (type == CustomerType.Supplier)
            {
                sql = string.Format("select count(1) from B_Weight where SupplierId='{0}'", customerId);
            }
            if (type == CustomerType.Transfer)
            {
                sql = string.Format("select count(1) from B_Weight where TransferId='{0}'", customerId);
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                scalar = sqliteDb.ExecuteScalar(sql);
            }
            else 
            {
                scalar = service.GetScalar(sql);
            }
            if (scalar != null)
                count = Convert.ToInt32(scalar);
            return count;
        }

        public int GetRechargeCount(string customerId)
        {
            int count = 0;
            object scalar = null;
            string sql = string.Format("select count(1) from B_Pay where CustomerId='{0}' and PayBizType='{1}'", 
                                                       customerId,PayBizType.Recharge.ToString());
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                scalar = sqliteDb.ExecuteScalar(sql);
            }
            else
            {
                scalar = service.GetScalar(sql);
            }
            if (scalar != null)
                count = Convert.ToInt32(scalar);
            return count;
        }

        public TPageResult GetList(PageQueryCondition qc)
        {
            TPageResult result = new TPageResult();
            List<SCustomerPrice> lstPrice = new List<SCustomerPrice>();
            int pageNo = qc.PageIndex;
            int pageSize = qc.PageSize;
            string condition = qc.ExtendCondition;
            if (pageSize <= 0)
            {
                pageSize = 20;
            }
            int startPageIndex = pageNo * pageSize;
            int endPageIndex = (pageNo + 1) * pageSize;
            int rowsCount = 0;
            string sql;
            DataTable dt;
            try
            {
                sql = string.Format(@"select count(1) from S_CustomerPrice a where 1=1 {0}", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    dt = service.GetDataTable(sql);
                }
                else 
                {
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                rowsCount = dt.Rows[0][0].ToInt();
                result.PageNo = pageNo;
                result.PageSize = pageSize;
                result.Count = rowsCount;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    sql = string.Format(@"select * from(select row_number() over(order by CreateTime asc) RN, a.* from S_CustomerPrice a 
                                                  where  1=1 {2}) a where RN>{0} and RN<={1}",
                                                    startPageIndex, endPageIndex, condition);
                    dt = service.GetDataTable(sql);
                }
                else
                {
                    sql = string.Format(@"select * from S_CustomerPrice a where 1=1 {0} limit {1},{2}", condition, startPageIndex, pageSize);
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    lstPrice = TableHelper.TableToList<SCustomerPrice>(dt);
                }
                result.Code = (int)ResultCode.Success;
                result.Rows = lstPrice;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                result.Code = (int)ResultCode.Error;
            }
            return result;
        }

        public void RefreshCustomerId(string oldCustomerId, string newCustomerId) 
        {
            List<string> lstSql = new List<string>();
            string sql;
            sql = string.Format("update S_Customer set Id='{0}' where Id='{1}'",newCustomerId,oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_Pay set CustomerId='{0}' where CustomerId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_Weight set CustomerId='{0}' where CustomerId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_Weight set SupplierId='{0}' where SupplierId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_Weight set DeliveryId='{0}' where DeliveryId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_Weight set ReceiverId='{0}' where ReceiverId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_PlanCard set CustomerId='{0}' where CustomerId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_PlanCard set DeliveryId='{0}' where DeliveryId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            sql = string.Format("update B_PlanCard set ReceiverId='{0}' where ReceiverId='{1}'", newCustomerId, oldCustomerId);
            lstSql.Add(sql);
            base.ExecuteSql(lstSql);
        }

        public bool Save(SCustomerPrice price)
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(price.Id))
            {
                price.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                isSaved = service.Save<SCustomerPrice>(price, price.Id);
            }
            else
            {
                string sql = SqliteSqlUtil.GetSaveSql<SCustomerPrice>(price, "S_CustomerPrice");
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }

            return isSaved;
        }

        public bool SaveCustomer(SCustomer customer)
        {
            bool isSaved = false;
            customer.SyncState = 0;
            if (string.IsNullOrEmpty(customer.Id))
            {
                customer.Id = YF.MWS.Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = string.Empty;
                sql = SqliteSqlUtil.GetSaveSql<SCustomer>(customer, "S_Customer");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else
            {
                isSaved = service.Save<SCustomer>(customer, customer.Id);
            }
            return isSaved;
        }

        public bool UpdateState(string customerId, RowState state) 
        {
            string sql = string.Format(@"update S_Customer set RowState={0} where Id='{1}'",
                                                            (int)state,customerId);
            return base.ExecuteSql(sql);
        }
        /*public VPage<SCustomer> GetCustomers() {
            string sql = "select * from S_Customer";
            string sql = string.Format(@"select {4},
                                 k.ClientName,l.ClientName as TareClientName,
                                 f.CustomerName as ReceiverId,g.CustomerName as SupplierId,h.CustomerName as TransferId,
                                b.MaterialName as MaterialId,c.WarehName as WarehId, d.CustomerName as CustomerId,e.CustomerName as DeliveryId,j.CustomerName as ManufacturerId,
                                m.WeightTime  as TareTime,m.WeighterName as TareWeighterName,
                                n.WeightTime  as GrossTime,n.WeighterName as GrossWeighterName
                                from(select a.* from B_Weight a  where 1=1 {0})a 
                                left join S_Material b on a.MaterialId=b.MaterialId 
                                 left join S_Wareh c on a.WarehId=c.WarehId
                                 left join S_Customer d on a.CustomerId=d.CustomerId 
                                 left join S_Customer e on a.DeliveryId=e.CustomerId  
                                 left join S_Customer f on a.ReceiverId=f.CustomerId 
                                 left join S_Customer g on a.SupplierId=g.CustomerId 
                                 left join S_Customer h on a.TransferId=h.CustomerId 
                                 left join S_Customer j on a.ManufacturerId=j.CustomerId 
                                 left join S_Client k on a.MachineCode=k.MachineCode 
                                 left join S_Client l on a.TareMachineCode=l.MachineCode 
                                 left join B_WeightDetail m on a.WeightId=m.WeightId and m.WeightType={1} 
                                 left join B_WeightDetail n on a.WeightId=n.WeightId and n.WeightType={2} 
                                 where 1=1 {3} order by a.FinishTime desc", condition, (int)WeightType.Tare, (int)WeightType.Gross, payCondition, WeightFiles);
        }*/
    }
}
