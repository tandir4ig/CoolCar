using CoolCar.Models;

namespace CoolCar
{
    public class CarsDatabase
    {
        public static List<Car> cars = new List<Car>()
        {
            new Car("audi","audi description", 1000000, "pics\\audi.jpg"),
            new Car("bmw","bmwi description", 2000000, "pics\\audi.jpg"),
            new Car("lada","lada description", 100000, "pics\\audi.jpg"),
            new Car("kia","kia description", 200000, "pics\\audi.jpg"),
            new Car("porsche","porsche description", 3000000, "pics\\audi.jpg")
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
