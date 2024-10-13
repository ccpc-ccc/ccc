using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using System.Data;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.Util;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;

namespace YF.MWS.SQliteService
{
    public class UserService:BaseService,IUserService
    {
        public bool Delete(List<string> lstUserId)
        {
            bool isDeleted = false;
            if (lstUserId != null && lstUserId.Count > 0)
            {
                string sql = string.Format("delete from S_User where Id in ({0})", YF.MWS.Util.Utility.GetSqlIn(lstUserId));
                return base.ExecuteSql(sql);
            }
            return isDeleted;
        }
        public bool Delete(string lstUserId) {
                string sql = string.Format("delete from S_User where Id = '{0}'", lstUserId);
                return base.ExecuteSql(sql);
        }

        public SUser GetById(string userId)
        {
            if (userId == null || userId == "") return null;
            SUser user = null;
            string sql;
            sql = string.Format(@"select * from S_User where Id='{0}'",userId);
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
                user = TableHelper.RowToEntity<SUser>(dt.Rows[0]);
            }
            return user;
        }

        public List<SUser> GetList(string[] companyIds)
        {
            string sql = "select * from S_User";
            if (companyIds != null) {
                string idx=string.Join("','", companyIds);
                sql += string.Format(" where CompanyId in ('{0}')",idx);
            }
            return base.getList<SUser>(sql);
        }
        public List<SUser> GetList(CurrentUser user) {
            string sql =string.Format("select * from S_User where Id<>'{0}'",user.Id);
            if (user.CompanyIds != null) {
                string idx=string.Join("','", user.CompanyIds);
                sql += string.Format(" and CompanyId in ('{0}')",idx);
            }
            return base.getList<SUser>(sql);
        }
        public SUser Get(string userName)
        {
            SUser user = null;
            string sql;
            sql = string.Format(@"select * from S_User where UserName='{0}'", userName);
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
                user = TableHelper.RowToEntity<SUser>(dt.Rows[0]);
            }
            return user;
        }

        public List<string> GetUserList() 
        {
            List<string> lstUser = new List<string>();
            string sql; 
            DataTable dt;
                sql = "select UserName from S_User where Active=1";
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
                foreach (DataRow dr in dt.Rows) 
                {
                    lstUser.Add(dr[0].ToObjectString());
                }
            }
            return lstUser;
        }

        public SUser Login(string userName, string userPwd)
        {
            SUser user = null;
            string sql = null;
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format("select * from S_User where UserName='{0}' and UserPwd='{1}'",
                     userName, userPwd);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format("select * from S_User where UserName='{0}' and UserPwd='{1}' and Platform='{2}'",
                     userName, userPwd, PlatformType.Client);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0) 
            {
                user = TableHelper.RowToEntity<SUser>(dt.Rows[0]);
            }
            return user;
        }

        public bool UserExist(string userName)
        {
            bool isExist = false;
            string sql = string.Format("select count(UserName) from S_User where UserName='{0}'", userName);
            int rows = 0;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                rows = sqliteDb.ExecuteScalar(sql).ToInt();
            }
            else 
            {
                rows = service.GetDataTable(sql).Rows[0][0].ToInt();
            }
            if (rows > 0) 
            {
                isExist = true;
            }
            return isExist;
        }

        public bool UpdatePassword(string userId, string newPasswrod)
        {
            string sql;
            sql = string.Format("update S_User set UserPwd='{0}' where Id='{1}'",newPasswrod,userId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public bool ResetPassword(string userName, string newPasswrod)
        {
            string sql;
            sql = string.Format("update S_User set UserPwd='{0}' where UserName='{1}'", newPasswrod, userName);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public bool Save(SUser user)
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(user.Id))
                user.Id = Util.Utility.GetGuid();
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql = SqliteSqlUtil.GetSaveSql(user, "S_User");
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                user.Platform = PlatformType.Client.ToString();
                isSaved = service.Save<SUser>(user, user.Id);
            }
            return isSaved;
        }
    }
}
