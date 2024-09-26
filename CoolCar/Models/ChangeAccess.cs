using CoolCar.Areas.Admin.Controllers;

namespace CoolCar.Models
{
    public class ChangeAccess
    {
        public string UserName { get; set; }
        public RoleViewModel Role { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
    }
}
