using GitHub.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.models
{
    public class Course
    {
        public int Id { get; set; }

        public double Duration { get; set; }
        public string Name { get; set; }

        //public List<Instructor> Instructors { get; set; }   = new ();


        #region Course_Inst
        public virtual ICollection<Course_Inst> Course_Insts { get; set; } = new HashSet<Course_Inst>();

        #endregion

        #region Coruse-topic
        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
        #endregion

        #region Stud-Course

        public virtual ICollection<Stud_Course> Stud_Courses { get; set; } = new HashSet<Stud_Course>();

        #endregion





    }
}
