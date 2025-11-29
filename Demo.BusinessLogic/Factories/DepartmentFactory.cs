using Demo.BusinessLogic.DTOS;
using Demo.DataAccess.Models.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    internal static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto
            {
                DeptId = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DateOfCreation = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedBy = department.CreatedBy,
                ModifiedBy = department.ModifiedBy,
                CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default,
                ModifiedOn = department.ModifiedOn.HasValue ? DateOnly.FromDateTime(department.ModifiedOn.Value) : default,
                IsDeleted = department.IsDeleted
            };
        }
        public static Department ToDepartment(this CreateDepartmentDto createDepartmentDto)
        {
            return new Department
            {
                Name = createDepartmentDto.Name,
                Description = createDepartmentDto.Description,
                Code = createDepartmentDto.Code,
                CreatedOn = createDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                
            };
        }
        //public static DepartmentViewModel ToDepartment1(this CreateDepartmentDto createDepartmentDto)
        //{
        //    return new DepartmentViewModel
        //    {
        //        Name = createDepartmentDto.Name,
        //        Description = createDepartmentDto.Description,
        //        Code = createDepartmentDto.Code,
        //        CreatedOn = createDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly()),

        //    };
        //}
        public static Department ToDepartment(this UpdatedDepartmentDto DepartmentDto)
        {
            return new Department
            {
                Name = DepartmentDto.Name,
                Description = DepartmentDto.Description,
                Code = DepartmentDto.Code,
                CreatedOn = DepartmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                Id = DepartmentDto.Id

            };
        }

    }
}
