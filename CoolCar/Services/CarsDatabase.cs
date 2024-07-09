using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class CarsDatabase : ICarsStorage
    {
        public static List<Car> cars = new List<Car>()
        {
            new Car("audi","audi description", 1000000, "pics\\audi.jpg") {weight = 8000, hp = 180, maxSpeed = 210},
            new Car("bmw","bmwi description", 2000000, "pics\\bmw.jpg") {weight = 1200, hp = 280, maxSpeed = 290},
            new Car("lada","lada description", 100000, "pics\\lada.jpg") {weight = 1100, hp = 120, maxSpeed = 180},
            new Car("kia","kia description", 200000, "pics\\kia.jpg") {weight = 1000, hp = 110, maxSpeed = 170},
            new Car("porsche","porsche description", 3000000, "pics\\porsche.jpg") {weight = 1300, hp = 270, maxSpeed = 310}
        };

        public List<Car> GetAll()
        {
            return cars;
        }
        public Car GetById(int id)
        {
            return cars.FirstOrDefault(car => car.Id == id);
        }
    }
}
