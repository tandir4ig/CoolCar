using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class LikedController : Controller
    {
        private readonly ILikedInterface _LikedDatabase;
        private readonly ICarsStorage _CarsStorage;
        public LikedController(ILikedInterface likedDatabase, ICarsStorage carsStorage)
        {
            _LikedDatabase = likedDatabase;
            _CarsStorage = carsStorage;
        }
        public IActionResult Index()
        {
            var likedcars = _LikedDatabase.GetAllLiked();
            return View((object)likedcars);
        }
        public IActionResult Add(Guid carid)
        {
            var car = _CarsStorage.GetById(carid);
			var carViewModel = new CarViewModel
			{
				Id = car.Id,
				Name = car.Name,
				Description = car.Description,
				Cost = car.Cost,
				Link = car.Link,
				hp = car.hp,
				weight = car.weight,
				maxSpeed = car.maxSpeed,
			};
			_LikedDatabase.Add(carViewModel);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _LikedDatabase.Clear();
            return RedirectToAction("Index");
        }
        //public IActionResult Remove(int carid)
        //{
        //    var car = _CarsStorage.GetById(carid);
        //    _LikedDatabase.Remove(car);
        //    return RedirectToAction("Index");
        //}
    }
}
