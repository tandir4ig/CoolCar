using CoolCar.Db;
using CoolCar.Db.Models;
using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly ICarsStorage carsStorage;
        private readonly IOrdersInterface orderStorage;
        private readonly IRoleInterface roleInterface;
        private readonly IUserInterface userInterface;

        //[ActivatorUtilitiesConstructor]
        public AdminController(ICarsStorage carsStorage, IOrdersInterface OrderStorage, IRoleInterface RolesStorage, IUserInterface userInterface)
        {
            orderStorage = OrderStorage;
            this.carsStorage = carsStorage;
            roleInterface = RolesStorage;
            this.userInterface = userInterface;
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
            return View(userInterface.GetAll());
        }
        public IActionResult Roles()
        {
            var roles = roleInterface.GetAllRoles();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            var roles = roleInterface.GetAllRoles();
            if (roles.FirstOrDefault(Role => Role.RoleName == role.RoleName) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            roles.Add(role);
            return RedirectToAction("Roles");
        }
        [HttpPost]
        public IActionResult DeleteRole(Role role)
        {
            var roles = roleInterface.GetAllRoles();
            var currentRole = roles.FirstOrDefault(role => role.RoleName == role.RoleName);
            roleInterface.Remove(currentRole);
            return RedirectToAction("Roles");
        }
        public IActionResult Cars()
        {
            var cars = carsStorage.GetAll();
            return View(cars);
        }
        public IActionResult DeleteCar(Guid carid)
        {
            var car = carsStorage.GetById(carid);
            carsStorage.Delete(car);
            return RedirectToAction("Cars");
        }
        [HttpPost]
        public IActionResult Edit(Guid carid, EditCar editcar)
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
        public IActionResult Edit(Guid carid)
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
        public IActionResult EditStatus(Guid id, OrderStatus Status)
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
        public IActionResult Add(CarViewModel car)
        {
            var car1 = new CarViewModel(car.Name, car.Description, car.Cost, car.Link, car.hp, car.weight, car.maxSpeed);

            var CarDb = new Car
            {
                Name = car1.Name,
                Description = car1.Description,
                Cost = car1.Cost,
                Link = car1.Link,
                hp = car1.hp,
                weight = car1.weight,
                maxSpeed = car1.maxSpeed
            };

            carsStorage.Add(CarDb);
            return RedirectToAction("Cars");
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
