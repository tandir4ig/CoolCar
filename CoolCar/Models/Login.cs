using System.ComponentModel.DataAnnotations;

namespace CoolCar.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl {  get; set; }
    }
}
