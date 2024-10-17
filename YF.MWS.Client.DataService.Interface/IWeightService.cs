using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 称重存储接口
    /// Author:闫孝感
    /// Date:2024-10-14
    /// </summary>
    public interface IWeightService
    {
        /// <summary>
        /// 物理删除磅单
        /// </summary>
        /// <param name="weightId">磅单Id</param>
        /// <returns></returns>
        bool DeleteWeight(BWeight weight);

        /// <summary>
        /// 根据ID获取磅单信息
        /// </summary>
        /// <param name="weightId"></param>
        /// <returns></returns>
        BWeight Get(string weightId);

        /// <summary>
        /// 获取当前日期的磅单记录总数
        /// </summary>
        /// <returns></returns>
        int GetCurrentDateCount(); 

        List<BWeightAttribute> GetAttributeList(string weightId);

        BWeightDetail GetDetail(string weightId, WeightType type);

        List<QDriver> GetDriverList();
        DataTable GetList(string where);

        List<QWeight> GetList(DateTime dtStart, DateTime dtEnd, int syncState);

        /// <summary>
        /// 获取当前的磅单列表
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="finishState">0:未完成 1:已完成 2:所有状态</param>
        /// <param name="overWegihtState">0:未超载 1:超载 2:所有状态</param>
        /// <returns></returns>
        List<QWeight> GetList(DateTime dtStart, DateTime dtEnd, int finishState,int overWegihtState);
        int GetWeightCountByMaterial(string materialId);
        DataTable GetWeighter();
        /// <summary>
        /// 获取最新的磅单
        /// </summary>
        /// <returns></returns>
        BWeight GetLastWeight();

        List<BWeight> GetUploadList();
        /// <summary>
        /// 获取当天的所有磅单列表
        /// </summary>
        /// <returns></returns>
        DataTable GetTodayList();

        List<BWeight> GetTodayWeightList(string carNo);

        SyncWeight GetTWeight(string weightId);

        /// <summary>
        /// 根据车牌号获取最近时间一条未完成的称重记录
        /// </summary>
        /// <param name="carNo">车Id</param>
        /// <returns></returns>
        BWeight GetUnFinishedByCarNo(string carNo);

        BWeight GetUnFinishedByCardNo(string cardNo);
        List<BWeight> GetUnFinishedList(DateTime startTime);

        /// <summary>
        /// 根据卡号获取最近时间一条未完成的称重记录
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="process">称重方式</param>
        /// <returns></returns>
        BWeight GetUnFinishedByCardNo(string cardNo, WeightProcess process);

        string GetUnFinishedWeightId(string attributeName, string attributeValue, string subjectId);
        /// <summary>
        /// 根据车辆Id获取最近时间一条未完成的称重记录
        /// </summary>
        /// <param name="carId">车辆Id</param>
        /// <returns></returns>
        BWeight GetUnFinishedByCarId(string carId);
        /// <summary>
        /// 获取磅单明细列表
        /// </summary>
        /// <param name="weightId">磅单Id</param>
        /// <returns></returns>
        List<BWeightDetail> GetWeightDetail(string weightId);
        /// <summary>
        /// 导入历史磅单数据
        /// </summary>
        /// <param name="dtWeight"></param>
        /// <returns></returns>
        bool ImportNew(DataTable dtWeight,SysCfg cfg);
        /// <summary>
        /// 保存磅单、皮重、毛重详情信息
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="tareDetail"></param>
        /// <param name="grossDetail"></param>
        /// <returns></returns>
        bool Save(BWeight weight, BWeightDetail tareDetail, BWeightDetail grossDetail,BWeight oldWeight=null);
        bool Save(BWeight weight);


        bool UpdateWeight(string weightId, RowState state);

        void UpdatePrint(string weightId);

        void UpdateSyncState(string weightId);
        bool UpdateQcState(string weightId, QcState state,decimal deducteWeight);
        bool UpdateWeightNo(string weightId, string weightNo);
        bool save(BWeight weight, DateTime time);
    }
}
