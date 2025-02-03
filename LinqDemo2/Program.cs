namespace LinqDemo1
{
    using Day_01_G01;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
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

            #region Quantifier Operators
            #region Any
            Console.WriteLine(ProductList.Any(p=>p.UnitsInStock==0));
            #endregion

            #region ALL
            Console.WriteLine(ProductList.All(p => p.UnitsInStock == 0));
            #endregion
            #region Contains
            Console.WriteLine(ProductList.Contains(ProductList[0]));
            #endregion

            #region SequenceEqual
            var seq1 = Enumerable.Range(0, 100);
            var seq2 = Enumerable.Range(0, 100);
            Console.WriteLine(seq1.SequenceEqual(seq2));
            #endregion
            #endregion


            #region  Transformation Opertors - Zip Opertor
            List<string> Words = new List<string>() { "Ten", "Twenty", "Thirty", "Fourty" };
            int[] Numbers = [10, 20, 30, 40, 50, 60];
            var res6 = Words.Zip(Numbers);
            var res7 = Words.Zip(Numbers, (w, n) => $"{w}={n}");


            #endregion

            #region Group Operators
            #region Example 01
            var res8 = from P in ProductList
                       group P by P.Category;


            res8 = ProductList.GroupBy(p => p.Category);


            foreach (var group in res8)
            {
                Console.WriteLine(group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine($">> {product}");
                }
            }

            #endregion

            #region Example 02
            var res9 = from P in ProductList
                         where P.UnitsInStock > 0
                         group P by P.Category
                         into prdoductGroup
                         where prdoductGroup.Count() > 10
                         select new { Category = prdoductGroup.Key, Count = prdoductGroup.Count() };


            res9 = ProductList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category).Where(g => g.Count() > 10).Select(g => new { Category= g.Key, Count = g.Count() });

            foreach (var item in res9 )
            {
                Console.WriteLine(item);
            }
            #endregion


            #endregion

            #region Partition
            var res10 = ProductList.Where(p => p.UnitsInStock > 0).Take(10);
             res10 = ProductList.Where(p => p.UnitsInStock > 0).TakeLast(10);



             res10 = ProductList.Where(p => p.UnitsInStock > 0).Skip(10);
             res10 = ProductList.Where(p => p.UnitsInStock > 0).SkipLast(10);



            int[] numbers = { 5, 4, 1, 3, 9, 8, 7, 5 };

            var res11 = numbers.SkipWhile((n, i) => n > i);

             res11 = numbers.TakeWhile((n, i) => n > i);


            #endregion

            #region Let & Into

            List<string> Names = new List<string>() { "omar", "Ali", "Sally", "Mohammed" };
            // A , E , I , O , U
            var res12 = from N in Names
                        select Regex.Replace(N, "[AEIOUaeiou]", string.Empty)
                          into noVowels
                        where noVowels.Length > 3
                        select noVowels;

            var res13 = from N in Names
                        let noVowels =  Regex.Replace(N, "[AEIOUaeiou]", string.Empty)
                        where noVowels.Length > 3
                        select noVowels;


           

            #endregion


        }
    
    }
}
