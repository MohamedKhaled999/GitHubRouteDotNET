using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    internal class Range<T>where T:IComparable<T>,ISubtractionOperators<T,T,T>
    {
        public T Minimum { get;  }

        public T Maximum { get;  }

        //private  List<T> _values;

        public Range(T min,T max)
        {
            if (min.CompareTo(max) < 0)
            {
                Minimum = min;
                Maximum = max;
            }
            else
                throw new("Invalid Inputs");

        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(Minimum) >= 0 && value.CompareTo(Maximum) <= 0;
        }


        public T Length()
        {
           return Maximum - Minimum;
           // return 0;
        }
       
    }
}
