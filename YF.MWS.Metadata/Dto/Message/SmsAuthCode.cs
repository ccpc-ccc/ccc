using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Dto
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    public class SmsAuthCode
    {
        public int AuthCode { get; set; }
        public string CompanyId { get; set; }
        public string Cellphone { get; set; }
        public string RealName { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
