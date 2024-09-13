using CoolCar.Models;
using CoolCar.Db.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoolCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInterface userInterface;
        private readonly UserManager<UserDb> _userManager;
        private readonly SignInManager<UserDb> _signInManager;
        public AccountController(IUserInterface userInterface, SignInManager<UserDb> signInManager, UserManager<UserDb> userManager)
        {
            this.userInterface = userInterface;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login log)
        {
            var result = _signInManager.PasswordSignInAsync(log.login, log.Password, log.RememberMe, false).Result;
            //User account = userInterface.TryGetByName(log.login);
            //if(account == null)
            //{
            //    ModelState.AddModelError("","Пользователь с таким именем не найден");
            //    return View();
            //}
            //if(account.Password != log.Password)
            //{
            //    ModelState.AddModelError("", "Неверный пароль");
            //    return View();
            //}
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(HomeController.Catalog), "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неправильный пароль");
            }
            return View();
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
