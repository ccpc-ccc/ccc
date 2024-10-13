namespace YF.MWS.Models.Query {
    public class QueryUser:S_User {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string? CompanyCode { get; set; }
    }
    public class QueryPwd { 
        public string? Id { get; set; }
        public string? UserPwd { get; set; }
        public string? NewPwd { get; set; }
    }
}
