using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEF.models
{
    internal class PartTimeEmployee : Employee2
    {
        public int CountOfHours { get; set; }
        public decimal HourRate { get; set; }
    }

}
