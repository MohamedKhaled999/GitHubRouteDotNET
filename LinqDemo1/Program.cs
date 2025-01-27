namespace LinqDemo1
{
    using static Day_01_G01.ListGenerator;
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>() { 1,2,3,4,5,6,7,9};


            #region Fluent
           var res =  list .Where(x => x %2 == 0);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            #endregion


            #region Query
            res = from item in list
                  where item %2==0
                  select item;

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }


            #endregion

            #region defferd excution

             res = list.Where(x => x % 2 == 1);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region immedate excution

            res = list.Where(x => x % 2 == 1).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region Filtration 
            var InStockCostMoreThan3 = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            InStockCostMoreThan3 = from p in InStockCostMoreThan3
                                   where p.UnitsInStock > 0 && p.UnitPrice > 3
                                   select p;

            foreach (var item in InStockCostMoreThan3)
            {
                Console.WriteLine(item);
            }



            // get the top 10 ele (out of stock)

            var outStock = ProductList.Where((p, i) => i < 10 && p.UnitsInStock == 0);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }



            #endregion


            #region Select




            var Result = from P in ProductList
                         select P.ProductName;

            Result = ProductList.Select(p => p.ProductName);    

            foreach (var item in Result)
            {
                Console.WriteLine(item);
            }
            #endregion


            #region selectMany
            var orders = CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500);

            orders = from c in CustomerList
                     from o in c.Orders
                     where o.Total < 500
                     select o;
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
            #endregion


            #region Ordering Operators
            #region Select Get Products Ordered By Price Asc
            var Result2 = ProductList.OrderBy(P => P.UnitPrice); 
             Result2 = ProductList.OrderByDescending(P => P.UnitPrice).ThenBy(p=>p.ProductID);

            Result2 = from P in ProductList
                      orderby P.ProductName, P.UnitPrice descending
                      select P;
            
            foreach (var item in Result2)
            {
            
                Console.WriteLine(item);
            }


            #endregion
            #endregion

            #region Reverse
            var Result5 = ProductList.Where(p => p.UnitsInStock == 0).Reverse();

            foreach (var item in Result5)
            {
                Console.WriteLine(item);
            }

            #endregion




        }
    }
}
