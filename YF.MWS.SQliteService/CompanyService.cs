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

namespace YF.MWS.SQliteService
{
    public class CompanyService : BaseService, ICompanyService {
        #region IMasterService 成员

        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        public bool DeleteCompany(string companyId)
        {
            bool isDeleted = false;
            string sql = string.Format(@"delete from S_Company where Id = '{0}'", companyId);
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


        public SCompany GetCompany()
        {
            string sql = "select * from S_Company";
            return base.getModel<SCompany>(sql);
        }

        public SCompany GetCompany(string companyId)
        {
            string sql = string.Format(@"select * from S_Company where Id='{0}'", companyId);
            return base.getModel<SCompany>(sql);
        }
        public List<string> GetCompanys(string companyId) {
            List<string> list = new List<string>();
            if (companyId == null || companyId=="") return list;
            list.Add(companyId);
            string sql = string.Format(@"select Id from S_Company where ParentId in ('{0}')", companyId);
            DataTable dt = base.GetTable(sql);
            if (dt == null) return list;
            foreach (DataRow dr in dt.Rows) {
                list.Add(dr[0].ToString());
            }
            list.AddRange(GetCompanys(list));
            return list;
        }

        private List<string> GetCompanys(List<string> companyIds)
        {
            List<string> list = new List<string>();
            if(companyIds==null||companyIds.Count<=0) return list;
            string ids=string.Join("','", companyIds);
            string sql = string.Format(@"select Id from S_Company where ParentId in ('{0}')", ids);
            DataTable dt= base.GetTable(sql);
            if(dt==null) return list;
            foreach(DataRow dr in dt.Rows) {
                list.Add(dr[0].ToString());
            }
            list.AddRange(GetCompanys(list));
            return list;
        }
        public List<ListItem> GetListItem(string[] ids) {
            DataTable dt = new DataTable();
            string sql = "select Id,CompanyName from S_Company";
            if(ids!=null) {
            string id=string.Join ("','", ids);
                sql = sql + string.Format(" where Id in ('{0}')", id);
            }
                dt=base.GetTable(sql);
            return dt.ToListItems("CompanyName");
        }
        public DataTable GetCompanies(string[] ids) {
            string sql = "select a.*,b.CompanyName as ParentName from S_Company a left join S_Company b on a.ParentId=b.Id";
            if (ids != null) {
                string idx = string.Join("','", ids);
                sql += string.Format(" where a.Id in ('{0}')", idx);
            }
            return base.GetTable(sql);
        }
        public List<SCompany> GetCompanyList(string[] ids)
        {
            DataTable dt=GetCompanies(ids);
            return TableHelper.TableToList<SCompany>(dt);
        }

        public bool SaveCompany(SCompany company)
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(company.Id))
            {
                company.Id = Util.Utility.GetGuid();
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = string.Empty; 
                sql = SqliteSqlUtil.GetSaveSql<SCompany>(company, "S_Company");
                if (!string.IsNullOrEmpty(sql))
                {
                    isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
                }
            }
            else 
            {
                isSaved = service.Save<SCompany>(company, company.Id);
            }
            return isSaved;
        }
        public bool upOverNumber(string companyId) {
            string sql = string.Format("update S_Company set OverNumber=OverNumber-1 where Id='{0}'",companyId);
            return base.ExecuteSql(sql);
        }

        #endregion
    }
}
