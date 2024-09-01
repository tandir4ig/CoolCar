using CoolCar.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCar.Db
{
	public class DatabaseContext : DbContext
	{
		// Доступ к таблицам
		public DbSet<Car> Cars { get; set; }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) 
			: base(options) 
		{
			Database.EnsureCreated();
		}
	}
}
