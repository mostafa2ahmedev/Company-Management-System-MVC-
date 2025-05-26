using El_sheikh.MVC.DAL.Entities.Identity;
using El_sheikh.MVC.PL.utilites;
using El_sheikh.MVC.PL.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace El_sheikh.MVC.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]

        public IActionResult SignUp() {
        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpVM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var user = await _userManager.FindByNameAsync(signUpVM.UserName);

            if (user is { })
            {
                ModelState.AddModelError(nameof(SignUpViewModel.UserName), "This username is already used");
                return View(signUpVM);
            }

            user = new ApplicationUser()
                {
                    FName = signUpVM.UserName,
                    LName = signUpVM.LastName,
                    Email = signUpVM.Email,
                    UserName = signUpVM.UserName,
                    IsAgree = signUpVM.IsAgree,
                };

                var result = await _userManager.CreateAsync(user, signUpVM.Password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(SignIn));
                
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                

                return View(signUpVM);
        }


        [HttpGet]  //Account/SignIn
        public IActionResult SignIn() {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel){

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            // 1. check if there is an email associated for that user
            var user= await _userManager.FindByEmailAsync(signInViewModel.Email);

            if (user is {} ) {
                var flag = await _userManager.CheckPasswordAsync(user,signInViewModel.Password);

                if (flag)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, signInViewModel.Password, signInViewModel.RememberMe, true);

                    if (result.IsLockedOut)
                        ModelState.AddModelError(string.Empty, "Your account is locked!!");

                    else if (result.IsNotAllowed)
                        ModelState.AddModelError(string.Empty, "Your account is not confirmed yet!!");

                    else if (result.Succeeded)
                        return RedirectToAction(nameof(HomeController.Index), "Home");

                    else
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }

            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(signInViewModel);
        }


        [HttpGet]
        public async new Task<IActionResult> SignOut() { 
        
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(SignIn));

        }

        #region Forget Password

        [HttpGet]
        public   IActionResult ForgetPassword()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordLink(ForgetPasswordViewModel viewModel){

            if (ModelState.IsValid) { 
            var user = _userManager.FindByEmailAsync(viewModel.Email);

                if (user is not null) {
                    var email = new Email() {
                    To=viewModel.Email,
                    Subject= "Reset Password",
                    Body="Link"
                    };
                
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Operatoin");
            return View(nameof(ForgetPassword), viewModel);
        }

        #endregion

    }
}
