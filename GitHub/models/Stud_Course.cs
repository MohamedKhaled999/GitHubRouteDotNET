﻿using GitHub.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.models
{

    public class Stud_Course
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int? Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

   
    }


}
