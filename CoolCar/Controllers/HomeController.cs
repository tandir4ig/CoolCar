using CoolCar.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsStorageService _carsDatabase = new CarsStorageService();
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
