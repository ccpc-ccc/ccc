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
using System.Reflection;
using YF.MWS.SQlSugService.Interface;
using YF.MWS.Metadata;

namespace YF.MWS.SQlSugService {
    public class CompanyService : BaseService<S_Company>, ICompanyService {
        public CompanyService(ConnectionStrings connection) : base(connection) {
        }
        public VPage<S_Company> getPage(QueryCompany query) {
            ISugarQueryable<S_Company> list =db.Queryable<S_Company>().Where(li => li.Id == query.Id || li.ParentId == query.Id);
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public List<S_Company> GetAll(string? parentId) {
          return db.Queryable<S_Company>().Where(li => (li.ParentId == parentId)).Includes(t => t.Parent).ToList();
        }
        public S_Company GetById(string id) {
            return db.Queryable<S_Company>().Where(li=>li.Id==id).First();
        }
        public S_Company GetByCode(string companyCode) {
            return db.Queryable<S_Company>().Where(li => li.CompanyCode == companyCode).First();
        }
        public bool save(S_Company model) {
            if (model.Id == null || model.Id == "") {
                model.Id = Guid.NewGuid().ToString("N");
                return db.Insertable(model).ExecuteCommand() > 0;
            }
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns().ExecuteCommand() > 0;
        }
        public bool delete(S_Company model) {
            List<S_Company> models=new List<S_Company>();
            models.Add(model);
            List<S_Company> s_Modules = getAll(model.Id, ref models);
            return db.Deleteable(s_Modules).ExecuteCommand()>0;
        }
        public List<S_Company> getAll(string parentId,ref List<S_Company> modules) {
            List<S_Company> s_Modules = db.Queryable<S_Company>().Where(it => it.ParentId == parentId).ToList();
            foreach (S_Company module in s_Modules) {
                modules.Add(module);
                return getAll(module.Id, ref modules);
            }
            return modules;
        }
    }
}
