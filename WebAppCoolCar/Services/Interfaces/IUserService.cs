using CoolCar.Db.Models;
using Microsoft.AspNetCore.Identity;
using WebAppCoolCar.Models;

namespace WebAppCoolCar.Services.Interfaces
{
    public interface IUserService
    {
        bool IsValidUserInformationForAuth(LoginModel model, SignInManager<User> signInManager);
        bool IsValidUserInformationForRegister(LoginModel model, UserManager<User> userManager);
    }
}
