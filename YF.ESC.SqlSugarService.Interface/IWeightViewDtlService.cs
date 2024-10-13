using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;

namespace YF.MWS.SQlSugService.Interface
{
    /// <summary>
    /// 用户信息管理接口
    /// </summary>
    public interface IWeightViewDtlService : IBaseService <S_WeightViewDtl> {
        VPage<S_WeightViewDtl> getPage(QueryWeightViewDtl query);
        S_WeightViewDtl GetByFieldName(string name);
    }
}
