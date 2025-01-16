using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Assosciation
{
    internal class Teacher
    {
        public string? Name { get; set; }
        public Teacher() { }
        public Teacher(Course course) {
            Console.WriteLine($"Teacher {Name} tech course {course.Name}");
        }
    }
}
