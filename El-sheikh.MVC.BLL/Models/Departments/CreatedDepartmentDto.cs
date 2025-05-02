using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Models.Departments
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set; } = null!;
        //Default error messgage
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        [Display(Name="Date of Creation")]
        public DateOnly CreationDate { get; set; }

    }
}
