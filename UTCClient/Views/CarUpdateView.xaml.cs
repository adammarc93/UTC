using System;
using System.Windows;

using UTCClient.Models;
using UTCClient.ViewModels;

namespace UTCClient.Views
{
    public partial class CarUpdateView : Window
    {
        private CarUpdateViewModel viewModel;
        private int Id;

        public CarUpdateView(Car updateCar)
        {
            InitializeComponent();
            viewModel = new CarUpdateViewModel();

            this.Id = updateCar.Id;
            this.BarndTextBox.Text = updateCar.Brand;
            this.ModelTextBox.Text = updateCar.Model;
            this.TotalCostTextBox.Text = updateCar.TotalCost.ToString();
            this.YearOfProductionTextBox.Text = updateCar.YearOfProduction.ToString();
            this.MileageTextBox.Text = updateCar.Mileage.ToString();
            this.FuelTextBox.Text = updateCar.Fuel;
            this.CarTypeTextBox.Text = updateCar.CarType;
            this.SeatsTextBox.Text = updateCar.Seats.ToString();
            this.ColorTextBox.Text = updateCar.Color;
            this.CarStatusTextBox.Text = updateCar.CarStatus;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var brand = !String.IsNullOrEmpty(this.BarndTextBox.Text) ? this.BarndTextBox.Text : "";
            var model = !String.IsNullOrEmpty(this.ModelTextBox.Text) ? this.ModelTextBox.Text : "";
            var totalCost = Convert.ToInt32(!String.IsNullOrEmpty(this.TotalCostTextBox.Text) ? this.TotalCostTextBox.Text : null);
            var yearOfProduction = Convert.ToInt32(!String.IsNullOrEmpty(this.YearOfProductionTextBox.Text) ? this.YearOfProductionTextBox.Text : null);
            var mileage = Convert.ToInt32(!String.IsNullOrEmpty(this.MileageTextBox.Text) ? this.MileageTextBox.Text : null);
            string fuel = !String.IsNullOrEmpty(this.FuelTextBox.Text) ? this.FuelTextBox.Text : "";
            string carType = !String.IsNullOrEmpty(this.CarTypeTextBox.Text) ? this.CarTypeTextBox.Text : "";
            int seats = Convert.ToInt32(!String.IsNullOrEmpty(this.SeatsTextBox.Text) ? this.SeatsTextBox.Text : null);
            string color = !String.IsNullOrEmpty(this.ColorTextBox.Text) ? this.ColorTextBox.Text : "";
            string carStatus = !String.IsNullOrEmpty(this.CarStatusTextBox.Text) ? this.CarStatusTextBox.Text : "";

            Car car = new Car(this.Id, brand, model, totalCost, yearOfProduction, mileage, fuel, carType, seats, color, carStatus);

            viewModel.UpdateCar(car);
            MessageBox.Show("Record has been updated.", "Update Car");
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
