using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.models;

namespace GitHub.models
{
    internal class CompanyDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CompanyRouteITIEFDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stud_Course>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<Course_Inst>().HasKey(ci => new {  ci.CourseId,ci.InstructorId});

           
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors  { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Stud_Course> stud_Courses { get; set; }
        public DbSet<Course_Inst> Course_Insts { get; set; }



    }
}
