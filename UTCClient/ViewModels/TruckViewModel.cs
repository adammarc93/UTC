using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTCClient.Mappers;
using UTCClient.Models;

namespace UTCClient.ViewModels
{
    public class TruckViewModel
    {
        public List<Truck> Trucks { get; set; }

        private TruckServiceClient client;

        public TruckViewModel()
        {
            Trucks = new List<Truck>();
            client = new TruckServiceClient();
        }

        public async void GetTrucks()
        {
            var trucks = await client.GetTrucksAsync();

            Trucks.Clear();

            foreach (var car in trucks)
            {
                Truck newCar = new Truck(car.Id, car.Brand, car.Model, car.TotalCost, car.YearOfProduction, car.Mileage,
                                                   car.Fuel, car.Color, car.CarStatus);

                Trucks.Add(newCar);
            }
        }

        public async void AddTruck(Truck truck)
        {
            var mapper = new TruckMapper();
            var newTruck = mapper.MapToServiceModel(truck);

            await client.AddTruckAsync(newTruck);
        }

        public async void DeleteTruck(int id)
        {
            await client.DeleteTruckAsync(id);
        }
    }
}
