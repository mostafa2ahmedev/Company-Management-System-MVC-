using System.ComponentModel.DataAnnotations;

namespace El_sheikh.MVC.PL.ViewModels.Identity
{
    public class SignInViewModel
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string  Password { get; set; } = null!;
        public bool RememberMe { get; set; } 
    }
}
