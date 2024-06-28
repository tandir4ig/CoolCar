using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class CardController : Controller
    {
        private readonly CarsDatabase _database;
        public CardController()
        {
            _database = new CarsDatabase();
        }
        public IActionResult Index()
        {
            var card = CardsDatabase.TryGetByUserId(Constants.UserId); 
            return View((object)card);
        }
        public IActionResult Add(int carId)
        {
            var car = _database.GetById(carId);
            CardsDatabase.Add(car, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
