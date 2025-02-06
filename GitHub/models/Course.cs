using GitHub.models;
using System;
using System.Collections.Generic;
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

        public int TopicId { get; set; }
        //public List<Student> Students { get; set; }   = new List<Student>();
        public List<Topic> Topics { get; set; }   = new List<Topic>();
        //public List<Instructor> Instructors { get; set; }   = new ();





    }
}
