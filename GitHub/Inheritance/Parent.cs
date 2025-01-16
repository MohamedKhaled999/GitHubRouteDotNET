using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Inheritance
{
    internal class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Parent(int x , int y) 
        {
            X= x;
            Y= y;
        }

        public int ProductOfNumbers()
        { 
            return X*Y;
        }
    }
}
