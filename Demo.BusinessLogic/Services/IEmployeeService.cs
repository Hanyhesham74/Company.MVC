using Demo.BusinessLogic.DTOS.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public interface IEmployeeService
    {
        int AddEmployee(CreateEmployeeDto employee);  
        int UpdateEmployee(UpdatedEmployeeDto employee); 
        bool DeleteEmployee(int id);
        EmployeeDetailsDto? GetEmployeeById(int id); 
        IEnumerable<EmployeeDto> GetAllEmployees(); 
    }
}
