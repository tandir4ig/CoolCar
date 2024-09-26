using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoolCar.Helpers.Mapping;
using Microsoft.AspNetCore.Authorization;

namespace CoolCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = CoolCar.Db.Constants.AdminRoleName)]
    public class AdminController : Controller
    {
        private readonly ICarsStorage carsStorage;
        private readonly IOrdersInterface orderStorage;
        private readonly IRoleInterface roleInterface;

        //[ActivatorUtilitiesConstructor]
        public AdminController(ICarsStorage carsStorage, IOrdersInterface OrderStorage, IRoleInterface RolesStorage)
        {
            orderStorage = OrderStorage;
            this.carsStorage = carsStorage;
            roleInterface = RolesStorage;
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
        public IActionResult AddRole(RoleViewModel role)
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
        public IActionResult DeleteRole(RoleViewModel role)
        {
            var roles = roleInterface.GetAllRoles();
            var currentRole = roles.FirstOrDefault(role => role.RoleName == role.RoleName);
            roleInterface.Remove(currentRole);
            return RedirectToAction("Roles");
        }
        public IActionResult Cars()
        {
            var cars = carsStorage.GetAll();
            var carsViewModels = new List<CarViewModel>();
            foreach(var car in cars)
            {
                CarViewModel carViewModel = new CarViewModel();
                carViewModel.Id = car.Id;
                carViewModel.Name = car.Name;
                carViewModel.Description = car.Description;
                carViewModel.Cost = car.Cost;
                carViewModel.weight = car.weight;
                carViewModel.hp = car.hp;
                carsViewModels.Add(carViewModel);
            }
            return View(carsViewModels);
        }
        public IActionResult DeleteCar(Guid carid)
        {
            var car = carsStorage.GetById(carid);
            carsStorage.Delete(car);
            return RedirectToAction("Cars");
        }
        [HttpPost]
        public IActionResult Edit(Guid carid, EditCarViewModel editcar)
        {
            carsStorage.Update(carid, Mapper.EditCarViewModel_to_EditCar(editcar));
            return RedirectToAction("cars");
        }
        public IActionResult Edit(Guid carid)
        {
            Car car = carsStorage.GetById(carid);
            var carViewModel = Mapper.Car_to_CarViewModel(car);
            return View(carViewModel);
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
