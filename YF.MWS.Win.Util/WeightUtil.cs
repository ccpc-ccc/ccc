using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Partner;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Configuration;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 称重工具类
    /// </summary>
    public class WeightUtil
    {
        public static TPWeight GetTPWeight(string materialName, string receiverName, string deliveryName, string picUrl) 
        {
            TPWeight weight = new TPWeight();
            weight.DeliveryName = deliveryName;
            weight.MaterialName = materialName;
            weight.PicUrl = picUrl;
            weight.ReceiverName = receiverName;
            return weight;
        }

        public static decimal GetMaxWeight(string carNo) 
        {
            decimal maxWeight = 0;
            if (!string.IsNullOrEmpty(carNo))
            {
                SCar car = CarCacher.GetWithCarNo(carNo);
                if (car != null)
                {
                    maxWeight = car.LimitWeight;
                }
            }
            if (maxWeight == 0)
            {
                SysCfg cfg = CfgUtil.GetCfg();
                if (cfg != null && cfg.OverWeight != null) 
                {
                    maxWeight = cfg.OverWeight.MaxWeight;
                }
            }
            return maxWeight;
        }

        public static void Calculate(QWeight weight, List<SCode> lstCode)
        {
            int axleCount = weight.AxleCount;
            if (axleCount > 6)
            {
                axleCount = 6;
            }
            SCode code = lstCode.Find(c => c.ItemCode.ToInt() == axleCount);
            if (code != null)
            {
                weight.MaxWeight = code.ItemValue.ToDecimal();
                decimal over = weight.GrossWeight - weight.MaxWeight;
                if (over < 0m)
                {
                    over = 0m;
                }
                //weight.OverWeight = over;
            }
        }

        public static void Calculate(List<QWeight> lstWeight, List<SCode> lstCode)
        {
            foreach (QWeight weight in lstWeight)
            {
                Calculate(weight, lstCode);
            }
        }

        public static void CalculateUnit(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string selftUnit = "Kg";
                string sourceUnit = dt.Rows[0]["MeasureUnit"].ToObjectString();
                dt.Rows[0]["GrossWeight"] = UnitUtil.GetValue(sourceUnit, selftUnit, dt.Rows[0]["GrossWeight"].ToDecimal());
                dt.Rows[0]["SuttleWeight"] = UnitUtil.GetValue(sourceUnit, selftUnit, dt.Rows[0]["SuttleWeight"].ToDecimal());
                dt.Rows[0]["TareWeight"] = UnitUtil.GetValue(sourceUnit, selftUnit, dt.Rows[0]["TareWeight"].ToDecimal());
                dt.Rows[0]["NetWeight"] = UnitUtil.GetValue(sourceUnit, selftUnit, dt.Rows[0]["NetWeight"].ToDecimal());
            }
        }

        /// <summary>
        /// 五舍六入
        /// </summary>
        /// <param name="org">原始数据</param>
        /// <param name="len">要计算的小数位数</param>
        /// <returns></returns>
        public static int RoundFiveWithSix(string org, int len)
        {

            int xsr = 0;//小数部分计算结果
            int zsr = 0;//整数部分

            //小数，判断len长度相对小数部分的长度
            if (org.IndexOf(".") > -1)
            {
                var strs = org.Split('.');
                zsr = int.Parse(strs[0]);
                var xsstr = strs[1];//小数部分数字的字符串

                if (len > xsstr.Length)
                {
                    //要求的部分比实际长，不处理，按原数字计算
                }
                else
                {

                    //要求的部分没有实际长，截取字符串处理
                    xsstr = xsstr.Substring(0, len);
                }
                //将小数部分转成整数比较好处理

                int xsint = int.Parse(xsstr);
                int xsfirst = int.Parse(xsstr[0].ToString());

                if (xsfirst < 5)
                {
                    xsr = 0;
                }
                else if (xsfirst > 5)
                {
                    xsr = 1;
                }
                else
                {//仅当小数第一位是5的时候计算
                    //从最后一位小数开始计算
                    int ii = 0; //标识计算小数部分的第几位数（int类型，从个位开始）
                    int max_idx = xsstr.Length - 1;
                    for (int i = max_idx; i > 0; i--)
                    {
                        //if (i == len) break;
                        int num = int.Parse(xsstr[i].ToString());
                        ii += 1;
                        if (num < 6)
                        {
                            //舍去，什么也不做
                        }
                        else if (num > 5)
                        {
                            xsint = xsint + int.Parse(Math.Pow(10, ii).ToString());
                            xsstr = xsint.ToString();
                        }
                    }

                    //循环完了再看小数第一位
                    xsfirst = int.Parse(xsstr[0].ToString());
                    if (xsfirst < 6)
                    {
                        xsr = 0;
                    }
                    else if (xsfirst > 5)
                    {
                        xsr = 1;
                    }
                }
            }
            else
            { //非小数,直接忽略len参数
                zsr = int.Parse(org);
            }
            return Cint(zsr + xsr);
        }

        private static int Cint(int org)
        {
            int rv = org % 10;
            if (rv < 6)
            {
                return (org / 10) * 10;
            }
            else
            {
                return (org / 10) * 10 + 10;
            }
        }


    }
}
