using El_sheikh.MVC.DAL.Common.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace El_sheikh.MVC.BLL.Models.Employees
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; } 
        // هنا لازم يكون معاك الايدي   حتي لو مش هتعرض المودل دا فوق علطول ف الفيو 
        // ف لازم يكون معاك الايدي عشان نسلم الايدي دا بالمابنج ل اللاير الي تحت  تمام؟
        [MaxLength(50, ErrorMessage = "Max Length of Name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of Name is 5 Chars")]
        public string Name { get; set; } = null!;

        [Range(18, 50)]
        public int? Age { get; set; }
        [RegularExpression(@"^\d{1,5}-[A-Za-z]{3,20}-[A-Za-z]{3,20}-[A-Za-z]{3,20}$",
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; } = null!;

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")] // دي ك اسم البروبيرتي لما تظهر تكون بالشكل دا 
        public bool IsActive { get; set; }
        [EmailAddress] // فالديشن ان الفاليو تكون ايميل  ادرس فعلا
        [DataType(DataType.EmailAddress)] // ك فاليو يعني لما تظهر تظهر بشكل الايميل

        public string Email { get; set; } = null!;
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public int? DepartmentId { get; set; }

        public IFormFile? Image { get; set; }

    }
}