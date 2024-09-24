using CoolCar.Models;
using CoolCar.Db.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoolCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; 
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() {ReturnUrl = returnUrl});
        }

        [HttpPost]
        public IActionResult Login(Login log)
        {
            var result = _signInManager.PasswordSignInAsync(log.login, log.Password, log.RememberMe, false).Result;

            if (result.Succeeded)
            {
                return Redirect(log.ReturnUrl ?? "/home/catalog");
            }
            else
            {
                ModelState.AddModelError("", "Неправильный пароль");
            }
            return View(log);
        }

        public IActionResult Register(string ReturnUrl)
        {
            var reg = new Register { ReturnUrl = ReturnUrl };
            return View(reg);
        }

        [HttpPost]
        public IActionResult Register(Register regis)
        {
            if(ModelState.IsValid)
            {
                var User = new User { UserName = regis.UserName };
                var result = _userManager.CreateAsync(User, regis.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(User, false).Wait();
                    
                    return Redirect(regis.ReturnUrl ?? "/home/catalog");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(regis);
            

            //if(userInterface.TryGetByName(regis.UserName) != null)
            //{
            //    ModelState.AddModelError("", "Пользователь с таким именем уже существует");
            //    return View();
            //}
            //if(regis.Password == regis.UserName)
            //{
            //    ModelState.AddModelError("", "Пароль и логин не должны совпадать");
            //    return View();
            //}
            //if(!ModelState.IsValid)
            //{
            //    return View();
            //}
            //userInterface.Add(new User(regis.UserName, regis.Password, regis.FirstName, regis.LastName, regis.Phone));
            //return RedirectToAction(nameof(HomeController.Catalog),"Home");
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("catalog","Home");
        }
    }
}
