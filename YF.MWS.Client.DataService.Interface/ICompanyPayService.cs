using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 基础数据服务接口
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public interface ICompanyPayService {
        bool Delete(SCompanyPay model);
        SCompanyPay GetCompany(string Id);
        SCompanyPay GetCompany(DataRow row);
        List<SCompanyPay> GetCompanys(string where);
        DataTable GetTable(string where);
        bool SaveCompany(SCompanyPay model);
    }
}
