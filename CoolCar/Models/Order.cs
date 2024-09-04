namespace CoolCar.Models
{
    public enum OrderStatus
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
    public class Order
    {
        public Guid Id { get; set; }
        public CardViewModel Card { get; set; }
        public string Name { get; set; }
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public string Date {  get; set; }
        public string Time {  get; set; }
        public int TotalCost
        {
            get
            {
                return Card.TotalSum;
            }
        }
        public Order()
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now.ToString("HH:mm:ss");
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            Status = OrderStatus.Created;
        }
    }
}

