using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareInterface compareInterface;
        private readonly ICarsStorage _carsDatabase;
        

        public CompareController(ICompareInterface compareInterface, ICarsStorage _carsDatabase)
        {
            this.compareInterface = compareInterface;
            this._carsDatabase = _carsDatabase;
            
        }
        public IActionResult Index()
        {
            var compareCars = compareInterface.GetAllCompare();
            return View(compareCars);
        }
        public IActionResult Add(int carid)
        {
            var compareCar = _carsDatabase.GetById(carid);
            compareInterface.Add(compareCar);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int carid)
        {
            var tempCar = _carsDatabase.GetById(carid);
            compareInterface.Remove(tempCar);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            compareInterface.Clear();
            return RedirectToAction("Index");
        }
    }
}
