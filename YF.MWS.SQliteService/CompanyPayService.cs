using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility.Data;
using System.Data;
using System.Transactions;
using YF.MWS.Metadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Util;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using System.Data.SqlClient;
using YF.Utility;
using YF.Data.NHProvider.Metadata;
using System.IO;
using YF.MWS.Metadata.Cfg;
using NHibernate.Driver;
using System.Web.Management;

namespace YF.MWS.SQliteService
{
    public class CompanyPayService : BaseService, ICompanyPayService {
        #region IMasterService 成员

        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        public bool Delete(SCompanyPay model)
        {
            List<string> sqls= new List<string>();
            string sql = string.Format(@"delete from S_CompanyPay where Id = '{0}'", model.Id);
            sqls.Add(sql);
            SCompany company = base.getModel<SCompany>(string.Format("select * from S_Company where Id='{0}'",model.CompanyId));
            if (company != null) {
                if (company.ChargeType == 1) {
            sql = string.Format("update S_Company set OverNumber=OverNumber-{0} where Id='{1}'", model.Quantity,model.CompanyId);
            sqls.Add(sql);
                }else if (company.ChargeType == 2) {
            sql = string.Format("update S_Company set OverTime=DATEADD(DAY, -{0}, OverTime) where Id='{1}'", model.Quantity,model.CompanyId);
            sqls.Add(sql);
                }
            }
            return base.ExecuteSql(sqls);
        }

        public SCompanyPay GetCompany(string Id)
        {
            string sql = string.Format(@"select * from S_CompanyPay where Id='{0}'", Id);
            return base.getModel<SCompanyPay>(sql);
        }
        public List<SCompanyPay> GetCompanys(string where) {
            string sql = string.Format(@"select a.*,b.CompanyName from S_CompanyPay a left join S_Company b on a.CompanyId=b.Id where 1=1 {0}", where);
            return base.getList<SCompanyPay>(sql);
        }
        public DataTable GetTable(string where) {
            string sql = string.Format(@"select a.*,b.CompanyName from S_CompanyPay a left join S_Company b on a.CompanyId=b.Id where 1=1 {0}", where);
            return base.GetTable(sql);
        }
        public bool SaveCompany(SCompanyPay model)
        {
            bool isSaved = false;
                string sql = string.Empty;
            if (string.IsNullOrEmpty(model.Id))
            {
                model.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            { 
                sql = SqliteSqlUtil.GetSaveSql<SCompanyPay>(model, "S_CompanyPay");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else 
            {
                
                isSaved = service.Save<SCompanyPay>(model, model.Id);
            }
            if (isSaved) {
                SCompany company = base.getModel<SCompany>(string.Format("select * from S_Company where Id='{0}'", model.CompanyId));
                if (company != null) {
                    if (company.ChargeType == 1) {
                        sql = string.Format("update S_Company set OverNumber=OverNumber+{0} where Id='{1}'", model.Quantity, model.CompanyId);
                return base.ExecuteSql(sql);
                    } else if (company.ChargeType == 2) {
                        sql = string.Format("update S_Company set OverTime=DATEADD(DAY, {0}, OverTime) where Id='{1}'", model.Quantity, model.CompanyId);
                return base.ExecuteSql(sql);
                    }
                }
            }
            return isSaved;
        }
        public SCompanyPay GetCompany(DataRow row) {
            return base.getModel<SCompanyPay>(row);
        }
        #endregion
    }
}
