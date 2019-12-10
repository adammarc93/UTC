using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UTCClient.Models;
using UTCClient.ViewModels;

namespace UTCClient.Views
{
    public partial class TruckUpdateView : Window
    {
        private TruckUpdateViewModel viewModel;
        private int Id;

        public TruckUpdateView(Truck updateTruck)
        {
            InitializeComponent();
            viewModel = new TruckUpdateViewModel();

            this.Id = updateTruck.Id;
            this.BarndTextBox.Text = updateTruck.Brand;
            this.ModelTextBox.Text = updateTruck.Model;
            this.TotalCostTextBox.Text = updateTruck.TotalCost.ToString();
            this.YearOfProductionTextBox.Text = updateTruck.YearOfProduction.ToString();
            this.MileageTextBox.Text = updateTruck.Mileage.ToString();
            this.FuelTextBox.Text = updateTruck.Fuel;
            this.ColorTextBox.Text = updateTruck.Color;
            this.CarStatusTextBox.Text = updateTruck.CarStatus;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var brand = !String.IsNullOrEmpty(this.BarndTextBox.Text) ? this.BarndTextBox.Text : "";
            var model = !String.IsNullOrEmpty(this.ModelTextBox.Text) ? this.ModelTextBox.Text : "";
            var totalCost = Convert.ToInt32(!String.IsNullOrEmpty(this.TotalCostTextBox.Text) ? this.TotalCostTextBox.Text : null);
            var yearOfProduction = Convert.ToInt32(!String.IsNullOrEmpty(this.YearOfProductionTextBox.Text) ? this.YearOfProductionTextBox.Text : null);
            var mileage = Convert.ToInt32(!String.IsNullOrEmpty(this.MileageTextBox.Text) ? this.MileageTextBox.Text : null);
            string fuel = !String.IsNullOrEmpty(this.FuelTextBox.Text) ? this.FuelTextBox.Text : "";
            string color = !String.IsNullOrEmpty(this.ColorTextBox.Text) ? this.ColorTextBox.Text : "";
            string carStatus = !String.IsNullOrEmpty(this.CarStatusTextBox.Text) ? this.CarStatusTextBox.Text : "";

            Truck truck = new Truck(this.Id, brand, model, totalCost, yearOfProduction, mileage, fuel, color, carStatus);

            viewModel.UpdateTruck(truck);
            MessageBox.Show("Record has been updated.", "Update Truck");
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
