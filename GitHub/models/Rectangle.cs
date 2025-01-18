using GitHub.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{
    internal class Rectangle : IRectangle
    {
        private double _width;
        private double _height;
       public double Width { get => _width; 
            set{
                if (value >= 0) _width = value;
                else
                    throw new ArgumentOutOfRangeException("can't be less than zero");
            }
        }


        public double Height
        {
            get => _height;
            set
            {
                if (value >= 0) _height = value;
                else
                    throw new ArgumentOutOfRangeException("can't be less than zero");
            }
        }

        public Rectangle(double width=0, double height =0)
        {
            Width = width;
            Height = height;
        }

        public double Area => Width * Height;





        

        public  void DisplayShapeInfo()
        {
            Console.WriteLine($"{this.GetType().Name}  , its Area is ==> {Area}");
        }
    }
}
