using El_sheikh.MVC.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using El_sheikh.MVC.DAL.Entities.Departments;
using System.ComponentModel.DataAnnotations.Schema;

namespace El_sheikh.MVC.DAL.Entities.Employees
{
    public class Employee : ModelBase
    {

        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string Address { get; set; } = null!;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }

        public Gender Gender  { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }

        //Navigational Property one
        public virtual Department? Department { get; set; }

    }
}
