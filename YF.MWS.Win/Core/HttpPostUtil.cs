using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Util;
using YF.MWS.Metadata.Partner;
using System.Net;
using System.IO;
using YF.Utility.Log;
using System.Threading;
using YF.Utility;

namespace YF.MWS.Win.Core
{
    public class HttpPostUtil
    {
        public static void SendWeight(object obj) 
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(AddWeight), obj);
        }

        private static void AddWeight(object obj)
        {
            WeightObject weightObject = (WeightObject)obj;
            string res= AddWeight(weightObject.Url, weightObject.Weight);
            Logger.Write(string.Format("send weight to server,return message:{0}",res));
        }

        private static string AddWeight(string url, PWeight weight)
        {
            string res = string.Empty;
            string json = weight.JsonSerialize();
            Logger.Write(string.Format("send weight json:{0}", json));
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream dataStream = null;
            StreamReader responseStream = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                using (dataStream = request.GetRequestStream())
                {
                    dataStream.Write(bytes, 0, bytes.Length);
                }
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    if (response != null)
                    {
                        response.Close();
                        response = null;
                    }
                    if (request != null)
                    {
                        request.Abort();
                    }
                    return null;
                }
                responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                res = responseStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (dataStream != null)
                {
                    dataStream.Close();
                    dataStream.Dispose();
                    dataStream = null;
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                    responseStream = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (request != null)
                {
                    request.Abort();
                }
                Logger.WriteException(ex);
            }
            finally
            {
                if (dataStream != null)
                {
                    dataStream.Close();
                    dataStream.Dispose();
                    dataStream = null;
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                    responseStream = null;
                }
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return res;
        } 
    }
}
