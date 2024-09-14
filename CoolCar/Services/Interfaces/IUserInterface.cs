using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface IUserInterface
    {
        List<UserViewModel> GetAll();
        UserViewModel TryGetById(Guid userId);
        UserViewModel TryGetByName(string name);
        void Del(Guid userId);
        void Add(UserViewModel user);
        void Edit(EditUser user, Guid userId);
        void ChangePassword(Guid userId, string password);
        void ChangeAccess(Guid userId, string roleName);
    }
}
