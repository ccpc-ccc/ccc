using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility;
using YF.Data.NHProvider;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Metadata.Query;
using YF.Utility.Log;
using YF.MWS.Metadata.Dto;
using YF.Utility.Configuration;
using YF.Utility.Net;
using YF.Utility.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using System.Runtime.InteropServices;

namespace YF.MWS.SQliteService
{
    public class PayService : IPayService
    {
        private SqliteDb sqliteDb = new SqliteDb();
        private IService service = null;
        private IMasterService masterService = new MasterService();
        private IWebMessageService webMessageService = new WebMessageService();

        #region private methods

        private void RefreshPayRecord(string customerId)
        {
            List<BPay> records = new List<BPay>();
            List<string> sqls = new List<string>();
            string sql = string.Format(@"select Id,PayAmount,BalanceAmount,PayBizType,RefId,PayType from B_Pay 
                                                      where CustomerId='{0}' and RowState!={1} order by PayTime asc", customerId, (int)RowState.Delete);
            decimal balanceAmount = 0;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                records = sqliteDb.GetObjectList<BPay>(sql);
            }
            else
            {
                records = service.GetObjectList<BPay>(sql);
            }
            if (records != null && records.Count > 0)
            {
                foreach (BPay pay in records)
                {
                    PayBizType payBizType = pay.PayBizType.ToEnum<PayBizType>();
                    WeightPayType payType = pay.PayType.ToEnum<WeightPayType>();
                    if (payBizType == PayBizType.Weight || payBizType == PayBizType.Deducte)
                    {
                        if (payBizType == PayBizType.Deducte)
                            balanceAmount -= pay.PayAmount;
                        if (payBizType == PayBizType.Weight)
                        {
                            if (payType == WeightPayType.Balance)
                                balanceAmount -= pay.PayAmount;
                        }
                        sql = string.Format("update B_Pay set BalanceAmount={0} where Id='{1}'", balanceAmount, pay.Id);
                        sqls.Add(sql);
                        if (!string.IsNullOrEmpty(pay.RefId) && pay.PayBizType == PayBizType.Weight.ToString())
                        {
                            sql = string.Format("update B_Weight set CustomerBalance={0} where Id='{1}'", balanceAmount, pay.RefId);
                            sqls.Add(sql);
                        }
                    }
                    else
                    {
                        balanceAmount += pay.PayAmount;
                        sql = string.Format("update B_Pay set BalanceAmount={0} where Id='{1}'", balanceAmount, pay.Id);
                        sqls.Add(sql);
                    }
                }
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sqliteDb.ExecuteNonQuery(sqls);
                }
                else
                {
                    service.BatchExecuteNonQuery(sqls);
                }
            }
        }

        private void SendMessage(BPay pay)
        {
            PayBizType bizType = pay.PayBizType.ToEnum<PayBizType>();
            SCustomer customer = masterService.GetCustomer(pay.CustomerId);
            if (customer != null)
            {
                if (bizType == PayBizType.Recharge)
                {
                    RechargeResultNotice notice = new RechargeResultNotice();
                    notice.BalanceAmount = customer.BalanceAmount;
                    notice.CustomerName = customer.CustomerName;
                    notice.RechargeAmount = pay.PayAmount;
                    notice.RechargeTime = pay.CreateTime;
                    notice.CustomerId = pay.CustomerId;
                    webMessageService.SendRechargeResultNotice(notice);
                }
                else
                {
                    ConsumeResultNotice notice = new ConsumeResultNotice();
                    notice.BalanceAmount = customer.BalanceAmount;
                    notice.CustomerName = customer.CustomerName;
                    notice.ConsumeAmount = pay.PayAmount;
                    notice.ConsumeTime = pay.CreateTime;
                    notice.CustomerId = pay.CustomerId;
                    webMessageService.SendConsumeResultNotice(notice);
                }
            }
        }

