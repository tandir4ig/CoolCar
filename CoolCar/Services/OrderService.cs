using CoolCar.Models;
using CoolCar.Services.Interfaces;

namespace CoolCar.Services
{
    public class OrderService : IOrdersInterface
    {
        public List<Order> orders = new List<Order>();
        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order> GetOrders()
        {
            return orders;  
        }
    }
}
