using System.ComponentModel.DataAnnotations;

namespace CoolCar.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Роль должна иметь от 3 до 50 символов")]
        public string RoleName {  get; set; }
        public Role(string name)
        {
            RoleName = name;
        }
        public Role() { }
    }
}
