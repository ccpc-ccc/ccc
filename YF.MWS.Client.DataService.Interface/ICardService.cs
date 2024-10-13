using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ICardService
    {
        bool DeleteBatch(List<string> lstCardId);
        bool Delete(string cardId);
        bool DeleteDetail(string detailId);
        bool ExistCarNo(string cardId, string carNo);
        List<ImportResult> ImportCard(List<BPlanCard> lstCard, ImportMode mode, ICarService carService, ICustomerService customerService,IMaterialService materialService);
        QPlanCard Get(string cardId);
        QPlanCard GetWithCardNo(string cardNo);
        BPlanCard GetByCardId(string cardId);
        BPlanCard GetByCarNo(string carNo);
        BPlanCard GetByNo(string cardNo);
        SCardViewDtl GetCardDetail(string viewId, string detailId);
        DataTable GetExport();
        List<QPlanCard> GetList();
        PageList<QPlanCard> GetList(PlanCardQuery query);
        DataTable GetCardList();
        List<QCardViewDtl> GetDetailList(string viewId);
        List<SWeightViewDtl> GetInitedWVDetailList(string viewId);
        List<BCardPreset> GetPresetList();
        List<BCardPreset> GetPresetList(string cardId);
        bool Save(BPlanCard card);
        bool SaveDetail(SCardViewDtl detail);
        void SavePreset(string cardId, List<BCardPreset> lst);
    }
}
