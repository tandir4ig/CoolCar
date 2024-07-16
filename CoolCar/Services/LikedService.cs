using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class LikedService : ILikedInterface
    {
        public List<Car> Liked = new List<Car>();
        public void Add(Car car)
        {
            if(Liked.Contains(car))
            {
                return;
            }
            else
            {
                Liked.Add(car);
            }
        }
        public void Remove(Car car)
        {
            Liked.Remove(car);
        }
        public void Clear()
        {
            Liked.Clear();
        }
        public List<Car> GetAllLiked()
        {
            return Liked;
        }
    }
}
