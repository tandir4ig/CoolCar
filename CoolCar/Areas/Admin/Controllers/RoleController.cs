
using CoolCar.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<User> roleManager;
        public RoleController(RoleManager<User> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index(string name)
        {
            return View();
        }
    }
}
