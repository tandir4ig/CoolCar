using CoolCar.Db.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoolCar.Db
{
    public class IdentityContext : IdentityDbContext<UserDb>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) 
            : base(options)
        {
            Database.Migrate(); 
        }
    }
}
