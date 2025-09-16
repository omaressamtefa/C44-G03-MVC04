using Demo.DataAccess.Models.Departments;
using Demo.DataAccess.Repositories.Generics;

namespace Demo.DataAccess.Repositories.Departments
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {

    }
}