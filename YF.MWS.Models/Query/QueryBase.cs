namespace YF.MWS.Models.Query {
    public class QueryBase :BaseEntity{
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
