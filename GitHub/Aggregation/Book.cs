using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Aggregation
{
    internal class Book
    {
        public string? Title { get; set; }
        public Book() { Title = "C#"; }
        public Book(string title) { Title = title; }
    }
}
