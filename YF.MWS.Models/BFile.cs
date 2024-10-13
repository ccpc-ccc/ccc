using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Models
{
    /// <summary>
    /// 附件实体类
    /// </summary>
    public class B_File : BaseEntity
    {
        public string? CompanyId { get; set; }
        public string? TableName { get; set; }
        public string? RecId { get; set; }
        /// <summary>
        /// 文件所属的业务类型
        /// 视频:Video,图片:Graphic 运单:Waybill
        /// </summary>
        public string? BusinessType { get; set; }
        /// <summary>
        /// 文件扩展名(去掉符号“.”)
        /// </summary>
        public string? FileExtension { get; set; }

        /// <summary>
        /// 原文件路径
        /// </summary>
        public string? FileUrl { get; set; }
        
        /// <summary>
        /// 缩略图路径
        /// </summary>
        public string? ThumbnailUrl { get; set; }
        public long? FileSize { get; set; }
        public int? SyncState { get; set; }
        public string? serverUrl { get; set; }
        [SugarColumn(IsIgnore = true)]
        public string? FileContent { get; set; }

    }
}
