

using CoolCar.Db.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICardsStorage
    {
        public Card TryGetByUserId(Guid userId);
        public void Add(Car car, Guid userId);
        public void Remove(Car car, Guid userId);
        public void Clear(Guid userId);
    }

}
