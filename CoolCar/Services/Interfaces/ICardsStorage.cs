﻿using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface ICardsStorage
    {
        public Card TryGetByUserId(string userId);
        public void Add(CarViewModel car, string userId);
        public void Remove(CarViewModel car, string userId);
        public void Clear(string userId);
    }

}
