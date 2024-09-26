using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class RoleService : IRoleInterface
    {
        public List<RoleViewModel> Roles = new List<RoleViewModel>() { new RoleViewModel("Admin"), new RoleViewModel("User")};

        public void Add(RoleViewModel roleName)
        {
            Roles.Add(roleName);
        }

        public List<RoleViewModel> GetAllRoles()
        {
            return Roles;
        }

        public void Remove(RoleViewModel roleName)
        {
            Roles.Remove(roleName);
        }
    }
}
