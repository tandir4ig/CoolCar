//using CoolCar.Db.Models;
//using CoolCar.Db.Services.Interfaces;
//using CoolCar.Models;
//using CoolCar.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using CoolCar.Helpers.Mapping;
//using Microsoft.AspNetCore.Authorization;
//using CoolCar.Areas.Admin.Models;
//using CoolCar.Helpers;

//namespace CoolCar.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Route("Admin/[controller]/[action]")]
//    [Authorize(Roles = CoolCar.Db.Constants.AdminRoleName)]
//    public class AdminController : Controller
//    {
//        private readonly ICarsStorage carsStorage;
//        //private readonly ImagesProvider imagesProvider;

//        //[ActivatorUtilitiesConstructor]
//        public AdminController(ICarsStorage carsStorage)
//        {
//            this.carsStorage = carsStorage;
//        }
//        [HttpGet("Index")]
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpGet]
//        public IActionResult AddRole()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddRole(RoleViewModel role)
//        {
//            var roles = roleInterface.GetAllRoles();
//            if (roles.FirstOrDefault(Role => Role.RoleName == role.RoleName) != null)
//            {
//                ModelState.AddModelError("", "Такая роль уже существует");
//            }
//            if (!ModelState.IsValid)
//            {
//                return View();
//            }
//            roles.Add(role);
//            return RedirectToAction("Roles");
//        }

//        [HttpPost]
//        public IActionResult DeleteRole(RoleViewModel role)
//        {
//            var roles = roleInterface.GetAllRoles();
//            var currentRole = roles.FirstOrDefault(role => role.RoleName == role.RoleName);
//            roleInterface.Remove(currentRole);
//            return RedirectToAction("Roles");
//        }

//        [HttpGet]
//        public IActionResult Cars()
//        {
//            var cars = carsStorage.GetAll();
//            var carsViewModels = new List<CarViewModel>();
//            foreach(var car in cars)
//            {
//                CarViewModel carViewModel = new CarViewModel();
//                carViewModel.Id = car.Id;
//                carViewModel.Name = car.Name;
//                carViewModel.Description = car.Description;
//                carViewModel.Cost = car.Cost;
//                carViewModel.weight = car.weight;
//                carViewModel.hp = car.hp;
//                carsViewModels.Add(carViewModel);
//            }
//            return View(carsViewModels);
//        }

//        [HttpGet]
//        public IActionResult DeleteCar(Guid carid)
//        {
//            var car = carsStorage.GetById(carid);
//            carsStorage.Delete(car);
//            return RedirectToAction("Cars");
//        }

//        [HttpPost]
//        public IActionResult Edit(EditCarViewModel editCarViewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(editCarViewModel);
//            }

//            var addedImagePaths = imagesProvider.SafeFiles(editCarViewModel.UploadedFiles, ImageFolders.Cars); //Вернули адреса добавленных картинок
//            editCarViewModel.ImagesPaths = addedImagePaths; // переопределили текущие пути к картинкам на пути новых картинок
//            carsStorage.Update(editCarViewModel.ToCar());
//            return RedirectToAction("cars");
//        }

//        [HttpGet]
//        public IActionResult Edit(Guid carid)
//        {
//            Car car = carsStorage.GetById(carid);
//            return View(car.ToEditCarViewModel());
//        }

//        [HttpGet]
//        public IActionResult AdminMenu()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(AddCarViewModel car)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(car);
//            }

//            var imagesPath = imagesProvider.SafeFiles(car.UploadedFiles, ImageFolders.Cars);

//            carsStorage.Add(car.ToCar(imagesPath));
//            return RedirectToAction("Catalog", "Home");
//        }

//        [HttpGet]
//        public IActionResult Add()
//        {
//            return View();
//        }
//    }
//}
