using CoolCar.Services;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class CardController : Controller
    {
        private readonly ICarsStorage _database;
        private readonly ICardsStorage _cardsDatabase;
        private readonly IConstants _constants;
        
        public CardController(ICardsStorage cardsDatabase, IConstants constants, ICarsStorage carsDatabase)
        {
            _database = carsDatabase;
            _cardsDatabase = cardsDatabase;
            _constants = constants;
        }
        public IActionResult Index()
        {
            var card = _cardsDatabase.TryGetByUserId(_constants.UserId); 
            return View((object)card);
        }
        public IActionResult Add(int carId)
        {
            var car = _database.GetById(carId);
            _cardsDatabase.Add(car, _constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int carId)
        {
            var tempCar = _database.GetById(carId);
            _cardsDatabase.Remove(tempCar, _constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _cardsDatabase.Clear(_constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
