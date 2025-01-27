namespace GitHub
{
    using Day_01_G01;
    using static Day_01_G01.ListGenerator;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region  Restriction Operators


            #region  1.Find all products that are out of stock.

            var outOfStock = ProductList.Where(p => p.UnitsInStock == 0);


            outOfStock = from p in outOfStock   
                         where p.UnitsInStock == 0
                         select p;


            foreach (var item in outOfStock)
            {
                Console.WriteLine(item);
            }


            #endregion
            #region  2. Find all products that are in stock and cost more than 3.00 per unit.

            Console.WriteLine("\n\n\n\n\n2. Find all products that are in stock and cost more than 3.00 per unit.");
            var InStockCostMoreThan3 = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            InStockCostMoreThan3 = from p in InStockCostMoreThan3
                                   where p.UnitsInStock > 0 && p.UnitPrice > 3
                                   select p;

            foreach (var item in InStockCostMoreThan3)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region  3. Returns digits whose name is shorter than their value.
            Console.WriteLine("\n\n\n\n\n 3.Returns digits whose name is shorter than their value.");

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


            var nums = Arr.Where((n, i) => n.Length < i);

            


            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }


            #endregion



            #endregion

            #region  Ordering Operators

            #region   Sort a list of products by name

            Console.WriteLine("\n\n\n\n\nSort a list of products by name");

            var productsByName = ProductList.OrderBy(p => p.ProductName);

            productsByName = from p in productsByName
                             orderby p.ProductName
                             select p;

            foreach (var item in productsByName)
            {
                Console.WriteLine(item);
            }


            #endregion
            #region Uses a custom comparer to do a case-insensitive sort of the words in an array.

            Console.WriteLine("\n\n\n\n\nUses a custom comparer to do a case-insensitive sort of the words in an array.");
            string[] Arr2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var items3 = Arr2.Order(StringComparer.OrdinalIgnoreCase);

            items3 = from p in items3
                     orderby p.ToLower() 
                     select p;

            foreach (var item in items3)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region  3.Sort a list of products by units in stock from highest to lowest.

            Console.WriteLine("\n\n\n\n\nSort a list of products by units in stock from highest to lowest.\r\n");

            var items4 = ProductList.OrderByDescending(p => p.UnitPrice);


            items4 = from p in items4
                     orderby p.UnitPrice
                     select p;

            foreach (var item in items4)
            {
                Console.WriteLine(item);
            }


            #endregion


            #region  4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.


            Console.WriteLine("\n\n\n\n\n 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.\r\n");

            string[] Arr3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var items5 = Arr3.OrderBy(p => p.Length).ThenBy(p => p);

            items5 = from p in items5
                     orderby p.Length,p
                     select p;

            foreach (var item in items5)
            {
                Console.WriteLine(item);
            }


            #endregion



            #region  5. Sort first by word length and then by a case-insensitive sort of the words in an array.


            Console.WriteLine("\n\n\n\n\n 5. Sort first by word length and then by a case-insensitive sort of the words in an array.\r\n");

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var items6 = Arr3.OrderBy(p => p.Length).Order(StringComparer.OrdinalIgnoreCase);

            items6 = from p in items6
                     orderby p.Length,p.ToLower()
                     select p;




            foreach (var item in items6)
            {
                Console.WriteLine(item);
            }


            #endregion


            #region  6. Sort a list of products, first by category, and then by unit price, from highest to lowest.



            Console.WriteLine("\n\n\n\n\n 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.\r\n");


            var items7 = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            items7 = from p in items7
                     orderby p.Category,p.UnitPrice descending
                     select p;


            foreach (var item in items7)
            {
                Console.WriteLine(item);
            }


            #endregion


            #region  7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.


            Console.WriteLine("\n\n\n\n\n 7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.\n");
            string[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };


            var items8 = Arr4.OrderBy(p => p.Length).ThenByDescending(p => p, StringComparer.OrdinalIgnoreCase);

            items8 = from p in items8
                     orderby p.Length,p.ToLower() descending
                     select p;


            foreach (var item in items8)
            {
                Console.WriteLine(item);
            } 


            #endregion


            
             #region 8 .Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.



            Console.WriteLine("\n\n\n\n\n 8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.\r\n\n");
            string[] Arr5 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


            var items9 = Arr5.Where(p => p[1] == 'i').Reverse();

            items9 = (from p in items9
                     where p[1] == 'i'
                     select p).Reverse();
                     


            foreach (var item in items9)
            {
                Console.WriteLine(item);
            }


            #endregion


            #endregion

            #region Transformation Operators


            #region  Return a sequence of just the names of a list of products.
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("Return a sequence of just the names of a list of products.");

            var productsNames =   ProductList.Select(p => p.ProductName);


            productsNames = from p in ProductList
                             select p.ProductName;


            foreach (var item in productsNames)
            {
                Console.WriteLine(item);   
            }


            #endregion


            #region 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).");

            var wordsVersions = words2.Select(p => new {lower=p.ToLower(),upper=p.ToUpper(),p});

            wordsVersions = from p in words2
                            select new { lower = p.ToLower(), upper = p.ToUpper(), p };


            foreach (var item in wordsVersions)
            {
                Console.WriteLine(item);
            }

            #endregion



            #region 3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.


            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.");

            var seq = ProductList.Select(p => new {price=p.UnitPrice ,p.ProductID,p.ProductName});

            seq = from p in ProductList
                  select new { price = p.UnitPrice, p.ProductID, p.ProductName };

            foreach (var item in seq)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region 4. Determine if the value of ints in an array match their position in the array.
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("4. Determine if the value of ints in an array match their position in the array.");

            int[] Arr6 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var res = Arr6.Select((n,i) => $"{n}:{n==i}");

            

            Console.WriteLine("Number: In-place?\r\n");

            foreach (var item in Arr6)
            {
                Console.WriteLine(item);    
            }
            #endregion


            #region 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine(" 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.");

            var pairs = numbersA.SelectMany(a => numbersB.Where(b => a < b).Select(b => new {a,b}));


            pairs = from a in numbersA
                    from b in numbersB
                    where a<b
                    select new { a,b};


                foreach (var pair in pairs)
                { Console.WriteLine(pair); }





            #endregion

            #region 6. Select all orders where the order total is less than 500.00.

            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine(" 6. Select all orders where the order total is less than 500.00.");

            var orders = CustomerList.SelectMany(c=>c.Orders).Where(o=>o.Total<500);

            orders = from c in CustomerList
                     from o in c.Orders
                     where o.Total < 500
                     select o;
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
            #endregion

            #region 7. Select all orders where the order was made in 1998 or later.


            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("7. Select all orders where the order was made in 1998 or later.");

            var orders2 = CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year>=1998);

            orders2 = from c in CustomerList
                      from o in c.Orders
                      where o.OrderDate.Year >= 1998
                      select o;
            foreach (var order in orders2)
            {
                Console.WriteLine(order);
            }


            #endregion

            #endregion



        }
    }
}
