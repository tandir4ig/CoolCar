using CoolCar.Db;
using CoolCar.Db.Models;
using CoolCar.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoolCar.Services
{
    public class CardsDbRepository : ICardsStorage
    {
        private readonly DatabaseContext databaseContext;

        public CardsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Card TryGetByUserId(Guid userId)
        {
            return databaseContext.Cards.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Car car, Guid userId)
        {
            Card existingCard = TryGetByUserId(userId);

            if (existingCard == null)
            {
                var newCard = new Card
                {
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
                databaseContext.Cards.Add(newCard);
            }

            else
            {
                var existingCardItem = existingCard.Cars.FirstOrDefault(x => x.car.Id == car.Id);
                if (existingCardItem != null)
                {
                    existingCardItem.Amount++;
                }   
            }
            databaseContext.SaveChanges();
        }

        public void Remove(Car car, Guid userId)
        {
            Card UserCard = TryGetByUserId(userId);

            CardItem? CardItem = UserCard.Cars.FirstOrDefault(x => x.car.Id == car.Id);

            if (CardItem.Amount > 1)
            {
                CardItem.Amount--;
            }
            else if (CardItem != null)
            {
                UserCard.Cars.Remove(CardItem);
            }
        }

        public void Clear(Guid userId)
        {
            var userCard = TryGetByUserId(userId);
            databaseContext.Cards.Remove(userCard);
            databaseContext.SaveChanges();
        }
    }
}
