﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models.Employees
{
    public class Employee: BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
