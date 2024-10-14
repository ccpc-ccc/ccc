using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IClientService
    {
        bool Add(string machineCode, string authCode);
        bool Delete();
        bool Delete(string machineCode);
        bool DeleteById(string clientId);
        SClient Get();
        SClient Get(string machineCode);
        SClient GetById(string clientId);
        List<SClient> GetList();
        bool IsConnect();
        bool Register(string clientName, string machineCode, string registerCode, string expireCode, string totalTimes, string verifyCode, string authCode);
        /// <summary>
        /// 加载用户信息
        /// </summary>
        SClient RegisterProbation(string machineCode, string clientName, string authCode);
        bool UpdateAuthCode(string machineCode, string authCode);
        bool UpdateClientName(string clientId, string clientName);
        bool Update(string clientId);
        bool UpdateProbation(string machineCode, int days);
    }
}
