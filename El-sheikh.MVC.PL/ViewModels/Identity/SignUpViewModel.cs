using System.ComponentModel.DataAnnotations;

namespace El_sheikh.MVC.PL.ViewModels.Identity
{
    public class SignUpViewModel
    {
        public string UserName { get; set; } = null!;
        [Display(Name="First Name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;


        [EmailAddress]
        public string Email { get; set; } = null!;

        //[MaxLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
        public bool IsAgree { get; set; }

    }
}
