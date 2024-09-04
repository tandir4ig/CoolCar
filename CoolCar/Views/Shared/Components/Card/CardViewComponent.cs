using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Views.Shared.Components.Card
{
    
    public class CardViewComponent : ViewComponent
    {
        private readonly ICardsStorage cardsStorage;
        private readonly IConstants constants;
        public CardViewComponent(ICardsStorage _cardsStorage, IConstants constants)
        {
            cardsStorage = _cardsStorage;
            this.constants = constants;
        }
        //public IViewComponentResult Invoke()
        //{
        //    var card = cardsStorage.TryGetByUserId(constants.UserId);
        //    // var Amount = card?.Amount ?? 0;

        //    return View("Card", Amount);

        //}
    }
}
