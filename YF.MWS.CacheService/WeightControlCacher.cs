using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.Utility.Cache;

namespace YF.MWS.CacheService
{
    /// <summary>
    /// 
    /// </summary>
    public class WeightControlCacher {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SControl> Remove(List<SControl> list,List<SWeightViewDtl>dtl)
        {
            List<SControl> controls = new List<SControl>();
            list.ForEach(c=>controls.Add(c));
            foreach (SControl control in list) {
                foreach(SWeightViewDtl sWeightViewDtl in dtl) {
                    if (control.Id == sWeightViewDtl.ControlId) {
                        controls.Remove(control);
                        break;
                    }
                }
            }
            return controls;
        }
        public static bool saveWeightView(SWeightView sWeight, List<SWeightViewDtl> dtls) {
            IWeightViewService weightViewService = new WeightViewService();
            if (sWeight.Id != null && sWeight.Id != "") {
                List<SWeightViewDtl> olds=weightViewService.GetAllDetailList(sWeight.Id);
                List<string> sqls=new List<string>();
                foreach(SWeightViewDtl dtl in dtls) {
                    foreach (SWeightViewDtl old in olds) {
                        if (old.FieldName == dtl.FieldName) {
                            sqls.Add(string.Format("update S_WeightViewDtl Caption set OrderNo='{0}',ControlName='{1}',Caption='{2}',RowState=1 where ControlId='{3}' and ViewId='{4}'"));
                        }
                    }
                }
            } else {
                sWeight.Id = Guid.NewGuid().ToString("N");
                int i = 0;
                foreach (SWeightViewDtl dtl in dtls) {
                    i++;
                    dtl.ViewId = sWeight.Id;
                    dtl.OrderNo = i;
                    weightViewService.SaveViewDetail(dtl);
                }
            }
            return weightViewService.SaveView(sWeight);
        }

    }
}
