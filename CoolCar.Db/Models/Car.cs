using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CoolCar.Db.Models
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int Cost { get; set; }

        public string Link { get; set; }

        public int hp { get; set; }

        public int weight { get; set; }

        public int maxSpeed { get; set; }
    }
}
