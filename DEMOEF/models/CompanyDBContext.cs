using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEF.models
{
    internal class CompanyDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CompanyRouteDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
