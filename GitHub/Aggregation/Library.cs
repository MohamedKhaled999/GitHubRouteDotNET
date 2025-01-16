using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Aggregation
{
    internal class Library
    {
        List<Book> books = new List<Book>();
        public Library() { }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
