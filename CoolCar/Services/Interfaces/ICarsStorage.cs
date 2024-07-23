using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICarsStorage
    {
        public List<Car> GetAll();
        public Car GetById(int id);
        public void Delete(Car car);
        public void Add(Car car);
    }
}
