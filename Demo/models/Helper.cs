using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.models
{
    internal class Helper<T>
    {
        public static List<T> Find(List<T> Numbers,Func<T, bool> func)
        {
            List<T> Result = new List<T>();
            if (Numbers != null)
            {
                for (int i = 0; i < Numbers.Count; i++)
                {
                    if (func(Numbers[i]))
                    {
                        Result.Add(Numbers[i]);
                    }
                }
            }
            return Result;
        }

    }
}
