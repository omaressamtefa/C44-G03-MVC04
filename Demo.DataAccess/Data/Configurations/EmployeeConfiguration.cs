using Demo.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    internal class EmployeeConfiguration :BaseEntityConfiguration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new  void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.Gender)
                .HasConversion(
                    gender => gender.ToString(),
                    toGender => (Gender)Enum.Parse(typeof(Gender), toGender)
                );
            builder.Property(e => e.EmployeeType)
                .HasConversion(
                    employeeType => employeeType.ToString(),
                    toEmployeeType => (EmployeeType)Enum.Parse(typeof(EmployeeType), toEmployeeType)
                );
            base.Configure(builder);
        }
    }
}
