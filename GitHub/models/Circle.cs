using GitHub.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{
    internal class Circle : ICircle
    {
        private double _redius;
        public double Reduis { 
            get { return _redius; }
            set { 
                if (value >= 0) _redius = value; 
                else 
                    throw new ArgumentOutOfRangeException("can't be less than zero");
                }
        }
        public double Area { get { return Math.Pow(Reduis, 2) * Math.PI; }  }


        public Circle(double reduis=0)
        {
            Reduis = reduis;
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"{this.GetType().Name}  , its Area is ==> {Area}");
        }
    }
}
