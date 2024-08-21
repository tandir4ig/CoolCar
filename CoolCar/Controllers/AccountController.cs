using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInterface userInterface;
        public AccountController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login log)
        {
            User account = userInterface.TryGetByName(log.login);
            if(account == null)
            {
                ModelState.AddModelError("","Пользователь с таким именем не найден");
                return View();
            }
            if(account.Password != log.Password)
            {
                ModelState.AddModelError("", "Неверный пароль");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction(nameof(HomeController.Catalog), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register regis)
        {
            if(userInterface.TryGetByName(regis.UserName) != null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
                return View();
            }
            if(regis.Password == regis.UserName)
            {
                ModelState.AddModelError("", "Пароль и логин не должны совпадать");
                return View();
            }
            if(!ModelState.IsValid)
            {
                return View();
            }
            userInterface.Add(new User(regis.UserName, regis.Password, regis.FirstName, regis.LastName, regis.Phone));
            return RedirectToAction(nameof(HomeController.Catalog),"Home");
        }
    }
}
