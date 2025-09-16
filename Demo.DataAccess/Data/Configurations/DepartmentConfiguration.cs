using Demo.DataAccess.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfigurations :BaseEntityConfiguration<Department> ,IEntityTypeConfiguration<Department>
    {
        public new  void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            base.Configure(builder);

        }
    }
}
