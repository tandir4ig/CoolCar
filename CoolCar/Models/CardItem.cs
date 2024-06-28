namespace CoolCar.Models
{
    public class CardItem
    {
        public Guid Id { get; set; }
        public Car car { get; set; }
        public int Amount {  get; set; }
        public int Cost
        {
            get
            {
                return Amount*car.Cost;
            }
        }
    }
}
