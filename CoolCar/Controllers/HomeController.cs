using CoolCar.Db;
using CoolCar.Models;
using CoolCar.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsDbRepository _carsDatabase;

        public HomeController(CarsDbRepository carsDatabase)
        {
            _carsDatabase = carsDatabase;
        }

        public IActionResult Catalog()
        {
            var CarsDb = _carsDatabase.GetAll();
            List<CarViewModel> Cars = new List<CarViewModel>();
            foreach (var car in CarsDb)
            {
                CarViewModel carViewModel = new CarViewModel()
                {
                    Name = car.Name,
                    Description = car.Description,
                    Cost = car.Cost,
                    Link = car.Link,
                    hp = car.hp,
                    weight = car.weight,
                    maxSpeed = car.maxSpeed
                };
                Cars.Add(carViewModel);
            }
            return View((object)Cars);
        }

        public IActionResult Car(Guid id)
        {
            var car = _carsDatabase.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if(name != null)
            {
                var products = _carsDatabase.GetAll();
                var needProduct = products.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                return View(needProduct);
            }
            return RedirectToAction("Catalog");
        }
    }
}
