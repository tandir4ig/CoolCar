using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace CoolCar.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Поле ФИО должно быть заполнено")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "ФИО должно содержать не менее 10 символов")]
        public string FullName {  get; set; }

        [Required(ErrorMessage = "Поле Email должно быть заполнено")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле телефона должно быть заполнено")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Поле Телефон должно содержать не менее 5 символов")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле Адрес должно быть заполнено")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Поле Адрес должно содержать от 10 до 200 символов")]
        public string Address { get; set; }
    }
}
