using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{
    internal class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            
            //builder.
            //    HasKey(D => D.DeptId);
            
            //builder.
            //    ToTable("Departments", "dbo");
            
            //builder.
            //    Property(d => d.DeptId).
            //    UseIdentityColumn(10, 10);

            //builder
            //   .Property(d => d.Name)
            //   .HasColumnName("DepartmentName")
            //   .HasColumnType("varchar")
            //   .IsRequired();

            //builder.
            //    Property(p => p.HiringDate).
            //    HasDefaultValueSql("GETDate()");


        }
    }
}
