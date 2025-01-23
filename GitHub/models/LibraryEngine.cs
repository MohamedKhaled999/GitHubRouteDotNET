using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{

    public delegate string CustomDelegateBookFun(Book B);
    internal static class LibraryEngine
    {
        public static void ProcessBook01(List<Book> bList, CustomDelegateBookFun FPtr)
        {

            foreach (Book b in bList)
            {
                Console.WriteLine( FPtr(b));
            }

        }


       
        public static void ProcessBook02(List<Book> bList, Func<Book,string> FPtr)
        {

            foreach (Book b in bList)
            {
                Console.WriteLine(FPtr(b));
            }

        }
    }
}
