using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Models;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoolCar.Helpers.Mapping;
using Microsoft.AspNetCore.Authorization;
using CoolCar.Areas.Admin.Models;
using CoolCar.Helpers;

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
        private readonly ImagesProvider imagesProvider;

        //[ActivatorUtilitiesConstructor]
        public AdminController(ICarsStorage carsStorage, IOrdersInterface OrderStorage, IRoleInterface RolesStorage, ImagesProvider imagesProvider)
        {
            orderStorage = OrderStorage;
            this.carsStorage = carsStorage;
            roleInterface = RolesStorage;
            this.imagesProvider = imagesProvider;
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
        public IActionResult Edit(EditCarViewModel editCarViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editCarViewModel);
            }

            var addedImagePaths = imagesProvider.SafeFiles(editCarViewModel.UploadedFiles, ImageFolders.Cars); //Вернули адреса добавленных картинок
            editCarViewModel.ImagesPaths = addedImagePaths; // переопределили текущие пути к картинкам на пути новых картинок
            carsStorage.Update(editCarViewModel.ToCar());
            return RedirectToAction("cars");
        }
        public IActionResult Edit(Guid carid)
        {
            Car car = carsStorage.GetById(carid);
            return View(car.ToEditCarViewModel());
        }

        public IActionResult AdminMenu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCarViewModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var imagesPath = imagesProvider.SafeFiles(car.UploadedFiles, ImageFolders.Cars);

            carsStorage.Add(car.ToCar(imagesPath));
            return RedirectToAction("Catalog", "Home");
        }
        public IActionResult Add()
        {
            return View();
        }

        //public IActionResult EditStatus(Guid orderid)
        //{
        //    var orders = orderStorage.GetOrders();
        //    var order = orders.FirstOrDefault(order => order.Id == orderid);
        //    return View(order);
        //}

        //[HttpPost]
        //public IActionResult EditStatus(Guid id, OrderStatus Status)
        //{
        //    var orders = orderStorage.GetOrders();
        //    var order = orders.FirstOrDefault(o => o.Id == id);
        //    order.Status = Status;
        //    return RedirectToAction("Orders");
        //}
    }
}
