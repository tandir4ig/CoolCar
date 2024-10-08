﻿using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoolCar.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICardsStorage _cardsStorage;
        private readonly IOrdersInterface _ordersInterface;
        public OrderController(ICardsStorage cardsStorage, IOrdersInterface ordersInterface)
        {
            _cardsStorage = cardsStorage;
            _ordersInterface = ordersInterface;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeOrder(UserDeliveryInfo order)
        {
            if (!order.FullName.All(c => char.IsLetter(c) || c == ' '))
            {
                ModelState.AddModelError("", "ФИО должно содержать только буквы");
            }
            if (!order.PhoneNumber.All(c => char.IsDigit(c) || "+()- ".Contains(c)))
            {
                ModelState.AddModelError("", "Номер телефона может содержать только цифры и символы: + , ( , ) , - .");
            }
            if (!ModelState.IsValid)
            {
                return View("index");
            }
            var existingCard = _cardsStorage.TryGetByUserId(Guid.NewGuid());
            var Order = new Order
            {
                Name = order.FullName,
                Address = order.Address,
                Email = order.Email,
                PhoneNumber = order.PhoneNumber,
                // Card = existingCard
            };
            _ordersInterface.Add(Order);
            _cardsStorage.Clear(Guid.NewGuid());
            return View("~/Views/Order/Success.cshtml");
        }
        public IActionResult AllOrders()
        {
            var orders = _ordersInterface.GetOrders();
            return View(orders);
        }
    }
}
