using CoolCar.Models;

namespace CoolCar.Services.Interfaces
{
    public interface IOrdersInterface
    {
        public void Add(Order order);
        public List<Order> GetOrders();
    }
}
