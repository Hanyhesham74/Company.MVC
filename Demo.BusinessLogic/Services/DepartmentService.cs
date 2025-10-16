using Demo.BusinessLogic.DTOS;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Data.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DTOS.DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            var departmentDtos = departments.Select(d => d.ToDepartmentDto());
            return departmentDtos;

        }

        public DepartmentDetailsDto ? GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return null;
            }

            return department.ToDepartmentDetailsDto();
        }
        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            return _departmentRepository.Add(departmentDto.ToDepartment());
        }
        public int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto)
        {
            return _departmentRepository.Update(updatedDepartmentDto.ToDepartment());
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return false;
            }
            int num = _departmentRepository.Delete(department);

            return num > 0 ? true : false;
        }
    }
}
