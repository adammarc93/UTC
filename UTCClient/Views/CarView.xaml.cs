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
    public partial class CarView : UserControl
    {
        public ObservableCollection<Car> CarCollection { get; set; }

        private CarViewModel viewModel;

        public CarView()
        {
            InitializeComponent();
            DataContext = this;
            viewModel = new CarViewModel();
            CarCollection = new ObservableCollection<Car>();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetCars();
            CarCollection.Clear();

            foreach (var car in viewModel.Cars)
            {
                CarCollection.Add(car);
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
                var id = CarCollection.ElementAt(CarListView.SelectedIndex).Id;

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
                var car = CarCollection.ElementAt(CarListView.SelectedIndex);

                CarUpdateView updateWindow = new CarUpdateView(car);
                updateWindow.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to update.", "Delete Car");
            }
        }
    }
}
