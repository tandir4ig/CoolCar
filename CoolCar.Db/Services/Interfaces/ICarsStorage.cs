using CoolCar.Db.Models;

namespace CoolCar.Db.Services.Interfaces
{
    public interface ICarsStorage
    {
        public List<Car> GetAll();
        public Car GetById(Guid id);
        public void Delete(Car car);
        public void Add(Car car);
    }
}
