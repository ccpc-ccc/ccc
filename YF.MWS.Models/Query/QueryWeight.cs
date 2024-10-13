namespace YF.MWS.Models.Query {
    public class QueryWeight : B_Weight {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string? MaterailName { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string? CustomerName { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string? WarehName { get; set; }
        /// <summary>
        /// 终端ID
        /// </summary>
        public string? ClientId { get; set; }
        /// <summary>
        /// 文件内容
        /// </summary>
        public string? FileContent { get; set; }
    }
}
