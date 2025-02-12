using GitHub.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.models
{
    public class Department
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int DeptId { get; set; }
        public string Name { get; set; }
        public DateTime? HiringDate { get; set; }


        #region [Inst-Dept] Manager

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public virtual Instructor Manager { get; set; } = null!;
        #endregion

        #region [Inst-Dept] Work

        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

        #endregion


        #region Stud-Dept

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

        #endregion



    }
}
