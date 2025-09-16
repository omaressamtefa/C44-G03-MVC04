using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Models.Departments;
using Demo.DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Departments
{
    public class DepartmentRepository :GenericRepository<Department> ,IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext):base(dbContext) // 1. Injection
        {
            _dbContext = dbContext;
        }

        
    }
}
