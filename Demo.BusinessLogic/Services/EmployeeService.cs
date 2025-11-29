using Demo.BusinessLogic.DTOS;
using Demo.BusinessLogic.DTOS.EmployeeDto;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Data.Repostitories;
using Demo.DataAccess.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService 
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) { 
        
        _employeeRepository = employeeRepository;
        }
        public int AddEmployee(CreateEmployeeDto employee)
        {
          return  _employeeRepository.Add(employee.ToEmployee());
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return false;
            }
            //int num = _employeeRepository.Delete(employee);
            //return num > 0 ? true : false;
            else { 
               employee.IsDeleted = true;
                return _employeeRepository.Update(employee)>0 ?true : false;
            } 

        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
           var employes= _employeeRepository.GetAll();
            var employeeDtos = employes.Select(e => e.ToEmployeeDto()); 
            return employeeDtos;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id) 
        {
           var employee= _employeeRepository.Get(id);
            if (employee == null)
            {
                return null;
            }
            return employee.ToEmployeeDetailsDto();         
        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
          return  _employeeRepository.Update(employee.ToEmployee());
        }
    }
}
