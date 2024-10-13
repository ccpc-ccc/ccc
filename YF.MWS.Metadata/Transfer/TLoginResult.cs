using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class TLoginResult : Result
    {
        public int Active { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string CarId { get; set; }
        public string CarNo { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string DeptCode { get; set; }
        public string EcsServer { get; set; }
        public string MachineCode { get; set; }
        public string RoleId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
