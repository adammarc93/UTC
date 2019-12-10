using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTCClient.Mappers
{
    public class CarMapper
    {
        public UTCService.Car MapToServiceModel(Models.Car _car)
        {
            UTCService.Car car = new UTCService.Car();

            car.Id = _car.Id;
            car.Brand = _car.Brand;
            car.CarStatus = _car.CarStatus;
            car.CarType = _car.CarType;
            car.Color = _car.Color;
            car.Fuel = _car.Fuel;
            car.Mileage = _car.Mileage;
            car.Model = _car.Model;
            car.Seats = _car.Seats;
            car.TotalCost = _car.TotalCost;
            car.YearOfProduction = _car.YearOfProduction;

            return car;
        }
    }
}
