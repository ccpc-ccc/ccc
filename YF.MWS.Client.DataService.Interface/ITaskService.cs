using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ITaskService
    {
        bool AddTask(BTask task);
        bool DeleteTask(string taskId);
        List<BTask> GetAutoPrintList();
        List<BTask> GetUnfinishedTask();
    }
}
