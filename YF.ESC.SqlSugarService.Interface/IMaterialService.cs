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
    public interface IMaterialService : IBaseService <S_Material> {
        VPage<S_Material> getPage(QueryMaterial query);
        S_Material GetByName(QueryMaterial model);
        S_Material GetByCode(QueryMaterial model);
        /// <summary>
        /// 合并终端数据
        /// </summary>
        /// <param name="model"></param>
        S_Material clientToModel(QueryMaterial model);
    }
}
