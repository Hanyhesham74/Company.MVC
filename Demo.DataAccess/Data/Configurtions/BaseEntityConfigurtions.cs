using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurtions
{
    internal class BaseEntityConfigurtions<T> : IEntityTypeConfiguration<T>where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(d => d.ModifiedOn).HasComputedColumnSql("getdate()");
        }
    }
}
