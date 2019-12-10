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

        public virtual bool IsEmpty()
        {
            if (Brand == "" && CarStatus == "" && Color == "" && Fuel == "" &&
                Mileage == 0 && Model == "" && TotalCost == 0 && YearOfProduction == 0)
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
