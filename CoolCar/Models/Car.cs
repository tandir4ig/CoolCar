using System.Diagnostics.Metrics;

namespace CoolCar.Models
{
    public class Car
    {
        public static int Counter = 0;
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Link { get; set; }

        //Спецификация
        public int hp { get; set; }
        public int weight { get; set; }
        public int maxSpeed { get; set; }
        //Спецификация
        public Car(string name, string desc, int cost, string link, int hp, int weight, int maxSpeed)
        {
            this.Id = Counter++;
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
            this.Link = link;
            this.hp = hp;
            this.weight = weight;
            this.maxSpeed = maxSpeed;
        }
        public Car(string name, string desc, int cost, string link)
        {
            this.Id = Counter++;
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
            this.Link = link;
        }
        public Car() { }
    }
}
