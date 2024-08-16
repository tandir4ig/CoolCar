using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface IRoleInterface
    {
        public void Add(Role roleName);
        public void Remove(Role roleName);
        public List<Role> GetAllRoles();
    }
}
