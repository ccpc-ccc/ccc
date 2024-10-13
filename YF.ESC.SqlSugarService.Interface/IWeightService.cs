using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;

namespace YF.MWS.SQlSugService.Interface
{
    /// <summary>
    /// 磅单接口
    /// </summary>
    public interface IWeightService : IBaseService <B_Weight> {
        VPage<B_Weight> getPage(QueryWeight query);
        /// <summary>
        /// 小程序查询数据（带openId）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        VPage<B_Weight> getWxPage(QueryWeight query);
        B_Weight GetById(string id);
        bool upState(B_Weight model);
        B_Weight GetByState1(QueryWeight model);
        /// <summary>
        /// 完成磅单数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool doneWeight(B_Weight model);
    }
}
