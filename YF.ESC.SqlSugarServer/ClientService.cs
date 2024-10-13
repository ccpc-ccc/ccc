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
using System.Reflection.Metadata.Ecma335;

namespace YF.MWS.SQlSugService {
    public class ClientService : BaseService<S_Client>,IClientService {
        public ClientService(ConnectionStrings connection) : base(connection) {
        }

        public bool Delete(List<string> lstUserId)
        {
            bool isDeleted = false;
            if (lstUserId != null && lstUserId.Count > 0)
            {
                using(SqlSugarClient db = new SqlSugarClient(config)) {
                    List<S_User> users = new List<S_User>();
                    foreach (string userId in lstUserId) {
                        users.Add(new S_User() { Id = userId });
                    }
                    isDeleted=db.Deleteable<S_User>().Where(users).ExecuteCommand()>0;
                }
            }
            return isDeleted;
        }

        public S_Client GetById(string userId)
        {
            return db.Queryable<S_Client>().Where(it => it.Id == userId).First();
        }

        public List<S_Client> GetList()
        {
                return db.Queryable<S_Client>().OrderBy("MachineCode").ToList();
        }

        public S_Client GetByName(string machineCode) {
            return db.Queryable<S_Client>().Where(it => it.MachineCode == machineCode).First();
        }

        public S_Client Login(string machineCode, string registerCode)
        {
            return db.Queryable<S_Client>().Where(it => it.MachineCode == machineCode && it.RegisterCode== registerCode).Includes(t =>t.Company).First();
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

        public bool save(S_Client user)
        {
            if (string.IsNullOrEmpty(user.Id)) {
                user.Id = Guid.NewGuid().ToString("N");
            return db.Insertable(user).ExecuteCommand()>0;
            } else {
            return db.Updateable(user).IgnoreColumns(t => new { 
                t.CreaterId,
            t.CreateTime
            }).ExecuteCommand()>0;
            }
        }
        public VPage<S_Client> getPage(QueryClient queryUser) {
            List<S_Client> users =new List<S_Client>();
           int total = 0;
            var list = db.Queryable<S_Client>().Where(li => li.CompanyId == queryUser.CompanyId).Includes(t => t.Company);
            if (queryUser.PageIndex != null && queryUser.PageSize != null&&queryUser.PageSize>0) {
                users= list.ToPageList((int)queryUser.PageIndex, (int)queryUser.PageSize, ref total);
            } else {
                users = list.ToList();
                total = users.Count;
            }
                return new VPage<S_Client>(){Items=users,Total=total};
        }
    }
}
