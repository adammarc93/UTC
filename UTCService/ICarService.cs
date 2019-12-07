using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UTCService
{
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        List<Car> GetCars();

        [OperationContract]
        void PostCar(Car newCar);

        [OperationContract]
        void PutCar(Car newCar);

        [OperationContract]
        void DeleteCar(int id);
    }

    [DataContract]
    public class Car
    {
        private int id;
        private string brand;
        private string model;
        private int totalCost;
        private int yearOfProduction;
        private int mileage;
        private string fuel;
        private string carType;
        private int seats;
        private string color;
        private string carStatus;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        [DataMember]
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        [DataMember]
        public int TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        [DataMember]
        public int YearOfProduction
        {
            get { return yearOfProduction; }
            set { yearOfProduction = value; }
        }

        [DataMember]
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        [DataMember]
        public string Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        [DataMember]
        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }

        [DataMember]
        public int Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        [DataMember]
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        [DataMember]
        public string CarStatus
        {
            get { return carStatus; }
            set { carStatus = value; }
        }
    }
}
