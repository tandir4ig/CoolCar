using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class LikedService : ILikedInterface
    {
        public List<CarViewModel> Liked = new List<CarViewModel>();
        public void Add(CarViewModel car)
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
        public void Remove(CarViewModel car)
        {
            Liked.Remove(car);
        }
        public void Clear()
        {
            Liked.Clear();
        }
        public List<CarViewModel> GetAllLiked()
        {
            return Liked;
        }
    }
}
