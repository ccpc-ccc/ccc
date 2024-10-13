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
    public interface IWarehService : IBaseService <S_Wareh> {
        VPage<S_Wareh> getPage(QueryWareh query);
        S_Wareh GetByName(S_Wareh model);
        S_Wareh GetByCode(S_Wareh model);
        /// <summary>
        /// 合并终端数据
        /// </summary>
        /// <param name="model"></param>
        S_Wareh clientToModel(S_Wareh model);
    }
}
