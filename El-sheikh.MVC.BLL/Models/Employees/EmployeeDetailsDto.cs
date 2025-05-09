using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Models.Employees
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public string Address { get; set; } = null!;

        [Display(Name = "Is Active")] // دي ك اسم البروبيرتي لما تظهر تكون بالشكل دا 
        public bool IsActive { get; set; }
        public string? PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)] // ك فاليو يعني لما تظهر تظهر بشكل الايميل
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
        public DateOnly HiringDate { get; set; }
        public int CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Last Modified By")]
        public int LastModifiedBy { get; set; }
        [Display(Name = "Last Modified On")]
        public DateTime LastModifiedOn { get; set; }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
    }
}
