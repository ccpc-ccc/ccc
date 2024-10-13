using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IWeightTempService
    {
        List<BWeightTemp> GetList(DateTime dtStart, DateTime dtEnd,int topN);
        bool Save(BWeightTemp weightTemp);
    }
}
