using CoolCar.Db.Services.Interfaces;
using CoolCar.Helpers.Mapping;

//using CoolCar.Helpers;
//using CoolCar.Helpers.Mapping;
using CoolCar.Models;
using CoolCar.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ICarsStorage _carsDatabase;

        public HomeController(ICarsStorage carsDatabase)
        {
            _carsDatabase = carsDatabase;
        }

        [HttpGet("Catalog")]
        public IActionResult Catalog()
        {
            var CarsDb = _carsDatabase.GetAll();
            List<CarViewModel> Cars = new List<CarViewModel>();
            foreach (var car in CarsDb)
            {
                CarViewModel carViewModel = new CarViewModel()
                {
                    Id = car.Id,
                    Name = car.Name,
                    Description = car.Description,
                    Cost = car.Cost,
                    hp = car.hp,
                    weight = car.weight,
                    maxSpeed = car.maxSpeed,
                    ImagesPaths = car.Images.Select(x => x.Url).ToArray(),
                };
                Cars.Add(carViewModel);
            }
            return View((object)Cars);
        }

        [HttpGet("Car")]
        public IActionResult Car(Guid id)
        {
            var car = _carsDatabase.GetById(id);
            return View(Mapper.Car_to_CarViewModel(car));
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
