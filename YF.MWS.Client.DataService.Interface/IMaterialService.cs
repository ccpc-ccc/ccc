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
    public interface IMaterialService {
        List<ImportResult> ImportMaterial(List<SMaterial> lstMaterial,ImportMode mode);

        SMaterial GetMaterialByName(string materialName);

        SMaterial GetSyncMaterial(string materialId);

        List<SCustomer> GetCustomerList();

        List<SCustomer> GetCustomerList(CustomerType customerType);

        /// <summary>
        /// 根据物资编号获取物资信息
        /// </summary>
        /// <param name="materialId">物资编号</param>
        /// <returns></returns>
        SMaterial GetMaterial(string materialId);

        /// <summary>
        /// 获取物资列表
        /// </summary>
        /// <returns></returns>
        List<SMaterial> GetMaterialList(MaterialStateType state = MaterialStateType.Enable);
        /// <summary>
        /// 获取物资列表
        /// </summary>
        /// <returns></returns>
        List<SMaterial> GetMaterialList();
        DataTable GetMaterialExport();
        /// <summary>
        /// 根据物资编号删除物资信息
        /// </summary>
        /// <param name="materialId">物资编号</param>
        /// <returns></returns>
        bool DeleteMaterial(string materialId);

        /// <summary>
        /// 保存物资信息
        /// </summary>
        /// <param name="material">物资信息实体类</param>
        /// <returns></returns>
        bool SaveMaterial(SMaterial material);

        void UpdateMaterialSyncState(int syncState, string materialId);
    }
}
