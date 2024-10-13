using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 收费服务接口
    /// </summary>
    public interface IPayService
    {
        /// <summary>
        /// 增加支付信息
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        bool AddPay(BPay pay);
        /// <summary>
        /// 删除收费配置信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCharge(string id);

        bool DeletePay(string payId);
        /// <summary>
        /// 批量删除充值记录
        /// </summary>
        /// <param name="payIds"></param>
        /// <returns></returns>
        bool DeletePay(List<string> payIds);
        /// <summary>
        /// 根据ID获取收费配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SCharge GetCharge(string id);

        BPay GetPay(string payId);

        BPay GetPayWithRefId(string refId);

        int GetPayState(string weightId);

        TPageResult GetChargeList(PageQueryCondition qc);

        /// <summary>
        /// 获取收费配置列表
        /// </summary>
        /// <returns></returns>
        List<SCharge> GetChargeList();

        TPageResult GetPayList(PageQueryCondition qc);

        decimal GetBalanceAmount(string customerId);

        /// <summary>
        /// 在线扫码预支付
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        PayJumpPageModel PreparePay(BPay pay);

        /// <summary>
        /// 保存收费配置信息
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        bool SaveChargeCfg(SCharge charge);
        /// <summary>
        /// 更新客户余额
        /// </summary>
        /// <param name="customerId"></param>
        void RefreshCustomerBalance(string customerId);
        /// <summary>
        /// 修改支付信息
        /// </summary>
        /// <param name="pay"></param>
        /// <returns></returns>
        bool UpdatePay(BPay pay);

        void UpdateSyncState(int syncState, string payId);
        bool UpdateRowState(RowState rowState, string refId);
        DataTable GetDetail(string PayId);
        bool save(BPay pay, List<BPayDetail> payDetails);
    }
}
