using System;
using YF.MWS.Models;

namespace YF.MWS.SQlSugService.Interface
{
    public interface IBaseService<Entry>
        where Entry : BaseEntity, new()
    {
        bool Add(Entry entry);
        bool Delete(Entry entry);
        bool Delete(string id);
        Entry Get(string id);
        System.Collections.Generic.List<Entry> GetList();
        bool Update(Entry entry);
        bool save(Entry entry);
    }
}