        private void UpdateCustomerAmount(string customerId)
        {
            DataTable dtSource;
            string sql;
            decimal rechargeAmount = 0;
            decimal payAmount = 0;
            decimal balanceAmount = 0;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"SELECT a.Recharge,b.PayAmount,a.Recharge-b.PayAmount as Amount  FROM(SELECT ifnull(sum(PayAmount),0) as Recharge from B_Pay 
                                        WHERE CustomerId='{0}' AND PayBizType!='{2}' AND PayBizType!='{3}' and RowState!='{1}') a,
                                         (SELECT ifnull(sum(PayAmount),0) as PayAmount from B_Pay WHERE CustomerId='{0}' AND  (PayBizType='{2}' or PayBizType='{3}')  and RowState!='{1}') b;", 
                                         customerId, (int)RowState.Delete, PayBizType.Weight.ToString(), PayBizType.Deducte.ToString());
                dtSource = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                sql = string.Format(@"SELECT a.RechargeAmount,b.PayAmount,a.RechargeAmount-b.PayAmount as BalanceAmount  FROM(SELECT isnull(sum(PayAmount),0) as RechargeAmount 
                                               from B_Pay WHERE CustomerId='{0}' AND PayBizType!='{2}' AND PayBizType!='{3}' and RowState!='{1}') a,
                                              (SELECT isnull(sum(PayAmount),0) as PayAmount from B_Pay WHERE CustomerId='{0}' AND  (PayBizType='{2}' or PayBizType='{3}')  and RowState!='{1}') b ;", 
                                              customerId, (int)RowState.Delete, PayBizType.Weight.ToString(), PayBizType.Deducte.ToString());
                dtSource = service.GetDataTable(sql);
            }
            rechargeAmount = dtSource.Rows[0][0].ToDecimal();
            payAmount = dtSource.Rows[0][1].ToDecimal();
            balanceAmount = dtSource.Rows[0][2].ToDecimal();
            sql = string.Format("UPDATE S_Customer SET RechargeAmount='{0}',PayAmount='{1}',BalanceAmount='{2}' WHERE Id='{3}'",
                                               rechargeAmount, payAmount, balanceAmount, customerId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sqliteDb.ExecuteNonQuery(sql);
            }
            else
            {
                service.ExecuteNonQuery(sql);
            }
        }

        #endregion

        public PayService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }

        public bool AddPay(BPay pay)
        {
            string sql;
            bool isSaved = false;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<BPay>(pay, "B_Pay");
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isSaved = service.Save<BPay>(pay, pay.Id);
            }
            if (isSaved)
            {
                RefreshPayRecord(pay.CustomerId);
                UpdateCustomerAmount(pay.CustomerId);
                SendMessage(pay);
            }
            return isSaved;
        }

        public PayJumpPageModel PreparePay(BPay pay) 
        {
            PayJumpPageModel model = null;
            if (string.IsNullOrEmpty(pay.CarNo))
                pay.CarNo = "无车牌";
            string url = string.Format(@"{0}/api/sf/pay/GetPreparePay?companyId={1}&weightId={2}&payNo={3}&payType={4}&payBizType={5}&payAmount={6}&payId={7}&remark={8}&drawerId={9}&drawerName={10}&materialId={11}&customerId={12}&carNo={13}", 
                                                     AppSetting.GetValue("EcsServer"), pay.CompanyId,pay.RefId,pay.PayNo,pay.PayType,pay.PayBizType,
                                                     pay.PayAmount,pay.Id,pay.Remark,pay.DrawerId,pay.DrawerName,pay.MaterialId,pay.CustomerId,pay.CarNo);
            model = WebApiUtil.Get<PayJumpPageModel>(url);
            return model;
        }

        public int GetPayState(string weightId) 
        {
            int payState = -1;
            string url = string.Format("{0}/api/sf/pay/paystate?weightId={1}", AppSetting.GetValue("EcsServer"),weightId);
            ResultMessage message = null;
            string result = HttpClient.DoGetJson(url);
            if (!string.IsNullOrEmpty(result)) 
            {
                message = result.JsonDeserialize<ResultMessage>();
            }
            if (message != null && message.Data != null) 
            {
                payState = message.Data.ToInt();
            }
            return payState;
        }

        public bool DeleteCharge(string id)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Charge where Id = '{0}'", id);
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

        public bool DeletePay(string payId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from B_Pay where Id='{0}'", payId);
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

        public bool DeletePay(List<string> payIds)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from B_Pay where Id in({0})", SqlConditionUtil.GetArrayIn(payIds));
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

        public BPay GetPay(string payId)
        {
            BPay pay = null;
            string sql;
            sql = string.Format("select * from B_Pay where Id='{0}'", payId);
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
                pay = TableHelper.RowToEntity<BPay>(dt.Rows[0]);
            }
            return pay;
        }

        public BPay GetPayWithRefId(string refId) 
        {
            BPay pay = null;
            string sql;
            sql = string.Format("select * from B_Pay where RefId='{0}'", refId);
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
                pay = TableHelper.RowToEntity<BPay>(dt.Rows[0]);
            }
            return pay;
        }

        public TPageResult GetChargeList(PageQueryCondition qc)
        {
            TPageResult result = new TPageResult();
            List<QPay> lstCfg = new List<QPay>();
            int pageNo = qc.PageIndex;
            int pageSize = qc.PageSize;
            string condition = qc.ExtendCondition;
            int startPageIndex = pageNo * pageSize;
            int endPageIndex = (pageNo + 1) * pageSize;
            int rowsCount = 0;
            string sql;
            DataTable dt;
            try
            {
                sql = string.Format(@"select count(1) from B_Pay a where 1=1 {0}", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                else
                {
                    dt = service.GetDataTable(sql);
                }
                rowsCount = dt.Rows[0][0].ToInt();
                result.PageNo = pageNo;
                result.PageSize = pageSize;
                result.Count = rowsCount;
                
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sql = string.Format(@"select  b.WeightNo,a.Id, PayNo, PayBizType, a.CustomerId, a.CustomerName, a.PayAmount, a.RefId, a.PayTime,
                                                 c.RechargeAmount,c.PayAmount as PayTotal,a.BalanceAmount
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where  1=1 {2} order by a.PayTime desc limit {0},{1}",
                                                 startPageIndex, pageSize, condition);
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                else
                {
                    sql = string.Format(@"select * from(select row_number() over(order by a.PayTime desc) RN, b.WeightNo,
                                                a.Id, PayNo, PayBizType, a.CustomerId, a.CustomerName, a.PayAmount, a.RefId, a.PayTime,
                                                 c.RechargeAmount,c.PayAmount as PayTotal,a.BalanceAmount
                                                 from B_Pay a left join B_Weight b on a.RefId=b.Id  
                                                 left join S_Customer c on a.CustomerId=c.Id where  1=1 {2}) a where RN>{0} and RN<={1}",
                                                startPageIndex, endPageIndex, condition);
                    dt = service.GetDataTable(sql);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    lstCfg = TableHelper.TableToList<QPay>(dt);
                }

                result.Code = (int)ResultCode.Success;
                result.Rows = lstCfg;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                result.Code = (int)ResultCode.Error;
            }
            return result;
        }

        public TPageResult GetPayList(PageQueryCondition qc)
        {
            TPageResult result = new TPageResult();
            List<QPay> lstCfg = new List<QPay>();
            int pageNo = qc.PageIndex;
            int pageSize = qc.PageSize;
            string condition = qc.ExtendCondition;
            int startPageIndex = pageNo * pageSize;
            int endPageIndex = (pageNo + 1) * pageSize;
            int rowsCount = 0;
            string sql;
            DataTable dt;
            try
            {
                if(pageSize > 0) {
                sql = string.Format(@"select count(1) from B_Pay a where 1=1 {0}", condition);
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                else
                {
                    dt = service.GetDataTable(sql);
                }
                rowsCount = dt.Rows[0][0].ToInt();
                result.PageNo = pageNo;
                result.PageSize = pageSize;
                result.Count = rowsCount;

                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sql = string.Format(@"select a.Id, a.PayNo, a.PayBizType, a.CustomerId, a.CustomerName, a.PayAmount, a.RefId, a.PayTime,
                                                c.RechargeAmount,c.PayAmount as PayTotal,a.BalanceAmount,a.DrawerName,a.PayType
                                                 from B_Pay a left join S_Customer c on a.CustomerId=c.Id  where  1=1 {2} order by a.PayTime desc limit {0},{1}",
                               startPageIndex, pageSize, condition);
                    dt = sqliteDb.ExecuteDataTable(sql);
                }
                else
                {
                    sql = string.Format(@"select * from(select row_number() over(order by a.PayTime desc) RN, 
                                                a.Id, a.PayNo, a.PayBizType, a.CustomerId, a.CustomerName, a.PayAmount, a.RefId, a.PayTime,
                                                c.RechargeAmount,c.PayAmount as PayTotal,a.BalanceAmount,a.DrawerName,a.PayType
                                                 from B_Pay a left join S_Customer c on a.CustomerId=c.Id  where  1=1 {2}) a where RN>{0} and RN<={1}",
                                startPageIndex, endPageIndex, condition);

                    dt = service.GetDataTable(sql);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    lstCfg = TableHelper.TableToList<QPay>(dt);
                }

                } else {
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                        sql = string.Format(@"select a.Id, a.PayNo, a.PayBizType, a.CustomerId, a.CustomerName, a.PayAmount, a.RefId, a.PayTime,
                                                c.RechargeAmount,c.PayAmount as PayTotal,a.BalanceAmount,a.DrawerName,a.PayType
                                                 from B_Pay a left join S_Customer c on a.CustomerId=c.Id  where  1=1 {0} order by a.PayTime desc }",condition);
                        dt = sqliteDb.ExecuteDataTable(sql);
                    } else {
                        sql = string.Format(@"select a.Id, a.PayNo, a.PayBizType, a.CustomerId, a.CustomerName, a.PayAmount, a.RefId, a.PayTime,
                                                c.RechargeAmount,c.PayAmount as PayTotal,a.BalanceAmount,a.DrawerName,a.PayType
                                                 from B_Pay a left join S_Customer c on a.CustomerId=c.Id  where  1=1 {0}",condition);

                        dt = service.GetDataTable(sql);
                    }
                    if (dt != null && dt.Rows.Count > 0) {
                        lstCfg = TableHelper.TableToList<QPay>(dt);
                    }
                }
                    result.Code = (int)ResultCode.Success;
                    result.Rows = lstCfg;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                result.Code = (int)ResultCode.Error;
            }
            return result;
        }

        public decimal GetBalanceAmount(string customerId)
        {
            decimal amount = 0;
            string sql;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"SELECT a.BalanceAmount from S_Customer a  WHERE Id='{0}' ", customerId);
                DataTable dt = sqliteDb.ExecuteDataTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    amount = dt.Rows[0][0].ToDecimal();
                }
            }
            else
            {
                sql = string.Format(@"SELECT a.BalanceAmount from S_Customer a  WHERE Id='{0}' ", customerId);
                DataTable dt = service.GetDataTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    amount = dt.Rows[0][0].ToDecimal();
                }
            }
            return amount;
        }

        public SCharge GetCharge(string id)
        {
            string sql;
            sql = string.Format("select * from S_Charge where Id='{0}' ", id);
            DataTable dt;
            SCharge price = null;
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
                price = TableHelper.RowToEntity<SCharge>(dt.Rows[0]);
            }
            return price;
        }

        public List<SCharge> GetChargeList()
        {
            string sql;
            sql = "select * from S_Charge";
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            return TableHelper.TableToList<SCharge>(dt);
        }

        public void RefreshCustomerBalance(string customerId)
        {
            RefreshPayRecord(customerId);
            UpdateCustomerAmount(customerId);
        }
        public bool save(BPay pay, List<BPayDetail> payDetails) {
            List<string> sqls = new List<string>();
            try {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                string sql = SqliteSqlUtil.GetSaveSql<BPay>(pay, "B_Pay");
                sqls.Add(sql);
                foreach(BPayDetail detail in payDetails) {
                    sql = SqliteSqlUtil.GetSaveSql<BPayDetail>(detail, "B_PayDetail");
                    sqls.Add(sql);
                sql = string.Format("update B_Weight set PayType='Settled' where Id='{0}'", detail.WeightId);
                    sqls.Add(sql);
                }
                sql = string.Format("update S_Customer set BalanceAmount=BalanceAmount-{0} where Id='{1}'", pay.PayAmount,pay.CustomerId);
                sqls.Add(sql);
                return sqliteDb.ExecuteNonQuery(sqls)>0;
            } else {
                string sql = QueryUtil.GetSaveSql<BPay>(pay, "B_Pay");
                sqls.Add(sql);
                foreach(BPayDetail detail in payDetails) {
                    sql = QueryUtil.GetSaveSql<BPayDetail>(detail, "B_PayDetail");
                    sqls.Add(sql);
                sql = string.Format("update B_Weight set PayType='Settled' where Id='{0}'", detail.WeightId);
                    sqls.Add(sql);
                }
                sql = string.Format("update S_Customer set BalanceAmount=BalanceAmount-{0} where Id='{1}'", pay.PayAmount,pay.CustomerId);
                sqls.Add(sql);
                    return service.BatchExecuteNonQuery(sqls);
            }
            }catch(Exception ex) {
                Logger.WriteException(ex);
                return false;
            }
        }

        public bool SaveChargeCfg(SCharge charge)
        {
            bool isSaved = false;
            string sql = string.Empty;
            if (string.IsNullOrEmpty(charge.Id))
            {
                charge.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = SqliteSqlUtil.GetSaveSql<SCharge>(charge, "S_Charge");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else
            {
                isSaved = service.Save<SCharge>(charge, charge.Id);
            }
            return isSaved;
        }

        public bool UpdatePay(BPay pay)
        {
            bool isUpdated = false;
            string sql = string.Format(@"update B_Pay set PayAmount={0},PayType={1},CustomerId='{2}',CustomerName='{3}',CarNo='{4}' where Id='{5}'",
                                                       pay.PayAmount, pay.PayType, pay.CustomerId, pay.CustomerName, pay.CarNo, pay.Id);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isUpdated = sqliteDb.ExecuteNonQuery(sql)>0;
            }
            else
            {
                isUpdated = service.ExecuteNonQuery(sql);
            }
            if (isUpdated)
            {
                RefreshCustomerBalance(pay.CustomerId);
            }
            return isUpdated;
        }

        public void UpdateSyncState(int syncState, string payId)
        {
            string sql;
            sql = string.Format(@"update B_Pay set SyncState={0} where Id='{1}' ", syncState, payId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sqliteDb.ExecuteNonQuery(sql);
            }
            else
            {
                service.ExecuteNonQuery(sql);
            }
        }

        public bool UpdateRowState(RowState rowState, string refId)
        {
            bool isUpdated = false;
            string sql = string.Format(@"update B_Pay set RowState={0} where RefId='{1}' ", (int)rowState, refId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isUpdated = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                isUpdated = service.ExecuteNonQuery(sql);
            }
            if (isUpdated)
            {
                BPay pay = GetPayWithRefId(refId);
                if (pay != null)
                {
                    RefreshPayRecord(pay.CustomerId);
                    UpdateCustomerAmount(pay.CustomerId);
                }
            }
            return isUpdated;
        }
        public DataTable GetDetail(string PayId) {
            string sql = string.Format("select * from B_PayDetail where PayId='{0}'",PayId);
            if(CurrentClient.Instance.DataBase==DataBaseType.Sqlite) {
                return sqliteDb.ExecuteDataTable(sql);
            } else {
                return service.GetDataTable(sql);
            }
        }
    }
}
