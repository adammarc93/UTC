using UTCClient.Mappers;
using UTCClient.Models;

namespace UTCClient.ViewModels
{
    public class TruckUpdateViewModel
    {
        private TruckServiceClient client;

        public TruckUpdateViewModel()
        {
            client = new TruckServiceClient();
        }

        public async void UpdateTruck(Truck truck)
        {
            TruckMapper mapper = new TruckMapper();
            var uptadeTruck = mapper.MapToServiceModel(truck);

            await client.UpdateTruckAsync(uptadeTruck);
            client.Close();
        }
    }
}
