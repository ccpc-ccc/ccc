using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SqlSugar;
using YF.MWS.Models;
using YF.MWS.BaseMetadata;
using Microsoft.AspNetCore.Identity;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using YF.MWS.SQlSugService.Interface;
using YF.Utility;
using Microsoft.Data.SqlClient;
using YF.MWS.Metadata;

namespace YF.MWS.SQlSugService {
    public class UserService: BaseService<S_User>,IUserService {
        public UserService(ConnectionStrings connection) : base(connection) {
        }

        public bool Delete(List<string> lstUserId)
        {
            bool isDeleted = false;
            if (lstUserId != null && lstUserId.Count > 0)
            {
                    List<S_User> users = new List<S_User>();
                    foreach (string userId in lstUserId) {
                        users.Add(new S_User() { Id = userId });
                    }
                    isDeleted=db.Deleteable<S_User>().Where(users).ExecuteCommand()>0;
            }
            return isDeleted;
        }
        public bool Delete(List<S_User> lstUser) {
            return db.Deleteable<S_User>().Where(lstUser).ExecuteCommand() > 0;
        }

        public S_User GetById(string userId)
        {
            S_User user = null;
                using (SqlSugarClient db = new SqlSugarClient(config)) {
                user = db.Queryable<S_User>().Where(it => it.Id == userId).First();
                }
            return user;
        }

        public List<S_User> GetList()
        {
            string sql;
            List<S_User> list = null;
            using (SqlSugarClient db = new SqlSugarClient(config)) {
                list = db.Queryable<S_User>().OrderBy("UserName").ToList();
            }
            return list;
        }

        public S_User GetByName(QueryUser query)
        {
            S_User user = null;
            using (SqlSugarClient db = new SqlSugarClient(config)) {
                user = db.Queryable<S_User>().Where(it => it.UserName == query.UserName&&it.CompanyId==query.CompanyId).First();
            }
            return user;
        }

        public List<string> GetUserList() 
        {
            List<string> lstUser = new List<string>();
            using (SqlSugarClient db = new SqlSugarClient(config)) {
                List<S_User> users = db.Queryable<S_User>().Where(it => it.Active == 1).ToList();
                users.ForEach(it => {
                    lstUser.Add(it.UserName);
                });
            }
            return lstUser;
        }

        public S_User Login(QueryUser query)
        {
            return db.Queryable<S_User>().Where(it => it.UserName == query.UserName && it.UserPwd == query.UserPwd&&it.Company.CompanyCode==query.CompanyCode).Includes(t => t.Role).Includes(t => t.Company).First();
        }
        public bool MasterSave(S_User user) {
            if (user.Id == null || user.Id == "") {
                user.Id=Guid.NewGuid().ToString("N");
                user.UserPwd = "123456".ToMd5();
                return db.Insertable(user).ExecuteCommand() > 0;
            }
           return db.Updateable(user).Where(it=>it.Id==user.Id).UpdateColumns(li=> new {
               li.FullName,li.Email,
               li.RoleId,
               li.MobilePhone
           }).ExecuteCommand()>0;
        }

        public bool UserExist(string userName)
        {
            bool isExist = false;
            using (SqlSugarClient db = new SqlSugarClient(config)) {
                int count = db.Queryable<S_User>().Where(it => it.UserName == userName).Count();
                if(count>0) isExist = true;
            }
            return isExist;
        }

        public bool UpdatePassword(string userId, string newPasswrod)
        {
            S_User user = new S_User() { Id = userId,UserPwd= newPasswrod };
            int count = db.Updateable(user).Where(it => it.Id == userId).UpdateColumns(it => new {
                    it.UserPwd
                }).ExecuteCommand();
            return count > 0;
        }
        public S_User getCompanyAdmin(string companyId) {
            return db.Queryable<S_User>().Where(li=>li.CompanyId==companyId&&li.IsAdmin==1).First();
        }
        public bool save(S_User user) {
            if (string.IsNullOrEmpty(user.Id))
                user.Id = Guid.NewGuid().ToString("N");
            return db.Updateable(user).ExecuteCommand() > 0;
        }
        public VPage<S_User> getPage(QueryUser queryUser) {
            var users = db.Queryable<S_User>().Where(li => li.CompanyId == queryUser.CompanyId&&li.Id!=queryUser.Id).Includes(t => t.Role).Includes(t => t.Company);
            return base.ToPage(queryUser.PageIndex, queryUser.PageSize, users);
        }
        public List<S_User> getListByCompany(string companyId) {
            return db.Queryable<S_User>().Where(it => it.CompanyId == companyId).ToList();
        }
        public bool savePermiss(QueryUser query) {
            S_User model = query.convert<S_User>();
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns(li => new {
                li.Permission,
                li.Permission2
            }).ExecuteCommand() > 0;
        }
    }
}
