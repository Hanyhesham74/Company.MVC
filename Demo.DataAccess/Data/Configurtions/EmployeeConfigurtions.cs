using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.EmployeeModule;

namespace Demo.DataAccess.Data.Configurtions
{
    internal class EmployeeConfigurtions : BaseEntityConfigurtions<Employee>,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e=>e.Address).HasColumnType("varchar(50)"); 
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e=>e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Gender).HasConversion((empgender) => empgender.ToString(),
            (gender) => (Gender)Enum.Parse(typeof(Gender),gender));
            builder.Property(e => e.EmployeeType).HasConversion((emptype) => emptype.ToString(),
           (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));
            base.Configure(builder);




        }
    }
}
