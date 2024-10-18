using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Helpers.Mapping;

//using CoolCar.Helpers;
//using CoolCar.Helpers.Mapping;
using CoolCar.Models;
using CoolCar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAppCoolCar.Models;
using WebAppCoolCar.Services;
using WebAppCoolCar.Services.Interfaces;

namespace WebAppCoolCar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ICarsStorage _carsDatabase;
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public HomeController(ICarsStorage carsDatabase, IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            _carsDatabase = carsDatabase;
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpGet("Catalog")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<CarViewModel>> Catalog()
        {
            var CarsDb = _carsDatabase.GetAll();
            List<CarViewModel> Cars = new List<CarViewModel>();
            foreach (var car in CarsDb)
            {
                CarViewModel carViewModel = new CarViewModel()
                {
                    Id = car.Id,
                    Name = car.Name,
                    Description = car.Description,
                    Cost = car.Cost,
                    hp = car.hp,
                    weight = car.weight,
                    maxSpeed = car.maxSpeed,
                    ImagesPaths = car.Images.Select(x => x.Url).ToArray(),
                };
                Cars.Add(carViewModel);
            }
            return Cars;
        }

        [HttpGet("Car")]
        public async Task<CarViewModel> Car(Guid id)
        {
            var car = _carsDatabase.GetById(id);
            return Mapper.Car_to_CarViewModel(car);
        }

        [HttpPost]
        public async Task<List<Car>> Search(string name)
        {
            if(name != null)
            {
                var products = _carsDatabase.GetAll();
                var needProduct = products.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                return needProduct;
            }
            return null;
        }

        //Generation JWT toker after successful login.

    }
}
