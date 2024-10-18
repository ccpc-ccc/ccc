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
    public interface IMasterService
    {
        bool CustomerExist(string type, string customerName, string customerId);

        /// <summary>
        /// 压缩数据库
        /// </summary>
        /// <returns></returns>
        bool Compress();
        /// <summary>
        /// 数据库备份
        /// </summary>
        void DataBackup(string backDir);
        bool DataPurge(int year);

        /// <summary>
        /// 删除系统编码
        /// </summary>
        /// <param name="codeId">编号</param>
        /// <returns></returns>
        bool DeleteCode(string codeId);
        
        /// <summary>
        /// 清理数据库
        /// </summary>
        /// <returns></returns>
        bool InitDb();
        void ImportCode(List<SCode> codes);

        SCode GetCode(string codeId);
        /// <summary>
        /// 根据编码获取系统编码
        /// </summary>
        /// <param name="codeNo">编码</param>
        /// <returns></returns>
        SCode GetCodeByCodeNo(string codeNo);

        /// <summary>
        /// 获取系统编码列表,返回List
        /// </summary>
        /// <returns></returns>
        List<SCode> GetList(string parentNo = null);

        List<SCode> GetList(int systemFlag);

        /// <summary>
        /// 根据父类编号获取子级的系统编码
        /// </summary>
        /// <param name="code">系统编码实体类</param>
        /// <returns>系统编码集合</returns>
        List<SCode> GetSubList(string code); 

        SCustomer GetCustomer(string customerId);

        DataTable GetCustomerTable(string customerId);

        DataTable GetCustomerByCustomerType(CustomerType customerType);
        SCustomer GetCustomerByIdCard(CustomerType customerType, string idCardNo);
        SCustomer GetCustomerByName(CustomerType customerType, string customerName);

        List<SCustomer> GetCustomerList();

        List<SCustomer> GetCustomerList(CustomerType customerType);

        List<SCustomer> GetSyncCustomer(BWeight weight);

        /// <summary>
        /// 根据部门Id获取部门信息
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <returns></returns>
        SDept GetDepart(string deptId);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        List<SDept> GetDeptList();

        /// <summary>
        /// 根据公司Id获取所有部门
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        DataTable GetDeptByCompanyId(string companyId);

        /// <summary>
        /// 根据公司Id获取部门列表
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        List<SDept> GetDeptListByCompany(string companyId);

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <returns></returns>
        bool DeleteDepart(string deptId);

        /// <summary>
        /// 保存系统编码信息
        /// </summary>
        /// <param name="code">系统编码实体类</param>
        /// <returns></returns>
        bool SaveCode(SCode code);

        bool SaveCode(SCode code, string parentCode);

        /// <summary>
        /// 保存客户信息
        /// </summary>
        /// <param name="customer">客户信息实体类</param>
        /// <returns></returns>
        bool SaveCustomer(SCustomer customer);

        /// <summary>
        /// 保存部门信息
        /// </summary>
        /// <param name="depart">部门信息实体类</param>
        /// <returns></returns>
        bool SaveDepart(SDept depart);

        void UpdateCustomerSyncState(int syncState, string customerId);
    }
}
