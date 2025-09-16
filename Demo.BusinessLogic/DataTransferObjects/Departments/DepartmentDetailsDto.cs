using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjects.Departments
{
    public class DepartmentDetailsDto
    {
      
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; } 
        public DateOnly DateOfCreation { get; set; }
        public int LastModifiedBy { get; set; } 
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
