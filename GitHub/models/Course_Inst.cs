using GitHub.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.models
{
    public class Course_Inst
    {
        [ForeignKey("Course")]
       public int CourseId { get; set; }
        [ForeignKey("Instructor")]
       public int InstructorId { get; set; }
        public int evaluate { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
