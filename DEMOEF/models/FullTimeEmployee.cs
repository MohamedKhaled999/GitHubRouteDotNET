using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEF.models
{
    internal class FullTimeEmployee : Employee2
    {
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
    }

}
