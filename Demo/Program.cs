using Demo.models;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region without Gen
            int[] Numbers = { 4, 2, 1, 5, 8 };
            SortingAlgorithms.BubbleSort(Numbers, SortingTypes.CompareGrt);
            foreach (int number in Numbers)
            {
                Console.WriteLine($"{number}");
            }

            SortingAlgorithms.BubbleSort(Numbers, SortingTypes.CompareLess);
            foreach (int number in Numbers)
            {
                Console.WriteLine($"{number}");
            }

            #endregion


            #region with Generics
            string[] Names = { "Ali", "Mohammed", "Omar", "Mai" };

         
            SortingAlgorithmsWithGenerics.BubbleSort(Names, SortingTypes.SortDec);
            Console.WriteLine("Sorted Descending by Length:");
            foreach (string name in Names)
            {
                Console.WriteLine(name);
            }


            #endregion


            #region Generics +lambada + buildin delegates 
            List<int> nums = new List<int>() { 1, 2, 3, 4, 8, 7 };
           var res =  Helper<int>.Find(nums, n => n % 2 == 0);

            Console.WriteLine("-------------------\n\n");
            foreach (var n in res)
            {
                Console.WriteLine(n);
            }

            #endregion


        }
    }
}
