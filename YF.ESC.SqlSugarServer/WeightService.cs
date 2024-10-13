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
    public class WeightService : BaseService<B_Weight>, IWeightService {
        public WeightService(ConnectionStrings connection) : base(connection) {
        }
        public VPage<B_Weight> getPage(QueryWeight query) {
            var models = db.Queryable<B_Weight>().Where(li=>li.CompanyId==query.CompanyId).Includes(t => t.Wareh).Includes(t=>t.Customer).Includes(t=>t.Material).OrderBy("CreateTime DESC");
            return base.ToPage(query.PageIndex, query.PageSize, models);
        }
        public VPage<B_Weight> getWxPage(QueryWeight query) {
            var models = db.Queryable<B_Weight>().Where(li => li.CompanyId == query.CompanyId&&li.OpenId==query.OpenId).Includes(t => t.Wareh).Includes(t => t.Customer).Includes(t => t.Material).OrderBy("CreateTime DESC");
            return base.ToPage(query.PageIndex, query.PageSize, models);
        }
        public B_Weight GetById(string id) {
            return db.Queryable<B_Weight>().Where(li=>li.Id==id).First();
        }
        public bool save(B_Weight model) {
            Expression<Func<B_Weight, object>> ps = li => new {
                li.MaterialId,
                li.CustomerId,
                li.CarNo
            };
            return base.save(model, ps);
        }
        public bool doneWeight(B_Weight model) {
            Expression<Func<B_Weight, object>> ps = li => new {
                li.OpenId,li.CompanyId,li.CreateTime,li.CreaterId
            };
            return db.Updateable(model).Where(it => it.Id == model.Id).IgnoreColumns(ps).ExecuteCommand() > 0;
        }
        public bool upState(B_Weight model) {
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns(li => new {li.FinishState }).ExecuteCommand() > 0;
        }
        public B_Weight GetByState1(QueryWeight model) {
            return db.Queryable<B_Weight>().Where(li => li.CompanyId == model.CompanyId && li.CarNo == model.CarNo&&li.FinishState==1)
                .Includes(t => t.Wareh).Includes(t => t.Customer).Includes(t => t.Material).OrderBy("CreateTime DESC").First();
        }
    }
}
