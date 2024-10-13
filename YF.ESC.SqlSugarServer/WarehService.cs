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
    public class WarehService : BaseService<S_Wareh>, IWarehService {
        public WarehService(ConnectionStrings connection) : base(connection) {
        }
        public S_Wareh GetByName(S_Wareh model) {
            return db.Queryable<S_Wareh>().Where(li=>li.WarehName==model.WarehName&&li.CompanyId==model.CompanyId).First();
        }
        public S_Wareh GetByCode(S_Wareh model) {
            return db.Queryable<S_Wareh>().Where(li=>li.WarehCode == model.WarehCode && li.CompanyId == model.CompanyId).First();
        }
        public VPage<S_Wareh> getPage(QueryWareh query) {
            var list = db.Queryable<S_Wareh>().Where(li=>li.CompanyId==query.CompanyId);
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public bool save(S_Wareh model) {
            Expression<Func<S_Wareh, object>> cols = li => new { li.WarehName };
            return base.save(model,cols);
        }
        /// <summary>
        /// 合并终端数据
        /// </summary>
        /// <param name="model"></param>
        public S_Wareh clientToModel(S_Wareh model) {
            S_Wareh wareh = GetByName(model);
            if (wareh != null) return wareh;
            S_Wareh s_Wareh = new S_Wareh();
            while (s_Wareh!=null) {
                model.WarehCode = "W" + DateTime.Now.ToString("yyMMddHHmmssffff");
                s_Wareh = GetByCode(model);
            }
            model.Id = Guid.NewGuid().ToString("N");
            if (base.save(model, null)) return model;
            else return null;
        }
    }
}
