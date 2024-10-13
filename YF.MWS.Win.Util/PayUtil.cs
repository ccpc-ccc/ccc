using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.Win.Util
{
    public class PayUtil
    {
        
        public static decimal GetCharge(decimal weight, FinanceCfg chargeCfg,List<SCharge> lstChargeCfg)
        {
            decimal result = 0;
            if (chargeCfg == null)
                chargeCfg = new FinanceCfg();
            if (chargeCfg.UnitPriceType == UnitPriceType.Fixed)
            {
                result = Math.Round(chargeCfg.UnitPrice * weight, 2);
                if (result < chargeCfg.MinCharge)
                    result = chargeCfg.MinCharge;
            }
            else
            {
                if (lstChargeCfg != null && lstChargeCfg.Count > 0)
                {
                    bool hasFind = false;
                    List<SCharge> lstPriceFind = lstChargeCfg.FindAll(c => c.Operator == OperatorType.Less.ToString());
                    SCharge charge = null;
                    if (lstPriceFind != null && lstPriceFind.Count > 0)
                    {
                        charge = lstPriceFind.Find(c => c.MinWeight > weight);
                        if (charge != null)
                        {
                            hasFind = true;
                            result = charge.Charge;
                        }
                    }
                    if (!hasFind)
                    {
                        lstPriceFind = lstChargeCfg.FindAll(c => c.Operator == OperatorType.Range.ToString());
                        if (lstPriceFind != null && lstPriceFind.Count > 0)
                        {
                            charge = lstPriceFind.Find(c => c.MinWeight <= weight && c.MaxWeight >= weight);
                            if (charge != null)
                            {
                                hasFind = true;
                                result = charge.Charge;
                            }
                        }
                    }
                    if (!hasFind)
                    {
                        lstPriceFind = lstChargeCfg.FindAll(c => c.Operator == OperatorType.Greater.ToString());
                        if (lstPriceFind != null && lstPriceFind.Count > 0)
                        {
                            charge = lstPriceFind.Find(c => c.MaxWeight <= weight);
                            if (charge != null)
                            {
                                hasFind = true;
                                result = charge.Charge;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
