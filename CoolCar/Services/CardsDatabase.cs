using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class CardsDatabase : ICardsStorage
    {
        private  List<CardViewModel> cards = new List<CardViewModel>();

        public CardViewModel TryGetByUserId(string userId)
        {
            return cards.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(CarViewModel car, string userId)
        {
            CardViewModel existingCard = TryGetByUserId(userId);

            if (existingCard == null)
            {
                var newCard = new CardViewModel
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Cars = new List<CardItemViewModel>
                    {
                        new CardItemViewModel
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            car = car
                        }
                    }
                };
                cards.Add(newCard);
            }
            else
            {
                var existingCardItem = existingCard.Cars.FirstOrDefault(x => x.car.Id == car.Id);
                if (existingCardItem != null)
                {
                    existingCardItem.Amount++;
                }
                
            }

        }

        public void Remove(CarViewModel car, string userId)
        {
            CardViewModel UserCard = TryGetByUserId(userId);

            CardItemViewModel? CardItem = UserCard.Cars.FirstOrDefault(x => x.car.Id == car.Id);

            if (CardItem.Amount > 1)
            {
                CardItem.Amount--;
            }
            //else
            //{
            //    UserCard.Cars.Remove(CardItemViewModel);
            //}
        }

        public void Clear(string userId)
        {
            var userCard = TryGetByUserId(userId);
            cards.Remove(userCard);
        }
    }
}
