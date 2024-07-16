namespace CoolCar.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Card Card { get; set; }
        public string Name { get; set; }
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

