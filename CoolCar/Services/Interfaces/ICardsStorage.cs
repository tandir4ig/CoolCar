using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICardsStorage
    {
        public Card TryGetByUserId(string userId);
        public void Add(Car car, string userId);
        public void Remove(Car car, string userId);
        public void Clear(string userId);
    }

}
