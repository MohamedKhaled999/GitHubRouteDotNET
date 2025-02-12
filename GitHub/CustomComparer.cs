using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    internal class CustomComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x is null || y is null) return false;

            return new string(x.Trim().Order().ToArray()) == new string(y.Trim().Order().ToArray());

        }

        public int GetHashCode(string obj)
        {
            if (obj is null) return 0;

            return new string(obj.Trim().Order().ToArray()).GetHashCode();


        }
    }
}
