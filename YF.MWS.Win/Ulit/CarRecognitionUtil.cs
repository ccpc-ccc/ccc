using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Metadata.CarPlate;
using YF.Utility;

namespace YF.MWS.Win
{
    /// <summary>
    /// 车牌识别工具类
    /// </summary>
    public class CarRecognitionUtil
    {
        /// <summary>
        /// 是否是重复识别的结果
        /// </summary>
        /// <param name="recognitionTimeSpan"></param>
        /// <param name="result"></param>
        /// <param name="lstRecognitionResult"></param>
        /// <returns></returns>
        private static bool IsRepeated(int recognitionTimeSpan, RecognitionResult result, List<RecognitionResult> lstRecognitionResult) 
        {
            bool isRepeated = false;
            RecognitionResult find = null;
            if (lstRecognitionResult != null && lstRecognitionResult.Count > 0) 
            {
                find = lstRecognitionResult.Find(c => c.CarNo == result.CarNo);
            }
            if (find != null) 
            {
                DateTime expiredTime = find.RecognitionTime.AddMinutes(recognitionTimeSpan);
                if (DateTime.Compare(result.RecognitionTime, expiredTime) <= 0) 
                {
                    isRepeated = true;
                }
            }
            return isRepeated;
        }

        public static List<RecognitionResult> RefreshResult(List<RecognitionResult> lstRecognitionResult, int recognitionTimeSpan)
        {
            List<RecognitionResult> lstFreshedResult = new List<RecognitionResult>();
            foreach (RecognitionResult result in lstRecognitionResult) 
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtExpired = result.RecognitionTime.AddMinutes(recognitionTimeSpan);
                if (DateTime.Compare(dtNow, dtExpired) < 0) 
                {
                    lstFreshedResult.Add(result);
                }
            }
            return lstFreshedResult;
        }

        /// <summary>
        /// 验证识别的车牌号是否有效
        /// </summary>
        /// <param name="carNo"></param>
        /// <param name="startSameCarNoControl"></param>
        /// <param name="recognitionTimeSpan"></param>
        /// <returns></returns>
        public static bool IsValidateCarNo(RecognitionResult result, int recognitionTimeSpan, List<RecognitionResult> lstRecognitionResult) 
        {
            bool isValidated = false;
            string carNo = result.CarNo;
            bool isRepeated = IsRepeated(recognitionTimeSpan, result, lstRecognitionResult);
            if (!isRepeated)
            {
                isValidated = true;
            }
            return isValidated;
        }
    }
}
