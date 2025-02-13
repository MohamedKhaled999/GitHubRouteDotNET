using DEMOEF.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DEMOEF04.Configurations
{
    internal class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.
                HasKey(D => D.DeptId);

            

            builder.
                Property(d => d.DeptId).
                UseIdentityColumn(10, 1);

            builder
               .Property(d => d.Name)
               .HasColumnName("DepartmentName")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.
                Property(p => p.CreationDate).
                HasDefaultValueSql("GETDate()");


        }
    }
}
