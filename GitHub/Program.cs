using GitHub.models;
using static GitHub.models.BookFunctions;    ////       using static  


namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Part 1
                // In Demo project
            #endregion



            #region Part 2
            List<Book> books = new List<Book>
             {
                new Book("978-0132350884", "Clean Code", new string[] { "Robert C. Martin" }, new DateTime(2008, 8, 1), 34.99m),
                new Book("978-0201616224", "The Pragmatic Programmer", new string[] { "Andrew Hunt", "David Thomas" }, new DateTime(1999, 10, 30), 39.99m),
                new Book("978-0131103627", "The C Programming Language", new string[] { "Brian W. Kernighan", "Dennis M. Ritchie" }, new DateTime(1988, 3, 22), 45.99m)
            };

            Console.WriteLine("\n \tAll Books");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            CustomDelegateBookFun customDelegate = GetTitle;
            LibraryEngine.ProcessBook01(books, customDelegate);
            Console.WriteLine("\n--------------------------------\n");
            customDelegate = GetPrice;
            LibraryEngine.ProcessBook01(books, customDelegate);
            Console.WriteLine("\n--------------------------------\n");
            customDelegate = GetAuthors; ;
            LibraryEngine.ProcessBook01(books, customDelegate);

            Console.WriteLine("\n--------------------------------\n");

            Console.WriteLine("\n--------------------------------\n");
            
            
            LibraryEngine.ProcessBook02(books, b=>b.Title);
            Console.WriteLine("--------------------------------\n");
    
            LibraryEngine.ProcessBook02(books, b=>b.Price.ToString());
            Console.WriteLine("\n--------------------------------\n");
       
            LibraryEngine.ProcessBook02(books, b=>string.Join(" , ",b.Authors));






            #endregion




        }
    }
}
