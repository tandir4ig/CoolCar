using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Cars()
        {
            return View();
        }
        public IActionResult AdminMenu()
        {
            return View();
        }
    }
}
