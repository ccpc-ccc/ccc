using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebCompanyService
    {
        bool DeleteDept(string deptId);
        bool DeleteWareh(string warehId);
        SCompanyPayCfgFull GetPayCfg(string companyId, PayPluginType type);
        /// <summary>
        /// 根据企业编号获取企业信息
        /// </summary>
        /// <param name="companyNo"></param>
        /// <returns></returns>
        SCompany GetWithNo(string companyNo);
        List<DCompany> GetList();
        /// <summary>
        /// 保存企业支付配置信息
        /// </summary>
        /// <param name="companyPayCfg"></param>
        /// <returns></returns>
        bool SavePayCfg(SCompanyPayCfgFull companyPayCfg);
        bool SaveWareh(SWareh wareh);
        bool SaveDept(SDept dept);
    }
}
