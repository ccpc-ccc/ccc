using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 磅单视图服务接口
    /// </summary>
    public interface IWeightViewService
    {
        bool DeleteView(string viewId);
        bool DeleteViewDetail(string detailId);
        bool DeleteControl(string controlId);
        SControl GetControl(string controlId);
        SControl GetControlByName(string fieldName);
        List<SControl> GetControlList();
        List<SControl> GetViewControlList();
        SWeightView GetDefaultView(ViewType type);
        SWeightView GetView(string viewId);
        List<QWeightView> GetViewList();
        SWeightViewDtl GetViewDetail(string detailId);
        /// <summary>
        /// 获取所有的字段列表
        /// </summary>
        List<SWeightViewDtl> GetAllDetailList(string viewId);
        List<SWeightViewDtl> GetAllShowDetailList(string viewId);
        /// <summary>
        /// 获取正常显示的字段列表
        /// </summary>
        List<SWeightViewDtl> GetDetailList(string viewId);
        List<SWeightViewDtl> GetShow2DetailList(string viewId);
        List<SWeightViewDtl> GetShow2DetailList(ViewType type);
        List<SWeightViewDtl> GetUnShow2DetailList(string viewId);
        bool SetDefaultView(ViewType type, string viewId);
        bool SaveConrol(SControl control);
        bool SaveView(SWeightView view);
        bool SaveViewDetail(SWeightViewDtl detail);
        bool UpdateExpression(string detailId, string expression);
        bool UpdateState(string detailId, RowState state);
        bool UpdateState(string detailId, RowState state,int orderNo);
        bool UpdateShow2(string detailId, int state);
        bool UpdateColumns(string viewId, int columnsCount);
        bool UpdateWeightColumnDecimalDigits(int decimalDigits);
        /// <summary>
        /// 保存界面设置
        /// </summary>
        bool saveWeightView(SWeightView sWeight, List<SWeightViewDtl> dtls);
        void saveWeightViewDtlShow2(SWeightViewDtl dtl);
        void saveWeightViewDtlRowState(SWeightViewDtl dtl);
        void saveWeightViewDtlColIndex(SWeightViewDtl dtl);
        void saveWeightViewDtlRowIndex(SWeightViewDtl dtl);
        /// <summary>
        /// 修改自动保存
        /// </summary>
        /// <param name="dtl"></param>
        void saveWeightViewDtlAutoSaveState(SWeightViewDtl dtl);
        /// <summary>
        /// 修改驻留状态
        /// </summary>
        /// <param name="dtl"></param>
        void saveWeightViewDtlStayState(SWeightViewDtl dtl);
    }
}
