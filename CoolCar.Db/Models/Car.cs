using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CoolCar.Db.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int Cost { get; set; }

        public int hp { get; set; }

        public int weight { get; set; }

        public int maxSpeed { get; set; }
        public List<Image> Images { get; set; }
        public Car(string name, string desc, int cost, int hp, int weight, int maxSpeed) : this()
        {
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
            this.hp = hp;
            this.weight = weight;
            this.maxSpeed = maxSpeed;
        }
        public Car(string name, string desc, int cost) : this()
        {
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
        }
        public Car() { }
    }
}
