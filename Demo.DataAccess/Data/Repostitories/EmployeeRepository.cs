using Demo.DataAccess.Data.Contexts; 
using Demo.DataAccess.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Data.Repostitories
{
    public class EmployeeRepository: GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public override IEnumerable<Employee> GetAll()
        {
            return _dbcontext.Employees.
                Where(e => e.IsDeleted == false)
                .Include(e => e.Department)
                .ToList();
        }

        public override Employee? Get(int id) 
        {
            return _dbcontext.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id && e.IsDeleted == false);
        }

    }
}
