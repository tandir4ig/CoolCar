using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Views.Shared.Components.Card
{
    
    public class CardViewComponent : ViewComponent
    {
        private readonly ICardsStorage cardsStorage;
        public CardViewComponent(ICardsStorage _cardsStorage)
        {
            cardsStorage = _cardsStorage;
        }
        //public IViewComponentResult Invoke()
        //{
        //    var cardViewModel = cardsStorage.TryGetByUserId(constants.UserId);
        //    var Amount = cardViewModel?.Amount ?? 0;

        //    return View("Card", Amount);

        //}
    }
}
