namespace GitHub
{
    using GitHub.models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Runtime.Intrinsics.X86;
    using Task.models;
    using static System.Net.Mime.MediaTypeNames;

    internal class Program
    {
        static void Main(string[] args)
        {
            #region CRUD

          using  CompanyDBContext db = new CompanyDBContext();

            #region Create

            Student student1 = new()
            {
                FName = "Test",
                LName = "Test",
                Age = 1,
                Salary = 600,
                Address = "cairo",
                //DepartmentId=1


            };

            Instructor instructor1 = new()
            {
                Name = "MK",
                Bouns = 2000,
                HourRate = 10,

                Address = "cairo",
                //DepartmentId=1


            };

            Department department1 = new()
            {
                Name = "IT"
                ,
                HiringDate = DateTime.Now
                ,
                ManagerId = 2
            };

            Topic topic1 = new()
            {
                Name = ".Net",

            };

            Course course1 = new()
            {
                TopicId = 1,
                Name = "BackEnd.net",
                Duration = 6,

            };
            Course_Inst course_Inst1 = new()
            {
                CourseId = 1,
                InstructorId = 2,
                evaluate = 3
            };

            Stud_Course stud_Course1 = new()
            {
                CourseId = 1,
                StudentId = 2,
                Grade = 70
            };

            //db.Add(instructor1);
            //db.Add(student1);
            //db.Add(department1);
            //db.Add(topic1);
            //db.Add(course1);
            //db.Add(course_Inst1);
            //db.Add(stud_Course1);



            //db.SaveChanges();


            #endregion

            #region Update/Retrive
            //var stud= db.Students.FirstOrDefault();
            //stud.Age = 50;

            var ins = db.Instructors.FirstOrDefault();
            ins.Name = "mohamed khaled";

            //var course = db.Courses.FirstOrDefault();
            //course.Name = "Microsoft .Net 9";


            var dept = db.Departments.FirstOrDefault();
            dept.Name = "Dev";

            var topic = db.Topics.FirstOrDefault();
            topic.Name = ".NET FrameWork .vs Core";


            //var stud_Course = db.stud_Courses.FirstOrDefault();
            //stud_Course.Grade = 0;

            //var course_Inst = db.Course_Insts.FirstOrDefault();
            //course_Inst.evaluate = -5;

            //db.SaveChanges();

            #endregion


            #region Delete
            // db.Remove(course_Inst);
            //var stud_Course2 = db.stud_Courses.FirstOrDefault();
            //db.Remove(stud_Course2);
            //db.Remove(course);
            //db.Remove(stud);
            //db.Remove(ins); //by default instructor Table will be deleted => Cascade Delete

            //db.SaveChanges();

            #endregion



            #endregion

        }

    }
}
