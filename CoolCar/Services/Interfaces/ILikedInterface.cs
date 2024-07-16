using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ILikedInterface
    {
        public void Add(Car car);
        public void Remove(Car car);
        public void Clear();
        public List<Car> GetAllLiked();

    }
}
