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
    public interface ICompanyService {
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        bool DeleteCompany(string companyId);


        SCompany GetCompany();
        /// <summary>
        /// 根据公司Id获取公司信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        SCompany GetCompany(string companyId);

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <returns></returns>
        DataTable GetCompanies(string[] ids);

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <returns></returns>
        List<SCompany> GetCompanyList(string[] ids);

        /// <summary>
        /// 保存公司信息
        /// </summary>
        /// <param name="company">公司信息实体类</param>
        /// <returns></returns>
        bool SaveCompany(SCompany company);
        /// <summary>
        /// 查询所有下属公司Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        List<string> GetCompanys(string companyId);
        /// <summary>
        /// 获取权限内的公司下拉列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<ListItem> GetListItem(string[] ids);
        bool upOverNumber(string companyId);
    }
}
