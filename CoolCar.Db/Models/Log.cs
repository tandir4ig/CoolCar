using System.ComponentModel.DataAnnotations;

namespace CoolCar.Db.Models
{
    public class Log
    {
        public string login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
