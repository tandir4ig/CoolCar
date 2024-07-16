using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class CompareServise : ICompareInterface
    {
        public List<Car> CompareCars = new List<Car>();
        public void Add(Car car)
        {
            if (CompareCars.Contains(car))
            {
                return;
            }
            else
            {
                CompareCars.Add(car);
            }
        }
        public void Remove(Car car)
        {
            CompareCars.Remove(car);
        }
        public void Clear()
        {
            CompareCars.Clear();
        }
        public List<Car> GetAllCompare()
        {
            return CompareCars;
        }
    }
}
