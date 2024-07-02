using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICardsStorage _cardsStorage;
        private readonly IConstants _constants;
        public OrderController(ICardsStorage cardsStorage, IConstants constants)
        {
            _cardsStorage = cardsStorage;
            _constants = constants;
        }
        public IActionResult Index()
        {
            var UserCard = _cardsStorage.TryGetByUserId(_constants.UserId);
            return View(UserCard);
        }
        public IActionResult MakeOrder()
        {
            _cardsStorage.Clear(_constants.UserId);
            return View("~/Views/Order/Success.cshtml");
        }
    }
}
