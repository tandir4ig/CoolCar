using Microsoft.AspNetCore.Mvc;

namespace CoolCar.Controllers
{
    public class LikedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
