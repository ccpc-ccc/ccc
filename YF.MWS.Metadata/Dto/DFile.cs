using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Configuration;
using Newtonsoft.Json;

namespace YF.MWS.Metadata.Dto
{
    public class DFile
    {
        /// <summary>
        /// 文件所属的业务类型
        /// 视频:Video,图片:Graphic 运单:Waybill
        /// </summary>
        /// 
        [JsonProperty("businessType")]
        public string BusinessType { get; set; }
        /// <summary>
        /// 原文件路径
        /// </summary>
        /// 
        [JsonIgnore()]
        public string FileUrl { get; set; }

        /// <summary>
        /// 缩略图路径
        /// </summary>
        /// 
        [JsonProperty("url")]
        public string Url 
        { 
            get 
            {
                return string.Format("{0}{1}", AppSetting.GetValue("domain"), FileUrl);
            } 
        }

        public string RecId { get; set; }
        public string FileId { get; set; }
    }
}
