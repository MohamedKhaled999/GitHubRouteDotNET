using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.models;

namespace GitHub.models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }
        public DateTime HiringDate { get; set; }


        //[ForeignKey("Instructor")]
        //public int InstructorId { get; set; }

        //public virtual Instructor Instructor { get; set; } = new Instructor();

        public virtual List<Student> Students { get; set; } = new();
        public virtual List<Instructor> Instructors { get; set; } = new();


    }
}
