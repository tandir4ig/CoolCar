using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICarsStorage carsStorage;

        //[ActivatorUtilitiesConstructor]
        public AdminController(ICarsStorage carsStorage)
        {
            this.carsStorage = carsStorage;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Cars()
        {
            var cars = carsStorage.GetAll();
            return View(cars);
        }
        public IActionResult DeleteCar(int carid)
        {
            var car = carsStorage.GetById(carid);
            carsStorage.Delete(car);
            return RedirectToAction("Cars");
        }
        [HttpPost]
        public IActionResult Edit(int carid, EditCar editcar)
        {
            var tempcar = carsStorage.GetById(carid);
            tempcar.Name = editcar.Name;
            tempcar.Description = editcar.Description;
            tempcar.Cost = editcar.Cost;
            tempcar.hp = editcar.hp;
            tempcar.weight = editcar.weight;
            tempcar.maxSpeed = editcar.maxSpeed;
            return RedirectToAction("cars");
        }
        public IActionResult Edit(int carid)
        {
            var car = carsStorage.GetById(carid);
            return View(car);
        }
        public IActionResult AdminMenu()
        {
            return View();
        }
    }
}
