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
    /// 车辆管理接口
    /// </summary>
    public interface ICarService : IBaseService <S_Car> {
        VPage<S_Car> getPage(QueryCar query);
        bool delete(S_Car model);
        S_Car GetById(string id);
        S_Car GetByNo(S_Car query);
        S_Car clientToModel(S_Car model);
    }
}
