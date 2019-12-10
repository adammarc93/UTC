using UTCClient.Mappers;
using UTCClient.Models;

namespace UTCClient.ViewModels
{
    public class CarUpdateViewModel
    {
        private CarServiceClient client;

        public CarUpdateViewModel()
        {
            client = new CarServiceClient();
        }

        public async void UpdateCar(Car car)
        {
            CarMapper mapper = new CarMapper();
            var uptadeCar = mapper.MapToServiceModel(car);

            await client.UpdateCarAsync(uptadeCar);
            client.Close();
        }
    }
}
