using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    public class ViewEntry:IKeyCode
    {
        public string? Id { get; set; }

        public int? Type { get; set; }

        public string? Layerout { get; set; }

        public string? Design { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        string? IKeyCode.Key
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        string? IKeyCode.Code
        {
            get { return this.Code; }
        }
    }
}
