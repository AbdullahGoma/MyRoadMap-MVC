using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewSecond.ViewModel;

namespace NewSecond.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        // In Controller there is no overload to Actions, In one Case only => Method Post
        // the same Method(Overloaded) Get

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        //IoC & DI
        //UserManager<IdentityUser> userManager;

        // Account/Registration
        // Regestration
        // Action Open Link
        public IActionResult Regestration()
        {
            return View();
        }


        // Action form => Database
        //[HttpDelete("r")]
        [HttpPost]
        public async Task<IActionResult> Regestration(RegisterAccountViewModel newAccount) // Properties we did not need it
            // & Can not write in identity user, Validation & Extra Properties
            // Create View Model
        {
            if(ModelState.IsValid) // ModelState => RegisterAccountViewModel
            {
                // Map from View Model to Model
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;
                
                // How to Save user and Create Cookie, Second Parameter Take Password to do Hash on it
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);// Return Identity Result
                if(result.Succeeded)
                {
                    // Create Cookie
                    await signInManager.SignInAsync(user, isPersistent: false); // Create cookie
                    return RedirectToAction("Index", "Department");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(newAccount); // Model& ModelState Error
        }

        // Login
        // Open Link
        public IActionResult Login(string ReturnURl = "~/Department/index")
        {
            ViewData["RedirectURL"] = ReturnURl;
            return View();
        }
        // Check Create Cookie
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser, string ReturnURl = "~/Department/index")
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = 
                        await signInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.isPersiste, false);
                    if(result.Succeeded)
                    {
                        //if(User.IsInRole("Admin"))
                        //return RedirectToAction("Index", "Department");
                        return LocalRedirect(ReturnURl);
                    }
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
            }
            return View(loginUser);
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        // ------------------------------------------------------------


        public IActionResult AddAdmin()
        {
            return View("Regestration");
        }


        // Action form => Database
        //[HttpDelete("r")]
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterAccountViewModel newAccount) 
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);// Return Identity Result
                if (result.Succeeded)
                {
                    // Add to Admin Role
                    await userManager.AddToRoleAsync(user, "Admin");
                    // Create Cookie
                    await signInManager.SignInAsync(user, isPersistent: false); // Create cookie
                    return RedirectToAction("Index", "Department");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Regestration", newAccount); // Model& ModelState Error
        }



    }
}
