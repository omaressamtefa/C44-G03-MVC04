﻿using Demo.BusinessLogic.DataTransferObjects.Departments;
using Demo.DataAccess.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    internal static class DepartmentFactory
    {
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
                LastModifiedOn = department.LastModifiedOn,
                IsDeleted = department.IsDeleted,
            };
        }
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now)
            };
        }
        public static Department ToEntity (this CreatedDepartmentDto departmentDto )
        {
           return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())

            };
        }
        public static Department ToEntity(this UpdateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}