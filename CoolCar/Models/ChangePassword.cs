﻿using System.ComponentModel.DataAnnotations;

namespace CoolCar.Models
{
    public class ChangePassword
    {
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string? ConfirmPassword { get; set; }
    }
}
