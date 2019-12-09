using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTCClient.Mappers;

namespace UTCClient.ViewModels
{
    public class CarViewModel
    {
        public List<Models.Car> Cars { get; set; }

        private CarServiceClient client;

        public CarViewModel()
        {
            Cars = new List<Models.Car>();
            client = new CarServiceClient();
        }

        public async void GetCars()
        {
            var cars = await client.GetCarsAsync();

            Cars.Clear();

            foreach (var car in cars)
            {
                Models.Car newCar = new Models.Car(car.Id, car.Brand, car.Model, car.TotalCost, car.YearOfProduction, car.Mileage,
                                                   car.Fuel, car.CarType, car.Seats, car.Color, car.CarStatus);

                Cars.Add(newCar);
            }
        }

        public async void AddCar(Models.Car car)
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
