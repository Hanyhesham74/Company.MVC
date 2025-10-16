

using Demo.DataAccess.Data.Contexts;

namespace Demo.DataAccess.Data.Repostitories
{
    //Contrler -[PLL]> Service -[BLL]> Repository -[DAL]> DbContext-[DAL]> Database
   public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public Department? Get(int id)
        {
            var department = _dbcontext.Departments.Find(id);

            return department;
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _dbcontext.Departments.ToList();
            return departments;
        }
        public int Add(Department department)
        {
            _dbcontext.Departments.Add(department);
           return _dbcontext.SaveChanges();
        }
        public int Update(Department department)
        {
            _dbcontext.Departments.Update(department);
           return _dbcontext.SaveChanges();
        }
        public int Delete(Department department)
        {
            _dbcontext.Departments.Remove(department);
           return _dbcontext.SaveChanges();
        }

    }
}
