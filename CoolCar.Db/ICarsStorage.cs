using CoolCar.Db;
using CoolCar.Db.Models;

namespace CoolCar.Db
{
    public interface ICarsStorage
    {
        public List<Car> GetAll();
        public Car GetById(Guid id);
        public void Delete(Car car);
        public void Add(Car car);
    }
}
