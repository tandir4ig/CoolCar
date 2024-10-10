using CoolCar.Areas.Admin.Models;
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
                //UserId = cardViewModel.UserId,
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
                hp = car.hp,
                weight = car.weight,
                maxSpeed = car.maxSpeed,
                ImagesPaths = ToImagesPaths(car.Images).ToArray()
            };
        }
        public static List<UserViewModel> Users_to_UsersViewModel(List<User> Users)
        {
            List<UserViewModel> UsersViewModelList = new List<UserViewModel>();

            foreach (var user in Users)
            {
                UsersViewModelList.Add(new UserViewModel(user.UserName, user.PhoneNumber));
            }

            return UsersViewModelList;
        }
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel(user.UserName, user.PhoneNumber) { Id = user.Id };
        }
        public static Car AddCarViewModel_to_Car(this AddCarViewModel car)
        {
            return new Car()
            {
                Name = car.Name,
                Description = car.Description,
                Cost = car.Cost,
                hp = car.hp,
                weight = car.weight,
                maxSpeed = car.maxSpeed,
            };
        }
        public static Car ToCar(this AddCarViewModel addCarViewModel, List<string> imagesPath)
        {
            return new Car
            {
                Name = addCarViewModel.Name,
                Description = addCarViewModel.Description,
                Cost = addCarViewModel.Cost,
                hp = addCarViewModel.hp,
                weight = addCarViewModel.weight,
                maxSpeed = addCarViewModel.maxSpeed,
                Images = ToImages(imagesPath)
            };
        }
        public static Car ToCar(this EditCarViewModel editCarViewModel)
        {
            return new Car()
            {
                Id = editCarViewModel.Id,
                Name = editCarViewModel.Name,
                Description = editCarViewModel.Description,
                Cost = editCarViewModel.Cost,
                hp = editCarViewModel.hp,
                weight = editCarViewModel.weight,
                maxSpeed = editCarViewModel.maxSpeed,
                Images = editCarViewModel.ImagesPaths.ToImages()
            }; 
        }
        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image() { Url = x }).ToList();
        }
        public static List<string> ToPaths(this List<Image> images)
        {
            return images.Select(x => x.Url).ToList();
        }
        public static List<string> ToImagesPaths(this List<Image> paths)
        {
            return paths.Select(x => x.Url).ToList();
        }
        public static EditCarViewModel ToEditCarViewModel(this Car car)
        {
            return new EditCarViewModel()
            {
                Id = car.Id,
                Name = car.Name,
                Description = car.Description,
                Cost = car.Cost,
                hp = car.hp,
                weight = car.weight,
                maxSpeed = car.maxSpeed,
                ImagesPaths = car.Images.ToImagesPaths()
            };
        }
    }
}
