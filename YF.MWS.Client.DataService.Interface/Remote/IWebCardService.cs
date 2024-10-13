using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebCardService
    {
        bool Save(BPlanCard card);
    }
}
