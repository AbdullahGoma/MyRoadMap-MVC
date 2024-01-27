using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AssignmentDTwo.ViewModel;

namespace AssignmentDTwo.Controllers
{
    [Authorize(Roles = "Admin")] // Authentication & Authorization
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }


        //Add
        public IActionResult AddRole()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRole)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole(){ Name = newRole.RoleName };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }


    }
}
