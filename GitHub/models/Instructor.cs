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

        #region Course_Inst
        public virtual ICollection<Course_Inst> Course_Insts { get; set; } = new HashSet<Course_Inst>();

        #endregion



        // One-to-One: 


        #region [Inst-Dept] Manager
        [InverseProperty(nameof(models.Department.Manager))]        
        public virtual Department? ManagedDepartment { get; set; }

        #endregion


        #region [Inst-Dept] Work

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        // many-to-one
        [InverseProperty(nameof(models.Department.Instructors))]
        public virtual Department? Department { get; set; }

        #endregion






        //public virtual List<Course> Courses { get; set; } =new List<Course>();

    }
}
