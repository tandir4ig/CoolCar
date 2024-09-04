using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;

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
            return databaseContext.Cars.ToList();
        }
        public Car GetById(Guid id)
        {
            return databaseContext.Cars.FirstOrDefault(car => car.Id == id);
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
    }
}
