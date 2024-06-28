using System.Diagnostics.Metrics;

namespace CoolCar.Models
{
    public class Car
    {
        public static int Counter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Link { get; set; }

        public Car(string name,string desc, int cost, string link)
        {
            this.Id = Counter++;
            this.Name = name;
            this.Description = desc;
            this.Cost = cost;
            this.Link = link;
        }
    }
}
