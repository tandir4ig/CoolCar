using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class RoleService : IRoleInterface
    {
        public List<Role> Roles = new List<Role>() { new Role("Admin"), new Role("User")};

        public void Add(Role roleName)
        {
            Roles.Add(roleName);
        }

        public List<Role> GetAllRoles()
        {
            return Roles;
        }

        public void Remove(Role roleName)
        {
            Roles.Remove(roleName);
        }
    }
}
