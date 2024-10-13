using System;
namespace YF.MWS.Client.DataService.Interface
{
    public interface IDataEntryService
    {
        bool Add(YF.MWS.Db.DataEntry entry);
        bool Delete(string id);
        bool Delete(YF.MWS.Db.DataEntry entry);
        YF.MWS.Db.DataEntry Get(string id);
        System.Collections.Generic.List<YF.MWS.Db.DataEntry> GetList();
        bool Update(YF.MWS.Db.DataEntry entry);
    }
}
