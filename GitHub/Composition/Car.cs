using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Composition
{
    internal class Car
    {

        public Engine Engine { get; set; };
        public Car() { Engine = new Engine(); }
    }
}
