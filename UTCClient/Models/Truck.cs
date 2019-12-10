using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTCClient.Models
{
    public class Truck : Vehicle
    {
        public Truck(string brand, string model, int totalCost, int yearOfProduction, int mileage,
                   string fuel, string color, string carStatus)
        {
            base.Brand = brand;
            base.Model = model;
            base.TotalCost = totalCost;
            base.YearOfProduction = yearOfProduction;
            base.Mileage = mileage;
            base.Fuel = fuel;
            base.Color = color;
            base.CarStatus = carStatus;
        }

        public Truck(int id, string brand, string model, int totalCost, int yearOfProduction, int mileage,
                   string fuel, string color, string carStatus)
        {
            base.Id = id;
            base.Brand = brand;
            base.Model = model;
            base.TotalCost = totalCost;
            base.YearOfProduction = yearOfProduction;
            base.Mileage = mileage;
            base.Fuel = fuel;
            base.Color = color;
            base.CarStatus = carStatus;
        }
    }
}
