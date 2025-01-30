namespace LinqDemo1
{
    using Day_01_G01;
    using System.Collections.Generic;
    using static Day_01_G01.ListGenerator;
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Elements Operator
            #region First-Last
            //var Result = ProductList.first();
            // Get First Element At Sequence
            //var Result = ProductList.Last();
            // Get Last Element At Sequence
            // Get First Element At Sequence
            //List<Product> TestProduct = new List<Product>();
            //var Result = TestProduct.First();
            //var Result = TestProduct.Last();
            // First And Last May Throw Exception => if The Sequence Is Empty

            // var Result = ProductList.First(P => P.UnitsInStock == 0);
            // Console.WriteLine(Result);
            #endregion

            #region FirstOrDefault-LastOrDefault
            // List<Product> TestProduct = new List<Product>();
            // var Result = TestProduct.FirstOrDefault();
            // var Result = TestProduct.FirstOrDefault();
            // Get First Element In Sequence If Sequence Is Empty Will Return Null
            // var Result = TestProduct.LastOrDefault();
            // Get Last Element In Sequence If Sequence Is Empty Will Return Null
            // Console.WriteLine(Result?.ProductName ?? "Not Found");
            #endregion

            #region Element At - Element At Or Default
            //var Result = ProductsList.ElementAt(77);
            //System.ArgumentOutOfRangeException: Index was out of range.
            //
            //var Result = ProductList.ElementAtOrDefault(77);
            //Console.WriteLine(Result?.ProductName ?? "Not Found");

            #endregion

            #region Single-SingleOrDefault
            // var Result = ProductsList.Single(P => P.UnitsInStock == 0);
            // Single Will Return it if Sequence Contains Only One Element Match Condition
            // if the sequence Contains More Elements Match Condition Or THE Sequence IS Empty

            //var Result = ProductsList.SingleOrDefault(P => P.UnitsInStock == 0);
            // If Sequence Contains No Elements Match Condition => Return Null
            // if Sequence Contains More Than One Element Match Condition => Throw Exception

            // Console.WriteLine(Result?.ProductName ?? "NOT found");
            #endregion

            #endregion


            #region Aggregate Operators


            #region Min=MAX
            // var Result = ProductsList.Min();
            // System.ArgumentException: At least one object must implement IComparable

            //var Result = ProductsList.Max(); Console.WriteLine(result);
            // var MinLength = ProductList.Min(P => P.ProductName.Length);
            //Console.WriteLine(MinLength);
            // Hybrid Syntax
            /*
            var Result = (from P in ProductList
                          where P.ProductName.Length == MinLength
                          select P).FirstOrDefault();
            */
            #endregion
            #region Average-Sum
            //var Result = ProductsList.Sum(P => P.UnitPrice); // 2222.7100
            // var Result = ProductList.Average(P => P.UnitPrice); // 28.8663636363636363636363636363600
            //Console.WriteLine(Result);
            #endregion

            #region Aggregate
            /* string[] Names = { " Aya", " Omar", " Amr", " Mohammed" };
             var Result = Names.Aggregate((str01, str02) => $"{str01} {str02}");
             Console.WriteLine(Result);
             */
            #endregion



            #endregion

            #region Casting [Conversion] Operators

            //List<Product> Result = ProductList.Where(P => P.UnitsInStock == 0).ToList();
            // Product[] Result = ProductList.Where(P => P.UnitsInStock == 0).ToArray();


            //Dictionary<long, string> Result = Product<List.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductID, P => P.ProductName);

            //HashSet<Product> Result = Product<List.Where(P => P.UnitsInStock == 0).ToHashSet();
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}
            //



            #endregion


            #region Generation Operators - Deferred Execution
            //var Result = Enumerable.Range(0, 100);//0-99
            // var Result = Enumerable.Repeat(2, 100);
            //var Result = Enumerable.Repeat(new Product(), 100);
            // Return IEnumerable Of 100 element Product
            //---
            /*  var Result = Enumerable.Empty<Product>().ToArray();
              // Will Generate An Empty Array Of Product

              foreach (var item in Result)
              {
                  Console.Write($" {item}\t");
              }
            */
            #endregion

            #region Set Operators [Union Family]
            var Seq01 = Enumerable.Range(0, 100); // 0-99
            var Seq02 = Enumerable.Range(50, 100); // 50-149
            var Result = Seq01.Union(Seq02);
            var Result2 = Seq01.Concat(Seq02);
            var Result3 = Seq01.Except(Seq02);

           /* 
            foreach (var item in Result)
            {
                Console.Write($"{item}\t");
            }

            foreach (var item in Result2)
            {
                Console.Write($"{item}\t");
            }

            foreach (var item in Result3)
            {
                Console.Write($"{item}\t");
            }*/

            #endregion

           



        }
    }
}
