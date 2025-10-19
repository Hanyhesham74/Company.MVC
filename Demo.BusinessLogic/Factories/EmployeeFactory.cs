using Demo.BusinessLogic.DTOS;
using Demo.BusinessLogic.DTOS.EmployeeDto;
using Demo.DataAccess.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    internal static class EmployeeFactory
    {
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {

                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString()
            };
        }
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee employee)
        {
            return new EmployeeDetailsDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                CreatedOn = employee.CreatedOn,
                ModifiedOn = employee.ModifiedOn,
                CreatedBy = 1,
                ModifiedBy = 1,
            };
        }

        public static Employee ToEmployee(this CreateEmployeeDto createEmployeeDto)
        {
            return new Employee
            {
                Name = createEmployeeDto.Name,
                Age = createEmployeeDto.Age.GetValueOrDefault(),
                Address = createEmployeeDto.Address,
                Salary = createEmployeeDto.Salary,
                IsActive = createEmployeeDto.IsActive,
                Email = createEmployeeDto.Email,
                PhoneNumber = createEmployeeDto.PhoneNumber,
                HiringDate = createEmployeeDto.HiringDate.ToDateTime(new TimeOnly(0, 0)),
                Gender = createEmployeeDto.Gender,
                EmployeeType = createEmployeeDto.EmployeeType
            };
        }

        public static Employee ToEmployee(this UpdatedEmployeeDto updatedEmployeeDto)
        {
            return new Employee
            {
                Id = updatedEmployeeDto.Id,
                Name = updatedEmployeeDto.Name,
                Age = updatedEmployeeDto.Age.GetValueOrDefault(),
                Address = updatedEmployeeDto.Address,
                Salary = updatedEmployeeDto.Salary,
                IsActive = updatedEmployeeDto.IsActive,
                Email = updatedEmployeeDto.Email,
                PhoneNumber = updatedEmployeeDto.PhoneNumber,
                HiringDate = updatedEmployeeDto.HiringDate.ToDateTime(new TimeOnly(0, 0)),
                Gender = updatedEmployeeDto.Gender,
                EmployeeType = updatedEmployeeDto.EmployeeType
            };
        }

        
    }
}
