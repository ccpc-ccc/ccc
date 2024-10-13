namespace YF.MWS.Models.Views {
    public class VPage<T> where T:BaseEntity,new() {
        public VPage() { }
        public int Total { get; set; }
        public List<T> Items { get; set; }
        public VPage(List<T> data,int total) { 
            this.Items = data;
            this.Total = total;
        }
    }
}
