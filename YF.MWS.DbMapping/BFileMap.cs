using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class BFileMap:ClassMap<BFile>
    {
        public BFileMap() 
        {
            Table("B_File");
            Id(m => m.Id);
            Map(m => m.BusinessType);
            Map(m => m.CreaterId);
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.FileExtension);
            Map(m => m.FileSize);
            Map(m => m.FileUrl);
            Map(m => m.ThumbnailUrl);
            Map(m => m.RecId); 
            Map(m => m.RowState);
            Map(m => m.SyncState);
            Map(m => m.TableName);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.ServerUrl);
            Map(m => m.OrderNo);
        }
    }
}
