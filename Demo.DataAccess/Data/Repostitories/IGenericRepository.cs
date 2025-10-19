using Demo.DataAccess.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repostitories
{
    public interface IGenericRepository<TEntity>where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        int Delete(TEntity entity);
        TEntity? Get(int id);
        IEnumerable<TEntity> GetAll();
        int Update(TEntity entity);
    }
}
