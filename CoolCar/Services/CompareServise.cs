using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class CompareServise : ICompareInterface
    {
        public List<CarViewModel> CompareCars = new List<CarViewModel>();
        public void Add(CarViewModel car)
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
        public void Remove(CarViewModel car)
        {
            CompareCars.Remove(car);
        }
        public void Clear()
        {
            CompareCars.Clear();
        }
        public List<CarViewModel> GetAllCompare()
        {
            return CompareCars;
        }
    }
}
