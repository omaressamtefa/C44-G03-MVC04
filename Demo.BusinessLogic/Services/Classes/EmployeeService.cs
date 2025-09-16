using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.Employees;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.Employees;
using Demo.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmpolyeeRepository _empolyeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmpolyeeRepository empolyeeRepository,IMapper mapper)
        {
            _empolyeeRepository = empolyeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _empolyeeRepository.GetAll(withTracking);
            var employesToReturn=_mapper.Map<IEnumerable<Employee> ,IEnumerable<EmployeeDto>>(employees);
            ///var employeeDtos = employees.Select(e => new EmployeeDto
            ///{
            ///    Id = e.Id,
            ///    Name = e.Name,
            ///    Age = e.Age,
            ///    Salary = e.Salary,
            ///    IsActive = e.IsActive,
            ///    Email = e.Email,
            ///    Gender = e.Gender.ToString(),
            ///    EmployeeType = e.EmployeeType.ToString()
            ///});
            return employesToReturn;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _empolyeeRepository.GetById(id);

            return employee is null?null: _mapper.Map<Employee, EmployeeDetailsDto?>(employee);
            ///return employee is null ? null : new EmployeeDetailsDto()
            ///{
            ///    Id = employee.Id,
            ///    Name = employee.Name,
            ///    Age = employee.Age,
            ///    Salary = employee.Salary,
            ///    Email = employee.Email,
            ///    PhoneNumber = employee.PhoneNumber,
            ///    HitringDate = DateOnly.FromDateTime(employee.HiringDate),
            ///    IsActive = employee.IsActive,
            ///    Gender = employee.Gender.ToString(),
            ///    EmployeeType = employee.EmployeeType.ToString(),
            ///    CreatedBy = employee.CreatedBy,
            ///    CreatedOn = employee.CreatedOn,
            ///    LastModifiedBy = employee.LastModifiedBy,
            ///    LastModifiedOn = employee.LastModifiedOn
            ///};
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            return _empolyeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _empolyeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _empolyeeRepository.GetById(id);
            if (employee is null)
            {
                return false;
            }
            employee.IsDeleted = true;
           var result= _empolyeeRepository.Update(employee);   
            if (result > 0) return true;
            else return false;  
            //var result = _empolyeeRepository.Remove(employee);
            //if (result > 0) return true;
            //else return false;
        }
    }
}
