namespace YF.MWS.Models.Query {
    public class QueryCustomer : S_Customer {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
