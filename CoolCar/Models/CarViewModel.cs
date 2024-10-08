﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CoolCar.Models
{
    public class CarViewModel
    {
        public static int Counter = 0;
        public Guid Id { get; set; }

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
        [StringLength(100, MinimumLength = 10, ErrorMessage = "длина должна составлять от 10 до 100 символов")]
        public string Link { get; set; }

        //Спецификация
        [Required(ErrorMessage = "Заполните поле")]
        [Range(1,9999, ErrorMessage = "Значение должно быть в пределах (1,9999)")]
        public int hp { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(1000, 10000, ErrorMessage = "Значение должно быть в пределах (1000,10000)")]
        public int weight { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(100, 2000, ErrorMessage = "Значение должно быть в пределах (100,2000)")]
        public int maxSpeed { get; set; }
        public string[] ImagesPaths { get; set; }
        public string ImagePath => ImagesPaths.Length == 0 ? "/images/Cars/NoImage.png" : ImagesPaths[0];

        public CarViewModel(string name, string desc, int cost, int hp, int weight, int maxSpeed) : this()
        {
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
            this.hp = hp;
            this.weight = weight;
            this.maxSpeed = maxSpeed;
        }
        public CarViewModel(string name, string desc, int cost) : this()
        {
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
        }
        public CarViewModel() { }
    }
}
