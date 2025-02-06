using GitHub.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Bouns { get; set; }

        public string Address { get; set; }

        public double HourRate { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = new Department();


        //public virtual List<Course> Courses { get; set; } =new List<Course>();

    }
}
