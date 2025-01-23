using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.models
{
    public delegate bool SortingTypesFuncDelegate(int arg01, int arg02);
    internal class SortingAlgorithms
    {
        public static void BubbleSortAsc(int[] array)
        {
            if (array != null)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }

        public static void BubbleSortDec(int[] array )
        {
            if (array != null)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j] < array[j + 1])
                        {

                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }



        public static void BubbleSort(int[] array , SortingTypesFuncDelegate sort)
        {
            if (array != null)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (sort(array[j] , array[j + 1]))
                        {

                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }
        }



        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
