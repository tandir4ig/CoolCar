using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICompareInterface
    {
        public void Add(Car car);
        public void Remove(Car car);
        public void Clear();
        public List<Car> GetAllCompare();
    }
}
