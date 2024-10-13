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
using System.Linq.Expressions;

namespace YF.MWS.SQlSugService
{
    public class RoleService : BaseService<S_Role>, IRoleService {
        public RoleService(ConnectionStrings connection) : base(connection) {
        }
        public VPage<S_Role> getPage(QueryRole query) {
            var models = db.Queryable<S_Role>().Where(li=>li.CompanyId==query.CompanyId);
            return base.ToPage(query.PageIndex, query.PageSize, models);
        }
        public S_Role GetById(string id) {
            return db.Queryable<S_Role>().Where(li=>li.Id==id).First();
        }
        public bool save(S_Role model) {
            Expression<Func<S_Role, object>> ps = li => new {
                li.RoleName,
                li.UpdaterId,
                li.UpdateTime,
                li.Remarks
            };
            return base.save(model, ps);
        }
        public bool savePermiss(QueryRole query) {
            S_Role model = query.convert<S_Role>();
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns(li => new {
                li.Permission,
                li.Permission2
            }).ExecuteCommand()>0;

        }
    }
}
