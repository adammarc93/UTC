using System.Collections.Generic;

using UTCClient.Mappers;
using UTCClient.Models;

namespace UTCClient.ViewModels
{
    public class CarViewModel
    {
        public List<Car> Cars { get; set; }

        private CarServiceClient client;

        public CarViewModel()
        {
            Cars = new List<Car>();
            client = new CarServiceClient();
        }

        public async void GetCars()
        {
            var cars = await client.GetCarsAsync();

            Cars.Clear();

            foreach (var car in cars)
            {
                Car newCar = new Car(car.Id, car.Brand, car.Model, car.TotalCost, car.YearOfProduction, car.Mileage,
                                                   car.Fuel, car.CarType, car.Seats, car.Color, car.CarStatus);

                Cars.Add(newCar);
            }
        }

        public async void AddCar(Car car)
        {
            var mapper = new CarMapper();
            var newCar = mapper.MapToServiceModel(car);

            await client.AddCarAsync(newCar);
        }

        public async void DeleteCar(int id)
        {
            await client.DeleteCarAsync(id);
        }
    }
}
