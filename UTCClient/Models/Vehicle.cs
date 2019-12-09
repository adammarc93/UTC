﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTCClient.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int TotalCost { get; set; }

        public int YearOfProduction { get; set; }

        public int Mileage { get; set; }

        public string Fuel { get; set; }

        public string Color { get; set; }

        public string CarStatus { get; set; }
    }
}