using CoolCar.Db.Models;
using Microsoft.AspNetCore.Identity;
using WebAppCoolCar.Models;
using WebAppCoolCar.Services.Interfaces;
namespace WebAppCoolCar.Services
{
    public class UserService : IUserService
    {
        public bool IsValidUserInformationForAuth(LoginModel model, SignInManager<User> signInManager)
        {
            var result = signInManager.PasswordSignInAsync(model.Name, model.Password, false, false).Result;
            return result.Succeeded;
        }
        public bool IsValidUserInformationForRegister(RegUser registeringUser, UserManager<User> userManager)
        {
            var user = new User { UserName = registeringUser.Email, Email = registeringUser.Email, PhoneNumber = registeringUser.Phone };
            var result = userManager.CreateAsync(user, registeringUser.Password).Result;
            return result.Succeeded;
        }
    }
}
