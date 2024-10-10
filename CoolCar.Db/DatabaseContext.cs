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
        public DbSet<Card> Cards { get; set; }
        public DbSet<Car> Cars { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<CardItem> Items { get; set; }
		

		public DatabaseContext(DbContextOptions<DatabaseContext> options) 
			: base(options) 
		{
			Database.Migrate();
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Image>().HasOne(p => p.Car).WithMany(p => p.Images).HasForeignKey(p => p.CarId).OnDelete(DeleteBehavior.Cascade);
        }
    }	
}
