using CoolCar.Models;

namespace CoolCar
{
    public static class CardsDatabase
    {
        private static List<Card> cards = new List<Card>();

        public static Card TryGetByUserId(string userId)
        {
            return cards.FirstOrDefault(x => x.UserId == userId);
        }

        public static void Add(Car car, string userId)
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
    }
}
