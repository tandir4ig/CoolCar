using System.ComponentModel.DataAnnotations;

namespace CoolCar.Areas.Admin.Models
{
    public class AddCarViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "длина должна составлять от 10 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "длина должна составлять от 10 до 100 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(1000000, 20000000, ErrorMessage = "Значение должно быть в пределах (1.000.000 , 20.000.000) рублей")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(1, 9999, ErrorMessage = "Значение должно быть в пределах (1,9999)")]
        public int hp { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(1000, 10000, ErrorMessage = "Значение должно быть в пределах (1000,10000)")]
        public int weight { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(100, 2000, ErrorMessage = "Значение должно быть в пределах (100,2000)")]
        public int maxSpeed { get; set; }

        public IFormFile[] UploadedFiles { get; set; }
    }
}
