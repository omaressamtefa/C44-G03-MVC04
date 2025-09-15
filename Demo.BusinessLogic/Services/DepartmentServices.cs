using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            var departmentsToReturn = departments.Select(d => d.ToDepartmentDto());

            return departmentsToReturn;
        }
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            ///if (department is null)
            ///{
            ///    return null;
            ///}
            ///else
            ///{
            ///    return new DepartmentDetailsDto
            ///    {
            ///        Name = department.Name,
            ///        Code = department.Code,
            ///        Description = department.Description,
            ///        CreatedBy = department.CreatedBy,
            ///        LastModifiedBy = department.LastModifiedBy,
            ///        DateOfCreation = DateOnly.FromDateTime(department.CreatedOn??DateTime.Now),
            ///        IsDeleted= department.IsDeleted,
            ///    };
            ///}
            return department is null ? null : department.ToDepartmentDetailsDto();

        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {

            return _departmentRepository.Add(departmentDto.ToEntity());
        }
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {

            return _departmentRepository.Update(departmentDto.ToEntity());
        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
            {
                return false;
            }
            else
            {
                var result = _departmentRepository.Remove(department);
                return result > 0 ? true : false;
            }

        }
    }
}
