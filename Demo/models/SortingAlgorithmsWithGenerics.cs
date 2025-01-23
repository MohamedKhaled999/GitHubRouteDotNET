using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.models
{
        public delegate bool SortingTypesFuncDelegateGen<T>(T arg01, T arg02);
    internal class SortingAlgorithmsWithGenerics
    {
        
           

            


            public static void BubbleSort<T>(T[] array, SortingTypesFuncDelegateGen<T> sort)
            {
                if (array != null)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        for (int j = 0; j < array.Length - i - 1; j++)
                        {
                            if (sort(array[j], array[j + 1]))
                            {

                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }



            private static void Swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        

    }
}
