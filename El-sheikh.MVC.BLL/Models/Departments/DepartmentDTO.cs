using El_sheikh.MVC.DAL.Entities.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Models.Departments
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        [Display(Name="Date of Creation")]
        public DateOnly CreationDate { get; set; }


        //public int CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }

        //public int LastModifiedBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }


    }
}
