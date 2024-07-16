using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICardsStorage _cardsStorage;
        private readonly IConstants _constants;
        private readonly IOrdersInterface _ordersInterface;
        public OrderController(ICardsStorage cardsStorage, IConstants constants, IOrdersInterface ordersInterface)
        {
            _cardsStorage = cardsStorage;
            _constants = constants;
            _ordersInterface = ordersInterface;
        }
        public IActionResult Index()
        {
            var UserCard = _cardsStorage.TryGetByUserId(_constants.UserId);
            return View(UserCard);
        }
        [HttpPost]
        public IActionResult MakeOrder(Order order)
        {
            _ordersInterface.Add(order);
            _cardsStorage.Clear(_constants.UserId);
            return View("~/Views/Order/Success.cshtml");
        }
        public IActionResult AllOrders()
        {
            var orders = _ordersInterface.GetOrders();
            return View(orders);
        }
    }
}
