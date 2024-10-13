using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    public class SMaterialSeries
    {
        public string? Id { get; set; }
        public string? MaterialId { get; set; }
        public string? SeriesName { get; set; }
        public decimal? MinWeight { get; set; }
        public decimal? MaxWeight { get; set; }
    }
}
