using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.ECS.Db
{
    /// <summary>
    /// 附件实体类
    /// </summary>
    public class BFile : BaseEntity
    {
        [Field(IsSqliteIgnore = true)]
        public virtual string CompanyId { get; set; }
        [Field(IsSqliteIgnore = true)]
        public virtual string FileContent { get; set; }
        public virtual string TableName { get; set; }
        public virtual string RecId { get; set; }
        /// <summary>
        /// 文件所属的业务类型
        /// 视频:Video,图片:Graphic 运单:Waybill
        /// </summary>
        public virtual string BusinessType { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public virtual int FileType { get; set; }
        /// <summary>
        /// 文件扩展名(去掉符号“.”)
        /// </summary>
        public virtual string FileExtension { get; set; }

        /// <summary>
        /// 原文件路径
        /// </summary>
        public virtual string FileUrl { get; set; }
        
        /// <summary>
        /// 缩略图路径
        /// </summary>
        public virtual string ThumbnailUrl { get; set; }
        public virtual long FileSize { get; set; }
        public virtual int SyncState { get; set; }
        
    }
}
