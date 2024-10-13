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

namespace YF.MWS.SQlSugService {
    public class ControlService : BaseService<S_Control>, IControlService {
        public ControlService(ConnectionStrings connection) : base(connection) {
        }
        public VPage<S_Control> getPage(QueryControl query) {
            ISugarQueryable<S_Control> list =db.Queryable<S_Control>();
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public S_Control GetById(string id) {
            return db.Queryable<S_Control>().Where(li=>li.Id==id).First();
        }
        public S_Control GetByFieldName(string fieldName) {
            return db.Queryable<S_Control>().Where(li=>li.FieldName == fieldName).First();
        }
        public bool save(S_Control model) {
            Expression<Func<S_Control, object>> ps = li => new { li.ControlName, li.Caption,li.FieldName};
            return base.save(model, ps);
        }
        public bool delete(S_Control model) {
            return db.Deleteable(model).Where(li=>li.Id==model.Id).ExecuteCommand()>0;
        }
    }
}
