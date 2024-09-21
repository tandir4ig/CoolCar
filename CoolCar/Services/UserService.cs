using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    //public class UserService : IUserInterface
    //{
    //    List<UserViewModel> users = new List<UserViewModel>()
    //    {
    //        new UserViewModel("kirill@kirill.ru", "12345678", "Кирилл", "Фисенко", "+79265846357"),
    //        new UserViewModel("andrey@andrey.ru", "12345678", "Андрей", "Петров", "+79164875124")
    //    };
    //    public List<UserViewModel> GetAll()
    //    {
    //        return users;
    //    }
    //    public void Add(UserViewModel user)
    //    {
    //        users.Add(user);
    //    }
    //    public UserViewModel TryGetById(Guid userId)
    //    {
    //        var user = users.FirstOrDefault(user => user.Id == userId);
    //        return user;
    //    }

    //    public UserViewModel TryGetByName(string name)
    //    {
    //        return users.FirstOrDefault(user => user.Name == name);
    //    }

    //    public void ChangeAccess(Guid userId, string roleName)
    //    {
    //        var user = TryGetById(userId);
    //        user.Role.RoleName = roleName;
    //    }

    //    public void ChangePassword(Guid userId, string password)
    //    {
    //        TryGetById(userId).Password = password;
    //    }

    //    public void Del(Guid userId)
    //    {
    //        users.Remove(TryGetById(userId));
    //    }

    //    public void Edit(EditUser user, Guid userId)
    //    {
    //        var currentUser = TryGetById(userId);
    //        currentUser.Name = user.UserName;
    //        currentUser.FirstName = user.FirstName;
    //        currentUser.LastName = user.LastName;
    //        currentUser.Phone = user.Phone;
    //    }
    //}
}
