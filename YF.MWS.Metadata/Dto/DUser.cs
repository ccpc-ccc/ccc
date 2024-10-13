using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Dto
{
    public class DUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UserTypeName
        { 
            get
            {
                return EnumUtil.GetEnumDescription(UserType.ToEnum<UserType>());
            } 
        }
    }
}
