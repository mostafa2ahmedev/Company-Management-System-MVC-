using El_sheikh.MVC.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Models.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")] // دي ك اسم البروبيرتي لما تظهر تكون بالشكل دا 
        public bool IsActive { get; set; }

        [DataType(DataType.EmailAddress)] // ك فاليو يعني لما تظهر تظهر بشكل الايميل
        public string? Email { get; set; }
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
        public string? Department { get; set; } = null!;


        public string? Image { get; set; }
    }
}
