using Demo.DataAccess.Models.Departments;
using Demo.DataAccess.Models.Employees;
using Demo.DataAccess.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Employees
{
    public interface IEmpolyeeRepository:IGenericRepository<Employee>
    {
     
    }
}
