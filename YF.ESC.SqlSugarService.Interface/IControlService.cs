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
    /// 控件管理接口
    /// </summary>
    public interface IControlService : IBaseService <S_Control> {
        VPage<S_Control> getPage(QueryControl query);
        bool delete(S_Control model);
        S_Control GetById(string id);
        S_Control GetByFieldName(string fieldName);
    }
}
