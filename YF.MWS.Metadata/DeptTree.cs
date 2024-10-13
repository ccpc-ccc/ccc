﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata
{
    public class DeptTree : SDept
    {
        public virtual List<DeptTree> children { get; set; }

        public virtual bool status { get; set; }
    }
}
