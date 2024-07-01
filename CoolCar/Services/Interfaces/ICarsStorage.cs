using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICarsStorage
    {
        public List<Car> GetAll();
        public Car GetById(int id);        
    }
}
