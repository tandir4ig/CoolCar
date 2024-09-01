using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class CardsDatabase : ICardsStorage
    {
        private  List<Card> cards = new List<Card>();

        public Card TryGetByUserId(string userId)
        {
            return cards.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(CarViewModel car, string userId)
        {
            Card existingCard = TryGetByUserId(userId);

            if (existingCard == null)
            {
                var newCard = new Card
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Cars = new List<CardItem>
                    {
                        new CardItem
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
                else existingCard.Cars.Add(new CardItem
                {
                    Id = Guid.NewGuid(),
                    Amount = 1,
                    car = car
                });
            }

        }

        public void Remove(CarViewModel car, string userId)
        {
            Card UserCard = TryGetByUserId(userId);

            CardItem? CardItem = UserCard.Cars.FirstOrDefault(x => x.car.Id == car.Id);

            if (CardItem.Amount > 1)
            {
                CardItem.Amount--;
            }
            else
            {
                UserCard.Cars.Remove(CardItem);
            }
        }

        public void Clear(string userId)
        {
            var userCard = TryGetByUserId(userId);
            cards.Remove(userCard);
        }
    }
}
