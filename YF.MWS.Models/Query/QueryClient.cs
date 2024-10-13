namespace YF.MWS.Models.Query {
    public class QueryClient : S_Client {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string? CompanyCode { get; set; }
    }
}
