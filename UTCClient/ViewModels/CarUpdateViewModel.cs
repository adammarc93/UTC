using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTCClient.CarServiceReference;
using UTCClient.Mappers;

namespace UTCClient.ViewModels
{
    public class CarUpdateViewModel
    {
        private CarServiceClient client;

        public CarUpdateViewModel()
        {
            client = new CarServiceClient();
        }

        public async void UpdateCar(Models.Car car)
        {
            CarMapper mapper = new CarMapper();
            var uptadeCar = mapper.MapToServiceModel(car);

            await client.UpdateCarAsync(uptadeCar);
            client.Close();
        }
    }
}
