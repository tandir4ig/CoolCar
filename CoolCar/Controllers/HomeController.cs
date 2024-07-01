using CoolCar.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsDatabase _carsDatabase = new CarsDatabase();
        public IActionResult Catalog()
        {
            var Cars = _carsDatabase.GetAll();
            return View((object)Cars);
        }
        public IActionResult Car(int id)
        {
            var car = _carsDatabase.GetById(id);
            return View(car);
        }
    }
}
