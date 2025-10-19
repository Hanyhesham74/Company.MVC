

using Demo.DataAccess.Models.DepartmentModule;

namespace Demo.DataAccess.Data.Configurtions
{
    internal class DepartmentConfigurtion : BaseEntityConfigurtions<Department>,IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
           
            base.Configure(builder);




        }
    }
}
