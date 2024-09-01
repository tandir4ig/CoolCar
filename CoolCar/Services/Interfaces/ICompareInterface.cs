using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICompareInterface
    {
        public void Add(CarViewModel car);
        public void Remove(CarViewModel car);
        public void Clear();
        public List<CarViewModel> GetAllCompare();
    }
}
