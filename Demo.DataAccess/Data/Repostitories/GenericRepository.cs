using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repostitories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbcontext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public TEntity? Get(int id)
        {
            var entity = _dbcontext.Set<TEntity>().Find(id);

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entity = _dbcontext.Set<TEntity>().Where(entity=>entity.IsDeleted==false).ToList();
            return entity;
        }
        public int Add(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Add(entity);
            return _dbcontext.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
            return _dbcontext.SaveChanges();
        }
        public int Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
