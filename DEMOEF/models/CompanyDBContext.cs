using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFSession02FlluentApis;
using System.Reflection;

namespace DEMOEF.models
{
    internal class CompanyDBContext:DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CompanyRouteDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Apis For Each And Every Model

            //modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            


            #region Employee
            //modelBuilder.Entity<Employee>().
            //     Property<string>("Address").
            //     HasColumnType("varchar").
            //     HasMaxLength(50).
            //     IsRequired();
            #endregion

            #region Department
            //modelBuilder.Entity<Department>().
            //    HasKey(D => D.DeptId);
            //modelBuilder.Entity<Department>().
            //    ToTable("Departments", "dbo");
            //modelBuilder.Entity<Department>().
            //    Property(d => d.DeptId).
            //    UseIdentityColumn(10, 10);
            //modelBuilder.Entity<Department>().
            //   Property(d => d.Name).
            //   HasColumnName("DepartmentName")
            //   .HasColumnType("varchar")
            //   .IsRequired();

            //modelBuilder.Entity<Department>().
            //    Property(p => p.CreationDate).
            //    HasDefaultValueSql("GETDate()");





            #endregion

        }
        
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
