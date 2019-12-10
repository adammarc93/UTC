namespace UTCClient.Models
{
    public class Car : Vehicle
    {
        public string CarType { get; set; }

        public int Seats { get; set; }

        public Car(string brand, string model, int totalCost, int yearOfProduction, int mileage,
                   string fuel, string carType, int seats, string color, string carStatus)
        {
            base.Brand = brand;
            base.Model = model;
            base.TotalCost = totalCost;
            base.YearOfProduction = yearOfProduction;
            base.Mileage = mileage;
            base.Fuel = fuel;
            this.CarType = carType;
            this.Seats = seats;
            base.Color = color;
            base.CarStatus = carStatus;
        }

        public Car(int id, string brand, string model, int totalCost, int yearOfProduction, int mileage,
                   string fuel, string carType, int seats, string color, string carStatus)
        {
            base.Id = id;
            base.Brand = brand;
            base.Model = model;
            base.TotalCost = totalCost;
            base.YearOfProduction = yearOfProduction;
            base.Mileage = mileage;
            base.Fuel = fuel;
            this.CarType = carType;
            this.Seats = seats;
            base.Color = color;
            base.CarStatus = carStatus;
        }

        public override bool IsEmpty()
        {
            if (base.Brand == "" && base.CarStatus == "" && this.CarType == "" && base.Color == "" && base.Fuel == "" &&
                base.Mileage == 0 && base.Model == "" && this.Seats == 0 && base.TotalCost == 0 && base.YearOfProduction == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
