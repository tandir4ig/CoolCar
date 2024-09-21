using CoolCar.Db.Models;
using CoolCar.Models;

namespace CoolCar.Helpers.Mapping
{
    public static class Mapper
    {
        public static Card Card_to_CardViewModel(CardViewModel cardViewModel)
        {
            return new Card()
            {
                Id = cardViewModel.Id,
                UserId = cardViewModel.UserId,
                Cars = new List<CardItem>(),
            };
        }

        public static List<CardItem> CardItemViewModelList_to_CardItemList(List<CardItemViewModel> list)
        {
            List<CardItem> cardItemList = new List<CardItem>();

            foreach (var item in list)
            {
                cardItemList.Add(new CardItem()
                {
                    Id = item.Id,
                    car = CarViewModel_to_Car(item.car),
                    Amount = item.Amount,
                });
            }

            return cardItemList;
        }

        public static Car CarViewModel_to_Car(CarViewModel carViewModel)
        {
            return new Car()
            {
                Id = carViewModel.Id,
                Name = carViewModel.Name,
                Description = carViewModel.Description,
                Cost = carViewModel.Cost,
                Link = carViewModel.Link,
                hp = carViewModel.hp,
                weight = carViewModel.weight,
                maxSpeed = carViewModel.maxSpeed,
            };
        }
        public static CarViewModel Car_to_CarViewModel(Car car)
        {
            return new CarViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                Description = car.Description,
                Cost = car.Cost,
                Link = car.Link,
                hp = car.hp,
                weight = car.weight,
                maxSpeed = car.maxSpeed,
            };
        }

        public static EditCar EditCarViewModel_to_EditCar(EditCarViewModel editCarViewModel)
        {
            return new EditCar()
            {
                Name = editCarViewModel.Name,
                Description = editCarViewModel.Description,
                Cost = editCarViewModel.Cost,
                Link = editCarViewModel.Link,
                hp = editCarViewModel.hp,
                weight = editCarViewModel.weight,
                maxSpeed = editCarViewModel.maxSpeed,
            };
        }
        public static List<UserViewModel> Users_to_UsersViewModel(List<User> Users)
        {
            List<UserViewModel> UsersViewModelList = new List<UserViewModel>();

            foreach(var user in Users)
            {
                UsersViewModelList.Add(new UserViewModel(user.UserName, user.PhoneNumber));    
            }

            return UsersViewModelList;
        }
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel(user.UserName, user.PhoneNumber) { Id = user.Id};
        }
    }
}
