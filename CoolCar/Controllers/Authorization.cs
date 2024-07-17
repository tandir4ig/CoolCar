using CoolCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class Authorization : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Enter(User user)
        {
            return Redirect("/Home/Catalog");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AddNewUser(User user)
        {
            return Redirect("/home/catalog");
        }
    }
}
