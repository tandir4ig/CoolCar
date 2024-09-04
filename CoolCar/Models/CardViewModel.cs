namespace CoolCar.Models
{
    public class CardViewModel
    {

        public Guid Id { get; set; }
        public List<CardItemViewModel> Cars { get; set; }
        public string UserId {  get; set; }
        public int TotalSum
        {
            get
            {
                return Cars.Sum(car => car.Cost);
            }
        }
        public int Amount
        {
            get
            {
                return Cars?.Sum(car => car.Amount) ?? 0;
            }
        }
    }
}
