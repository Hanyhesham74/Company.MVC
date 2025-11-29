
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.EmployeeModule;
using Department = Demo.DataAccess.Models.DepartmentModule.Department;

namespace Demo.DataAccess.Data.Configurtions
{
    //internal class DepartmentConfigurtion : BaseEntityConfigurtions<DepartmentViewModel>,IEntityTypeConfiguration<DepartmentViewModel>
    internal class DepartmentConfigurtion : BaseEntityConfigurtions<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder) 
        {
            builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)"); 
            builder.HasMany(d=>d.Employees).WithOne(e=>e.Department).HasForeignKey(e=>e.DepartmentId).OnDelete(DeleteBehavior.SetNull);


            base.Configure(builder);  

        }
    }
}
