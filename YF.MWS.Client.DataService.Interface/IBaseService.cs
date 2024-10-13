using System;
namespace YF.MWS.Client.DataService.Interface
{
    public interface IBaseService<Entry>
        where Entry : class, YF.MWS.Db.IKeyCode, new()
    {
        bool Add(Entry entry);
        bool Delete(Entry entry);
        bool Delete(string id);
        Entry Get(string id);
        System.Collections.Generic.List<Entry> GetList();
        System.Collections.Generic.List<Entry> GetList(Entry param);
        bool Update(Entry entry);
    }
}
