using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 
 2.	Create a struct called "Point" to 
represent a 2D point with properties "X" and "Y".
Write a C# program that takes two points
as input from the user and calculates the distance between them.
 
 */

namespace GitHub
{
    internal struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double calDistance(Point other)
        {
            return Math.Sqrt(Math.Pow((this.X - other.X), 2) + Math.Pow((this.Y - other.Y), 2));
        }

       public override string ToString()
        {
            return $"P( {this.X} , {this.Y} )";
        }


    }
}
