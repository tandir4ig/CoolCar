﻿using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICarsStorage carsStorage;
        private readonly IOrdersInterface orderStorage;

        //[ActivatorUtilitiesConstructor]
        public AdminController(ICarsStorage carsStorage, IOrdersInterface OrderStorage)
        {
            this.orderStorage = OrderStorage;
            this.carsStorage = carsStorage;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = orderStorage.GetOrders();
            return View(orders);
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
        public IActionResult EditStatus(Guid orderid)
        {
            var orders = orderStorage.GetOrders();
            var order = orders.FirstOrDefault(order => order.Id == orderid);
            return View(order);
        }

        [HttpPost]
        public IActionResult EditStatus(Guid id,OrderStatus Status)
        {
            var orders = orderStorage.GetOrders();
            var order = orders.FirstOrDefault(o => o.Id == id);
            order.Status = Status;
            return RedirectToAction("Orders");

        }
        public IActionResult AdminMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            var car1 = new Car(car.Name, car.Description, car.Cost, car.Link, car.hp, car.weight, car.maxSpeed);
            carsStorage.Add(car1);
            return RedirectToAction("Cars");
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
