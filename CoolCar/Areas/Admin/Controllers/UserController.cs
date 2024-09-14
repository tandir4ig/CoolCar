using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CoolCar.Db.Models;
using CoolCar.Helpers.Mapping;

namespace CoolCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = CoolCar.Db.Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IRoleInterface roleInterface;
        private readonly UserManager<User> userManager;
        public UserController(UserManager<User> userManager, IRoleInterface roleInterface)
        {
            this.roleInterface = roleInterface;
            this.userManager = userManager;

        }
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(Mapper.Users_to_UsersViewModel(users));
        }
        public IActionResult AddUser()
        {
            return View();
        }

        //[HttpPost]
        //      public IActionResult AddUser(Register reg)
        //      {
        //          if (userInterface.TryGetByName(reg.UserName) != null)
        //          {
        //              ModelState.AddModelError("", "Пользователь с таким именем уже существует");
        //              return View();
        //          }

        //          if (reg.Password == reg.UserName)
        //          {
        //              ModelState.AddModelError("", "Пароль и логин не должны совпадать");
        //              return View();
        //          }

        //          if (!ModelState.IsValid)
        //          {
        //              return View();
        //          }

        //          userInterface.Add(new UserViewModel(reg.UserName, reg.Password, reg.FirstName, reg.LastName, reg.Phone));
        //          return RedirectToAction(nameof(HomeController.Catalog), "Home");
        //      }

        public IActionResult Details(string name)
        {
            var user = userManager.FindByNameAsync(name);
            return View(user.ToUserViewModel());
        }

        //      public IActionResult RemoveUser(Guid Id)
        //      {
        //          userInterface.Del(Id);
        //          return RedirectToAction("Index", "User");
        //      }

        //      public IActionResult ChangePassword(Guid userId)
        //      {
        //          var user = userInterface.TryGetById(userId);
        //          ViewData["userId"] = userId;
        //          ViewData["userName"] = user.Name;
        //          return View();
        //      }

        //      [HttpPost]
        //      public IActionResult ChangePassword(ChangePassword password, Guid UserId)
        //      {

        //          userInterface.ChangePassword(UserId, password.NewPassword);
        //          return RedirectToAction("index");
        //      }

        //      public IActionResult ChangeAccess(Guid userId)
        //      {
        //          var user = userInterface.TryGetById(userId);
        //          var roles = roleInterface.GetAllRoles();
        //          ViewData["userId"] = userId;
        //          ViewData["userName"] = user.Name;
        //          ViewData["userRole"] = user.Role.RoleName;
        //          return View(roles);
        //      }

        //      [HttpPost]
        //      public IActionResult ChangeAccess(Guid userId, string role)
        //      {
        //          userInterface.ChangeAccess(userId, role);
        //          return RedirectToAction(nameof(Index));
        //      }

        //public IActionResult Edit(Guid userId)
        //{
        //	var user = userInterface.TryGetById(userId);
        //	var editUser = new EditUser();
        //	editUser.UserName = user.Name;
        //	editUser.FirstName = user.FirstName;
        //	editUser.LastName = user.LastName;
        //	editUser.Phone = user.Phone;
        //	ViewData["userId"] = userId;
        //	return View(editUser);
        //}

        //[HttpPost]
        //public IActionResult Edit(EditUser user, Guid userId)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return View(user);
        //	}
        //	userInterface.Edit(user, userId);
        //	return RedirectToAction(nameof(Index));
        //}
    }
}
