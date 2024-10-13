using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    public interface IKeyCode
    {
        string Key { get; set; }

        string Code { get; }
    }
}
