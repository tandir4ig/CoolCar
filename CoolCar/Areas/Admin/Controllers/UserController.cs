using CoolCar.Controllers;
using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CoolCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserInterface userInterface;
        private readonly IRoleInterface roleInterface;
        public UserController(IUserInterface userInterface, IRoleInterface roleInterface)
        {
            this.userInterface = userInterface;
            this.roleInterface = roleInterface;
        }
        public IActionResult Index()
        {
            var Users = userInterface.GetAll();
            return View(Users);
        }
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(Register reg)
        {
            if (userInterface.TryGetByName(reg.UserName) != null)
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
                return View();
            }

            if (reg.Password == reg.UserName)
            {
                ModelState.AddModelError("", "Пароль и логин не должны совпадать");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            userInterface.Add(new User(reg.UserName, reg.Password, reg.FirstName, reg.LastName, reg.Phone));
            return RedirectToAction(nameof(HomeController.Catalog), "Home");
        }

        public IActionResult Details(Guid id)
        {
            var user = userInterface.TryGetById(id);
            return View(user);
        }

        public IActionResult RemoveUser(Guid Id)
        {
            userInterface.Del(Id);
            return RedirectToAction("Index", "User");
        }

        public IActionResult ChangePassword(Guid userId)
        {
            var user = userInterface.TryGetById(userId);
            ViewData["userId"] = userId;
            ViewData["userName"] = user.Name;
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword password, Guid UserId)
        {
            userInterface.ChangePassword(UserId, password.NewPassword);
            return RedirectToAction("index");
        }
    }
}
