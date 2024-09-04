using CoolCar.Db.Models;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Models;

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
        public void Update(Guid Id, EditCar car)
        {
            var carDb = GetById(Id);

            carDb.Name = car.Name;
            carDb.Description = car.Description;
            carDb.Cost = car.Cost;
            carDb.Link = car.Link;
            carDb.hp = car.hp;
            carDb.weight = car.weight;
            carDb.maxSpeed = car.maxSpeed;

            databaseContext.Update(carDb);
            databaseContext.SaveChanges();
        }
    }
}
