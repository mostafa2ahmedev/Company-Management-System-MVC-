using System.ComponentModel.DataAnnotations;

namespace El_sheikh.MVC.PL.ViewModels.Departments
{
    public class DepartmentEditViewModel
    {
  
        [Required(ErrorMessage ="Code is Required Ya Hamada")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; } = null!;

        [Display(Name="Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
