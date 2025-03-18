using IKEA.DAL.Common;
using IKEA.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistence.Data.Configurations.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GetUTCDATE()");
            builder.Property(E => E.Gender)
                .HasConversion(
                    (gender) => gender.ToString(),
                    (gender) => (Gender)Enum.Parse(typeof(Gender), gender)
                );
            builder.Property(E => E.EmployeeType)
                .HasConversion(
                    (Type) => Type.ToString(),
                    (Type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), Type)
                );



        }
    }
}
