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
using System.Linq.Expressions;
using YF.MWS.Db;

namespace YF.MWS.SQlSugService {
    public class WeightViewDtlService : BaseService<S_WeightViewDtl>, IWeightViewDtlService {
        public WeightViewDtlService(ConnectionStrings connection) : base(connection) {
        }
        public S_WeightViewDtl GetByFieldName(string name) {
            return db.Queryable<S_WeightViewDtl>().Where(li=>li.FieldName == name).First();
        }
        public VPage<S_WeightViewDtl> getPage(QueryWeightViewDtl query) {
            var list = db.Queryable<S_WeightViewDtl>().Where(li=>li.CompanyId==query.CompanyId);
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public bool save(S_WeightViewDtl model) {
            Expression<Func<S_WeightViewDtl, object>> cols = li => new { li.Caption,li.ControlId,li.FieldName,li.ErrorText,li.ControlName };
            return base.save(model,cols);
        }
    }
}
