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
    public partial class CarView : UserControl
    {
        public ObservableCollection<Car> CarsCollection { get; set; }

        private CarViewModel viewModel;

        public CarView()
        {
            InitializeComponent();
            DataContext = this;
            viewModel = new CarViewModel();
            CarsCollection = new ObservableCollection<Car>();
            SearchComboBox.ItemsSource = Enum.GetValues(typeof(CarColumns));
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetCars();
            CarsCollection.Clear();

            foreach (var car in viewModel.Cars)
            {
                CarsCollection.Add(car);
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
            string carType = !String.IsNullOrEmpty(CarTypeTextBox.Text) ? CarTypeTextBox.Text : "";
            int seats = Convert.ToInt32(!String.IsNullOrEmpty(SeatsTextBox.Text) ? SeatsTextBox.Text : null);
            string color = !String.IsNullOrEmpty(ColorTextBox.Text) ? ColorTextBox.Text : "";
            string carStatus = !String.IsNullOrEmpty(CarStatusTextBox.Text) ? CarStatusTextBox.Text : "";

            Car car = new Car(brand, model, totalCost, yearOfProduction, mileage, fuel, carType, seats, color, carStatus);

            if (car.IsEmpty())
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

            viewModel.AddCar(car);
            MessageBox.Show("Record has been added.", "Added Car");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = CarsCollection.ElementAt(CarListView.SelectedIndex).Id;

                viewModel.DeleteCar(id);
                MessageBox.Show("Record has been deleted.", "Delete Car");
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
                var car = CarsCollection.ElementAt(CarListView.SelectedIndex);

                CarUpdateView updateWindow = new CarUpdateView(car);
                updateWindow.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to update.", "Delete Car");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var text = SearchTextBox.Text;
            var newList = new List<Car>();

            newList = CompareTextWithListValues(text, newList);
            CarsCollection.Clear();

            foreach (var car in newList)
            {
                CarsCollection.Add(car);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var fileName = String.Format("{0}_Cars.csv", DateTime.Now.ToString()).Replace(' ', '_').Replace(':', '_').Replace('-', '_');
            StreamWriter file = new StreamWriter(fileName, false, Encoding.Default);

            foreach (var car in CarsCollection)
            {
                file.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", car.Brand, car.Model, car.TotalCost, car.YearOfProduction,
                               car.Mileage, car.Fuel, car.CarType, car.Seats, car.Color, car.CarStatus);
            }

            file.Close();
            MessageBox.Show("List has been saved.", "Saved List");
        }

        private List<Car> CompareTextWithListValues(string text, List<Car> list)
        {
            switch (SearchComboBox.SelectedItem)
            {
                case CarColumns.Brand:
                    list = viewModel.Cars.Where(x => x.Brand.Contains(text)).ToList();
                    break;
                case CarColumns.Model:
                    list = viewModel.Cars.Where(x => x.Model.Contains(text)).ToList();
                    break;
                case CarColumns.TotalCost:
                    list = viewModel.Cars.Where(x => x.TotalCost.ToString().Contains(text)).ToList();
                    break;
                case CarColumns.YearOfProduction:
                    list = viewModel.Cars.Where(x => x.YearOfProduction.ToString().Contains(text)).ToList();
                    break;
                case CarColumns.Mileage:
                    list = viewModel.Cars.Where(x => x.Mileage.ToString().Contains(text)).ToList();
                    break;
                case CarColumns.Fuel:
                    list = viewModel.Cars.Where(x => x.Fuel.Contains(text)).ToList();
                    break;
                case CarColumns.CarType:
                    list = viewModel.Cars.Where(x => x.CarType.Contains(text)).ToList();
                    break;
                case CarColumns.Seats:
                    list = viewModel.Cars.Where(x => x.Seats.ToString().Contains(text)).ToList();
                    break;
                case CarColumns.Color:
                    list = viewModel.Cars.Where(x => x.Color.Contains(text)).ToList();
                    break;
                case CarColumns.CarStatus:
                    list = viewModel.Cars.Where(x => x.CarStatus.Contains(text)).ToList();
                    break;
                default:
                    break;
            }

            return list;
        }
    }
}
