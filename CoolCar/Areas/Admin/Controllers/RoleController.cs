using CoolCar.Db.Models;
using CoolCar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CoolCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = CoolCar.Db.Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Roles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles.Select(x => new RoleViewModel { RoleName = x.Name }).ToList());
        }

        public IActionResult Remove(string name)
        {
            var role = roleManager.FindByNameAsync(name).Result;
            if (role != null)
            {
                roleManager.DeleteAsync(role).Wait();
            }
            return RedirectToAction("roles", "role");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(RoleViewModel model)
        {
            var result = roleManager.CreateAsync(new IdentityRole(model.RoleName)).Result;
            if(result.Succeeded)
            {
                return RedirectToAction("roles","role");
            }
            else
            {
                foreach( var error in result.Errors )
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
