using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInterface _userInterface;
        public AccountController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Enter(Register user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Catalog", "Home");
            }
            return RedirectToAction("index", "Authorization");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewUser(Register user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddNewUser", "Authorization");
            }
            return RedirectToAction("Register", "Authorization");
        }
    }
}
