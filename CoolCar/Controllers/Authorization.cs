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
            return View();
        }
    }
}
