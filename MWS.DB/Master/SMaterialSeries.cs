using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    public class SMaterialSeries
    {
        public virtual string Id { get; set; }
        public virtual string MaterialId { get; set; }
        public virtual string SeriesName { get; set; }
        public virtual decimal MinWeight { get; set; }
        public virtual decimal MaxWeight { get; set; }
    }
}
