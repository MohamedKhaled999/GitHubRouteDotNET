namespace GitHub
{
    using Day_01_G01;
    using System.Linq;
    using System.Reflection.Metadata;
    using static Day_01_G01.ListGenerator;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region LINQ - Element Operators
            #region Get first Product out of Stock 
            Console.WriteLine("\n\nGet first Product out of Stock");
            var first= ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine(first);
            #endregion
            #region Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            Console.WriteLine("\n\n\nReturn the first product whose Price > 1000, unless there is no match, in which case null is returned.");
            first= ProductList.FirstOrDefault(p=>p.UnitPrice>1000);
            Console.WriteLine(first);
            #endregion

            #region Retrieve the second number greater than 5
            Console.WriteLine("\n\n\nRetrieve the second number greater than 5");
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var second = Arr.Where((n)=>n>5).Skip(1).FirstOrDefault();
            Console.WriteLine(second);
            #endregion



            #endregion

            #region LINQ - Aggregate Operators
            #region 1. Uses Count to get the number of odd numbers in the array
            Console.WriteLine("\n\n Uses Count to get the number of odd numbers in the array");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var odds = Arr2.Count(n => n % 2 == 1);

            foreach (var item in Arr2)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Return a list of customers and how many orders each has.
            Console.WriteLine("\n\nReturn a list of customers and how many orders each has.");
            var customrsAndOrders = CustomerList.Select(c => new { c.CustomerID,c.CustomerName,numOfOrders= c.Orders.Count()});

            foreach (var item in customrsAndOrders)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Return a list of categories and how many products each has

            Console.WriteLine("\n\n\n Return a list of categories and how many products each has");

            var categoriesAndProducts = ProductList.GroupBy(p => p.Category)
                                        .Select(g => new { Category = g.Key, Count = g.Count() });
                                        


            foreach (var item in categoriesAndProducts)
            {
                Console.WriteLine($"{item}");
            }
            #endregion


            #region Get the total of the numbers in an array.
            Console.WriteLine("\n\n\nGet the total of the numbers in an array.");
            var total = Arr.Sum();
            Console.WriteLine($"Sum is  : {total}");
            #endregion

            #region 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var dictionaryEnglish = File.ReadAllLines("dictionary_english.txt");
            var characters =  dictionaryEnglish.SelectMany(line => line.ToCharArray()).Count();


           
                Console.WriteLine($"total number of characters of all words {characters} characters");

            #endregion

            #region Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var dictionaryEnglish2 = File.ReadAllLines("dictionary_english.txt");
            var shortestWord = dictionaryEnglish2.SelectMany(line => line.Split(" ")).MinBy(w=>w.Length).Length;
            Console.WriteLine($"the length of the shortest word in dictionary_english.txt is :{shortestWord} ");

            #endregion


            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var longestWord = dictionaryEnglish2.SelectMany(line => line.Split(" ")).MaxBy(w => w.Length).Length;
            Console.WriteLine($"the length of the longest word in dictionary_english.txt is :{longestWord} ");
            #endregion


            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var avrageLength = dictionaryEnglish2.SelectMany(line => line.Split(" ")).Average(w => w.Length);
            Console.WriteLine($"the length of the Avrage word length in dictionary_english.txt is :{avrageLength} ");
            #endregion


            #region Get the total units in stock for each product category.
            var unitsPerGategory = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, untits = g.Sum(p => p.UnitsInStock) });

            Console.WriteLine($"\n\n\n Get the total units in stock for each product category.");
            foreach (var unit in unitsPerGategory) 
            {
                Console.WriteLine(unit);
            }


            #endregion

            #region 10. Get the cheapest price among each category's products
            var cheapestPerGategory = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, cheapest = g.MinBy(p => p.UnitPrice).UnitPrice });

            Console.WriteLine($"\n\n\n  10. Get the cheapest price among each category's products");

            foreach (var unit in cheapestPerGategory)
            {
                Console.WriteLine(unit);
            }
            #endregion



            #region Get the products with the cheapest price in each category (Use Let)
            var cheepPerCategory = from p in ProductList
                                   group p by p.Category into groups
                                   let cheap = groups.MinBy(p => p.UnitPrice)
                                   select new { groups.Key, price = cheap.UnitPrice };


            Console.WriteLine($"\n\n\n   Get the products with the cheapest price in each category (Use Let)");

            foreach (var unit in cheepPerCategory)
            {
                Console.WriteLine(unit);
            }


            #endregion


            #region 12. Get the most expensive price among each category's products.

            var MostExpensivePerGategory = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, MostExpensive = g.MaxBy(p => p.UnitPrice).UnitPrice });

            Console.WriteLine($"\n\n\n 12. Get the most expensive price among each category's products.");

            foreach (var unit in MostExpensivePerGategory)
            {
                Console.WriteLine(unit);
            }

            #endregion

            #region 13. Get the products with the most expensive price in each category.

            var MostExpensiveProducrPerGategory = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, MostExpensiveProduct = g.MaxBy(p => p.UnitPrice) });

            Console.WriteLine($"\n\n\n 13. Get the products with the most expensive price in each category.");

            foreach (var unit in MostExpensiveProducrPerGategory)
            {
                Console.WriteLine(unit);
            }

            #endregion



            #region 14. Get the average price of each category's products.
            var averagePerGategory = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, Average = g.Average(p => p.UnitPrice) });

            Console.WriteLine($"\n\n\n  14. Get the average price of each category's products.");

            foreach (var unit in averagePerGategory)
            {
                Console.WriteLine(unit);
            }

            #endregion
            #endregion

            #region LINQ - Set Operators
            var uniqueLetters1 = ProductList.Select(p => p.ProductName[0]);
            var uniqueLetters2 = CustomerList.Select(p => p.CustomerName[0]);
            #region 1. Find the unique Category names from Product List
            Console.WriteLine("\n\n\nFind the unique Category names from Product List");

            var unique1 = ProductList.Select(p => p.ProductName).Distinct();

            foreach (var item in unique1)
            {
                Console.Write($"{item,-50}");
            }

            #endregion

            Console.WriteLine();
            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.

            var uniqueLetters = uniqueLetters1.Union(uniqueLetters2);
            Console.WriteLine(" 2. Produce a Sequence containing the unique first letter from both product and customer names.");

            foreach (var item in uniqueLetters)
            {
                Console.Write($"{item}\t");
            }

            #endregion
            Console.WriteLine();
            #region 3.Create one sequence that contains the common first letter from both product and customer names.
            var uniqueLetters3 = uniqueLetters1.Intersect(uniqueLetters2);

            Console.WriteLine("3.Create one sequence that contains the common first letter from both product and customer names.");

            foreach (var item in uniqueLetters3)
            {
                Console.Write($"{item}\t");
            }

            #endregion


            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var uniqueLetters4 = uniqueLetters1.Except(uniqueLetters2);
            Console.WriteLine();
            Console.WriteLine("4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.");

            foreach (var item in uniqueLetters4)
            {
                Console.Write($"{item}\t");
            }

            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            var uniqueLetters5 = CustomerList.Select(c => c.CustomerName.Substring(Math.Max(0, c.CustomerName.Length - 3)));
            var uniqueLetters6 = ProductList.Select(p => p.ProductName.Substring(Math.Max(0, p.ProductName.Length - 3)));
            var lastThreeeLetters= uniqueLetters5.Concat(uniqueLetters6);
            Console.WriteLine();
            Console.WriteLine("5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates");

            foreach (var item in lastThreeeLetters)
            {
                Console.Write($"{item}\t");
            }

            #endregion




            #endregion

            #region LINQ - Partitioning Operators

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            #region 1. Get the first 3 orders from customers in Washington

            Console.WriteLine("\n\n\n Get the first 3 orders from customers in Washington");
            var firstThreeOrders = CustomerList
                                                .Where(c => c.City.ToLower() == "washington")
                                                .SelectMany(c => c.Orders)  
                                                .Take(3); 

            foreach (var item in firstThreeOrders)
            {
                Console.WriteLine(item);   
            }
            #endregion
            #region 2. Get all but the first 2 orders from customers in Washington.

            Console.WriteLine("\n\n\n2. Get all but the first 2 orders from customers in Washington.");

            var washingtonOrders = CustomerList
                                    .Where(c => c.City.ToLower() == "washington")
                                    .SelectMany(c => c.Orders)
                                    .Skip(2);

            foreach (var item in washingtonOrders)
            {
                Console.WriteLine(item);
            }


            #endregion
            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            var num3 = numbers.TakeWhile((n, i) => n >= i);

            Console.WriteLine("\n\n\n3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.");

            foreach (var item in num3)
            {

                Console.WriteLine(item);
            }
            #endregion
            #region 4.Get the elements of the array starting from the first element divisible by 3.
            var num4 = numbers.SkipWhile(n => n % 3 != 0); ;

            Console.WriteLine("\n\n\n4.Get the elements of the array starting from the first element divisible by 3.");

            foreach (var item in num4)
            {

                Console.WriteLine(item);
            }
            #endregion
            #region 5. Get the elements of the array starting from the first element less than its position.
            var num5 = numbers.SkipWhile((n,i) => n >=i ); ;

            Console.WriteLine("\n\n\n5. Get the elements of the array starting from the first element less than its position.");

            foreach (var item in num5)
            {

                Console.WriteLine(item);
            }
            #endregion
            #endregion


            #region LINQ - Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            var dictionaryEnglish3 = File.ReadAllLines("dictionary_english.txt");
            Console.WriteLine();
            Console.WriteLine("\n\n\n1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.");

            Console.WriteLine(dictionaryEnglish3.SelectMany(d => d.Split(" ")).Any(w => w.Contains("ei")));




            #endregion
            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            Console.WriteLine("\n\n2. Return a grouped a list of products only for categories that have at least one product that is out of stock.");
             var groupedListOfProductsOnly=                 ProductList.GroupBy(p => p.Category).
                                                                                Where(g => g.Any(p => p.UnitsInStock == 0)).
                                                                                Select(g=> new { g.Key ,Products=string.Join(",",g.Select(p => p.ProductName).ToArray()) });

            foreach (var item in groupedListOfProductsOnly)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Products);
            }
            #endregion
            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

            Console.WriteLine("\n\n3. Return a grouped a list of products only for categories that have all of their products in stock.");
            var groupedListOfProductsAll = ProductList.GroupBy(p => p.Category).
                                                                               Where(g => g.All(p => p.UnitsInStock != 0)).
                                                                               Select(g => new { g.Key, Products = string.Join(",", g.Select(p => p.ProductName).ToArray()) });

            foreach (var item in groupedListOfProductsAll)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Products);
            }
            #endregion
            #endregion
        }
    }
}
