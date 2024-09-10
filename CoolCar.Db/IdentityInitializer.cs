using CoolCar.Db.Models;
using Microsoft.AspNetCore.Identity;

namespace CoolCar.Db
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<UserDb> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@gmail.com";
            var password = "_Aa123456";
            if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result != null )
            {
                roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
            {

            }
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new UserDb { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
                }
            }
        }
    }
}
