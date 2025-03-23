using IKEA.DAL.Models.Identity;
using IKEA.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSettings _emailSettings;

        public AccountController(UserManager<ApplicationUser> userManager ,
                                 SignInManager<ApplicationUser> signInManager
                                  //,IEmailSettings emailSettings
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSettings = emailSettings;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //Check If The User Name  already Exists
            var existingUser = await _userManager.FindByNameAsync(signUpViewModel.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(SignUpViewModel.UserName), "This User Name Is Already Taken");
                return View(signUpViewModel);
            }
            var User = new ApplicationUser()
            {
                FName = signUpViewModel.FirstName,
                LName = signUpViewModel.LastName,
                UserName = signUpViewModel.UserName,
                Email = signUpViewModel.Email,
                IsAgree = signUpViewModel.IsAgree
                

            };
            var result = await _userManager.CreateAsync(User, signUpViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(SignIn));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(signUpViewModel);

        }

        public async Task<IActionResult> SignIn()
        {
            return View();
        }

    }
}
