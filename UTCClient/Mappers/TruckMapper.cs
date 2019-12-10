using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTCClient.Mappers
{
    public class TruckMapper
    {
        public UTCService.Truck MapToServiceModel(Models.Truck _truck)
        {
            UTCService.Truck truck = new UTCService.Truck();

            truck.Id = _truck.Id;
            truck.Brand = _truck.Brand;
            truck.CarStatus = _truck.CarStatus;
            truck.Color = _truck.Color;
            truck.Fuel = _truck.Fuel;
            truck.Mileage = _truck.Mileage;
            truck.Model = _truck.Model;
            truck.TotalCost = _truck.TotalCost;
            truck.YearOfProduction = _truck.YearOfProduction;

            return truck;
        }
    }
}
