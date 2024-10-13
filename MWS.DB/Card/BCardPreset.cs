using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// IC卡预设的数据
    /// </summary>
    public class BCardPreset:BaseEntity
    {
        public virtual string? CardId { get; set; }
        public virtual string? CvDetailId { get; set; }
        public virtual string? ControlId { get; set; }
        public virtual string PresetValue { get; set; }
    }
}
