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
        public IActionResult Add(int carid)
        {
            var car = _CarsStorage.GetById(carid);
            _LikedDatabase.Add(car);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _LikedDatabase.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int carid)
        {
            var car = _CarsStorage.GetById(carid);
            _LikedDatabase.Remove(car);
            return RedirectToAction("Index");
        }
    }
}
