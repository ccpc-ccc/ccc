using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.Utility.Configuration;
using YF.Utility.Net;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using System.IO;
using System.Net;
using YF.Utility.Log;
using YF.MWS.Db.Server;

namespace YF.MWS.SQliteService.Remote
{
    public class WebBaseService {
        public static ReturnEntity sendPost(string url, object query, string token="") {
            string res = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream dataStream = null;
            StreamReader responseStream = null;
            try {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                if (token != null && token.Length > 0) request.Headers["Authorization"] = "Bearer " + token;
                string body = query.JsonSerialize();
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                using (dataStream = request.GetRequestStream()) {
                    dataStream.Write(bytes, 0, bytes.Length);
                }
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.RequestTimeout) {
                    if (response != null) {
                        response.Close();
                        response = null;
                    }
                    if (request != null) {
                        request.Abort();
                    }
                    return null;
                }
                responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                res = responseStream.ReadToEnd();
                Logger.Write("服务器返回数据： "+res);
            } catch (Exception ex) {
                if (dataStream != null) {
                    dataStream.Close();
                    dataStream.Dispose();
                    dataStream = null;
                }
                if (responseStream != null) {
                    responseStream.Close();
                    responseStream.Dispose();
                    responseStream = null;
                }
                if (response != null) {
                    response.Close();
                    response = null;
                }
                if (request != null) {
                    request.Abort();
                }
                Logger.WriteException(ex);
            } finally {
                if (dataStream != null) {
                    dataStream.Close();
                    dataStream.Dispose();
                    dataStream = null;
                }
                if (responseStream != null) {
                    responseStream.Close();
                    responseStream.Dispose();
                    responseStream = null;
                }
                if (response != null) {
                    response.Close();
                    response = null;
                }
                if (request != null) {
                    request.Abort();
                }
            }
            return JsonUtil.JsonDeserialize<ReturnEntity>(res);
        }
    }
}
