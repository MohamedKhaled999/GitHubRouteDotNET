using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.interfaces
{
    internal interface IRectangle : IShape
    {
        double Width { get; set; }
        double Height { get; set; }

        bool test() { return false; }
    }
}
