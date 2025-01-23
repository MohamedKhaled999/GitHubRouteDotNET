using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.models
{
    internal class SortingTypes
    {

        public static bool SortAsc(string X, string Y) { return X?.Length > Y?.Length; } 
        public static bool SortDec(string X, string Y) { return X?.Length < Y?.Length; } 
        public static bool CompareGrt(int X, int Y)
        {
            return X > Y;
        }


        public static bool CompareLess(int X, int Y)
        {
            return X < Y; 
        }
    }
}
