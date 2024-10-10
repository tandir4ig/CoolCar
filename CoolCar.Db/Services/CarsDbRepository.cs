using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolCar.Db.Services
{
    public class CarsDbRepository : ICarsStorage
    {
        private readonly DatabaseContext databaseContext;
        public CarsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Car> GetAll()
        {
            return databaseContext.Cars.Include(x => x.Images).ToList();
        }
        public Car GetById(Guid id)
        {
            return databaseContext.Cars.Include(x => x.Images).FirstOrDefault(car => car.Id == id);
        }
        public void Delete(Car car)
        {
            databaseContext.Cars.Remove(car);
            databaseContext.SaveChanges();
        }
        public void Add(Car car)
        {
            databaseContext.Cars.Add(car);
            databaseContext.SaveChanges();
        }
        public void Update(Car car)
        {
            var existingCar = databaseContext.Cars.Include(x => x.Images).FirstOrDefault(x => x.Id == car.Id);

            existingCar.Name = car.Name;
            existingCar.Description = car.Description;
            existingCar.Cost = car.Cost;
            existingCar.hp = car.hp;
            existingCar.weight = car.weight;
            existingCar.maxSpeed = car.maxSpeed;

            foreach(var image in car.Images)
            {
                image.CarId = car.Id;
                databaseContext.Images.Add(image);
            }

            databaseContext.SaveChanges();
        }
    }
}
