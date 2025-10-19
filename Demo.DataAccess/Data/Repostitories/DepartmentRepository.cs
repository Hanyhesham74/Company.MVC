

using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModule;

namespace Demo.DataAccess.Data.Repostitories
{
    //Contrler -[PLL]> Service -[BLL]> Repository -[DAL]> DbContext-[DAL]> Database
   public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        private readonly ApplicationDbContext _dbcontext; 
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext; 
        }
    }
}
