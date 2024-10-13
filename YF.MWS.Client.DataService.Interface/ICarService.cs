using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ICarService
    {
        SCar Add(string carNo);
        bool CarNoExist(string carNo, string carId);
        bool Delete(string carId);
        DataTable GetExport();
        List<ImportResult> Import(List<SCar> lstCar, ImportMode mode);
        List<SCar> GetList();
        List<SCar> GetList(string carNoKey);
        List<SCar> GetUnSyncList();
        SCar Get(string carId);
        SCar Get(string carId, string cardNo);
        SCar GetByCarNo(string carNo);
        bool Save(SCar car);
        bool UpdateSyncState(BatchUpdate batch);
    }
}
