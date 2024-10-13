using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IWeightQcService
    {
        BWeightQc Get(string qcId);
        BWeightQc GetByNo(string qcNo);
        BWeightQc GetByWeightId(string weightId);
        List<BWeightQc> GetList();
        DataSet GetReport(string weightId, string qcId);
        bool SaveQc(BWeightQc weightQc);
    }
}
