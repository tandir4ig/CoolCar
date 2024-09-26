using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface IRoleInterface
    {
        public void Add(RoleViewModel roleName);
        public void Remove(RoleViewModel roleName);
        public List<RoleViewModel> GetAllRoles();
    }
}
