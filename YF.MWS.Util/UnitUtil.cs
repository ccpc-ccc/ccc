using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;

namespace YF.MWS.Util
{
    public class UnitUtil
    {
        /// <summary>
        /// 单位换算值
        /// </summary>
        /// <param name="sourceUnit">原单位</param>
        /// <param name="targetUnit">目标单位</param>
        /// <param name="sourceValue">原来的数值</param>
        /// <returns></returns>
        public static decimal GetValue(DeviceCfg device,decimal sourceValue) 
        {
            return GetValue(device.SUnit,device.DUnit,sourceValue);
        }
        /// <summary>
        /// 单位换算值 sunit:原单位,dunit:目标单位,sourceValue:原来的数值
        /// </summary>
        /// <returns>换算后的数值</returns>
        public static decimal GetValue(string sunit,string dunit,decimal sourceValue) 
        {
            decimal val = sourceValue;
            MeasureUnitType sourceMeasureUnit = MeasureUnitType.Kg;
            MeasureUnitType selfMeasureUnit = MeasureUnitType.Kg; 
            if (!string.IsNullOrEmpty(dunit) &&(dunit.ToLower() == "ton" || dunit.ToLower() == "dun"))
            {
                sourceMeasureUnit = MeasureUnitType.Ton;
            }
            if (!string.IsNullOrEmpty(sunit) &&(sunit.ToLower() == "ton" || sunit.ToLower() == "dun"))
            {
                selfMeasureUnit = MeasureUnitType.Ton;
            }
            if (sourceValue != 0) 
            {
                if (sourceMeasureUnit != selfMeasureUnit) 
                {
                    if (sourceMeasureUnit == MeasureUnitType.Ton && selfMeasureUnit == MeasureUnitType.Kg) 
                    {
                        val = 1000 * sourceValue;
                    }
                    if (sourceMeasureUnit == MeasureUnitType.Kg && selfMeasureUnit == MeasureUnitType.Ton)
                    {
                        val = sourceValue/1000;
                    }
                }
            }
            return val;
        }

        /// <summary>
        /// 文件转换成Base64字符串
        /// </summary>
        /// <param name="fileName">文件绝对路径</param>
        /// <returns></returns>
        public static string FileToBase64(string fileName) {
            string strRet = "";
            try {
                if(File.Exists(fileName)) {
                    byte[] bytes = File.ReadAllBytes(fileName);
                    strRet = Convert.ToBase64String(bytes);
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                strRet = "";
            }
            return strRet;
        }
        /// <summary>
        /// Base64字符串转换成文件
        /// </summary>
        /// <param name="strInput">base64字符串</param>
        /// <param name="fileName">保存文件的绝对路径</param>
        /// <returns></returns>
        public static bool Base64ToFileAndSave(string strInput, string fileName) {
            bool bTrue = false;
            try {
                byte[] buffer = Convert.FromBase64String(strInput);
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                bTrue = true;
            } catch (Exception ex) {

            }
            return bTrue;
        }
    }
}
