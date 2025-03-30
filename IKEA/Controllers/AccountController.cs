using IKEA.BLL.Common.Services.EmailSettings;
using IKEA.DAL.Models.Identity;
using IKEA.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace IKEA.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSettings _emailSettings;

        public AccountController(UserManager<ApplicationUser> userManager ,
                                 SignInManager<ApplicationUser> signInManager
                                  ,IEmailSettings emailSettings
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSettings = emailSettings;
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
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var User = await _userManager.FindByEmailAsync(signInViewModel.Email);
            if (User is { })
            {
                var flage = await _userManager.CheckPasswordAsync(User, signInViewModel.Password);

                if (flage)
                {
                 var result = await  _signInManager.PasswordSignInAsync(User, signInViewModel.Password, signInViewModel.RememberMe, true);

                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "Your Account Is Not Comfirmed Yet !");
                    }
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Your Account Is Locked !");

                    }

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Index),"Home");
                    }

                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(signInViewModel);
        }

        public async Task<IActionResult> SignOut()
        {
          await  _signInManager.SignOutAsync();
            return View();
        }

        public async Task<IActionResult> ForgetPassword()
        {
            //await _signInManager.for();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendRessetPasswordUrl
                            (ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Email);

                if (user is not null)
                {
                    // TO ,Subject, Body
                    var url = Url.Action(nameof(RessetPassword), "Account", new { email =forgetPasswordViewModel.Email,token=user},Request.Scheme);
                    var email = new Email()
                    {
                        Body = url,
                        Subject ="Reset Your Password !"
                        ,
                        To = user.Email,

                    };

                    // Send Email
                    _emailSettings.Send(email);
                    return RedirectToAction("CheckYourInBox");

                }

              
            }
            ModelState.AddModelError("", "Invalid Operation , Please Try");

            return View(forgetPasswordViewModel);

        }
        public async Task<IActionResult> RessetPassword()
        {
            //await _signInManager.for();
            return View();
        }

        public async Task<IActionResult> CheckYourInBox()
        {
            //await _signInManager.for();
            return View();
        }




    }
}
