using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Enums
{

    [Flags]
    internal enum SecurityLevel
    {
        None = 0,
        Guest=1,
        Developer=2,
        Secretary=4,
        DBA=8
    }
}
