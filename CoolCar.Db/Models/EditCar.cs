namespace CoolCar.Models
{
    public class EditCar
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Link { get; set; }

        //Спецификация
        public int hp { get; set; }
        public int weight { get; set; }
        public int maxSpeed { get; set; }
    }
}
