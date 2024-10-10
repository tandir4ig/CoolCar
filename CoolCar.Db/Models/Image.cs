using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCar.Db.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
