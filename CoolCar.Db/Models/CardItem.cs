using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCar.Db.Models
{
    public class CardItem
    {
        public Guid Id { get; set; }
        public Car car { get; set; }
        public int Amount { get; set; }
        
    }
}
