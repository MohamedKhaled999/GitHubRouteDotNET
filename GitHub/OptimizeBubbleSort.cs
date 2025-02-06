using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    internal static class OptimizeBubbleSort<T> where T : IComparable<T>
    {


        public static void Sort(ref List<T> list)
        {
            bool isSwaped;
            for (int i = 0; i < list.Count; i++)
            {
                isSwaped = false;
                for (int  j = 0; j < list.Count-1-i ; j++)
                {
                    if (list[j].CompareTo(list[j + 1])>0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                        isSwaped = true;
                    }
                }

                if (!isSwaped) break;
            }

        }


    }
}
