using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Enum
{
    public enum FinaSettlement
    {
        /// <summary>
        /// 所有状态
        /// </summary>
        All,
        /// <summary>
        /// 财务已审核
        /// </summary>
        FinanceAuthed,
        /// <summary>
        /// 财务未审核
        /// </summary>
        FinanceUnAuthed,
        /// <summary>
        /// 运费已结算
        /// </summary>
        FreightSettled,
        /// <summary>
        /// 运费未结算
        /// </summary>
        FreightUnSettled,
        /// <summary>
        /// 货款已结算
        /// </summary>
        PaymentSettled,
        /// <summary>
        /// 货款未结算
        /// </summary>
        PaymentUnSettled,
        /// <summary>
        /// 全部已结算
        /// </summary>
        AllSettled,
        /// <summary>
        /// 全部未结清
        /// </summary>
        AllUnSettled
    }
}
