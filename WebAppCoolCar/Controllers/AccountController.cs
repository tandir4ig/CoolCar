using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
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
    public class AccountController : Controller
    {
        private readonly ICarsStorage _carsDatabase;
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AccountController(ICarsStorage carsDatabase, IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            _carsDatabase = carsDatabase;
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public IActionResult Auth([FromBody] LoginModel user)
        {
            bool isValid = userService.IsValidUserInformationForAuth(user, signInManager);
            if (isValid)
            {
                var tokenString = GenerateJwtToken(user.Name);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valid Username and Password");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegUser user)
        {
            bool isValid = userService.IsValidUserInformationForRegister(user, userManager);
            if (isValid)
            {
                var tokenString = GenerateJwtToken(user.Email);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valiid Username and password");
        }

        private string GenerateJwtToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("email", userName) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
