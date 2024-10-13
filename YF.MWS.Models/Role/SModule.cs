using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 模块定义信息
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    /// 
    public class S_Module : BaseEntity
    {
        public string? ParentId { get; set; }
        public string? Platform { get; set; }
        public string? ModuleName { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? ActionName { get; set; }
        public string? ModuleType { get; set; }
        public string? LinkUrl { get; set; }
        public string? Title { get; set; }
        public string? Permiss { get; set; }
        public int? OrderNo { get; set; }
        public string? Icon { get; set; }
        public int? SuperTipState { get; set; }
        public string? SuperTipContent { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(ParentId))]
        public S_Module? Parent { get; set; }
    }
}
