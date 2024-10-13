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

namespace YF.MWS.SQlSugService {
    public class MaterialService : BaseService<S_Material>, IMaterialService {
        public MaterialService(ConnectionStrings connection) : base(connection) {
        }
        public S_Material GetByName(QueryMaterial model) {
            return db.Queryable<S_Material>().Where(li=>li.MaterialName==model.MaterialName&&li.CompanyId==model.CompanyId).First();
        }
        public S_Material GetByCode(QueryMaterial model) {
            return db.Queryable<S_Material>().Where(li=>li.MaterialCode==model.MaterialCode&&li.CompanyId==model.CompanyId).First();
        }
        public VPage<S_Material> getPage(QueryMaterial query) {
            var list = db.Queryable<S_Material>().Where(li=>li.CompanyId==query.CompanyId);
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public bool save(S_Material model) {
            Expression<Func<S_Material, object>> cols = li => new { li.MaterialName };
            return base.save(model,cols);
        }
        /// <summary>
        /// 合并终端数据
        /// </summary>
        /// <param name="model"></param>
        public S_Material clientToModel(QueryMaterial model) {
            S_Material old = GetByName(model);
            if (old != null) return old;
            S_Material s_Wareh = new S_Material();
            while (s_Wareh != null) {
                model.MaterialCode = "M" + DateTime.Now.ToString("yyMMddHHmmssffff");
                s_Wareh = GetByCode(model);
            }
            model.Id = Guid.NewGuid().ToString("N");
            if (base.save(model, null)) return new S_Material() {Id=model.Id,MaterialCode=model.MaterialCode,MaterialName=model.MaterialName };
            else return null;
        }
    }
}
