using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UTCClient.Models;
using UTCClient.ViewModels;

namespace UTCClient.Views
{
    public partial class TruckView : UserControl
    {
        public ObservableCollection<Truck> TrukcsCollection { get; set; }

        private TruckViewModel viewModel;

        public TruckView()
        {
            InitializeComponent();
            DataContext = this;
            viewModel = new TruckViewModel();
            TrukcsCollection = new ObservableCollection<Truck>();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetTrucks();
            TrukcsCollection.Clear();

            foreach (var truck in viewModel.Trucks)
            {
                TrukcsCollection.Add(truck);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var brand = !String.IsNullOrEmpty(BarndTextBox.Text) ? BarndTextBox.Text : "";
            var model = !String.IsNullOrEmpty(ModelTextBox.Text) ? ModelTextBox.Text : "";
            var totalCost = Convert.ToInt32(!String.IsNullOrEmpty(TotalCostTextBox.Text) ? TotalCostTextBox.Text : null);
            var yearOfProduction = Convert.ToInt32(!String.IsNullOrEmpty(YearOfProductionTextBox.Text) ? YearOfProductionTextBox.Text : null);
            var mileage = Convert.ToInt32(!String.IsNullOrEmpty(MileageTextBox.Text) ? MileageTextBox.Text : null);
            string fuel = !String.IsNullOrEmpty(FuelTextBox.Text) ? FuelTextBox.Text : "";
            string color = !String.IsNullOrEmpty(ColorTextBox.Text) ? ColorTextBox.Text : "";
            string carStatus = !String.IsNullOrEmpty(CarStatusTextBox.Text) ? CarStatusTextBox.Text : "";

            Truck truck = new Truck(brand, model, totalCost, yearOfProduction, mileage, fuel, color, carStatus);

            if (truck.IsEmpty())
            {
                var result = MessageBox.Show("Are you want to add an empty record to the database ", "Empty record!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        return;
                }
            }

            viewModel.AddTruck(truck);
            MessageBox.Show("Record has been added.", "Added Truck");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = TrukcsCollection.ElementAt(TruckListView.SelectedIndex).Id;

                viewModel.DeleteTruck(id);
                MessageBox.Show("Record has been deleted.", "Delete Truck");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to delete.", "Delete Car");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var truck = TrukcsCollection.ElementAt(TruckListView.SelectedIndex);

                TruckUpdateView updateWindow = new TruckUpdateView(truck);
                updateWindow.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to update.", "Delete Truck");
            }
        }
    }
}
