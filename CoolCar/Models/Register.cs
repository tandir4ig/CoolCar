using System.ComponentModel.DataAnnotations;

namespace CoolCar.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 15 символов")]
        public string Login {  get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string PasswordComfirm {  get; set; }
    }
}
