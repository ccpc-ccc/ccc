using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebClientService
    {
        bool AddConsult(BConsult consult);
        SClient Get(string machineCode);
        List<SClient> GetClientList(string companyId);
        bool Save(SClient client);
        bool SaveLocation(SLocation location);
    }
}
