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
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName ="varchar")]
        //not related to DB

        //[StringLength(50,MinimumLength =10)]
        //[MinLength(50)]
        [Length(10,50)]
        public string? FName { get; set; }
        [Length(10, 50)]
        public string? LName { get; set; }

        [Column(TypeName ="decimal(18,2)")]

        public decimal Salary { get; set; }

        [Range(22,60)]
        [AllowedValues(20,21,22,23)]
        [DeniedValues(10,15)]
        public int? Age { get; set; }

        [EmailAddress]
        public string Address { get; set; }
        public int DepartmentId { get; set; }


        //public virtual List<Course> Courses { get; set; } = new List<Course>();

        public virtual Department Department { get; set; } =new Department();



        


    }
}
