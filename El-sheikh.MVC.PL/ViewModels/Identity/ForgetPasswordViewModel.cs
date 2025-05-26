using System.ComponentModel.DataAnnotations;

namespace El_sheikh.MVC.PL.ViewModels.Identity
{
    public class ForgetPasswordViewModel
    {
       [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!
    }
}
