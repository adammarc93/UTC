using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using UTCClient.Enums;
using UTCClient.Models;
using UTCClient.ViewModels;

namespace UTCClient.Views
{
    public partial class TruckView : UserControl
    {
        public ObservableCollection<Truck> TrucksColections { get; set; }

        private TruckViewModel viewModel;

        public TruckView()
        {
            InitializeComponent();
            DataContext = this;
            viewModel = new TruckViewModel();
            TrucksColections = new ObservableCollection<Truck>();
            SearchComboBox.ItemsSource = Enum.GetValues(typeof(TruckColumns));
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetTrucks();
            TrucksColections.Clear();

            foreach (var truck in viewModel.Trucks)
            {
                TrucksColections.Add(truck);
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
                var id = TrucksColections.ElementAt(TruckListView.SelectedIndex).Id;

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
                var truck = TrucksColections.ElementAt(TruckListView.SelectedIndex);

                TruckUpdateView updateWindow = new TruckUpdateView(truck);
                updateWindow.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to update.", "Delete Truck");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var text = SearchTextBox.Text;
            var newList = new List<Truck>();

            newList = CompareTextWithListValues(text, newList);
            TrucksColections.Clear();

            foreach (var truck in newList)
            {
                TrucksColections.Add(truck);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var fileName = String.Format("{0}_Truck.csv", DateTime.Now.ToString()).Replace(' ', '_').Replace(':', '_').Replace('-', '_');
            StreamWriter file = new StreamWriter(fileName, false, Encoding.Default);

            foreach (var truck in TrucksColections)
            {
                file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7}", truck.Brand, truck.Model, truck.TotalCost, truck.YearOfProduction,
                               truck.Mileage, truck.Fuel, truck.Color, truck.CarStatus);
            }

            file.Close();
            MessageBox.Show("List has been saved.", "Saved List");
        }

        private List<Truck> CompareTextWithListValues(string text, List<Truck> list)
        {
            switch (SearchComboBox.SelectedItem)
            {
                case TruckColumns.Brand:
                    list = viewModel.Trucks.Where(x => x.Brand.Contains(text)).ToList();
                    break;
                case TruckColumns.Model:
                    list = viewModel.Trucks.Where(x => x.Model.Contains(text)).ToList();
                    break;
                case TruckColumns.TotalCost:
                    list = viewModel.Trucks.Where(x => x.TotalCost.ToString().Contains(text)).ToList();
                    break;
                case TruckColumns.YearOfProduction:
                    list = viewModel.Trucks.Where(x => x.YearOfProduction.ToString().Contains(text)).ToList();
                    break;
                case TruckColumns.Mileage:
                    list = viewModel.Trucks.Where(x => x.Mileage.ToString().Contains(text)).ToList();
                    break;
                case TruckColumns.Fuel:
                    list = viewModel.Trucks.Where(x => x.Fuel.Contains(text)).ToList();
                    break;
                case TruckColumns.Color:
                    list = viewModel.Trucks.Where(x => x.Color.Contains(text)).ToList();
                    break;
                case TruckColumns.CarStatus:
                    list = viewModel.Trucks.Where(x => x.CarStatus.Contains(text)).ToList();
                    break;
                default:
                    break;
            }

            return list;
        }
    }
}
