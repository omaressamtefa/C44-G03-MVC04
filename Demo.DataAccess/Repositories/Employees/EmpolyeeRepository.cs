using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Models.Departments;
using Demo.DataAccess.Models.Employees;
using Demo.DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Employees
{
    public class EmpolyeeRepository:GenericRepository<Employee>,IEmpolyeeRepository
    {

        private new readonly ApplicationDbContext _dbContext;

        public EmpolyeeRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }




    }
}
